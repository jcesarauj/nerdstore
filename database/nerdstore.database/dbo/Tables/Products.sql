CREATE TABLE [dbo].[Products] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [Name]            VARCHAR (250)    NOT NULL,
    [Description]     VARCHAR (500)    NOT NULL,
    [Active]          BIT              NOT NULL,
    [Price]           DECIMAL (18, 2)  NOT NULL,
    [CreateDate]      DATETIME2 (7)    NOT NULL,
    [Image]           VARCHAR (250)    NOT NULL,
    [QuantityInStock] INT              NOT NULL,
    [CategoryId]      UNIQUEIDENTIFIER NOT NULL,
    [Height]          INT              NULL,
    [Width]           INT              NULL,
    [Depth]           INT              NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId]
    ON [dbo].[Products]([CategoryId] ASC);

