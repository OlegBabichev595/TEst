CREATE TABLE [dbo].[Book]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [PK_dbo_Book] PRIMARY KEY,
    [Title] NVARCHAR(1024) NOT NULL,
    [PublisherId] UNIQUEIDENTIFIER NULL CONSTRAINT [FK_dbo_Book_dbo_Publisher] FOREIGN KEY REFERENCES [dbo].[Publisher] ([Id]) ON DELETE SET NULL,
    [Description] NVARCHAR(MAX) NULL,
    [PublishingDate] DATE NULL,
    [Rating] FLOAT NULL CONSTRAINT [FK_dbo_Book_dbo_Rating] CHECK ([Rating] BETWEEN 0 AND 5),
    [CoverUrl] NVARCHAR(MAX) NULL
);
GO

CREATE INDEX [IX_dbo_Book_PublisherId] ON [dbo].[Book]([PublisherId]);
GO
