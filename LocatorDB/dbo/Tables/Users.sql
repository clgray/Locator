CREATE TABLE [dbo].[Users] (
    [UserId]       INT           IDENTITY (1, 1) NOT NULL,
    [LastName]     VARCHAR (150) NOT NULL,
    [FirstName]    VARCHAR (150) NOT NULL,
    [SecondName]   VARCHAR (150) NULL,
    [Login]        VARCHAR (150) NOT NULL,
    [Password]     VARCHAR (150) NOT NULL,
    [UserRole]     SMALLINT      NOT NULL,
    [Status]       SMALLINT      NOT NULL,
    [Sex]          BIT           NOT NULL,
    [Birthday]     DATETIME2 (7) NULL,
    [Email]        VARCHAR (150) NULL,
    [StudNumber]   VARCHAR (50)  NULL,
    [AfinaId]      VARCHAR (50)  NULL,
    [CreationDate] DATETIME      CONSTRAINT [DF_Users_CreationDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_1]
    ON [dbo].[Users]([Login] ASC, [Password] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users]
    ON [dbo].[Users]([Login] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_Users_7_21575115__K5_K6_K1_K8_2_3_4_7_9_10_11_12_13]
    ON [dbo].[Users]([Login] ASC, [Password] ASC, [UserId] ASC, [Status] ASC)
    INCLUDE([LastName], [FirstName], [SecondName], [UserRole], [Sex], [Birthday], [Email], [StudNumber], [AfinaId]);


GO
CREATE NONCLUSTERED INDEX [_dta_index_Users_7_21575115__K2_K3_K7_K8_K5_1_4_12]
    ON [dbo].[Users]([LastName] ASC, [FirstName] ASC, [UserRole] ASC, [Status] ASC, [Login] ASC)
    INCLUDE([UserId], [SecondName], [StudNumber]);

