CREATE TABLE [dbo].[SystemEventsLog] (
    [EventId]   INT           IDENTITY (1, 1) NOT NULL,
    [EventTime] DATETIME      NOT NULL,
    [EventCode] SMALLINT      NOT NULL,
    [Login]     VARCHAR (150) NOT NULL,
    [EventText] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_SystemEventsLog] PRIMARY KEY CLUSTERED ([EventId] ASC)
);

