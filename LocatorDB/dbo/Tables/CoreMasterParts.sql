CREATE TABLE [dbo].[CoreMasterParts] (
    [MasterPartId]    INT IDENTITY (1, 1) NOT NULL,
    [MasterTestId]    INT NOT NULL,
    [PartTestId]      INT NOT NULL,
    [QuestionsNumber] INT NOT NULL,
    CONSTRAINT [PK_CoreMasterParts_1] PRIMARY KEY CLUSTERED ([MasterPartId] ASC),
    CONSTRAINT [FK_CoreMasterParts_CoreTests] FOREIGN KEY ([PartTestId]) REFERENCES [dbo].[CoreTests] ([TestId]),
    CONSTRAINT [FK_CoreMasterParts_CoreTests1] FOREIGN KEY ([MasterTestId]) REFERENCES [dbo].[CoreTests] ([TestId])
);

