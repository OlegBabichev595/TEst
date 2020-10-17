CREATE TABLE [dbo].[Publisher]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [PK_dbo_Publisher] PRIMARY KEY,
    [Name] NVARCHAR(64) NOT NULL CONSTRAINT [UK_dbo_Publisher_Name] UNIQUE
);
