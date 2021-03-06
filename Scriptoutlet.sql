USE [outlet]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProduct](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](max) NULL,
	[SalesPrice] [decimal](18, 0) NULL,
	[Uom] [int] NULL,
	[Cost] [decimal](18, 0) NULL,
	[Quantity] [int] NULL,
	[BrandID] [int] NULL,
	[CategoryID] [int] NULL,
	[SubCatID] [int] NULL,
	[GenderID] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[ProductDetails] [nvarchar](max) NULL,
	[MaterialCare] [nvarchar](max) NULL,
	[FreeDelivery] [int] NULL,
	[VendorID] [int] NULL,
 CONSTRAINT [PK_tblProduct] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblProduct] ON
INSERT [dbo].[tblProduct] ([ProductId], [ProductName], [SalesPrice], [Uom], [Cost], [Quantity], [BrandID], [CategoryID], [SubCatID], [GenderID], [Description], [ProductDetails], [MaterialCare], [FreeDelivery], [VendorID]) VALUES (36, N'Casual Milano Shirt in R-Blue', CAST(3290 AS Decimal(18, 0)), 18, CAST(2500 AS Decimal(18, 0)), NULL, 1, 1, 1, 1, N'....', N'abcd', N'...', 0, 1)
INSERT [dbo].[tblProduct] ([ProductId], [ProductName], [SalesPrice], [Uom], [Cost], [Quantity], [BrandID], [CategoryID], [SubCatID], [GenderID], [Description], [ProductDetails], [MaterialCare], [FreeDelivery], [VendorID]) VALUES (37, N'Men Slim Fit Checkered Casual Shirt', CAST(3290 AS Decimal(18, 0)), 18, CAST(2500 AS Decimal(18, 0)), NULL, 2, 1, 1, 1, N'Fabric: 100% Selected Cotton', N'  Shirt Type: Casual  Country Origin: UK  Sleeves: Long Sleeves With Adjustable Button Cuffs  Collars Type: Button Down Collar  Fit: Slim Fit', N'...', 0, 1)
SET IDENTITY_INSERT [dbo].[tblProduct] OFF
/****** Object:  Table [dbo].[tblPODetail]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPODetail](
	[PODetID] [int] IDENTITY(1,1) NOT NULL,
	[POID] [int] NULL,
	[PID] [int] NULL,
	[SizeID] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tblPODetail] PRIMARY KEY CLUSTERED 
(
	[PODetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblPODetail] ON
INSERT [dbo].[tblPODetail] ([PODetID], [POID], [PID], [SizeID], [Quantity], [Price]) VALUES (72, 69, 36, 2, 1, CAST(2500 AS Decimal(18, 0)))
INSERT [dbo].[tblPODetail] ([PODetID], [POID], [PID], [SizeID], [Quantity], [Price]) VALUES (73, 69, 37, 4, 2, CAST(5000 AS Decimal(18, 0)))
INSERT [dbo].[tblPODetail] ([PODetID], [POID], [PID], [SizeID], [Quantity], [Price]) VALUES (74, 70, 36, 2, 1, CAST(2500 AS Decimal(18, 0)))
INSERT [dbo].[tblPODetail] ([PODetID], [POID], [PID], [SizeID], [Quantity], [Price]) VALUES (75, 70, 37, 3, 2, CAST(5000 AS Decimal(18, 0)))
INSERT [dbo].[tblPODetail] ([PODetID], [POID], [PID], [SizeID], [Quantity], [Price]) VALUES (76, 70, 37, 4, 2, CAST(5000 AS Decimal(18, 0)))
INSERT [dbo].[tblPODetail] ([PODetID], [POID], [PID], [SizeID], [Quantity], [Price]) VALUES (77, 71, 36, 2, 1, CAST(2500 AS Decimal(18, 0)))
INSERT [dbo].[tblPODetail] ([PODetID], [POID], [PID], [SizeID], [Quantity], [Price]) VALUES (78, 71, 37, 3, 2, CAST(5000 AS Decimal(18, 0)))
INSERT [dbo].[tblPODetail] ([PODetID], [POID], [PID], [SizeID], [Quantity], [Price]) VALUES (79, 71, 36, 2, 1, CAST(2500 AS Decimal(18, 0)))
INSERT [dbo].[tblPODetail] ([PODetID], [POID], [PID], [SizeID], [Quantity], [Price]) VALUES (80, 72, 36, 2, 1, CAST(2500 AS Decimal(18, 0)))
INSERT [dbo].[tblPODetail] ([PODetID], [POID], [PID], [SizeID], [Quantity], [Price]) VALUES (81, 72, 37, 3, 2, CAST(5000 AS Decimal(18, 0)))
INSERT [dbo].[tblPODetail] ([PODetID], [POID], [PID], [SizeID], [Quantity], [Price]) VALUES (82, 72, 37, 4, 1, CAST(2500 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[tblPODetail] OFF
/****** Object:  Table [dbo].[tblPO]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPO](
	[POID] [int] IDENTITY(1,1) NOT NULL,
	[SOref] [int] NULL,
	[PONo] [nvarchar](100) NULL,
	[Createdon] [datetime] NULL,
	[VendorID] [int] NULL,
	[Status] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblPO] PRIMARY KEY CLUSTERED 
(
	[POID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblPO] ON
INSERT [dbo].[tblPO] ([POID], [SOref], [PONo], [Createdon], [VendorID], [Status]) VALUES (69, 66, N'PO-0001', CAST(0x0000AD6E00BAFD18 AS DateTime), 1, N'Received')
INSERT [dbo].[tblPO] ([POID], [SOref], [PONo], [Createdon], [VendorID], [Status]) VALUES (70, 67, N'PO-0002', CAST(0x0000AD6F0129CF65 AS DateTime), 1, N'To Receive')
INSERT [dbo].[tblPO] ([POID], [SOref], [PONo], [Createdon], [VendorID], [Status]) VALUES (71, 68, N'PO-0003', CAST(0x0000AD6F012A315E AS DateTime), 1, N'To Receive')
INSERT [dbo].[tblPO] ([POID], [SOref], [PONo], [Createdon], [VendorID], [Status]) VALUES (72, 69, N'PO-0004', CAST(0x0000AD6F018A1238 AS DateTime), 1, N'To Receive')
SET IDENTITY_INSERT [dbo].[tblPO] OFF
/****** Object:  Table [dbo].[tblPay]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPay](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[SOID] [int] NULL,
	[TotalAmount] [money] NULL,
	[CreditCardNumber] [nvarchar](max) NULL,
	[DebitCardNumber] [nvarchar](max) NULL,
	[PaymentType] [nvarchar](100) NULL,
	[DeliveryAddress] [nvarchar](max) NULL,
	[Status] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblPay] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblPay] ON
INSERT [dbo].[tblPay] ([PaymentId], [SOID], [TotalAmount], [CreditCardNumber], [DebitCardNumber], [PaymentType], [DeliveryAddress], [Status]) VALUES (35, 66, 23030.0000, N'', N'', N'Cash on Delivery', N'...', N'Paid')
INSERT [dbo].[tblPay] ([PaymentId], [SOID], [TotalAmount], [CreditCardNumber], [DebitCardNumber], [PaymentType], [DeliveryAddress], [Status]) VALUES (36, 67, 19740.0000, N'', N'', N'Cash on Delivery', N'...', N'Paid')
INSERT [dbo].[tblPay] ([PaymentId], [SOID], [TotalAmount], [CreditCardNumber], [DebitCardNumber], [PaymentType], [DeliveryAddress], [Status]) VALUES (37, 68, 3290.0000, N'', N'', N'Cash on Delivery', N'...', N'Paid')
INSERT [dbo].[tblPay] ([PaymentId], [SOID], [TotalAmount], [CreditCardNumber], [DebitCardNumber], [PaymentType], [DeliveryAddress], [Status]) VALUES (38, 69, 9870.0000, N'', N'', N'Cash on Delivery', N'....', N'Paid')
SET IDENTITY_INSERT [dbo].[tblPay] OFF
/****** Object:  Table [dbo].[tblLeads]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLeads](
	[LeadId] [int] IDENTITY(1,1) NOT NULL,
	[CampaignId] [int] NULL,
	[UserId] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](100) NULL,
	[LeadSource] [nvarchar](50) NULL,
	[ContactNo] [nvarchar](200) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblLeads] PRIMARY KEY CLUSTERED 
(
	[LeadId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblLeads] ON
INSERT [dbo].[tblLeads] ([LeadId], [CampaignId], [UserId], [Name], [Address], [Email], [LeadSource], [ContactNo], [Status]) VALUES (1, 1, 14, N'Company ABC', N'H#669, DOHS-1, Malir Cantt', N'owaismumtaz96@gmail.com', N'Company Contact', N'03003497300', N'Qualified')
INSERT [dbo].[tblLeads] ([LeadId], [CampaignId], [UserId], [Name], [Address], [Email], [LeadSource], [ContactNo], [Status]) VALUES (2, 1, 16, N'Wasim Akram', N'...', N'wasimakram@gmail.com', N'Website', N'03003497300', N'Pending')
SET IDENTITY_INSERT [dbo].[tblLeads] OFF
/****** Object:  Table [dbo].[tblGender]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGender](
	[GenderID] [int] IDENTITY(1,1) NOT NULL,
	[GenderName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[GenderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblGender] ON
INSERT [dbo].[tblGender] ([GenderID], [GenderName]) VALUES (1, N'Men')
INSERT [dbo].[tblGender] ([GenderID], [GenderName]) VALUES (2, N'Women')
SET IDENTITY_INSERT [dbo].[tblGender] OFF
/****** Object:  Table [dbo].[tblecommLogin]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblecommLogin](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](500) NULL,
	[Password] [varchar](500) NULL,
	[Email] [varchar](max) NULL,
	[FullName] [varchar](max) NULL,
	[isAdmin] [bit] NULL,
 CONSTRAINT [PK_tblecommLogin] PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblecommLogin] ON
INSERT [dbo].[tblecommLogin] ([LoginId], [UserName], [Password], [Email], [FullName], [isAdmin]) VALUES (3, N'admin', N'12345', N'onlineoutletshopping2021@gmail.com', N'Faizan Khan', 1)
INSERT [dbo].[tblecommLogin] ([LoginId], [UserName], [Password], [Email], [FullName], [isAdmin]) VALUES (17, N'Faizan Khan', N'12345', N'onlineoutletshopping2021@gmail.com', N'Faizan', 0)
SET IDENTITY_INSERT [dbo].[tblecommLogin] OFF
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblCustomer] ON
INSERT [dbo].[tblCustomer] ([CustomerId], [UserId]) VALUES (1, 14)
SET IDENTITY_INSERT [dbo].[tblCustomer] OFF
/****** Object:  Table [dbo].[tblContacts]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblContacts](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[LeadId] [int] NULL,
 CONSTRAINT [PK_tblContacts] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblContacts] ON
INSERT [dbo].[tblContacts] ([ContactId], [LeadId]) VALUES (5, 1)
SET IDENTITY_INSERT [dbo].[tblContacts] OFF
/****** Object:  Table [dbo].[tblCode]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblCode] ON
INSERT [dbo].[tblCode] ([Id], [Code]) VALUES (1, N'DMxf_|d#p&zB')
SET IDENTITY_INSERT [dbo].[tblCode] OFF
/****** Object:  Table [dbo].[tblCategory]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[CatID] [int] IDENTITY(1,1) NOT NULL,
	[CatName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[CatID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblCategory] ON
INSERT [dbo].[tblCategory] ([CatID], [CatName]) VALUES (1, N'Shirts')
INSERT [dbo].[tblCategory] ([CatID], [CatName]) VALUES (2, N'Pants')
SET IDENTITY_INSERT [dbo].[tblCategory] OFF
/****** Object:  Table [dbo].[tblCampaigns]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCampaigns](
	[CampaignId] [int] IDENTITY(1,1) NOT NULL,
	[CampaignName] [varchar](max) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[ExpectedRevenue] [decimal](18, 0) NULL,
	[Status] [varchar](100) NULL,
 CONSTRAINT [PK_tblCampaigns] PRIMARY KEY CLUSTERED 
(
	[CampaignId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblCampaigns] ON
INSERT [dbo].[tblCampaigns] ([CampaignId], [CampaignName], [StartDate], [EndDate], [ExpectedRevenue], [Status]) VALUES (1, N'Campaign New1', CAST(0x0000AD6F00000000 AS DateTime), CAST(0x0000AD6F00000000 AS DateTime), CAST(20001 AS Decimal(18, 0)), N'Successfull')
SET IDENTITY_INSERT [dbo].[tblCampaigns] OFF
/****** Object:  Table [dbo].[tblBrands]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBrands](
	[BrandID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblBrands] ON
INSERT [dbo].[tblBrands] ([BrandID], [Name]) VALUES (1, N'Diners')
INSERT [dbo].[tblBrands] ([BrandID], [Name]) VALUES (2, N'Peter England')
SET IDENTITY_INSERT [dbo].[tblBrands] OFF
/****** Object:  Table [dbo].[tblStockMoveDetail]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStockMoveDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StockMoveID] [int] NULL,
	[PID] [int] NULL,
	[SizeID] [int] NULL,
	[Quantity] [int] NULL,
	[Status] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblStockMoveDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblStockMoveDetail] ON
INSERT [dbo].[tblStockMoveDetail] ([Id], [StockMoveID], [PID], [SizeID], [Quantity], [Status]) VALUES (6, 19, 37, 3, 1, N'Stock Picking')
INSERT [dbo].[tblStockMoveDetail] ([Id], [StockMoveID], [PID], [SizeID], [Quantity], [Status]) VALUES (7, 20, 36, 2, 1, N'Received')
INSERT [dbo].[tblStockMoveDetail] ([Id], [StockMoveID], [PID], [SizeID], [Quantity], [Status]) VALUES (8, 20, 37, 4, 2, N'Received')
INSERT [dbo].[tblStockMoveDetail] ([Id], [StockMoveID], [PID], [SizeID], [Quantity], [Status]) VALUES (9, 21, 36, 2, 1, N'Stock Picking')
INSERT [dbo].[tblStockMoveDetail] ([Id], [StockMoveID], [PID], [SizeID], [Quantity], [Status]) VALUES (10, 21, 37, 4, 2, N'Stock Picking')
INSERT [dbo].[tblStockMoveDetail] ([Id], [StockMoveID], [PID], [SizeID], [Quantity], [Status]) VALUES (11, 22, 37, 3, 1, N'Stock Picking')
SET IDENTITY_INSERT [dbo].[tblStockMoveDetail] OFF
/****** Object:  Table [dbo].[tblStockMove]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStockMove](
	[StockMoveID] [int] IDENTITY(1,1) NOT NULL,
	[DocNo] [nvarchar](100) NULL,
	[SOID] [int] NULL,
	[POID] [int] NULL,
	[MoveType] [nvarchar](100) NULL,
	[Status] [nvarchar](200) NULL,
	[GiCount] [int] NULL,
 CONSTRAINT [PK_tblStockMove] PRIMARY KEY CLUSTERED 
(
	[StockMoveID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblStockMove] ON
INSERT [dbo].[tblStockMove] ([StockMoveID], [DocNo], [SOID], [POID], [MoveType], [Status], [GiCount]) VALUES (19, N'GI-0001', 66, 0, N'Stock Out', N'Shipped', 1)
INSERT [dbo].[tblStockMove] ([StockMoveID], [DocNo], [SOID], [POID], [MoveType], [Status], [GiCount]) VALUES (20, N'GR-0001', 0, 69, N'Stock In', N'Received', NULL)
INSERT [dbo].[tblStockMove] ([StockMoveID], [DocNo], [SOID], [POID], [MoveType], [Status], [GiCount]) VALUES (21, N'GI-0002', 66, 0, N'Stock Out', N'Shipped', 2)
INSERT [dbo].[tblStockMove] ([StockMoveID], [DocNo], [SOID], [POID], [MoveType], [Status], [GiCount]) VALUES (22, N'GI-0003', 69, 0, N'Stock Out', N'Stock Picking', 1)
SET IDENTITY_INSERT [dbo].[tblStockMove] OFF
/****** Object:  Table [dbo].[tblSODetail]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSODetail](
	[SOdetailID] [int] IDENTITY(1,1) NOT NULL,
	[SOID] [int] NULL,
	[PID] [int] NULL,
	[SizeID] [int] NULL,
	[Quantity] [int] NULL,
	[ScheduledDeliveryDate] [datetime] NULL,
	[DeliveryStatus] [nvarchar](100) NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tblSODetail] PRIMARY KEY CLUSTERED 
(
	[SOdetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblSODetail] ON
INSERT [dbo].[tblSODetail] ([SOdetailID], [SOID], [PID], [SizeID], [Quantity], [ScheduledDeliveryDate], [DeliveryStatus], [Price]) VALUES (117, 66, 36, 2, 1, CAST(0x0000AD7200000000 AS DateTime), N'Not Delivered', CAST(3290 AS Decimal(18, 0)))
INSERT [dbo].[tblSODetail] ([SOdetailID], [SOID], [PID], [SizeID], [Quantity], [ScheduledDeliveryDate], [DeliveryStatus], [Price]) VALUES (118, 66, 37, 3, 1, CAST(0x0000AD7000000000 AS DateTime), N'Not Delivered', CAST(3290 AS Decimal(18, 0)))
INSERT [dbo].[tblSODetail] ([SOdetailID], [SOID], [PID], [SizeID], [Quantity], [ScheduledDeliveryDate], [DeliveryStatus], [Price]) VALUES (119, 66, 37, 4, 2, CAST(0x0000AD7200000000 AS DateTime), N'Not Delivered', CAST(6580 AS Decimal(18, 0)))
INSERT [dbo].[tblSODetail] ([SOdetailID], [SOID], [PID], [SizeID], [Quantity], [ScheduledDeliveryDate], [DeliveryStatus], [Price]) VALUES (120, 67, 37, 3, 2, CAST(0x0000AD7300000000 AS DateTime), N'Not Delivered', CAST(6580 AS Decimal(18, 0)))
INSERT [dbo].[tblSODetail] ([SOdetailID], [SOID], [PID], [SizeID], [Quantity], [ScheduledDeliveryDate], [DeliveryStatus], [Price]) VALUES (121, 67, 37, 4, 2, CAST(0x0000AD7300000000 AS DateTime), N'Not Delivered', CAST(6580 AS Decimal(18, 0)))
INSERT [dbo].[tblSODetail] ([SOdetailID], [SOID], [PID], [SizeID], [Quantity], [ScheduledDeliveryDate], [DeliveryStatus], [Price]) VALUES (122, 68, 36, 2, 1, CAST(0x0000AD7300000000 AS DateTime), N'Not Delivered', CAST(3290 AS Decimal(18, 0)))
INSERT [dbo].[tblSODetail] ([SOdetailID], [SOID], [PID], [SizeID], [Quantity], [ScheduledDeliveryDate], [DeliveryStatus], [Price]) VALUES (123, 69, 37, 3, 1, CAST(0x0000AD7300000000 AS DateTime), N'Not Delivered', CAST(3290 AS Decimal(18, 0)))
INSERT [dbo].[tblSODetail] ([SOdetailID], [SOID], [PID], [SizeID], [Quantity], [ScheduledDeliveryDate], [DeliveryStatus], [Price]) VALUES (124, 69, 37, 4, 1, CAST(0x0000AD7300000000 AS DateTime), N'Not Delivered', CAST(3290 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[tblSODetail] OFF
/****** Object:  Table [dbo].[tblSO]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSO](
	[SOID] [int] IDENTITY(1,1) NOT NULL,
	[SONo] [nvarchar](max) NULL,
	[UserID] [int] NULL,
	[Createdon] [datetime] NULL,
	[POref] [int] NULL,
	[Status] [nvarchar](100) NULL,
	[CustomerType] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblSO] PRIMARY KEY CLUSTERED 
(
	[SOID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblSO] ON
INSERT [dbo].[tblSO] ([SOID], [SONo], [UserID], [Createdon], [POref], [Status], [CustomerType]) VALUES (66, N'SO-0001', 4, CAST(0x0000AD6E00BACE3E AS DateTime), 0, N'To Deliver', N'New')
INSERT [dbo].[tblSO] ([SOID], [SONo], [UserID], [Createdon], [POref], [Status], [CustomerType]) VALUES (67, N'SO-0002', 14, CAST(0x0000AD6F0129CEC2 AS DateTime), 0, N'To Deliver', N'New')
INSERT [dbo].[tblSO] ([SOID], [SONo], [UserID], [Createdon], [POref], [Status], [CustomerType]) VALUES (68, N'SO-0003', 14, CAST(0x0000AD6F012A3154 AS DateTime), 0, N'To Deliver', N'New')
INSERT [dbo].[tblSO] ([SOID], [SONo], [UserID], [Createdon], [POref], [Status], [CustomerType]) VALUES (69, N'SO-0004', 14, CAST(0x0000AD6F018A11CD AS DateTime), 0, N'To Deliver', N'New')
SET IDENTITY_INSERT [dbo].[tblSO] OFF
/****** Object:  Table [dbo].[tblVendorBill]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVendorBill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[POID] [int] NULL,
	[TotalAmount] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tblVendorBill] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVendor]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVendor](
	[VendorID] [int] IDENTITY(1,1) NOT NULL,
	[VendorName] [nvarchar](100) NULL,
	[Email] [nvarchar](max) NULL,
	[ContactNo] [nvarchar](200) NULL,
	[Address] [nvarchar](max) NULL,
	[DeliveryLeadtime] [int] NULL,
 CONSTRAINT [PK_tblVendor] PRIMARY KEY CLUSTERED 
(
	[VendorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblVendor] ON
INSERT [dbo].[tblVendor] ([VendorID], [VendorName], [Email], [ContactNo], [Address], [DeliveryLeadtime]) VALUES (1, N'Ahmed', N'owaismumtaz96@gmail.com', N'03003497300', N'H#669, DOHS-1, Malir Cantt', 2)
INSERT [dbo].[tblVendor] ([VendorID], [VendorName], [Email], [ContactNo], [Address], [DeliveryLeadtime]) VALUES (2, N'Bilal', N'owaismumtaz96@gmail.com', N'03003497300', N'H#669, DOHS-1, Malir Cantt', 2)
INSERT [dbo].[tblVendor] ([VendorID], [VendorName], [Email], [ContactNo], [Address], [DeliveryLeadtime]) VALUES (3, N'Kamran', N'owaismumtaz96@gmail.com', N'03003497300', N'H#669, DOHS-1, Malir Cantt', 2)
SET IDENTITY_INSERT [dbo].[tblVendor] OFF
/****** Object:  Table [dbo].[tblUom]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUom](
	[UomId] [int] IDENTITY(1,1) NOT NULL,
	[Unitofmeasure] [varchar](500) NULL,
 CONSTRAINT [PK_tblUom] PRIMARY KEY CLUSTERED 
(
	[UomId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblUom] ON
INSERT [dbo].[tblUom] ([UomId], [Unitofmeasure]) VALUES (1, N'Kg')
INSERT [dbo].[tblUom] ([UomId], [Unitofmeasure]) VALUES (15, N'Litres')
INSERT [dbo].[tblUom] ([UomId], [Unitofmeasure]) VALUES (18, N'Piece')
SET IDENTITY_INSERT [dbo].[tblUom] OFF
/****** Object:  Table [dbo].[tblProductImages]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProductImages](
	[PIMGID] [int] IDENTITY(1,1) NOT NULL,
	[PID] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[Extension] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[PIMGID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblProductImages] ON
INSERT [dbo].[tblProductImages] ([PIMGID], [PID], [Name], [Extension]) VALUES (16, 36, N'Casual Milano Shirt in R-Blue01', N'.jpg')
INSERT [dbo].[tblProductImages] ([PIMGID], [PID], [Name], [Extension]) VALUES (17, 36, N'Casual Milano Shirt in R-Blue02', N'.jpg')
INSERT [dbo].[tblProductImages] ([PIMGID], [PID], [Name], [Extension]) VALUES (18, 36, N'Casual Milano Shirt in R-Blue03', N'.jpg')
INSERT [dbo].[tblProductImages] ([PIMGID], [PID], [Name], [Extension]) VALUES (19, 37, N'Men Slim Fit Checkered Casual Shirt01', N'.jpeg')
INSERT [dbo].[tblProductImages] ([PIMGID], [PID], [Name], [Extension]) VALUES (20, 37, N'Men Slim Fit Checkered Casual Shirt02', N'.jpeg')
INSERT [dbo].[tblProductImages] ([PIMGID], [PID], [Name], [Extension]) VALUES (21, 37, N'Men Slim Fit Checkered Casual Shirt03', N'.jpeg')
SET IDENTITY_INSERT [dbo].[tblProductImages] OFF
/****** Object:  Table [dbo].[tblSubCategory]    Script Date: 07/25/2021 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSubCategory](
	[SubCatID] [int] IDENTITY(1,1) NOT NULL,
	[SubCatName] [nvarchar](max) NULL,
	[MainCatID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SubCatID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblSubCategory] ON
INSERT [dbo].[tblSubCategory] ([SubCatID], [SubCatName], [MainCatID]) VALUES (1, N'Casual Shirts', 1)
SET IDENTITY_INSERT [dbo].[tblSubCategory] OFF
/****** Object:  StoredProcedure [dbo].[procBindAllProducts]    Script Date: 07/25/2021 00:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[procBindAllProducts]
AS
select A.*,B.*,C.Name,A.Cost-A.SalesPrice as DiscAmount,B.Name as ImageName,C.Name as BrandName from tblProduct A
inner join tblBrands C on C.BrandID=A.BrandID
cross apply(
select top 1 * from tblProductImages B where B.PID=A.ProductId order by B.PID desc
)B
order by A.ProductId desc

Return 0
GO
/****** Object:  Table [dbo].[tblSizes]    Script Date: 07/25/2021 00:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSizes](
	[SizeID] [int] IDENTITY(1,1) NOT NULL,
	[SizeName] [nvarchar](100) NULL,
	[BrandID] [int] NULL,
	[CategoryID] [int] NULL,
	[SubCategoryID] [int] NULL,
	[GenderID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SizeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblSizes] ON
INSERT [dbo].[tblSizes] ([SizeID], [SizeName], [BrandID], [CategoryID], [SubCategoryID], [GenderID]) VALUES (1, N'Small', 1, 1, 1, 2)
INSERT [dbo].[tblSizes] ([SizeID], [SizeName], [BrandID], [CategoryID], [SubCategoryID], [GenderID]) VALUES (2, N'Medium', 1, 1, 1, 1)
INSERT [dbo].[tblSizes] ([SizeID], [SizeName], [BrandID], [CategoryID], [SubCategoryID], [GenderID]) VALUES (3, N'S', 2, 1, 1, 1)
INSERT [dbo].[tblSizes] ([SizeID], [SizeName], [BrandID], [CategoryID], [SubCategoryID], [GenderID]) VALUES (4, N'M', 2, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[tblSizes] OFF
/****** Object:  Table [dbo].[tblProductSizeQuantity]    Script Date: 07/25/2021 00:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProductSizeQuantity](
	[PrdSizeQuantID] [int] IDENTITY(1,1) NOT NULL,
	[PID] [int] NULL,
	[SizeID] [int] NULL,
	[Quantity] [int] NULL,
	[ReorderPoint] [int] NULL,
	[CustomerLeadTime] [int] NULL,
 CONSTRAINT [PK__tblProdu__DAB7F4F024927208] PRIMARY KEY CLUSTERED 
(
	[PrdSizeQuantID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblProductSizeQuantity] ON
INSERT [dbo].[tblProductSizeQuantity] ([PrdSizeQuantID], [PID], [SizeID], [Quantity], [ReorderPoint], [CustomerLeadTime]) VALUES (15, 36, 2, 8, 7, 2)
INSERT [dbo].[tblProductSizeQuantity] ([PrdSizeQuantID], [PID], [SizeID], [Quantity], [ReorderPoint], [CustomerLeadTime]) VALUES (16, 37, 3, 8, 7, 2)
INSERT [dbo].[tblProductSizeQuantity] ([PrdSizeQuantID], [PID], [SizeID], [Quantity], [ReorderPoint], [CustomerLeadTime]) VALUES (17, 37, 4, 8, 7, 2)
SET IDENTITY_INSERT [dbo].[tblProductSizeQuantity] OFF
/****** Object:  UserDefinedFunction [dbo].[getSizeName]    Script Date: 07/25/2021 00:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[getSizeName]

(
 @SizeID int
 )
 Returns Nvarchar(10)
 as 
 Begin
 Declare @SizeName nvarchar(10)
 select @SizeName=SizeName from tblSizes where SizeID=@SizeID
 RETURN @SizeName
 
 End
GO
/****** Object:  ForeignKey [FK_tblProductImages_TOProduct]    Script Date: 07/25/2021 00:40:27 ******/
ALTER TABLE [dbo].[tblProductImages]  WITH CHECK ADD  CONSTRAINT [FK_tblProductImages_TOProduct] FOREIGN KEY([PID])
REFERENCES [dbo].[tblProduct] ([ProductId])
GO
ALTER TABLE [dbo].[tblProductImages] CHECK CONSTRAINT [FK_tblProductImages_TOProduct]
GO
/****** Object:  ForeignKey [FK_tblSubCategory_tblCategory]    Script Date: 07/25/2021 00:40:27 ******/
ALTER TABLE [dbo].[tblSubCategory]  WITH CHECK ADD  CONSTRAINT [FK_tblSubCategory_tblCategory] FOREIGN KEY([MainCatID])
REFERENCES [dbo].[tblCategory] ([CatID])
GO
ALTER TABLE [dbo].[tblSubCategory] CHECK CONSTRAINT [FK_tblSubCategory_tblCategory]
GO
/****** Object:  ForeignKey [FK_tblSizes_ToBrand]    Script Date: 07/25/2021 00:41:20 ******/
ALTER TABLE [dbo].[tblSizes]  WITH CHECK ADD  CONSTRAINT [FK_tblSizes_ToBrand] FOREIGN KEY([BrandID])
REFERENCES [dbo].[tblBrands] ([BrandID])
GO
ALTER TABLE [dbo].[tblSizes] CHECK CONSTRAINT [FK_tblSizes_ToBrand]
GO
/****** Object:  ForeignKey [FK_tblSizes_ToCategory]    Script Date: 07/25/2021 00:41:20 ******/
ALTER TABLE [dbo].[tblSizes]  WITH CHECK ADD  CONSTRAINT [FK_tblSizes_ToCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[tblCategory] ([CatID])
GO
ALTER TABLE [dbo].[tblSizes] CHECK CONSTRAINT [FK_tblSizes_ToCategory]
GO
/****** Object:  ForeignKey [FK_tblSizes_TOGender]    Script Date: 07/25/2021 00:41:20 ******/
ALTER TABLE [dbo].[tblSizes]  WITH CHECK ADD  CONSTRAINT [FK_tblSizes_TOGender] FOREIGN KEY([GenderID])
REFERENCES [dbo].[tblGender] ([GenderID])
GO
ALTER TABLE [dbo].[tblSizes] CHECK CONSTRAINT [FK_tblSizes_TOGender]
GO
/****** Object:  ForeignKey [FK_tblSizes_ToSubCategory]    Script Date: 07/25/2021 00:41:20 ******/
ALTER TABLE [dbo].[tblSizes]  WITH CHECK ADD  CONSTRAINT [FK_tblSizes_ToSubCategory] FOREIGN KEY([SubCategoryID])
REFERENCES [dbo].[tblSubCategory] ([SubCatID])
GO
ALTER TABLE [dbo].[tblSizes] CHECK CONSTRAINT [FK_tblSizes_ToSubCategory]
GO
/****** Object:  ForeignKey [FK_tblProductSizeQty_TOProduct]    Script Date: 07/25/2021 00:41:20 ******/
ALTER TABLE [dbo].[tblProductSizeQuantity]  WITH CHECK ADD  CONSTRAINT [FK_tblProductSizeQty_TOProduct] FOREIGN KEY([PID])
REFERENCES [dbo].[tblProduct] ([ProductId])
GO
ALTER TABLE [dbo].[tblProductSizeQuantity] CHECK CONSTRAINT [FK_tblProductSizeQty_TOProduct]
GO
/****** Object:  ForeignKey [FK_tblProductSizeQty_TOSize]    Script Date: 07/25/2021 00:41:20 ******/
ALTER TABLE [dbo].[tblProductSizeQuantity]  WITH CHECK ADD  CONSTRAINT [FK_tblProductSizeQty_TOSize] FOREIGN KEY([SizeID])
REFERENCES [dbo].[tblSizes] ([SizeID])
GO
ALTER TABLE [dbo].[tblProductSizeQuantity] CHECK CONSTRAINT [FK_tblProductSizeQty_TOSize]
GO
