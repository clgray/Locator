CREATE TABLE [dbo].[UserGroups] (
    [UserGroupId]     INT IDENTITY (1, 1) NOT NULL,
    [UserId]          INT NOT NULL,
    [GroupId]         INT NOT NULL,
    [IsAdministrator] BIT NOT NULL,
    CONSTRAINT [PK_UserGroups] PRIMARY KEY CLUSTERED ([UserGroupId] ASC),
    CONSTRAINT [FK_UserGroups_GroupTree] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[GroupTree] ([GroupId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_UserGroups_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE
);

