CREATE TABLE [dbo].[generationHistorySet] (
    [Id]     UNIQUEIDENTIFIER NOT NULL IDENTITY,
    [result] NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_generationHistorySet] PRIMARY KEY CLUSTERED ([Id] ASC)
);

