Create Database QrDb
go
use QrDb
go

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [QrCodes] (
    [Id] int NOT NULL IDENTITY,
    [Code] nvarchar(12) NOT NULL,
    CONSTRAINT [PK_QrCodes] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250524185905_initial', N'9.0.5');

CREATE UNIQUE INDEX [IX_QrCodes_Code] ON [QrCodes] ([Code]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250524203916_QrCodeIndexUnique', N'9.0.5');

CREATE TABLE [ExtProducts] (
    [Id] int NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [Rating] real NOT NULL,
    [Stock] int NOT NULL,
    CONSTRAINT [PK_ExtProducts] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250526043002_ExtProducts', N'9.0.5');

COMMIT;
GO


