--CREATE TABLE [dbo].[RainFall](
--	[Id] uniqueidentifier NOT NULL,
--	[Xref] int NOT NULL,
--	[Yref] int NOT NULL,
--	[Date] smalldatetime NOT NULL,
--	[Day] int NOT NULL,
--	[Month] int NOT NULL,
--	[Year] int NOT NULL,
--	[Value] int NOT NULL,
--	[Created] smalldatetime NOT NULL
--	CONSTRAINT [PK_RainFall_Id] PRIMARY KEY CLUSTERED 
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO

--ALTER TABLE [dbo].[RainFall] ADD  CONSTRAINT [DF_RainFall_Id]  DEFAULT (NEWID()) FOR [Id]
--GO

--ALTER TABLE [dbo].[RainFall] ADD  CONSTRAINT [DF_RainFall_Created]  DEFAULT (GETDATE()) FOR [Created]
--GO

CREATE TABLE [dbo].[RainFall](
	[Id] nvarchar(255) NULL,
	[Xref] nvarchar(255) NULL,
	[Yref] nvarchar(255) NULL,
	[Date] nvarchar(255) NULL,
	[Day] nvarchar(255) NULL,
	[Month] nvarchar(255) NULL,
	[Year]nvarchar(255) NULL,
	[Value] nvarchar(255) NULL,
	[Created] nvarchar(255) NULL
)
GO


