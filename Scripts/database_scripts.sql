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
GO

CREATE TABLE [Grades] (
    [Id] tinyint NOT NULL IDENTITY,
    [Oid] uniqueidentifier NOT NULL DEFAULT (NEWID()),
    [Name] nvarchar(30) NOT NULL,
    [Description] nvarchar(200) NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Grades] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Students] (
    [Id] bigint NOT NULL IDENTITY,
    [Oid] uniqueidentifier NOT NULL DEFAULT (NEWID()),
    [FirstName] nvarchar(50) NOT NULL,
    [MiddleName] nvarchar(50) NULL,
    [FirstSurname] nvarchar(50) NOT NULL,
    [LastSurname] nvarchar(50) NULL,
    [Gender] nvarchar(max) NOT NULL,
    [BirthDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Teachers] (
    [Id] smallint NOT NULL IDENTITY,
    [Oid] uniqueidentifier NOT NULL DEFAULT (NEWID()),
    [FirstName] nvarchar(50) NOT NULL,
    [MiddleName] nvarchar(50) NULL,
    [FirstSurname] nvarchar(50) NOT NULL,
    [LastSurname] nvarchar(50) NULL,
    [Gender] nvarchar(max) NOT NULL,
    [BirthDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Teachers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Enrollments] (
    [Id] bigint NOT NULL IDENTITY,
    [Oid] uniqueidentifier NOT NULL DEFAULT (NEWID()),
    [Group] nvarchar(max) NOT NULL,
    [Year] tinyint NOT NULL,
    [StudentId] bigint NOT NULL,
    [TeacherId] smallint NOT NULL,
    [GradeId] tinyint NOT NULL,
    CONSTRAINT [PK_Enrollments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Enrollments_Grades_GradeId] FOREIGN KEY ([GradeId]) REFERENCES [Grades] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Enrollments_Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Students] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Enrollments_Teachers_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [Teachers] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'IsActive', N'Name') AND [object_id] = OBJECT_ID(N'[Grades]'))
    SET IDENTITY_INSERT [Grades] ON;
INSERT INTO [Grades] ([Id], [Description], [IsActive], [Name])
VALUES (CAST(1 AS tinyint), N'Primer Grado. Mayormente asisten niños de 7 años.', CAST(1 AS bit), N'1°'),
(CAST(2 AS tinyint), N'Segundo Grado. Mayormente asisten niños de 8 años.', CAST(1 AS bit), N'2°'),
(CAST(3 AS tinyint), N'Tercer Grado. Mayormente asisten niños de 9 años.', CAST(1 AS bit), N'3°'),
(CAST(4 AS tinyint), N'Cuarto Grado. Mayormente asisten niños de 10 años.', CAST(1 AS bit), N'4°'),
(CAST(5 AS tinyint), N'Quinto Grado. Mayormente asisten niños de 11 años.', CAST(1 AS bit), N'5°'),
(CAST(6 AS tinyint), N'Sexto Grado. Mayormente asisten niños de 12 años.', CAST(1 AS bit), N'6°'),
(CAST(7 AS tinyint), N'Séptimo Grado. Mayormente asisten adolescentes de 13 años.', CAST(1 AS bit), N'7°'),
(CAST(8 AS tinyint), N'Octavo Grado. Mayormente asisten adolescentes de 14 años.', CAST(1 AS bit), N'8°'),
(CAST(9 AS tinyint), N'Sexto Grado. Mayormente asisten adolescentes de 15 años.', CAST(1 AS bit), N'9°');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'IsActive', N'Name') AND [object_id] = OBJECT_ID(N'[Grades]'))
    SET IDENTITY_INSERT [Grades] OFF;
GO

CREATE INDEX [IX_Enrollments_GradeId] ON [Enrollments] ([GradeId]);
GO

CREATE UNIQUE INDEX [IX_Enrollments_Oid] ON [Enrollments] ([Oid]);
GO

CREATE INDEX [IX_Enrollments_StudentId] ON [Enrollments] ([StudentId]);
GO

CREATE INDEX [IX_Enrollments_TeacherId] ON [Enrollments] ([TeacherId]);
GO

CREATE UNIQUE INDEX [IX_Grades_Oid] ON [Grades] ([Oid]);
GO

CREATE UNIQUE INDEX [IX_Students_Oid] ON [Students] ([Oid]);
GO

CREATE UNIQUE INDEX [IX_Teachers_Oid] ON [Teachers] ([Oid]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240814170322_Init', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP INDEX [IX_Enrollments_StudentId] ON [Enrollments];
GO

CREATE UNIQUE INDEX [IX_Enrollments_StudentId_GradeId] ON [Enrollments] ([StudentId], [GradeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240814183613_Add_StudentIdGradeId_UniqueConstraint_To_Enrollments_Table', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Enrollments]') AND [c].[name] = N'Year');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Enrollments] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Enrollments] ALTER COLUMN [Year] smallint NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240815004359_Change_Year_ColumnType_From_Tinyint_To_Smallint', N'8.0.8');
GO

COMMIT;
GO

