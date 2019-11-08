CREATE TABLE [dbo].[AnonymousUsers] (
    [AnonymousUserId] INT      IDENTITY (-1, -1) NOT NULL,
    [CreateTime]      DATETIME NOT NULL,
    CONSTRAINT [PK_AnonymousUsers] PRIMARY KEY CLUSTERED ([AnonymousUserId] ASC)
);

