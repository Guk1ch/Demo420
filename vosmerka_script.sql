USE [VosmerkaDBLiana]
GO
/****** Object:  Table [dbo].[Agent]    Script Date: 06.02.2025 18:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[AgentTypeID] [int] NOT NULL,
	[Address] [nvarchar](300) NULL,
	[INN] [varchar](12) NOT NULL,
	[KPP] [varchar](9) NULL,
	[DirectorName] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](255) NULL,
	[Logo] [nvarchar](100) NULL,
	[Priority] [int] NOT NULL,
 CONSTRAINT [PK_Agent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AgentPriorityHistory]    Script Date: 06.02.2025 18:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgentPriorityHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AgentID] [int] NOT NULL,
	[ChangeDate] [datetime] NOT NULL,
	[PriorityValue] [int] NOT NULL,
 CONSTRAINT [PK_AgentPriorityHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AgentType]    Script Date: 06.02.2025 18:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgentType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](100) NULL,
 CONSTRAINT [PK_AgentType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material]    Script Date: 06.02.2025 18:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[MaterialTypeID] [int] NOT NULL,
	[CountInPack] [int] NOT NULL,
	[idUnit] [int] NOT NULL,
	[CountInStock] [float] NULL,
	[MinCount] [float] NOT NULL,
	[Cost] [decimal](10, 2) NOT NULL,
	[Image] [nvarchar](100) NULL,
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialCountHistory]    Script Date: 06.02.2025 18:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialCountHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaterialID] [int] NOT NULL,
	[ChangeDate] [datetime] NOT NULL,
	[CountValue] [float] NOT NULL,
 CONSTRAINT [PK_MaterialCountHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialSupplier]    Script Date: 06.02.2025 18:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialSupplier](
	[MaterialID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NOT NULL,
 CONSTRAINT [PK_MaterialSupplier] PRIMARY KEY CLUSTERED 
(
	[MaterialID] ASC,
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialType]    Script Date: 06.02.2025 18:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[DefectedPercent] [float] NULL,
 CONSTRAINT [PK_MaterialType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 06.02.2025 18:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[ProductTypeID] [int] NULL,
	[ArticleNumber] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](100) NULL,
	[ProductionPersonCount] [int] NULL,
	[ProductionWorkshopNumber] [int] NULL,
	[MinCostForAgent] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCostHistory]    Script Date: 06.02.2025 18:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCostHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[ChangeDate] [datetime] NOT NULL,
	[CostValue] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_ProductCostHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductMaterial]    Script Date: 06.02.2025 18:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductMaterial](
	[ProductID] [int] NOT NULL,
	[MaterialID] [int] NOT NULL,
	[Count] [float] NULL,
 CONSTRAINT [PK_ProductMaterial] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[MaterialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSale]    Script Date: 06.02.2025 18:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSale](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AgentID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[SaleDate] [date] NOT NULL,
	[ProductCount] [int] NOT NULL,
 CONSTRAINT [PK_ProductSale] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 06.02.2025 18:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[DefectedPercent] [float] NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shop]    Script Date: 06.02.2025 18:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shop](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Address] [nvarchar](300) NULL,
	[AgentID] [int] NOT NULL,
 CONSTRAINT [PK_Shop] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 06.02.2025 18:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[INN] [varchar](12) NOT NULL,
	[StartDate] [date] NOT NULL,
	[QualityRating] [int] NULL,
	[SupplierType] [nvarchar](20) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnitOfMeasurement]    Script Date: 06.02.2025 18:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitOfMeasurement](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NULL,
 CONSTRAINT [PK_UnitOfMeasurement] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Material] ON 

INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (1, N'Шипы для льда 3x2', 1, 3, 1, 470, 26, CAST(6511.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (2, N'Резина для льда 0x2', 2, 2, 2, 816, 21, CAST(48785.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (3, N'Шипы для льда 2x2', 1, 1, 1, 479, 22, CAST(13077.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (4, N'Шипы для льда 3x0', 1, 9, 1, 885, 5, CAST(52272.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (5, N'Шипы для пустыни 3x2', 1, 2, 1, 923, 19, CAST(28748.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (6, N'Шипы для лета 3x1', 1, 6, 2, 184, 40, CAST(51974.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (7, N'Резина для зимы 2x3', 2, 3, 3, 344, 12, CAST(53323.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (8, N'Резина для зимы 3x3', 2, 2, 2, 275, 28, CAST(31356.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (9, N'Шипы для льда 1x0', 1, 10, 1, 914, 22, CAST(25538.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (10, N'Резина для лета 0x1', 2, 9, 2, 127, 17, CAST(23936.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (11, N'Резина для лета 2x2', 2, 2, 3, 542, 20, CAST(54298.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (12, N'Резина для зимы 3x1', 2, 9, 2, 690, 24, CAST(25844.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (13, N'Шипы для зимы 0x1', 1, 3, 1, 255, 25, CAST(6484.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (14, N'Шипы для льда 2x0', 1, 4, 4, 214, 15, CAST(17996.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (15, N'Резина для пустыни 3x2', 2, 1, 3, 931, 43, CAST(5854.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (16, N'Шипы для зимы 3x0', 1, 6, 1, 192, 48, CAST(9260.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (17, N'Резина для пустыни 2x0', 2, 5, 2, 769, 14, CAST(17425.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (18, N'Шипы для лета 3x2', 1, 1, 1, 547, 11, CAST(43288.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (19, N'Резина для зимы 0x3', 2, 4, 3, 726, 46, CAST(37293.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (20, N'Шипы для льда 0x0', 1, 2, 2, 585, 37, CAST(21188.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (21, N'Шипы для льда 0x1', 1, 2, 4, 147, 8, CAST(49557.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (22, N'Резина для льда 1x3', 2, 2, 2, 286, 39, CAST(23551.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (23, N'Резина для пустыни 1x3', 2, 5, 2, 222, 9, CAST(21546.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (24, N'Шипы для зимы 3x3', 1, 4, 1, 652, 33, CAST(15159.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (25, N'Шипы для пустыни 0x2', 1, 4, 1, 792, 46, CAST(8571.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (26, N'Шипы для лета 2x0', 1, 1, 1, 68, 43, CAST(8206.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (27, N'Резина для пустыни 3x3', 2, 9, 3, 840, 11, CAST(5144.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (28, N'Резина для льда 0x1', 2, 5, 3, 964, 34, CAST(53394.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (29, N'Резина для лета 0x2', 2, 4, 2, 753, 33, CAST(9069.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (30, N'Резина для зимы 1x0', 2, 5, 2, 929, 48, CAST(43046.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (31, N'Резина для лета 3x3', 2, 6, 3, 652, 28, CAST(6764.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (32, N'Резина для пустыни 1x1', 2, 6, 2, 120, 21, CAST(11642.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (33, N'Шипы для пустыни 0x1', 1, 4, 4, 612, 24, CAST(55689.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (34, N'Шипы для льда 3x1', 1, 8, 1, 123, 43, CAST(42668.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (35, N'Резина для льда 3x3', 2, 7, 2, 909, 35, CAST(23174.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (36, N'Шипы для льда 2x3', 1, 10, 4, 237, 7, CAST(27105.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (37, N'Шипы для лета 2x2', 1, 4, 1, 15, 10, CAST(44506.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (38, N'Резина для пустыни 2x3', 2, 5, 3, 103, 38, CAST(55679.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (39, N'Резина для зимы 1x3', 2, 9, 3, 84, 50, CAST(27823.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (40, N'Резина для лета 1x0', 2, 5, 3, 234, 32, CAST(25499.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (41, N'Резина для пустыни 0x3', 2, 8, 3, 761, 7, CAST(8094.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (42, N'Резина для лета 2x1', 2, 2, 3, 561, 39, CAST(47610.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (43, N'Резина для пустыни 2x1', 2, 10, 2, 918, 12, CAST(34518.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (44, N'Шипы для пустыни 3x1', 1, 4, 1, 37, 43, CAST(27104.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (45, N'Шипы для льда 1x1', 1, 7, 1, 335, 33, CAST(48279.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (46, N'Шипы для зимы 2x0', 1, 3, 4, 466, 8, CAST(34841.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (47, N'Резина для пустыни 1x2', 2, 9, 2, 496, 36, CAST(24876.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (48, N'Резина для льда 2x0', 2, 6, 3, 86, 8, CAST(24767.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (49, N'Шипы для лета 0x1', 1, 2, 2, 974, 35, CAST(28825.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Material] ([ID], [Title], [MaterialTypeID], [CountInPack], [idUnit], [CountInStock], [MinCount], [Cost], [Image]) VALUES (50, N'Шипы для льда 2x1', 1, 10, 4, 634, 25, CAST(23287.00 AS Decimal(10, 2)), NULL)
SET IDENTITY_INSERT [dbo].[Material] OFF
GO
SET IDENTITY_INSERT [dbo].[MaterialType] ON 

INSERT [dbo].[MaterialType] ([ID], [Title], [DefectedPercent]) VALUES (1, N'Шипы', NULL)
INSERT [dbo].[MaterialType] ([ID], [Title], [DefectedPercent]) VALUES (2, N'Резина', NULL)
SET IDENTITY_INSERT [dbo].[MaterialType] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (2, N'Запаска R15 Кованый', 2, N'327657', NULL, N'\products\tire_64.jpg', 2, 8, CAST(8667.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (3, N'Шина R21 Лето', 3, N'266521', NULL, N'\products\tire_6.jpg', 4, 1, CAST(10561.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (4, N'Шина R21 Кованый', 3, N'329576', NULL, N'\products\tire_59.jpg', 2, 2, CAST(7989.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (5, N'Диск R17 Лето', 4, N'400508', NULL, N'\products\tire_24.jpg', 1, 4, CAST(12941.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (6, N'Шина R14 Липучка', 3, N'331598', NULL, N'\products\tire_17.jpg', 4, 1, CAST(13879.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (7, N'Диск R16 Кованый', 4, N'440075', NULL, N'\products\tire_25.jpg', 3, 9, CAST(9068.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (8, N'Запаска R14 Лето', 2, N'448396', NULL, N'\products\tire_32.jpg', 1, 5, CAST(12878.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (9, N'Диск R22 Липучка', 4, N'418286', NULL, N'\products\tire_4.jpg', 4, 2, CAST(10670.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (10, N'Запаска R15 Лето', 2, N'348910', NULL, N'\products\tire_50.jpg', 1, 9, CAST(4969.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (11, N'Шина R15 Липучка', 3, N'349418', NULL, N'\products\tire_48.jpg', 1, 4, CAST(6393.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (12, N'Колесо R15 Кованый', 1, N'376388', NULL, NULL, 3, 4, CAST(9439.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (13, N'Колесо R20 Кованый', 1, N'445217', NULL, N'\products\tire_1.jpg', 3, 10, CAST(9569.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (14, N'Диск R19 Лето', 4, N'243152', NULL, N'\products\tire_0.jpg', 1, 9, CAST(6264.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (15, N'Колесо R18 Лето', 1, N'412238', NULL, N'\products\tire_14.jpg', 2, 7, CAST(13892.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (16, N'Диск R20 Зима', 4, N'252453', NULL, NULL, 4, 9, CAST(14526.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (17, N'Диск R17 Зима', 4, N'343841', NULL, NULL, 3, 9, CAST(12768.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (18, N'Запаска R21 Липучка', 2, N'247470', NULL, N'\products\tire_62.jpg', 1, 2, CAST(10139.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (19, N'Запаска R20 Липучка', 2, N'335226', NULL, NULL, 1, 2, CAST(9988.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (20, N'Шина R17 Кованый', 3, N'299692', NULL, N'\products\tire_58.jpg', 3, 10, CAST(11463.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (21, N'Диск R20 Липучка', 4, N'447543', NULL, N'\products\tire_3.jpg', 4, 8, CAST(11661.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (22, N'Запаска R20 Кованый', 2, N'249737', NULL, NULL, 5, 5, CAST(7509.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (23, N'Колесо R14 Кованый', 1, N'429265', NULL, NULL, 3, 6, CAST(11838.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (24, N'Диск R21 Кованый', 4, N'299085', NULL, N'\products\tire_61.jpg', 3, 3, CAST(4757.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (25, N'Шина R20 Кованый', 3, N'330937', NULL, N'\products\tire_45.jpg', 3, 1, CAST(10928.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (26, N'Диск R16 Липучка', 4, N'435703', NULL, NULL, 5, 2, CAST(9934.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (27, N'Запаска R18 Лето', 2, N'305509', NULL, N'\products\tire_41.jpg', 1, 3, CAST(5192.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (28, N'Запаска R19 Кованый', 2, N'390434', NULL, N'\products\tire_46.jpg', 5, 8, CAST(14258.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (29, N'Диск R18 Лето', 4, N'317858', NULL, N'\products\tire_52.jpg', 5, 3, CAST(8435.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (30, N'Запаска R14 Кованый', 2, N'412235', NULL, N'\products\tire_47.jpg', 4, 6, CAST(12891.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (31, N'Запаска R22 Липучка', 2, N'328305', NULL, N'\products\tire_13.jpg', 2, 1, CAST(10116.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (32, N'Колесо R21 Липучка', 1, N'403378', NULL, N'\products\tire_55.jpg', 3, 10, CAST(3626.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (33, N'Шина R18 Лето', 3, N'425463', NULL, NULL, 4, 10, CAST(11625.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (34, N'Запаска R17 Липучка', 2, N'327883', NULL, N'\products\tire_10.jpg', 2, 2, CAST(12332.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (35, N'Диск R22 Кованый', 4, N'388520', NULL, N'\products\tire_19.jpg', 3, 2, CAST(7498.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (36, N'Шина R18 Липучка', 3, N'319450', NULL, NULL, 3, 6, CAST(4951.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (37, N'Шина R16 Кованый', 3, N'421321', NULL, NULL, 1, 2, CAST(14691.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (38, N'Диск R17 Липучка', 4, N'282569', NULL, N'\products\tire_42.jpg', 5, 5, CAST(12356.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (39, N'Запаска R23 Зима', 2, N'394768', NULL, N'\products\tire_8.jpg', 1, 9, CAST(13019.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (40, N'Диск R21 Зима', 4, N'250714', NULL, N'\products\tire_11.jpg', 5, 5, CAST(8762.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (41, N'Диск R16 Лето', 4, N'251201', NULL, NULL, 3, 10, CAST(8149.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (42, N'Шина R14 Кованый', 3, N'274477', NULL, N'\products\tire_34.jpg', 5, 5, CAST(9527.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (43, N'Диск R19 Зима', 4, N'358851', NULL, N'\products\tire_16.jpg', 5, 6, CAST(5695.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (44, N'Диск R21 Лето', 4, N'449834', NULL, N'\products\tire_35.jpg', 4, 8, CAST(2698.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (45, N'Запаска R19 Липучка', 2, N'438383', NULL, NULL, 3, 1, CAST(12000.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (46, N'Колесо R19 Лето', 1, N'298778', NULL, N'\products\tire_38.jpg', 1, 10, CAST(7493.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (47, N'Колесо R16 Лето', 1, N'337577', NULL, N'\products\tire_2.jpg', 1, 9, CAST(10161.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (48, N'Запаска R21 Зима', 2, N'365509', NULL, NULL, 5, 6, CAST(14556.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (49, N'Шина R20 Липучка', 3, N'348553', NULL, NULL, 2, 2, CAST(3508.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (50, N'Диск R20 Лето', 4, N'300047', NULL, N'\products\tire_56.jpg', 3, 10, CAST(10323.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (51, N'Запаска R18 Липучка', 2, N'279256', NULL, N'\products\tire_53.jpg', 4, 5, CAST(9759.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (52, N'Шина R22 Лето', 3, N'406784', NULL, N'\products\tire_37.jpg', 3, 5, CAST(14692.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (53, N'Колесо R21 Лето', 1, N'276905', NULL, NULL, 1, 2, CAST(10343.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (54, N'Диск R19 Липучка', 4, N'318661', NULL, NULL, 1, 6, CAST(5544.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (55, N'Запаска R14 Зима', 2, N'440993', NULL, NULL, 5, 2, CAST(6020.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (56, N'Запаска R22 Кованый', 2, N'341800', NULL, NULL, 2, 4, CAST(5447.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (57, N'Диск R22 Зима', 4, N'453650', NULL, N'\products\tire_22.jpg', 5, 3, CAST(11459.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (58, N'Запаска R17 Кованый', 2, N'372287', NULL, N'\products\tire_57.jpg', 5, 3, CAST(5808.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (59, N'Диск R15 Лето', 4, N'347427', NULL, NULL, 1, 1, CAST(5071.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (60, N'Шина R15 Кованый', 3, N'274665', NULL, N'\products\tire_63.jpg', 2, 10, CAST(13101.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (61, N'Запаска R19 Лето', 2, N'283112', NULL, N'\products\tire_33.jpg', 3, 4, CAST(3362.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (62, N'Колесо R20 Липучка', 1, N'363664', NULL, NULL, 1, 8, CAST(12681.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (63, N'Шина R19 Зима', 3, N'444141', NULL, NULL, 2, 8, CAST(2741.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (64, N'Шина R22 Кованый', 3, N'416324', NULL, N'\products\tire_30.jpg', 2, 8, CAST(13841.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (65, N'Колесо R18 Зима', 1, N'387609', NULL, N'\products\tire_9.jpg', 1, 4, CAST(3445.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (66, N'Запаска R16 Кованый', 2, N'432234', NULL, NULL, 3, 7, CAST(13556.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (67, N'Колесо R17 Зима', 1, N'381949', NULL, NULL, 4, 6, CAST(5902.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (68, N'Запаска R16 Зима', 2, N'394413', NULL, N'\products\tire_49.jpg', 3, 10, CAST(12679.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (69, N'Колесо R20 Лето', 1, N'434626', NULL, N'\products\tire_31.jpg', 5, 8, CAST(11959.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (70, N'Шина R17 Липучка', 3, N'280863', NULL, NULL, 4, 8, CAST(11695.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (71, N'Шина R18 Зима', 3, N'444280', NULL, N'\products\tire_44.jpg', 4, 6, CAST(13168.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (72, N'Запаска R17 Лето', 2, N'331576', NULL, N'\products\tire_39.jpg', 3, 8, CAST(4803.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (73, N'Запаска R22 Зима', 2, N'268886', NULL, NULL, 3, 2, CAST(13471.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (74, N'Колесо R20 Зима', 1, N'427198', NULL, NULL, 4, 10, CAST(2397.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (75, N'Шина R17 Лето', 3, N'354738', NULL, N'\products\tire_20.jpg', 2, 10, CAST(11329.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (76, N'Шина R14 Лето', 3, N'330951', NULL, N'\products\tire_29.jpg', 4, 7, CAST(6786.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (77, N'Запаска R20 Зима', 2, N'241577', NULL, N'\products\tire_51.jpg', 2, 6, CAST(9125.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (78, N'Колесо R17 Липучка', 1, N'281537', NULL, NULL, 1, 2, CAST(4365.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (79, N'Шина R16 Зима', 3, N'300433', NULL, NULL, 4, 2, CAST(2570.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (80, N'Запаска R19 Зима', 2, N'254860', NULL, NULL, 2, 5, CAST(5568.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (81, N'Диск R22 Лето', 4, N'406411', NULL, N'\products\tire_23.jpg', 2, 4, CAST(2904.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (82, N'Колесо R19 Липучка', 1, N'440973', NULL, N'\products\tire_5.jpg', 4, 4, CAST(8439.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (83, N'Шина R21 Липучка', 3, N'308647', NULL, N'\products\tire_26.jpg', 4, 6, CAST(12830.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (84, N'Шина R17 Зима', 3, N'291319', NULL, N'\products\tire_54.jpg', 2, 4, CAST(6426.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (85, N'Диск R18 Зима', 4, N'255211', NULL, N'\products\tire_21.jpg', 1, 6, CAST(13239.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (86, N'Шина R18 Кованый', 3, N'275809', NULL, N'\products\tire_40.jpg', 4, 10, CAST(3258.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (87, N'Колесо R17 Лето', 1, N'332936', NULL, N'\products\tire_28.jpg', 2, 1, CAST(11145.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (88, N'Шина R22 Зима', 3, N'382661', NULL, NULL, 1, 2, CAST(10373.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (89, N'Шина R19 Лето', 3, N'335030', NULL, NULL, 4, 10, CAST(4870.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (90, N'Шина R19 Кованый', 3, N'291359', NULL, N'\products\tire_27.jpg', 5, 10, CAST(14682.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (91, N'Колесо R18 Липучка', 1, N'332858', NULL, N'\products\tire_12.jpg', 3, 7, CAST(14804.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (92, N'Запаска R15 Липучка', 2, N'237228', NULL, N'\products\tire_18.jpg', 3, 8, CAST(5510.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (93, N'Шина R15 Зима', 3, N'312952', NULL, NULL, 2, 5, CAST(4039.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (94, N'Шина R19 Липучка', 3, N'341034', NULL, N'\products\tire_36.jpg', 1, 5, CAST(13063.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (95, N'Запаска R15 Зима', 2, N'251241', NULL, NULL, 3, 10, CAST(3874.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (96, N'Шина R16 Лето', 3, N'437927', NULL, NULL, 3, 6, CAST(7181.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (97, N'Колесо R16 Липучка', 1, N'263261', NULL, NULL, 4, 1, CAST(14521.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (98, N'Запаска R21 Лето', 2, N'299112', NULL, N'\products\tire_43.jpg', 2, 8, CAST(3694.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (99, N'Шина R21 Зима', 3, N'398710', NULL, N'\products\tire_7.jpg', 2, 2, CAST(9378.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (100, N'Шина R16 Липучка', 3, N'320970', NULL, N'\products\tire_60.jpg', 1, 2, CAST(2264.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (101, N'Колесо 2 разряда', 1, N'123123123', N'Колесо 2 разряда', NULL, 1, 2, CAST(12345.00 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([ID], [Title], [ProductTypeID], [ArticleNumber], [Description], [Image], [ProductionPersonCount], [ProductionWorkshopNumber], [MinCostForAgent]) VALUES (102, N'Резина Зимняя', 2, N'2222', N'Зимняя резина', NULL, 2, 1, CAST(1231.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (3, 7, 3)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (3, 39, 11)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (5, 34, 15)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (6, 8, 3)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (6, 26, 9)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (6, 39, 3)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (6, 49, 10)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (7, 5, 16)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (7, 6, 13)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (7, 37, 18)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (8, 15, 7)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (9, 2, 14)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (9, 9, 4)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (9, 12, 10)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (11, 7, 2)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (14, 14, 5)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (14, 31, 8)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (15, 9, 9)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (15, 11, 4)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (15, 42, 10)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (21, 1, 14)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (25, 29, 11)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (25, 47, 5)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (27, 13, 13)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (27, 18, 13)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (27, 37, 8)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (28, 12, 6)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (30, 1, 9)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (30, 7, 18)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (30, 12, 16)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (30, 19, 11)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (30, 20, 1)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (30, 31, 6)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (30, 37, 15)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (31, 26, 8)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (34, 26, 9)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (34, 40, 14)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (35, 31, 1)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (38, 23, 11)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (38, 34, 4)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (38, 45, 8)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (38, 47, 5)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (42, 7, 9)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (42, 10, 14)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (42, 21, 14)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (42, 33, 10)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (43, 14, 2)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (43, 40, 9)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (43, 50, 8)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (47, 19, 14)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (47, 30, 2)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (47, 44, 11)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (52, 32, 14)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (57, 19, 8)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (57, 35, 11)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (57, 45, 8)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (61, 3, 11)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (61, 29, 8)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (61, 41, 13)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (65, 14, 5)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (65, 19, 10)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (65, 25, 14)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (68, 41, 3)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (68, 42, 4)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (69, 22, 14)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (71, 30, 14)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (71, 43, 9)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (72, 24, 5)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (75, 14, 6)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (76, 25, 12)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (81, 12, 3)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (82, 5, 5)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (82, 29, 15)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (82, 38, 5)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (83, 17, 2)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (83, 26, 16)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (83, 47, 18)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (83, 49, 13)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (85, 6, 19)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (87, 2, 5)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (87, 11, 3)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (87, 20, 4)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (87, 39, 20)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (91, 6, 14)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (91, 8, 5)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (91, 47, 6)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (91, 49, 12)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (92, 1, 19)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (92, 6, 10)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (94, 6, 12)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (94, 15, 13)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (94, 23, 19)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (94, 30, 5)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (98, 30, 4)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (98, 47, 19)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (99, 15, 3)
INSERT [dbo].[ProductMaterial] ([ProductID], [MaterialID], [Count]) VALUES (99, 21, 4)
GO
SET IDENTITY_INSERT [dbo].[ProductType] ON 

INSERT [dbo].[ProductType] ([ID], [Title], [DefectedPercent]) VALUES (1, N'Колесо', NULL)
INSERT [dbo].[ProductType] ([ID], [Title], [DefectedPercent]) VALUES (2, N'Запаска', NULL)
INSERT [dbo].[ProductType] ([ID], [Title], [DefectedPercent]) VALUES (3, N'Шина', NULL)
INSERT [dbo].[ProductType] ([ID], [Title], [DefectedPercent]) VALUES (4, N'Диск', NULL)
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO
SET IDENTITY_INSERT [dbo].[UnitOfMeasurement] ON 

INSERT [dbo].[UnitOfMeasurement] ([id], [name]) VALUES (1, N' г        ')
INSERT [dbo].[UnitOfMeasurement] ([id], [name]) VALUES (2, N' кг       ')
INSERT [dbo].[UnitOfMeasurement] ([id], [name]) VALUES (3, N' м        ')
INSERT [dbo].[UnitOfMeasurement] ([id], [name]) VALUES (4, N' шт       ')
SET IDENTITY_INSERT [dbo].[UnitOfMeasurement] OFF
GO
ALTER TABLE [dbo].[Agent]  WITH CHECK ADD  CONSTRAINT [FK_Agent_AgentType] FOREIGN KEY([AgentTypeID])
REFERENCES [dbo].[AgentType] ([ID])
GO
ALTER TABLE [dbo].[Agent] CHECK CONSTRAINT [FK_Agent_AgentType]
GO
ALTER TABLE [dbo].[AgentPriorityHistory]  WITH CHECK ADD  CONSTRAINT [FK_AgentPriorityHistory_Agent] FOREIGN KEY([AgentID])
REFERENCES [dbo].[Agent] ([ID])
GO
ALTER TABLE [dbo].[AgentPriorityHistory] CHECK CONSTRAINT [FK_AgentPriorityHistory_Agent]
GO
ALTER TABLE [dbo].[Material]  WITH CHECK ADD  CONSTRAINT [FK_Material_MaterialType] FOREIGN KEY([MaterialTypeID])
REFERENCES [dbo].[MaterialType] ([ID])
GO
ALTER TABLE [dbo].[Material] CHECK CONSTRAINT [FK_Material_MaterialType]
GO
ALTER TABLE [dbo].[Material]  WITH CHECK ADD  CONSTRAINT [FK_Material_UnitOfMeasurement] FOREIGN KEY([idUnit])
REFERENCES [dbo].[UnitOfMeasurement] ([id])
GO
ALTER TABLE [dbo].[Material] CHECK CONSTRAINT [FK_Material_UnitOfMeasurement]
GO
ALTER TABLE [dbo].[MaterialCountHistory]  WITH CHECK ADD  CONSTRAINT [FK_MaterialCountHistory_Material] FOREIGN KEY([MaterialID])
REFERENCES [dbo].[Material] ([ID])
GO
ALTER TABLE [dbo].[MaterialCountHistory] CHECK CONSTRAINT [FK_MaterialCountHistory_Material]
GO
ALTER TABLE [dbo].[MaterialSupplier]  WITH CHECK ADD  CONSTRAINT [FK_MaterialSupplier_Material] FOREIGN KEY([MaterialID])
REFERENCES [dbo].[Material] ([ID])
GO
ALTER TABLE [dbo].[MaterialSupplier] CHECK CONSTRAINT [FK_MaterialSupplier_Material]
GO
ALTER TABLE [dbo].[MaterialSupplier]  WITH CHECK ADD  CONSTRAINT [FK_MaterialSupplier_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([ID])
GO
ALTER TABLE [dbo].[MaterialSupplier] CHECK CONSTRAINT [FK_MaterialSupplier_Supplier]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([ProductTypeID])
REFERENCES [dbo].[ProductType] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
ALTER TABLE [dbo].[ProductCostHistory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCostHistory_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductCostHistory] CHECK CONSTRAINT [FK_ProductCostHistory_Product]
GO
ALTER TABLE [dbo].[ProductMaterial]  WITH CHECK ADD  CONSTRAINT [FK_ProductMaterial_Material] FOREIGN KEY([MaterialID])
REFERENCES [dbo].[Material] ([ID])
GO
ALTER TABLE [dbo].[ProductMaterial] CHECK CONSTRAINT [FK_ProductMaterial_Material]
GO
ALTER TABLE [dbo].[ProductMaterial]  WITH CHECK ADD  CONSTRAINT [FK_ProductMaterial_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductMaterial] CHECK CONSTRAINT [FK_ProductMaterial_Product]
GO
ALTER TABLE [dbo].[ProductSale]  WITH CHECK ADD  CONSTRAINT [FK_ProductSale_Agent] FOREIGN KEY([AgentID])
REFERENCES [dbo].[Agent] ([ID])
GO
ALTER TABLE [dbo].[ProductSale] CHECK CONSTRAINT [FK_ProductSale_Agent]
GO
ALTER TABLE [dbo].[ProductSale]  WITH CHECK ADD  CONSTRAINT [FK_ProductSale_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductSale] CHECK CONSTRAINT [FK_ProductSale_Product]
GO
ALTER TABLE [dbo].[Shop]  WITH CHECK ADD  CONSTRAINT [FK_Shop_Agent] FOREIGN KEY([AgentID])
REFERENCES [dbo].[Agent] ([ID])
GO
ALTER TABLE [dbo].[Shop] CHECK CONSTRAINT [FK_Shop_Agent]
GO
