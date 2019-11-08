CREATE TABLE [dbo].[SystemSettings] (
    [PropertyId]    INT           IDENTITY (1, 1) NOT NULL,
    [PropertyName]  VARCHAR (25)  NOT NULL,
    [PropertyValue] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_SystemSettings] PRIMARY KEY CLUSTERED ([PropertyId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SystemSettings]
    ON [dbo].[SystemSettings]([PropertyName] ASC);

