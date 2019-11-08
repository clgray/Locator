CREATE TABLE [dbo].[GroupTree] (
    [GroupId]   INT                 IDENTITY (1, 1) NOT NULL,
    [GroupNode] [sys].[hierarchyid] NOT NULL,
    [GroupName] VARCHAR (250)       NOT NULL,
    [GroupCode] VARCHAR (50)        NOT NULL,
    CONSTRAINT [PK_GroupTree_1] PRIMARY KEY CLUSTERED ([GroupId] ASC),
    CONSTRAINT [FK_GroupTree_GroupTree] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[GroupTree] ([GroupId]),
    CONSTRAINT [IX_GroupTree] UNIQUE NONCLUSTERED ([GroupCode] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_GroupTree_1]
    ON [dbo].[GroupTree]([GroupNode] ASC);

