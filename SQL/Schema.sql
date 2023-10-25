BEGIN TRANSACTION;
    CREATE TABLE IF NOT EXISTS "Genero" (
            "ID" INTEGER NOT NULL UNIQUE,
            "Nome" TEXT NOT NULL UNIQUE DEFAULT '',
            PRIMARY KEY("ID" AUTOINCREMENT),
        );

    CREATE TABLE IF NOT EXISTS "Estudio" (
            "ID" INTEGER NOT NULL UNIQUE,
            "Nome" TEXT NOT NULL UNIQUE DEFAULT '',
            PRIMARY KEY("ID" AUTOINCREMENT),
        );

    CREATE TABLE IF NOT EXISTS "Plataforma" (
            "ID" INTEGER NOT NULL UNIQUE,
            "Nome" TEXT NOT NULL UNIQUE DEFAULT '',
            PRIMARY KEY("ID" AUTOINCREMENT),
        );

    CREATE TABLE IF NOT EXISTS "Nota" (
            "ID" INTEGER NOT NULL UNIQUE,
            "Nota" TEXT NOT NULL UNIQUE DEFAULT '',
            PRIMARY KEY("ID" AUTOINCREMENT),
        );                    

    CREATE TABLE IF NOT EXISTS "Jogo" (
        "ID" INTEGER NOT NULL UNIQUE,
        "Nome" TEXT NOT NULL DEFAULT '',
        "Edicao" TEXT NOT NULL DEFAULT '',
        "Descricao" TEXT NOT NULL DEFAULT '',
        "Disponibilidade" BOOLEAN NOT NULL DEFAULT 1,
        PRIMARY KEY("ID" AUTOINCREMENT),
        UNIQUE ("Nome", "Edicao")
    );

    CREATE TABLE IF NOT EXISTS "JogoGenero" (
        "ID"	INTEGER NOT NULL,
        "IDJogo"	INTEGER NOT NULL,
        "IDGenero"	INTEGER NOT NULL,
        PRIMARY KEY("ID" AUTOINCREMENT),
        FOREIGN KEY("IDJogo") REFERENCES "Jogo"("ID"),
        FOREIGN KEY("IDGenero") REFERENCES "Genero"("ID"),
        UNIQUE ("IDJogo", "IDGenero")
    );

    CREATE TABLE IF NOT EXISTS "JogoEstudio" (
        "ID"	INTEGER NOT NULL,
        "IDJogo"	INTEGER NOT NULL,
        "IDEstudio"	INTEGER NOT NULL,
        PRIMARY KEY("ID" AUTOINCREMENT),
        FOREIGN KEY("IDJogo") REFERENCES "Jogo"("ID"),
        FOREIGN KEY("IDEstudio") REFERENCES "Estudio"("ID"),
        UNIQUE ("IDJogo", "IDEstudio")
    );

    CREATE TABLE IF NOT EXISTS "JogoPlataforma" (
        "ID"	INTEGER NOT NULL,
        "IDJogo"	INTEGER NOT NULL,
        "IDPlataforma"	INTEGER NOT NULL,
        PRIMARY KEY("ID" AUTOINCREMENT),
        FOREIGN KEY("IDJogo") REFERENCES "Jogo"("ID"),
        FOREIGN KEY("IDPlataforma") REFERENCES "Plataforma"("ID").
        UNIQUE ("IDJogo", "IDPlataforma")
    );        

    CREATE TABLE IF NOT EXISTS "JogoNota" (
        "ID"	INTEGER NOT NULL,
        "IDJogo"	INTEGER NOT NULL,
        "IDNota"	INTEGER NOT NULL,
        PRIMARY KEY("ID" AUTOINCREMENT),
        FOREIGN KEY("IDJogo") REFERENCES "Jogo"("ID"),
        FOREIGN KEY("IDNota") REFERENCES "Nota"("ID")
    );   
COMMIT;
