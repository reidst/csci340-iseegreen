import sqlite3
import argparse
from access_parser import AccessParser
from os.path import exists
from pathlib import Path

create_commands = {
    "Categories": """
        CREATE TABLE "Categories" (
            "Category" TEXT NOT NULL CONSTRAINT "PK_Categories" PRIMARY KEY,
            "Description" TEXT NULL,
            "Sort" INTEGER NOT NULL,
            "APG4sort" INTEGER NOT NULL
        )
    """,
    "TaxonomicOrders": """
        CREATE TABLE "TaxonomicOrders" (
            "TaxonomicOrder" TEXT NOT NULL CONSTRAINT "PK_TaxonomicOrders" PRIMARY KEY,
            "SortLevel1Heading" TEXT NULL,
            "SortLevel1" INTEGER NOT NULL,
            "SortLevel2Heading" TEXT NULL,
            "SortLevel2" INTEGER NOT NULL,
            "SortLevel3Heading" TEXT NULL,
            "SortLevel3" INTEGER NOT NULL,
            "SortLevel4Heading" TEXT NULL,
            "SortLevel4" INTEGER NOT NULL,
            "SortLevel5Heading" TEXT NULL,
            "SortLevel5" INTEGER NOT NULL,
            "SortLevel6Heading" TEXT NULL,
            "SortLevel6" INTEGER NOT NULL
        )
    """,
    "Families": """
        CREATE TABLE "Families" (
            "Family" TEXT NOT NULL CONSTRAINT "PK_Families" PRIMARY KEY,
            "TranslateTo" TEXT NULL,
            "CategoryID" TEXT NULL,
            "TaxonomicOrderID" TEXT NULL,
            CONSTRAINT "FK_Families_Categories_CategoryID" FOREIGN KEY ("CategoryID") REFERENCES "Categories" ("Category"),
            CONSTRAINT "FK_Families_TaxonomicOrders_TaxonomicOrderID" FOREIGN KEY ("TaxonomicOrderID") REFERENCES "TaxonomicOrders" ("TaxonomicOrder")
        )
    """,
    "Genera": """
        CREATE TABLE "Genera" (
            "GenusID" TEXT NOT NULL CONSTRAINT "PK_Genera" PRIMARY KEY,
            "KewID" TEXT NOT NULL,
            "FamilyID" TEXT NULL,
            CONSTRAINT "FK_Genera_Families_FamilyID" FOREIGN KEY ("FamilyID") REFERENCES "Families" ("Family")
        )
    """,
    "Taxa": """
        CREATE TABLE "Taxa" (
            "KewID" TEXT NOT NULL CONSTRAINT "PK_Taxa" PRIMARY KEY,
            "GenusID" TEXT NULL,
            "SpecificEpithet" TEXT NULL,
            "InfraspecificEpithet" TEXT NULL,
            "TaxonRank" TEXT NULL,
            "HybridGenus" TEXT NULL,
            "HybridSpecies" TEXT NULL,
            "Authors" TEXT NULL,
            "USDAsymbol" TEXT NULL,
            "USDAsynonym" TEXT NULL,
            CONSTRAINT "FK_Taxa_Genera_GenusID" FOREIGN KEY ("GenusID") REFERENCES "Genera" ("GenusID")
        )
    """,
    "Synonyms": """
        CREATE TABLE "Synonyms" (
            "KewID" TEXT NOT NULL CONSTRAINT "PK_Synonyms" PRIMARY KEY,
            "TaxaID" TEXT NULL,
            "Genus" TEXT NULL,
            "Species" TEXT NULL,
            "InfraspecificEpithet" TEXT NULL,
            "TaxonRank" TEXT NULL,
            "Authors" TEXT NULL,
            CONSTRAINT "FK_Synonyms_Taxa_TaxaID" FOREIGN KEY ("TaxaID") REFERENCES "Taxa" ("KewID")
        )
    """,
}

