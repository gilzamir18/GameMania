BEGIN TRANSACTION;
    CREATE TABLE IF NOT EXISTS "Genero" (
            "ID" INTEGER NOT NULL UNIQUE,
            "Nome" TEXT NOT NULL UNIQUE DEFAULT "",
            PRIMARY KEY("ID" AUTOINCREMENT)
        );

    CREATE TABLE IF NOT EXISTS "Estudio" (
            "ID" INTEGER NOT NULL UNIQUE,
            "Nome" TEXT NOT NULL UNIQUE DEFAULT "",
            PRIMARY KEY("ID" AUTOINCREMENT)
        );

    CREATE TABLE IF NOT EXISTS "Plataforma" (
            "ID" INTEGER NOT NULL UNIQUE,
            "Nome" TEXT NOT NULL UNIQUE DEFAULT "",
            PRIMARY KEY("ID" AUTOINCREMENT)
        );

    CREATE TABLE IF NOT EXISTS "Nota" (
            "ID" INTEGER NOT NULL UNIQUE,
            "Nota" TEXT NOT NULL UNIQUE DEFAULT "",
            PRIMARY KEY("ID" AUTOINCREMENT)
        );                    

    CREATE TABLE IF NOT EXISTS "Jogo" (
        "ID" INTEGER NOT NULL UNIQUE,
        "Nome" TEXT NOT NULL DEFAULT "",
        "Edicao" TEXT NOT NULL DEFAULT "",
        "Descricao" TEXT NOT NULL DEFAULT "",
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
        FOREIGN KEY("IDPlataforma") REFERENCES "Plataforma"("ID"),
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

BEGIN TRANSACTION;
    INSERT INTO "Genero" ("Nome")
    VALUES 	
         ("acao"),("aventura"),("rpg"),("corrida"),("luta"),("puzzle"),("plataforma"),("sobrevivencia"),
         ("terror"),("mundo aberto"),("fps"),("tps"),("rts"),("battle royale"),("single player"),("multi player"),
         ("souls like"),("rogue like"),("sandbox"),("simulacao"),("esporte"),("2d"),("3d"),("stealth"),
         ("tabuleiro"),("hack and slash"),("mmo"),("vr"),("tower defense"),("point and click");   

    INSERT INTO "Plataforma" ("Nome")
    VALUES 	
         ("windows"),("linux"),("mac"),
         ("android"),("ios"),("switch"),
         ("xbox"),("xbox 360"),("xbox one"),("xbox sx"),
         ("ps 1"),("ps 2"),("ps 3"),("ps 4"),("ps 5"),
         ("x cloud"),("geforce now");   

    INSERT INTO "Estudio" ("Nome")
    VALUES 	
         ("xbox game studios"),("playstation studios"),("rockstar north"),("ubisoft"),("bethesda"),("santa monica"),("nintendo"),("game freak"),
         ("guerrila"),("insomniac"),("naughty dog"),("from software"),("mojang"),("obsidian"),
         ("343 industries"),("activision"),("blizzard"),("infinity ward"),("king"),("gearbox"),
         ("treyarch"),("valve"),("rare"),("square enix"),("epic games"),("capcom"),("netherrealm"),
         ("bungie"),("riot"),("konami"),("ea"),("playground games");   

    INSERT INTO "Nota" ("Nota")
    VALUES 	
         (1),(2),(3),(4),(5),(6),(7),(8),(9),(10);   
COMMIT;

BEGIN TRANSACTION;

    INSERT INTO "Jogo" ("Nome", "Edicao", "Descricao", "Disponibilidade")
    VALUES (
            "far cry",
            "3",
            "Edicao 3 de Far Cry",
            1
    );

    CREATE TEMPORARY TABLE TempJogo AS
    SELECT "ID"
    FROM "Jogo"
    WHERE "Nome" = "far cry" AND "Edicao" = "3";

    INSERT INTO "JogoGenero" ("IDJogo", "IDGenero")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Genero" WHERE "Nome" = "acao")),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Genero" WHERE "Nome" = "aventura"));

    INSERT INTO "JogoEstudio" ("IDJogo", "IDEstudio")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Estudio" WHERE "Nome" = "ubisoft"));

    INSERT INTO "JogoPlataforma" ("IDJogo", "IDPlataforma")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Plataforma" WHERE "Nome" = "windows")),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Plataforma" WHERE "Nome" = "xbox 360")),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Plataforma" WHERE "Nome" = "ps 3"));

    INSERT INTO "JogoNota" ("IDJogo", "IDNota")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Nota" WHERE "Nota" = 10)),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Nota" WHERE "Nota" = 9)),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Nota" WHERE "Nota" = 9)),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Nota" WHERE "Nota" = 8));

    DROP TABLE TempJogo;

