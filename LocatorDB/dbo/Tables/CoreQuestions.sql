CREATE TABLE [dbo].[CoreQuestions] (
    [QuestionId]       INT           IDENTITY (1, 1) NOT NULL,
    [TestId]           INT           NOT NULL,
    [QuestionType]     TINYINT       NOT NULL,
    [Question]         VARCHAR (MAX) NOT NULL,
    [QuestionMark]     FLOAT (53)    NOT NULL,
    [QuestionMetadata] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_CoreQuestions] PRIMARY KEY CLUSTERED ([QuestionId] ASC),
    CONSTRAINT [FK_CoreQuestions_CoreTests] FOREIGN KEY ([TestId]) REFERENCES [dbo].[CoreTests] ([TestId])
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_CoreQuestions_7_197575742__K2]
    ON [dbo].[CoreQuestions]([TestId] ASC);

