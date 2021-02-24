CREATE TABLE [dbo].[Categories] (
    [Id]   UNIQUEIDENTIFIER NOT NULL,
    [Name] VARCHAR (250)    NOT NULL,
    [Code] VARCHAR (500)    NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

