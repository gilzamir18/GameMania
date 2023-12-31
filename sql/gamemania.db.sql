BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Avaliacao" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"ID_Jogo"	INTEGER NOT NULL,
	"Nota"	INTEGER NOT NULL DEFAULT 0,
	FOREIGN KEY("ID_Jogo") REFERENCES "Jogo"("ID"),
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Plataforma" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Nome"	TEXT NOT NULL UNIQUE,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "JogoPlataforma" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"ID_Jogo"	INTEGER NOT NULL,
	"ID_Plataforma"	INTEGER NOT NULL,
	FOREIGN KEY("ID_Jogo") REFERENCES "Jogo"("ID"),
	FOREIGN KEY("ID_Plataforma") REFERENCES "Plataforma"("ID"),
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Jogo" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Titulo"	TEXT NOT NULL UNIQUE,
	"Genero"	TEXT NOT NULL,
	"Studio"	TEXT NOT NULL,
	"Edicao"	TEXT NOT NULL,
	"Descricao"	TEXT,
	"Disponibilidade"	INTEGER NOT NULL DEFAULT 1,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
COMMIT;
