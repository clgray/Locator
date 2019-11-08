CREATE TABLE [dbo].[CoreAnswers] (
    [AnswerId]       INT           IDENTITY (1, 1) NOT NULL,
    [QuestionId]     INT           NOT NULL,
    [Answer]         VARCHAR (MAX) NOT NULL,
    [IsTrue]         BIT           NOT NULL,
    [AnswerMetadata] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_CoreAnswers] PRIMARY KEY CLUSTERED ([AnswerId] ASC),
    CONSTRAINT [FK_CoreAnswers_CoreQuestions] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[CoreQuestions] ([QuestionId]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_CoreAnswers_7_757577737__K2_1_3_4]
    ON [dbo].[CoreAnswers]([QuestionId] ASC)
    INCLUDE([AnswerId], [Answer], [IsTrue]);

