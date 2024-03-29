/****** Object:  Table [dbo].[SystemSettings]    Script Date: 06/21/2009 23:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SystemSettings](
	[PropertyId] [int] IDENTITY(1,1) NOT NULL,
	[PropertyName] [varchar](25) NOT NULL,
	[PropertyValue] [varchar](max) NOT NULL,
 CONSTRAINT [PK_SystemSettings] PRIMARY KEY CLUSTERED 
(
	[PropertyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SystemSettings] ON [dbo].[SystemSettings] 
(
	[PropertyName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemEventsLog]    Script Date: 06/21/2009 23:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SystemEventsLog](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[EventCode] [smallint] NOT NULL,
	[Login] [varchar](150) NOT NULL,
	[EventText] [varchar](max) NOT NULL,
 CONSTRAINT [PK_SystemEventsLog] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 06/21/2009 23:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](150) NOT NULL,
	[FirstName] [varchar](150) NOT NULL,
	[SecondName] [varchar](150) NULL,
	[Login] [varchar](150) NOT NULL,
	[Password] [varchar](150) NOT NULL,
	[UserRole] [smallint] NOT NULL,
	[Status] [smallint] NOT NULL,
	[Sex] [bit] NOT NULL,
	[Birthday] [datetime2](7) NULL,
	[Email] [varchar](150) NULL,
	[StudNumber] [varchar](50) NULL,
	[AfinaId] [varchar](50) NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [_dta_index_Users_7_21575115__K2_K3_K7_K8_K5_1_4_12] ON [dbo].[Users] 
(
	[LastName] ASC,
	[FirstName] ASC,
	[UserRole] ASC,
	[Status] ASC,
	[Login] ASC
)
INCLUDE ( [UserId],
[SecondName],
[StudNumber]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [_dta_index_Users_7_21575115__K5_K6_K1_K8_2_3_4_7_9_10_11_12_13] ON [dbo].[Users] 
(
	[Login] ASC,
	[Password] ASC,
	[UserId] ASC,
	[Status] ASC
)
INCLUDE ( [LastName],
[FirstName],
[SecondName],
[UserRole],
[Sex],
[Birthday],
[Email],
[StudNumber],
[AfinaId]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users] ON [dbo].[Users] 
(
	[Login] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Users_1] ON [dbo].[Users] 
(
	[Login] ASC,
	[Password] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnonymousUsers]    Script Date: 06/21/2009 23:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnonymousUsers](
	[AnonymousUserId] [int] IDENTITY(-1,-1) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_AnonymousUsers] PRIMARY KEY CLUSTERED 
(
	[AnonymousUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupTree]    Script Date: 06/21/2009 23:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GroupTree](
	[GroupId] [int] IDENTITY(1,1) NOT NULL,
	[GroupNode] [hierarchyid] NOT NULL,
	[GroupName] [varchar](250) NOT NULL,
	[GroupCode] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GroupTree_1] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_GroupTree] UNIQUE NONCLUSTERED 
(
	[GroupCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_GroupTree_1] ON [dbo].[GroupTree] 
(
	[GroupNode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoreTests]    Script Date: 06/21/2009 23:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CoreTests](
	[TestId] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [varchar](150) NOT NULL,
	[TestKey] [uniqueidentifier] NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[QuestionsNumber] [smallint] NOT NULL,
	[VariantsMode] [bit] NOT NULL,
	[PassagesNumber] [smallint] NOT NULL,
	[PassingScore] [float] NOT NULL,
	[TimeLimit] [int] NOT NULL,
	[BeginTime] [datetime2](7) NOT NULL,
	[EndTime] [datetime2](7) NOT NULL,
	[AllowAdmitQuestions] [bit] NOT NULL,
	[ShowTestResult] [bit] NOT NULL,
	[ShowDetailsTestResult] [bit] NOT NULL,
	[ShowRightAnswersCount] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsMasterTest] [bit] NOT NULL,
	[AdaptiveMode] [smallint] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_CoreTests] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CoreRequirements]    Script Date: 06/21/2009 23:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoreRequirements](
	[RequirementId] [int] IDENTITY(1,1) NOT NULL,
	[TestId] [int] NOT NULL,
	[Requirement] [int] NOT NULL,
 CONSTRAINT [PK_CoreRequirements] PRIMARY KEY CLUSTERED 
(
	[RequirementId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoreQuestions]    Script Date: 06/21/2009 23:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CoreQuestions](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[TestId] [int] NOT NULL,
	[QuestionType] [tinyint] NOT NULL,
	[Question] [varchar](max) NOT NULL,
	[QuestionMark] [float] NOT NULL,
	[QuestionMetadata] [varchar](max) NULL,
 CONSTRAINT [PK_CoreQuestions] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [_dta_index_CoreQuestions_7_197575742__K2] ON [dbo].[CoreQuestions] 
(
	[TestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoreMasterParts]    Script Date: 06/21/2009 23:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoreMasterParts](
	[MasterPartId] [int] IDENTITY(1,1) NOT NULL,
	[MasterTestId] [int] NOT NULL,
	[PartTestId] [int] NOT NULL,
	[QuestionsNumber] [int] NOT NULL,
 CONSTRAINT [PK_CoreMasterParts_1] PRIMARY KEY CLUSTERED 
(
	[MasterPartId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetGroupTreeByLevel]    Script Date: 06/21/2009 23:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <04.11.2008>
-- Description:	<GetGroupTreeByLevel>
-- =============================================
CREATE PROCEDURE [dbo].[GetGroupTreeByLevel]
	@ParentId int,  -- Id родителя, в случае NULL родителем будет корень дерева
	@Level int=NULL -- Число уровней, с которых берутся потомки
AS
BEGIN
DECLARE  @Id hierarchyid;

IF @ParentId IS NULL
BEGIN
SET @Id = hierarchyid::GetRoot()
END ELSE BEGIN
SELECT @Id=GroupNode FROM GroupTree WHERE GroupId=@ParentId
END


IF @Level IS NOT NULL
BEGIN
DECLARE  @RealLevel int
SET @RealLevel= (@Id.GetLevel()+@Level+1)

SELECT GroupId,GroupNode.ToString() AS 'GroupNode',GroupName, GroupCode
FROM GroupTree
WHERE GroupNode.IsDescendantOf(@Id) = 1 AND GroupNode.GetLevel()<@RealLevel AND 
GroupNode.GetLevel()>@Id.GetLevel() OR GroupNode=@Id ORDER BY GroupNode

END ELSE BEGIN

SELECT GroupId,GroupNode.ToString() AS 'GroupNode',GroupName, GroupCode
FROM GroupTree
WHERE GroupNode.IsDescendantOf(@Id) = 1 ORDER BY GroupNode

END
END
GO
/****** Object:  StoredProcedure [dbo].[GetGroupIdByCode]    Script Date: 06/21/2009 23:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetGroupIdByCode]
	@GroupCode varchar(50)-- Код группы
AS
BEGIN
DECLARE @GID int;
SELECT @GID = GroupId FROM GroupTree WHERE GroupCode=@GroupCode
RETURn @GID
END
GO
/****** Object:  StoredProcedure [dbo].[AddGroupTreeItem]    Script Date: 06/21/2009 23:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <4.11.2008>
-- Description:	<AddGroupTreeItem>
-- =============================================
CREATE PROCEDURE [dbo].[AddGroupTreeItem]
	@ParentId int, -- Id родителя, в случае NULL родителем будет корень дерева
	@GroupName varchar(250)=NULL, -- Имя группы
	@GroupCode varchar(50)=NULL -- Код группы
AS
BEGIN
DECLARE  @Id hierarchyid;

IF @ParentId IS NULL
BEGIN

SELECT @Id = MAX(GroupNode)
FROM GroupTree
WHERE GroupNode.GetAncestor(1) = hierarchyid::GetRoot()
INSERT INTO GroupTree (GroupNode, GroupName, GroupCode)
VALUES (hierarchyid::GetRoot().GetDescendant(@Id,NULL),@GroupName,@GroupCode);

END ELSE BEGIN

DECLARE  @ParentHierId hierarchyid;
SELECT @ParentHierId=GroupNode FROM GroupTree WHERE GroupId=@ParentId;

SELECT @Id = MAX(GroupNode)
FROM GroupTree
WHERE GroupNode.GetAncestor(1) = @ParentHierId

INSERT INTO GroupTree (GroupNode, GroupName, GroupCode)
VALUES (@ParentHierId.GetDescendant(@Id, NULL),@GroupName, @GroupCode);

END
RETURN @@IDENTITY
END
GO
/****** Object:  Table [dbo].[ActivationKeys]    Script Date: 06/21/2009 23:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ActivationKeys](
	[ActivationKeyId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ActivationKey] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ActivationKeyes] PRIMARY KEY CLUSTERED 
(
	[ActivationKeyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[RemoveGroupTreeItem]    Script Date: 06/21/2009 23:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <04.11.2008>
-- Description:	<RemoveGroupTreeItem>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveGroupTreeItem]
	@ItemId int
AS
BEGIN

DECLARE  @GroupId int=NULL;

DECLARE  @Id hierarchyid
SELECT @Id=GroupNode,@GroupId=GroupId FROM GroupTree WHERE GroupId=@ItemId

DELETE
FROM GroupTree
WHERE GroupNode.IsDescendantOf(@Id) = 1

RETURN @GroupId

END
GO
/****** Object:  StoredProcedure [dbo].[RenameGroupTreeItem]    Script Date: 06/21/2009 23:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <04.11.2008>
-- Description:	<RenameGroupTreeItem>
-- =============================================
CREATE PROCEDURE [dbo].[RenameGroupTreeItem]
    @ItemId int, 
	@GroupNewName varchar(150)
AS
BEGIN
	UPDATE GroupTree SET GroupName=@GroupNewName WHERE GroupId=@ItemId
END
GO
/****** Object:  Table [dbo].[TestTree]    Script Date: 06/21/2009 23:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestTree](
	[NodeId] [int] IDENTITY(1,1) NOT NULL,
	[TreeNode] [hierarchyid] NOT NULL,
	[NodeType] [tinyint] NOT NULL,
	[TestId] [int] NULL,
	[ItemOwner] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TestTree_1] PRIMARY KEY CLUSTERED 
(
	[NodeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TestTree] ON [dbo].[TestTree] 
(
	[TreeNode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestSessions]    Script Date: 06/21/2009 23:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestSessions](
	[TestSessionId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TestId] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NULL,
	[MaxScore] [float] NOT NULL,
	[Score] [float] NULL,
	[IsPassed] [bit] NOT NULL,
	[ClientIP] [varchar](15) NOT NULL,
	[UniqId] [varchar](15) NOT NULL,
	[AdditionalTime] [smallint] NULL,
 CONSTRAINT [PK_TestSessions] PRIMARY KEY CLUSTERED 
(
	[TestSessionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [_dta_index_TestSessions_7_405576483__K2_K5_K1] ON [dbo].[TestSessions] 
(
	[UserId] ASC,
	[EndTime] ASC,
	[TestSessionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [_dta_index_TestSessions_7_405576483__K4D_K2_1_10] ON [dbo].[TestSessions] 
(
	[StartTime] DESC,
	[UserId] ASC
)
INCLUDE ( [TestSessionId],
[UniqId]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_TestSessions] ON [dbo].[TestSessions] 
(
	[StartTime] ASC,
	[EndTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_TestSessions_1] ON [dbo].[TestSessions] 
(
	[UserId] ASC,
	[TestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 06/21/2009 23:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroups](
	[UserGroupId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[IsAdministrator] [bit] NOT NULL,
 CONSTRAINT [PK_UserGroups] PRIMARY KEY CLUSTERED 
(
	[UserGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SetUsersFIONormalization]    Script Date: 06/21/2009 23:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Antony
-- Create date: 2009.06.07
-- Description: Нормализация ФИО (с большой
--    буквы, маленькими)
-- =============================================
CREATE PROCEDURE [dbo].[SetUsersFIONormalization] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Users
	Set 
		LastName	= case LEN(LastName) when 0 then '' else UPPER(SUBSTRING(LastName,1,1)) + LOWER(SUBSTRING(LastName,2,LEN(LastName)-1)) end
		,FirstName	= case LEN(FirstName) when 0 then '' else UPPER(SUBSTRING(FirstName,1,1)) + LOWER(SUBSTRING(FirstName,2,LEN(FirstName)-1)) end
		,SecondName	= case LEN(SecondName) when 0 then '' else UPPER(SUBSTRING(SecondName,1,1)) + LOWER(SUBSTRING(SecondName,2,LEN(SecondName)-1)) end
END
GO
/****** Object:  Table [dbo].[TestGroups]    Script Date: 06/21/2009 23:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestGroups](
	[TestGroupId] [int] IDENTITY(1,1) NOT NULL,
	[TestId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
 CONSTRAINT [PK_TestGroups] PRIMARY KEY CLUSTERED 
(
	[TestGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ReparentGroupTreeItem]    Script Date: 06/21/2009 23:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <21.11.2008>
-- Description:	<ReparentGroupTreeItem>
-- =============================================
CREATE PROCEDURE [dbo].[ReparentGroupTreeItem]
    @ItemId int, 
	@ItemNewParent int
AS
BEGIN
DECLARE @ParentHierId hierarchyid;
DECLARE @Child hierarchyid
DECLARE @Id hierarchyid;

IF @ItemNewParent != 0 BEGIN
SELECT @ParentHierId = GroupNode FROM GroupTree WHERE GroupId = @ItemNewParent
END ELSE BEGIN
SELECT @ParentHierId = hierarchyid::GetRoot() FROM GroupTree
END

SELECT @Id = MAX(GroupNode)
FROM GroupTree
WHERE GroupNode.GetAncestor(1) = @ParentHierId

SELECT @Child = GroupNode FROM GroupTree WHERE GroupId = @ItemId

UPDATE GroupTree
SET GroupNode = GroupNode.GetReparentedValue(@Child, @ParentHierId.GetDescendant(@Id, NULL)) 
WHERE 
GroupNode.IsDescendantOf(@Child) = 1
END
GO
/****** Object:  StoredProcedure [dbo].[RenameTestTreeItem]    Script Date: 06/21/2009 23:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RenameTestTreeItem]
    @ItemId int, 
	@TestNewName varchar(150)
AS
BEGIN
	UPDATE CoreTests SET TestName=@TestNewName WHERE TestId=(
	SELECT TestId FROM TestTree WHERE NodeId=@ItemId)
END
GO
/****** Object:  StoredProcedure [dbo].[SetTestTreeItemActivity]    Script Date: 06/21/2009 23:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetTestTreeItemActivity] 
    @NodeId int, 
	@Activity bit
AS
BEGIN
	UPDATE TestTree SET IsActive=@Activity WHERE NodeId=@NodeId
END
GO
/****** Object:  StoredProcedure [dbo].[ReparentTestTreeItem]    Script Date: 06/21/2009 23:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <21.11.2008>
-- Description:	<ReparentTestTreeItem>
-- =============================================
CREATE PROCEDURE [dbo].[ReparentTestTreeItem]
    @ItemId int, 
	@ItemNewParent int
AS
BEGIN
DECLARE @ParentHierId hierarchyid;
DECLARE @Child hierarchyid
DECLARE @Id hierarchyid;

IF @ItemNewParent != 0 BEGIN
SELECT @ParentHierId=TreeNode FROM TestTree WHERE NodeId=@ItemNewParent;
END ELSE BEGIN
SELECT @ParentHierId = hierarchyid::GetRoot() FROM TestTree
END

SELECT @Id = MAX(TreeNode)
FROM TestTree
WHERE TreeNode.GetAncestor(1) = @ParentHierId

SELECT @Child = TreeNode FROM TestTree WHERE NodeId = @ItemId

UPDATE TestTree
SET TreeNode = TreeNode.GetReparentedValue(@Child, @ParentHierId.GetDescendant(@Id, NULL)) 
WHERE 
TreeNode.IsDescendantOf(@Child) = 1
END
GO
/****** Object:  Table [dbo].[TestSessionQuestions]    Script Date: 06/21/2009 23:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestSessionQuestions](
	[TestSessionQuestId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionIndex] [smallint] NOT NULL,
	[TestSessionId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[Answer] [varchar](max) NULL,
	[IsRightAnswer] [bit] NULL,
 CONSTRAINT [PK_TestSessionQuestions] PRIMARY KEY CLUSTERED 
(
	[TestSessionQuestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [_dta_index_TestSessionQuestions_7_533576939__K4_K3] ON [dbo].[TestSessionQuestions] 
(
	[QuestionId] ASC,
	[TestSessionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[RemoveTestTreeItem]    Script Date: 06/21/2009 23:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <17.10.2008>
-- Description:	<RemoveTestTreeItem>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveTestTreeItem]
	@ItemId int
AS
BEGIN

DECLARE  @TestId int=NULL;

DECLARE  @Id hierarchyid
SELECT @Id=TreeNode,@TestId=TestId FROM TestTree WHERE NodeId=@ItemId

DELETE
FROM TestTree
WHERE TreeNode.IsDescendantOf(@Id) = 1

RETURN @TestId

END
GO
/****** Object:  StoredProcedure [dbo].[RemoveDuplicateStudents]    Script Date: 06/21/2009 23:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Antony
-- Create date: 2009.06.06
-- Description:	Удаление дубликатов студентов 
--   с переносом результатов (Фамилия+Имя+Отчество)
-- =============================================
CREATE PROCEDURE [dbo].[RemoveDuplicateStudents] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
-- =============================================
-- Declare and using a READ_ONLY cursor
-- =============================================
DECLARE DoubleStudentsCur CURSOR
READ_ONLY
FOR 
Select TT.mId,TT.UserFIO,TT.CNT from 
(
SELECT 
      LOWER([LastName] + [FirstName] + [SecondName]) as UserFIO
      ,COUNT (LOWER([LastName] + [FirstName] + [SecondName])) as CNT
      ,MIN(U.UserId) as mId
   FROM [Users] as U
  Group BY LOWER([LastName] + [FirstName] + [SecondName])
) AS TT
Where TT.CNT > 1


DECLARE @stud_name nvarchar(450)
DECLARE @stud_new_id int
DECLARE @count int

DECLARE @ProcessedCount int
SET @ProcessedCount = 0


OPEN DoubleStudentsCur

FETCH NEXT FROM DoubleStudentsCur INTO @stud_new_id,@stud_name,@count
WHILE (@@fetch_status <> -1)
BEGIN
	IF (@@fetch_status <> -2)
	BEGIN
--		PRINT 'add user defined code here'
--		eg.

		
		UPDATE [TestSessions]
		SET [UserId] = @stud_new_id
		WHERE 
			[UserId] in
			(
			select UserId from Users
			where
				LOWER([LastName] + [FirstName] + [SecondName]) = @stud_name
				and UserId <> @stud_new_id
			)  
		
		
		
		DELETE FROM [UserGroups]
		WHERE [UserId] in
			(
			select UserId from Users
			where
				LOWER([LastName] + [FirstName] + [SecondName]) = @stud_name
				and UserId <> @stud_new_id
			) 
		
		
		DELETE FROM [Users]
		WHERE [UserId] in
			(
			select UserId from Users
			where
				LOWER([LastName] + [FirstName] + [SecondName]) = @stud_name
				and UserId <> @stud_new_id
			) 
		
		SET @ProcessedCount = @ProcessedCount + 1
		DECLARE @message varchar(100)
		SELECT @message = 'The Kill is: ' + @stud_name 
		PRINT @message
	END
	FETCH NEXT FROM DoubleStudentsCur INTO @stud_new_id,@stud_name,@count
END

CLOSE DoubleStudentsCur
DEALLOCATE DoubleStudentsCur

SELECT @ProcessedCount
RETURN @ProcessedCount

END
GO
/****** Object:  StoredProcedure [dbo].[AddTestTreeItem]    Script Date: 06/21/2009 23:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <17.10.2008>
-- Description:	<AddTestTreeItem>
-- =============================================
CREATE PROCEDURE [dbo].[AddTestTreeItem]
	@ParentId int, -- Id родителя, в случае NULL родителем будет корень дерева
	@NodeType tinyint, -- Тип.
	@TestId int=NULL, --Id теста в таблице CoreTests
	@ItemOwner int = NULL --Пользователь, создавший элемент
AS
BEGIN
DECLARE  @Id hierarchyid;

IF @ParentId IS NULL
BEGIN

SELECT @Id = MAX(TreeNode)
FROM TestTree
WHERE TreeNode.GetAncestor(1) = hierarchyid::GetRoot()
INSERT INTO TestTree (TreeNode, NodeType, TestId, ItemOwner, IsActive)
VALUES (hierarchyid::GetRoot().GetDescendant(@Id,NULL),@NodeType,@TestId,@ItemOwner, 1);

END ELSE BEGIN

DECLARE  @ParentHierId hierarchyid;
SELECT @ParentHierId=TreeNode FROM TestTree WHERE NodeId=@ParentId;

SELECT @Id = MAX(TreeNode)
FROM TestTree
WHERE TreeNode.GetAncestor(1) = @ParentHierId

INSERT INTO TestTree (TreeNode, NodeType, TestId, ItemOwner, IsActive)
VALUES (@ParentHierId.GetDescendant(@Id, NULL),@NodeType,@TestId, @ItemOwner, 1);

END
RETURN @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[GetAppointedTests]    Script Date: 06/21/2009 23:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAppointedTests]
		@UserId int
AS
BEGIN
DECLARE @Id hierarchyid;

SELECT @Id=GroupNode FROM GroupTree 
INNER JOIN UserGroups ON GroupTree.GroupId=UserGroups.GroupId
WHERE UserGroups.UserId=@UserId

SELECT DISTINCT TestTree.NodeId,CoreTests.TestName, COUNT(TestSessions.IsPassed) AS PassedCount FROM GroupTree 
INNER JOIN TestGroups ON TestGroups.GroupId=GroupTree.GroupId 
INNER JOIN CoreTests ON CoreTests.TestId=TestGroups.TestId
INNER JOIN TestTree ON TestTree.TestId=CoreTests.TestId
LEFT OUTER JOIN TestSessions ON TestSessions.TestId=CoreTests.TestId AND TestSessions.UserId=@UserId
WHERE @Id.IsDescendantOf(GroupNode) = 1 AND CoreTests.IsActive=1 AND CoreTests.BeginTime<GETDATE() AND (GETDATE()<CoreTests.EndTime OR CoreTests.EndTime='0001-01-01 00:00:00.0000000')
AND CoreTests.IsDeleted=0
GROUP BY TestTree.NodeId,CoreTests.TestName
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserGroupTree]    Script Date: 06/21/2009 23:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserGroupTree]
	@UserId int,  -- Id пользователя
	@ParentId int,  -- Id родителя, в случае NULL родителем будет корень дерева
    @IsAdmin bit,
	@Level int=NULL -- Число уровней, с которых берутся потомки
AS
BEGIN
SET @Level=@Level+1;

IF @UserId=0 BEGIN

EXEC GetGroupTreeByLevel @ParentId,@Level

END ELSE BEGIN

DECLARE @ProductTotals TABLE 
(
    [GroupId] [int] PRIMARY KEY NOT NULL,
	[GroupNode] [hierarchyid] NOT NULL,
	[GroupName] [varchar](250) NOT NULL,
	[GroupCode] [varchar](50) NOT NULL
)
DECLARE  @Id hierarchyid;
DECLARE @GroupId int;

DECLARE GroupsCur CURSOR FOR SELECT grp.GroupId
FROM UserGroups usr 
INNER JOIN GroupTree grp 
ON grp.GroupId=usr.GroupId WHERE usr.UserId=@UserId AND usr.IsAdministrator=@IsAdmin
OPEN GroupsCur
FETCH NEXT FROM GroupsCur INTO @GroupId
	WHILE @@FETCH_STATUS = 0
	BEGIN
	INSERT INTO @ProductTotals ([GroupId],[GroupNode],[GroupName],[GroupCode]) EXEC GetGroupTreeByLevel @GroupId,@Level
	  FETCH NEXT FROM GroupsCur INTO @GroupId
	END
CLOSE GroupsCur
DEALLOCATE GroupsCur

IF @ParentId IS NULL BEGIN
SELECT DISTINCT [GroupId],[GroupNode].ToString() AS 'GroupNode',[GroupName] FROM @ProductTotals
ORDER BY GroupNode
END ELSE BEGIN
SELECT @Id=GroupNode FROM GroupTree WHERE GroupId=@ParentId
SELECT DISTINCT [GroupId],[GroupNode].ToString() AS 'GroupNode',[GroupName] FROM @ProductTotals
WHERE GroupNode.IsDescendantOf(@Id) = 1
ORDER BY GroupNode
END
END
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserGroups]    Script Date: 06/21/2009 23:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserGroups]
	@UserId int
AS
BEGIN
SELECT grp.GroupId,grp.GroupName,usr.IsAdministrator FROM UserGroups usr INNER JOIN GroupTree grp ON grp.GroupId=usr.GroupId WHERE usr.UserId=@UserId 
END
GO
/****** Object:  StoredProcedure [dbo].[GetTestTreeByLevel]    Script Date: 06/21/2009 23:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <17.10.2008>
-- Description:	<GetTestTreeByLevel>
-- =============================================
CREATE PROCEDURE [dbo].[GetTestTreeByLevel]
	@ParentId int,  -- Id родителя, в случае NULL родителем будет корень дерева
	@Level int=NULL, -- Число уровней, с которых берутся потомки
	@GetParents bit, --Выбрать всех родителей данного узла
	@GetOnlyActive bit --Получить только активные тесты
AS
BEGIN

DECLARE  @Id hierarchyid;
IF @ParentId IS NULL
BEGIN
SET @Id = hierarchyid::GetRoot()
END ELSE BEGIN
SELECT @Id=TreeNode FROM TestTree WHERE NodeId=@ParentId
END

IF @GetParents=1
BEGIN
SELECT TestTree.NodeId,TestTree.NodeType,TestTree.TreeNode.ToString() AS 'TreeNode',TestTree.TestId,
CoreTests.TestName, TestTree.ItemOwner, TestTree.IsActive AS 'TestTreeIsActive'
FROM TestTree LEFT JOIN CoreTests ON TestTree.TestId=CoreTests.TestId
WHERE @Id.IsDescendantOf(TreeNode) = 1 AND(
  ((@GetOnlyActive=1) AND (CoreTests.IsActive=1))
  OR
  (@GetOnlyActive=0)
  )
ORDER BY TestTree.TreeNode
END ELSE BEGIN

IF @Level IS NOT NULL
BEGIN
DECLARE @RealLevel int
SET @RealLevel= (@Id.GetLevel()+@Level+1)

SELECT TestTree.NodeId,TestTree.NodeType,TestTree.TreeNode.ToString() AS 'TreeNode',TestTree.TestId,
CoreTests.TestName, TestTree.ItemOwner, TestTree.IsActive AS 'TestTreeIsActive'
FROM TestTree LEFT JOIN CoreTests ON TestTree.TestId=CoreTests.TestId
WHERE TreeNode.IsDescendantOf(@Id) = 1 AND TreeNode.GetLevel()<@RealLevel AND 
TreeNode.GetLevel()>@Id.GetLevel() AND(
  ((@GetOnlyActive=1) AND (CoreTests.IsActive=1))
  OR
  (@GetOnlyActive=0)
  )
ORDER BY TestTree.TreeNode

END ELSE BEGIN

SELECT TestTree.NodeId,TestTree.NodeType,TestTree.TreeNode.ToString() AS 'TreeNode',TestTree.TestId,
CoreTests.TestName, TestTree.ItemOwner, TestTree.IsActive AS 'TestTreeIsActive'
FROM TestTree LEFT JOIN CoreTests ON TestTree.TestId=CoreTests.TestId
WHERE TreeNode.IsDescendantOf(@Id) = 1 AND(
  ((@GetOnlyActive=1) AND (CoreTests.IsActive=1))
  OR
  (@GetOnlyActive=0)
  )
ORDER BY TestTree.TreeNode

END
END
END
GO
/****** Object:  StoredProcedure [dbo].[GetTestRequirements]    Script Date: 06/21/2009 23:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTestRequirements]
	@TestId int
AS
BEGIN
SELECT req.Requirement,tree.NodeId,test.TestName FROM CoreRequirements req
INNER JOIN CoreTests test on req.Requirement=test.TestId
INNER JOIN TestTree tree on req.Requirement=tree.TestId
WHERE req.TestId=@TestId 
END
GO
/****** Object:  StoredProcedure [dbo].[GetTestOwner]    Script Date: 06/21/2009 23:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTestOwner]
	@ItemId int
AS
BEGIN
DECLARE @ItemOwner int = NULL;
SELECT @ItemOwner = ItemOwner FROM TestTree WHERE  TestId=@ItemId;
RETURN @ItemOwner;
END
GO
/****** Object:  StoredProcedure [dbo].[GetTestItemOwner]    Script Date: 06/21/2009 23:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTestItemOwner]
	@ItemId int
AS
BEGIN
DECLARE @ItemOwner int = NULL;
SELECT @ItemOwner = ItemOwner FROM TestTree WHERE NodeId=@ItemId;
RETURN @ItemOwner;
END
GO
/****** Object:  Table [dbo].[CoreBLOBs]    Script Date: 06/21/2009 23:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CoreBLOBs](
	[BLOBId] [uniqueidentifier] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[BLOBContent] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_CoreBLOBs] PRIMARY KEY CLUSTERED 
(
	[BLOBId] ASC,
	[QuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CoreAnswers]    Script Date: 06/21/2009 23:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CoreAnswers](
	[AnswerId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[Answer] [varchar](max) NOT NULL,
	[IsTrue] [bit] NOT NULL,
	[AnswerMetadata] [varchar](max) NULL,
 CONSTRAINT [PK_CoreAnswers] PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [_dta_index_CoreAnswers_7_757577737__K2_1_3_4] ON [dbo].[CoreAnswers] 
(
	[QuestionId] ASC
)
INCLUDE ( [AnswerId],
[Answer],
[IsTrue]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CloseOpenedSessionsOnEnd]    Script Date: 06/21/2009 23:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Antony
-- Create date: 2009.06.11
-- Description:	Закрытие открытых сессий, у которых 
--   истекло время тестирования (если время неограничено,
--   то сессии также закрываются)
-- =============================================
CREATE PROCEDURE [dbo].[CloseOpenedSessionsOnEnd] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



-- =============================================
-- Declare and using a READ_ONLY cursor
-- =============================================
DECLARE OpenedSessions_cur CURSOR
READ_ONLY
FOR 
SELECT 
	--DATEADD(minute,Tst.TimeLimit,Ses.StartTime) as EndTime
	--,Ses.StartTime
	--,*
	Ses.[TestSessionId]
	,Tst.[PassingScore]  
FROM 
	[TestSessions] as Ses
	left join [CoreTests] as Tst on Ses.TestId = Tst.TestId 
WHERE
	[Score] = -1
	AND -- Те что старые и кончились по времени
	DATEADD(minute,Tst.TimeLimit,Ses.StartTime) <= GETDATE()

DECLARE @SessID int
DECLARE @PassingScore int

DECLARE @Score int

DECLARE @ProcessedCount int
SET @ProcessedCount = 0

OPEN OpenedSessions_cur

FETCH NEXT FROM OpenedSessions_cur INTO @SessID,@PassingScore
WHILE (@@fetch_status <> -1)
BEGIN
	IF (@@fetch_status <> -2)
	BEGIN
--		PRINT 'add user defined code here'
--		eg.
		DECLARE @message varchar(100)
		SELECT @message = 'Closed Session was: ' + CAST(@SessID as nvarchar)
		PRINT @message
		
		--Берем результат
		SELECT 
			--COUNT(*)
			@Score = SUM(CAST(ISNULL([IsRightAnswer],0) as int))
		FROM 
			[TestSessionQuestions]
		WHERE
			[TestSessionId] = @SessID
			
		UPDATE
			[TestSessions]
		SET
			[Score] = @Score
			,[IsPassed] = CASE WHEN @Score>=@PassingScore THEN 1 ELSE 0 END 
			,[EndTime] = GetDate()
		WHERE
			[TestSessionId] = @SessID	
		
		--select @SessID,@Score,@PassingScore,CASE WHEN @Score>=@PassingScore THEN 1 ELSE 0 END
		
		SET @ProcessedCount = @ProcessedCount + 1
	END
	FETCH NEXT FROM OpenedSessions_cur INTO @SessID,@PassingScore
END

CLOSE OpenedSessions_cur
DEALLOCATE OpenedSessions_cur

SELECT @ProcessedCount
RETURN @ProcessedCount

END
GO
/****** Object:  Default [DF_Users_CreationDate]    Script Date: 06/21/2009 23:02:11 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
/****** Object:  Default [DF_CoreTests_TestKey]    Script Date: 06/21/2009 23:02:11 ******/
ALTER TABLE [dbo].[CoreTests] ADD  CONSTRAINT [DF_CoreTests_TestKey]  DEFAULT (newid()) FOR [TestKey]
GO
/****** Object:  Default [DF_BLOBs_BLOBId]    Script Date: 06/21/2009 23:02:13 ******/
ALTER TABLE [dbo].[CoreBLOBs] ADD  CONSTRAINT [DF_BLOBs_BLOBId]  DEFAULT (newid()) FOR [BLOBId]
GO
/****** Object:  ForeignKey [FK_GroupTree_GroupTree]    Script Date: 06/21/2009 23:02:11 ******/
ALTER TABLE [dbo].[GroupTree]  WITH CHECK ADD  CONSTRAINT [FK_GroupTree_GroupTree] FOREIGN KEY([GroupId])
REFERENCES [dbo].[GroupTree] ([GroupId])
GO
ALTER TABLE [dbo].[GroupTree] CHECK CONSTRAINT [FK_GroupTree_GroupTree]
GO
/****** Object:  ForeignKey [FK_CoreRequirements_CoreRequirements1]    Script Date: 06/21/2009 23:02:11 ******/
ALTER TABLE [dbo].[CoreRequirements]  WITH CHECK ADD  CONSTRAINT [FK_CoreRequirements_CoreRequirements1] FOREIGN KEY([TestId])
REFERENCES [dbo].[CoreTests] ([TestId])
GO
ALTER TABLE [dbo].[CoreRequirements] CHECK CONSTRAINT [FK_CoreRequirements_CoreRequirements1]
GO
/****** Object:  ForeignKey [FK_CoreRequirements_CoreTests]    Script Date: 06/21/2009 23:02:11 ******/
ALTER TABLE [dbo].[CoreRequirements]  WITH CHECK ADD  CONSTRAINT [FK_CoreRequirements_CoreTests] FOREIGN KEY([Requirement])
REFERENCES [dbo].[CoreTests] ([TestId])
GO
ALTER TABLE [dbo].[CoreRequirements] CHECK CONSTRAINT [FK_CoreRequirements_CoreTests]
GO
/****** Object:  ForeignKey [FK_CoreQuestions_CoreTests]    Script Date: 06/21/2009 23:02:11 ******/
ALTER TABLE [dbo].[CoreQuestions]  WITH CHECK ADD  CONSTRAINT [FK_CoreQuestions_CoreTests] FOREIGN KEY([TestId])
REFERENCES [dbo].[CoreTests] ([TestId])
GO
ALTER TABLE [dbo].[CoreQuestions] CHECK CONSTRAINT [FK_CoreQuestions_CoreTests]
GO
/****** Object:  ForeignKey [FK_CoreMasterParts_CoreTests]    Script Date: 06/21/2009 23:02:11 ******/
ALTER TABLE [dbo].[CoreMasterParts]  WITH CHECK ADD  CONSTRAINT [FK_CoreMasterParts_CoreTests] FOREIGN KEY([PartTestId])
REFERENCES [dbo].[CoreTests] ([TestId])
GO
ALTER TABLE [dbo].[CoreMasterParts] CHECK CONSTRAINT [FK_CoreMasterParts_CoreTests]
GO
/****** Object:  ForeignKey [FK_CoreMasterParts_CoreTests1]    Script Date: 06/21/2009 23:02:11 ******/
ALTER TABLE [dbo].[CoreMasterParts]  WITH CHECK ADD  CONSTRAINT [FK_CoreMasterParts_CoreTests1] FOREIGN KEY([MasterTestId])
REFERENCES [dbo].[CoreTests] ([TestId])
GO
ALTER TABLE [dbo].[CoreMasterParts] CHECK CONSTRAINT [FK_CoreMasterParts_CoreTests1]
GO
/****** Object:  ForeignKey [FK_ActivationKeyes_Users]    Script Date: 06/21/2009 23:02:12 ******/
ALTER TABLE [dbo].[ActivationKeys]  WITH CHECK ADD  CONSTRAINT [FK_ActivationKeyes_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActivationKeys] CHECK CONSTRAINT [FK_ActivationKeyes_Users]
GO
/****** Object:  ForeignKey [FK_TestTree_Users]    Script Date: 06/21/2009 23:02:12 ******/
ALTER TABLE [dbo].[TestTree]  WITH CHECK ADD  CONSTRAINT [FK_TestTree_Users] FOREIGN KEY([ItemOwner])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[TestTree] CHECK CONSTRAINT [FK_TestTree_Users]
GO
/****** Object:  ForeignKey [FK_TestSessions_CoreTests]    Script Date: 06/21/2009 23:02:12 ******/
ALTER TABLE [dbo].[TestSessions]  WITH CHECK ADD  CONSTRAINT [FK_TestSessions_CoreTests] FOREIGN KEY([TestId])
REFERENCES [dbo].[CoreTests] ([TestId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TestSessions] CHECK CONSTRAINT [FK_TestSessions_CoreTests]
GO
/****** Object:  ForeignKey [FK_UserGroups_GroupTree]    Script Date: 06/21/2009 23:02:12 ******/
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserGroups_GroupTree] FOREIGN KEY([GroupId])
REFERENCES [dbo].[GroupTree] ([GroupId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_UserGroups_GroupTree]
GO
/****** Object:  ForeignKey [FK_UserGroups_Users]    Script Date: 06/21/2009 23:02:12 ******/
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserGroups_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_UserGroups_Users]
GO
/****** Object:  ForeignKey [FK_TestGroups_CoreTests]    Script Date: 06/21/2009 23:02:12 ******/
ALTER TABLE [dbo].[TestGroups]  WITH CHECK ADD  CONSTRAINT [FK_TestGroups_CoreTests] FOREIGN KEY([TestId])
REFERENCES [dbo].[CoreTests] ([TestId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TestGroups] CHECK CONSTRAINT [FK_TestGroups_CoreTests]
GO
/****** Object:  ForeignKey [FK_TestGroups_GroupTree]    Script Date: 06/21/2009 23:02:12 ******/
ALTER TABLE [dbo].[TestGroups]  WITH CHECK ADD  CONSTRAINT [FK_TestGroups_GroupTree] FOREIGN KEY([GroupId])
REFERENCES [dbo].[GroupTree] ([GroupId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TestGroups] CHECK CONSTRAINT [FK_TestGroups_GroupTree]
GO
/****** Object:  ForeignKey [FK_TestSessionQuestions_CoreQuestions]    Script Date: 06/21/2009 23:02:13 ******/
ALTER TABLE [dbo].[TestSessionQuestions]  WITH CHECK ADD  CONSTRAINT [FK_TestSessionQuestions_CoreQuestions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[CoreQuestions] ([QuestionId])
GO
ALTER TABLE [dbo].[TestSessionQuestions] CHECK CONSTRAINT [FK_TestSessionQuestions_CoreQuestions]
GO
/****** Object:  ForeignKey [FK_TestSessionQuestions_TestSessions]    Script Date: 06/21/2009 23:02:13 ******/
ALTER TABLE [dbo].[TestSessionQuestions]  WITH CHECK ADD  CONSTRAINT [FK_TestSessionQuestions_TestSessions] FOREIGN KEY([TestSessionId])
REFERENCES [dbo].[TestSessions] ([TestSessionId])
GO
ALTER TABLE [dbo].[TestSessionQuestions] CHECK CONSTRAINT [FK_TestSessionQuestions_TestSessions]
GO
/****** Object:  ForeignKey [FK_BLOBs_CoreQuestions]    Script Date: 06/21/2009 23:02:13 ******/
ALTER TABLE [dbo].[CoreBLOBs]  WITH CHECK ADD  CONSTRAINT [FK_BLOBs_CoreQuestions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[CoreQuestions] ([QuestionId])
GO
ALTER TABLE [dbo].[CoreBLOBs] CHECK CONSTRAINT [FK_BLOBs_CoreQuestions]
GO
/****** Object:  ForeignKey [FK_CoreAnswers_CoreQuestions]    Script Date: 06/21/2009 23:02:13 ******/
ALTER TABLE [dbo].[CoreAnswers]  WITH CHECK ADD  CONSTRAINT [FK_CoreAnswers_CoreQuestions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[CoreQuestions] ([QuestionId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CoreAnswers] CHECK CONSTRAINT [FK_CoreAnswers_CoreQuestions]
GO
