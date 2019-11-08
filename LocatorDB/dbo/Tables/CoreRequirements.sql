CREATE TABLE [dbo].[CoreRequirements] (
    [RequirementId] INT IDENTITY (1, 1) NOT NULL,
    [TestId]        INT NOT NULL,
    [Requirement]   INT NOT NULL,
    CONSTRAINT [PK_CoreRequirements] PRIMARY KEY CLUSTERED ([RequirementId] ASC),
    CONSTRAINT [FK_CoreRequirements_CoreRequirements1] FOREIGN KEY ([TestId]) REFERENCES [dbo].[CoreTests] ([TestId]),
    CONSTRAINT [FK_CoreRequirements_CoreTests] FOREIGN KEY ([Requirement]) REFERENCES [dbo].[CoreTests] ([TestId])
);

