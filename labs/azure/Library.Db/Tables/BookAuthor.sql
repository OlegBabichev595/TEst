CREATE TABLE [dbo].[BookAuthor]
(
    [BookId] UNIQUEIDENTIFIER CONSTRAINT [FK_dbo_BookAuthor_dbo_Book] FOREIGN KEY REFERENCES [dbo].[Book]([Id]) ON DELETE CASCADE,
    [AuthorId] UNIQUEIDENTIFIER CONSTRAINT [FK_dbo_BookAuthor_dbo_Author] FOREIGN KEY REFERENCES [dbo].[Author]([Id]) ON DELETE CASCADE,
    CONSTRAINT [PK_dbo_BookAuthor] PRIMARY KEY ([BookId], [AuthorId]),
);
GO

CREATE INDEX [IX_dbo_BookAuthor_BookId] ON [dbo].[BookAuthor]([BookId]);
GO

CREATE INDEX [IX_dbo_BookAuthor_AuthorId] ON [dbo].[BookAuthor]([AuthorId]);
GO
