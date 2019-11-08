CREATE TABLE [dbo].[ActivationKeys] (
    [ActivationKeyId] INT          IDENTITY (1, 1) NOT NULL,
    [UserId]          INT          NOT NULL,
    [ActivationKey]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_ActivationKeyes] PRIMARY KEY CLUSTERED ([ActivationKeyId] ASC),
    CONSTRAINT [FK_ActivationKeyes_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE
);