column_translations = {
    "Families": {
        "Category": "CategoryID",
        "TaxonomicOrder": "TaxonomicOrderID",
    },
    "Genera": {
        "kew_id": "KewID",
        "genus": "GenusID",
        "family": "FamilyID",
    },
    "Taxa": {
        "kew_id": "KewID",
        "genus": "GenusID"
    },
    "Synonyms": {
        "kew_id": "KewID",
        "accepted_kew_id": "TaxaID",
        "genus": "Genus",
        "species": "Species",
    },
}

drop_columns = {
    "Taxa": [
        "family",
    ],
}

plant_tables = list(create_commands.keys())


def remove_unused_columns(table_name, column_names):
    columns_to_remove = drop_columns.get(table_name, {})
    return tuple(col for col in column_names if col not in columns_to_remove)


def translate_column_names(table_name, old_column_names):
    translation_table = column_translations.get(table_name, {})
    return tuple(translation_table.get(name, name) for name in old_column_names)


def parse_args():
    argparser = argparse.ArgumentParser(
        description="Generates formatted seed data from a Microsoft Access database for the iSeeGreen web app"
    )
    argparser.add_argument(
        "access_file",
        type=Path,
        help="the .accdb (Access 2007-2016 format) input file"
    )
    argparser.add_argument(
        "sqlite_file",
        type=Path,
        nargs="?",
        default="./wwwroot/seed.db",
        help="(optional) the .db (SQLite3 format) output file; defaults to './wwwroot/seed.db'"
    )
    return argparser.parse_args()


def build_insert_template(table_name, column_names):
    template = f"INSERT INTO '{table_name}' "
    template += f"{column_names}"
    template += f" VALUES ("
    template += ", ".join("?" for _ in column_names)
    template += ")"
    return template


def main():
    # -------- argparse setup --------
    args = parse_args()
    
    # -------- open databases --------
    if not exists(args.access_file):
        print(f"error: an Access file named '{args.access_file}' does not exist.")
        exit(1)
    if exists(args.sqlite_file):
        print(f"warning: a SQLite file named '{args.sqlite_file}' already exists; some of its data will be overwritten.")
    print("loading Access file...")
    accdb = AccessParser(args.access_file)
    print("connecting to SQLite database...")
    sqldb = sqlite3.connect(args.sqlite_file)
    cur = sqldb.cursor()

    # -------- create tables --------
    print("checking for existing tables in SQLite DB...")
    res = cur.execute(f"SELECT name FROM sqlite_master")
    existing_tables = [result[0] for result in res.fetchall()]
    for (table_name, create_command) in create_commands.items():
        if table_name in existing_tables:
            print(f"\ttable '{table_name}' already exists; it will be dropped and re-created.")
            cur.execute(f"DROP TABLE '{table_name}'")
        cur.execute(create_command)

    # -------- transfer data --------
    print("transferring data...")
    total_rows = 0
    for table_name in plant_tables:
        print(f"\tloading Access table '{table_name}' (this may take a while)...")
        table = accdb.parse_table(table_name)
        access_column_names = remove_unused_columns(table_name, table.keys())
        column_names = translate_column_names(table_name, access_column_names)
        insert_template = build_insert_template(table_name, column_names)
        for col in table:
            row_count = len(table[col])
            total_rows += row_count
            break
        print(f"\ttransferring {row_count} rows to SQLite...")
        for row in range(row_count):
            row_contents = tuple(table[col][row] for col in access_column_names)
            try:
                cur.execute(insert_template, row_contents)
            except sqlite3.OperationalError as oe:
                print(f"failed to execute command: cur.execute({insert_template!r}, {row_contents!r})")
                raise oe
        sqldb.commit()
        print(f"\ttable transfer for {table_name} completed.")
    print(f"transfer process completed. {total_rows} rows transferred from {args.access_file} to {args.sqlite_file}.")


if __name__ == "__main__":
    main()
