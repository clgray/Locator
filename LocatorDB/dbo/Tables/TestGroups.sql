CREATE TABLE [dbo].[TestGroups] (
    [TestGroupId] INT IDENTITY (1, 1) NOT NULL,
    [TestId]      INT NOT NULL,
    [GroupId]     INT NOT NULL,
    CONSTRAINT [PK_TestGroups] PRIMARY KEY CLUSTERED ([TestGroupId] ASC),
    CONSTRAINT [FK_TestGroups_CoreTests] FOREIGN KEY ([TestId]) REFERENCES [dbo].[CoreTests] ([TestId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_TestGroups_GroupTree] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[GroupTree] ([GroupId]) ON DELETE CASCADE ON UPDATE CASCADE
);

