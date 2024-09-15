CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Customer" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Customer" PRIMARY KEY,
    "ApiKeyExpired" INTEGER NOT NULL,
    "ApiKey" TEXT NOT NULL,
    "Name" TEXT NOT NULL,
    "SubscriptionType" INTEGER NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240915141107_Initial', '8.0.8');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "Customer" RENAME COLUMN "ApiKey" TO "ApiKey1";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240915142126_Initial1', '8.0.8');

COMMIT;