COMMIT;

BEGIN TRANSACTION;

    INSERT INTO "Jogo" ("Nome", "Edicao", "Descricao", "Disponibilidade")
    VALUES (
            "starfield",
            "1",
            "Edicao 1 de Starfield",
            1
    );

    CREATE TEMPORARY TABLE TempJogo AS
    SELECT "ID"
    FROM "Jogo"
    WHERE "Nome" = "starfield" AND "Edicao" = "1";

    INSERT INTO "JogoGenero" ("IDJogo", "IDGenero")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Genero" WHERE "Nome" = "rpg")),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Genero" WHERE "Nome" = "mundo aberto"));

    INSERT INTO "JogoEstudio" ("IDJogo", "IDEstudio")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Estudio" WHERE "Nome" = "bethesda"));

    INSERT INTO "JogoPlataforma" ("IDJogo", "IDPlataforma")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Plataforma" WHERE "Nome" = "windows")),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Plataforma" WHERE "Nome" = "xbox sx"));

    INSERT INTO "JogoNota" ("IDJogo", "IDNota")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Nota" WHERE "Nota" = 9)),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Nota" WHERE "Nota" = 8)),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Nota" WHERE "Nota" = 8));

    DROP TABLE TempJogo;

COMMIT;

BEGIN TRANSACTION;

    INSERT INTO "Jogo" ("Nome", "Edicao", "Descricao", "Disponibilidade")
    VALUES (
            "valorant",
            "1",
            "Edicao 1 de Valorant",
            0
    );

    CREATE TEMPORARY TABLE TempJogo AS
    SELECT "ID"
    FROM "Jogo"
    WHERE "Nome" = "valorant" AND "Edicao" = "1";

    INSERT INTO "JogoGenero" ("IDJogo", "IDGenero")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Genero" WHERE "Nome" = "fps")),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Genero" WHERE "Nome" = "multi player"));

    INSERT INTO "JogoEstudio" ("IDJogo", "IDEstudio")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Estudio" WHERE "Nome" = "riot"));

    INSERT INTO "JogoPlataforma" ("IDJogo", "IDPlataforma")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Plataforma" WHERE "Nome" = "windows"));

    INSERT INTO "JogoNota" ("IDJogo", "IDNota")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Nota" WHERE "Nota" = 3)),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Nota" WHERE "Nota" = 5)),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Nota" WHERE "Nota" = 2));

    DROP TABLE TempJogo;

COMMIT;

BEGIN TRANSACTION;

    INSERT INTO "Jogo" ("Nome", "Edicao", "Descricao", "Disponibilidade")
    VALUES (
            "forza",
            "horizon",
            "Edicao 1 de Forza",
            1
    );

    CREATE TEMPORARY TABLE TempJogo AS
    SELECT "ID"
    FROM "Jogo"
    WHERE "Nome" = "forza" AND "Edicao" = "horizon";

    INSERT INTO "JogoGenero" ("IDJogo", "IDGenero")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Genero" WHERE "Nome" = "corrida")),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Genero" WHERE "Nome" = "multi player"));

    INSERT INTO "JogoEstudio" ("IDJogo", "IDEstudio")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Estudio" WHERE "Nome" = "playground games")),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Estudio" WHERE "Nome" = "xbox game studios"));

    INSERT INTO "JogoPlataforma" ("IDJogo", "IDPlataforma")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Plataforma" WHERE "Nome" = "windows")),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Plataforma" WHERE "Nome" = "xbox 360")),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Plataforma" WHERE "Nome" = "xbox one"));

    INSERT INTO "JogoNota" ("IDJogo", "IDNota")
    VALUES
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Nota" WHERE "Nota" = 8)),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Nota" WHERE "Nota" = 7)),
        ((SELECT "ID" FROM TempJogo), (SELECT "ID" FROM "Nota" WHERE "Nota" = 8));

    DROP TABLE TempJogo;

COMMIT;

/*
PRAGMA FOREIGN_KEYS = 0;
DELETE FROM Jogo;
DELETE FROM Genero;
DELETE FROM Estudio;
DELETE FROM Plataforma;
DELETE FROM Nota;
DELETE FROM JogoGenero;
DELETE FROM JogoEstudio;
DELETE FROM JogoPlataforma;
DELETE FROM JogoNota;
PRAGMA FOREIGN_KEYS = 1;
DELETE FROM sqlite_sequence;
*/