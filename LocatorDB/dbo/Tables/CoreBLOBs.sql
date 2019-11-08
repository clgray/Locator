CREATE TABLE [dbo].[CoreBLOBs] (
    [BLOBId]      UNIQUEIDENTIFIER CONSTRAINT [DF_BLOBs_BLOBId] DEFAULT (newid()) NOT NULL,
    [QuestionId]  INT              NOT NULL,
    [BLOBContent] VARBINARY (MAX)  NOT NULL,
    CONSTRAINT [PK_CoreBLOBs] PRIMARY KEY CLUSTERED ([BLOBId] ASC, [QuestionId] ASC),
    CONSTRAINT [FK_BLOBs_CoreQuestions] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[CoreQuestions] ([QuestionId])
);

