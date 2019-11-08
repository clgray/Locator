CREATE TABLE [dbo].[TestTree] (
    [NodeId]    INT                 IDENTITY (1, 1) NOT NULL,
    [TreeNode]  [sys].[hierarchyid] NOT NULL,
    [NodeType]  TINYINT             NOT NULL,
    [TestId]    INT                 NULL,
    [ItemOwner] INT                 NULL,
    [IsActive]  BIT                 NOT NULL,
    CONSTRAINT [PK_TestTree_1] PRIMARY KEY CLUSTERED ([NodeId] ASC),
    CONSTRAINT [FK_TestTree_Users] FOREIGN KEY ([ItemOwner]) REFERENCES [dbo].[Users] ([UserId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TestTree]
    ON [dbo].[TestTree]([TreeNode] ASC);

