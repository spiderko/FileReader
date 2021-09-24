CREATE TABLE [dbo].[RainFall](
	[Id] uniqueidentifier NOT NULL,
	[RainFallHeaderId] uniqueidentifier NULL,
	[Xref] int NOT NULL,
	[Yref] int NOT NULL,
	[Date] smalldatetime NOT NULL,
	[Day] int NOT NULL,
	[Month] int NOT NULL,
	[Year] int NOT NULL,
	[Value] int NOT NULL,
	[Created] smalldatetime NOT NULL
	CONSTRAINT [PK_RainFall_Id] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RainFall] ADD  CONSTRAINT [DF_RainFall_Id]  DEFAULT (NEWID()) FOR [Id]
GO

ALTER TABLE [dbo].[RainFall] ADD  CONSTRAINT [DF_RainFall_Created]  DEFAULT (GETDATE()) FOR [Created]
GO


CREATE TABLE [dbo].[RainFallHeader](
	[Id] uniqueidentifier NOT NULL,
	[Title] nvarchar(100) NOT NULL,
	[Type] nvarchar(30) NOT NULL,
	[ClimaticResearchUnitVersion] nvarchar(5) NOT NULL,
	[CreatedBy] nvarchar(100) NOT NULL,
	[CreatedOn] smalldatetime NOT NULL,
	[LongitudeMin] decimal(5,2) NOT NULL,
	[LongitudeMax] decimal(5,2) NOT NULL,
	[LatitudeMin] decimal(4,2) NOT NULL,
	[LatitudeMax] decimal(4,2) NOT NULL,
	[GridX] int NOT NULL,
	[GridY] int NOT NULL,
	[Boxes] int NOT NULL,
	[YearMin] int NOT NULL,
	[YearMax] int NOT NULL,
	[Multi] decimal(5,4) NOT NULL,
	[Missing] int NOT NULL,
	[Created] smalldatetime NOT NULL
	CONSTRAINT [PK_RainFallHeader_Id] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RainFallHeader] ADD  CONSTRAINT [DF_RainFallHeader_Id]  DEFAULT (NEWID()) FOR [Id]
GO

ALTER TABLE [dbo].[RainFallHeader] ADD  CONSTRAINT [DF_RainFallHeader_Created]  DEFAULT (GETDATE()) FOR [Created]
GO

ALTER TABLE [dbo].[RainFall] ADD  CONSTRAINT [FK_RainFallHeader_RainFall]  FOREIGN KEY ([RainFallHeaderId]) REFERENCES [dbo].[RainFallHeader] ([Id])
GO

