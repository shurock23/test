USE [master]
GO
/****** Object:  Database [Inventory]    Script Date: 11/10/2019 00:00:49 ******/
CREATE DATABASE [Inventory] ON  PRIMARY 
( NAME = N'Inventory', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Inventory.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Inventory_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Inventory_log.LDF' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Inventory] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Inventory].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Inventory] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Inventory] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Inventory] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Inventory] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Inventory] SET ARITHABORT OFF
GO
ALTER DATABASE [Inventory] SET AUTO_CLOSE ON
GO
ALTER DATABASE [Inventory] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Inventory] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Inventory] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Inventory] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Inventory] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Inventory] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Inventory] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Inventory] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Inventory] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Inventory] SET  ENABLE_BROKER
GO
ALTER DATABASE [Inventory] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Inventory] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Inventory] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Inventory] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Inventory] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Inventory] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Inventory] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Inventory] SET  READ_WRITE
GO
ALTER DATABASE [Inventory] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Inventory] SET  MULTI_USER
GO
ALTER DATABASE [Inventory] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Inventory] SET DB_CHAINING OFF
GO
USE [Inventory]
GO
/****** Object:  Table [dbo].[tb_Users]    Script Date: 11/10/2019 00:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](50) NOT NULL,
	[Lastname] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[PositionId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Username] [varchar](50) NULL,
	[UserPassword] [varchar](50) NULL,
 CONSTRAINT [PK_tb_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tb_Users] ON
INSERT [dbo].[tb_Users] ([UserId], [Firstname], [Lastname], [Email], [PositionId], [IsActive], [Username], [UserPassword]) VALUES (2, N'John', N'Cabugao', N'john.cris.23@gmail.com', 1, 1, N'sa', N'sa')
SET IDENTITY_INSERT [dbo].[tb_Users] OFF
/****** Object:  Table [dbo].[tb_TransactionHeader]    Script Date: 11/10/2019 00:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_TransactionHeader](
	[TransactionHeaderId] [int] IDENTITY(1,1) NOT NULL,
	[TransactionCode] [varchar](50) NULL,
	[CustomerCode] [varchar](50) NULL,
	[ORNo] [varchar](50) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[TransactionDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[Discount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tb_TransactionHeader] PRIMARY KEY CLUSTERED 
(
	[TransactionHeaderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tb_TransactionHeader] ON
INSERT [dbo].[tb_TransactionHeader] ([TransactionHeaderId], [TransactionCode], [CustomerCode], [ORNo], [TotalAmount], [TransactionDate], [CreatedBy], [Discount]) VALUES (3, N'Transaction-1000001', N'CUST-10002', N'', CAST(500.00 AS Decimal(18, 2)), CAST(0x0000AAF3001B2FF8 AS DateTime), N'', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[tb_TransactionHeader] ([TransactionHeaderId], [TransactionCode], [CustomerCode], [ORNo], [TotalAmount], [TransactionDate], [CreatedBy], [Discount]) VALUES (4, N'Transaction-1000002', N'CUST-10001', N'112', CAST(500.00 AS Decimal(18, 2)), CAST(0x0000AAF3001F8747 AS DateTime), N'', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[tb_TransactionHeader] ([TransactionHeaderId], [TransactionCode], [CustomerCode], [ORNo], [TotalAmount], [TransactionDate], [CreatedBy], [Discount]) VALUES (5, N'Transaction-1000003', N'CUST-10001', N'312312', CAST(1080.00 AS Decimal(18, 2)), CAST(0x0000AAF300C4EE05 AS DateTime), N'', CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[tb_TransactionHeader] ([TransactionHeaderId], [TransactionCode], [CustomerCode], [ORNo], [TotalAmount], [TransactionDate], [CreatedBy], [Discount]) VALUES (6, N'Transaction-1000004', N'CUST-10002', N'12321', CAST(380.00 AS Decimal(18, 2)), CAST(0x0000AAF300C73F01 AS DateTime), N'', CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[tb_TransactionHeader] ([TransactionHeaderId], [TransactionCode], [CustomerCode], [ORNo], [TotalAmount], [TransactionDate], [CreatedBy], [Discount]) VALUES (7, N'Transaction-1000005', N'Cust-1001', N'321', CAST(1500.00 AS Decimal(18, 2)), CAST(0x0000AAF300F78777 AS DateTime), N'', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[tb_TransactionHeader] ([TransactionHeaderId], [TransactionCode], [CustomerCode], [ORNo], [TotalAmount], [TransactionDate], [CreatedBy], [Discount]) VALUES (8, N'Transaction-1000006', N'CUST-10001', N'32131', CAST(1200.00 AS Decimal(18, 2)), CAST(0x0000AB000101F9D6 AS DateTime), N'', CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[tb_TransactionHeader] OFF
/****** Object:  Table [dbo].[tb_TransactionDetail]    Script Date: 11/10/2019 00:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_TransactionDetail](
	[TransactionDetailId] [int] IDENTITY(1,1) NOT NULL,
	[ItemCode] [varchar](20) NULL,
	[TransactionHeaderId] [int] NULL,
	[OrderQty] [int] NULL,
 CONSTRAINT [PK_tb_TransactionDetail] PRIMARY KEY CLUSTERED 
(
	[TransactionDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tb_TransactionDetail] ON
INSERT [dbo].[tb_TransactionDetail] ([TransactionDetailId], [ItemCode], [TransactionHeaderId], [OrderQty]) VALUES (1, N'ITEM-10001', 4, 1)
INSERT [dbo].[tb_TransactionDetail] ([TransactionDetailId], [ItemCode], [TransactionHeaderId], [OrderQty]) VALUES (2, N'ITEM-10001', 5, 2)
INSERT [dbo].[tb_TransactionDetail] ([TransactionDetailId], [ItemCode], [TransactionHeaderId], [OrderQty]) VALUES (3, N'ITEM-10002', 5, 1)
INSERT [dbo].[tb_TransactionDetail] ([TransactionDetailId], [ItemCode], [TransactionHeaderId], [OrderQty]) VALUES (4, N'ITEM-10002', 6, 1)
INSERT [dbo].[tb_TransactionDetail] ([TransactionDetailId], [ItemCode], [TransactionHeaderId], [OrderQty]) VALUES (5, N'ITEM-10001', 7, 3)
INSERT [dbo].[tb_TransactionDetail] ([TransactionDetailId], [ItemCode], [TransactionHeaderId], [OrderQty]) VALUES (6, N'ITEM-10003', 8, 12)
SET IDENTITY_INSERT [dbo].[tb_TransactionDetail] OFF
/****** Object:  Table [dbo].[tb_PaymentType]    Script Date: 11/10/2019 00:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_PaymentType](
	[PaymentTypeId] [int] IDENTITY(1,1) NOT NULL,
	[PaymentName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_tb_PaymentType] PRIMARY KEY CLUSTERED 
(
	[PaymentTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_ItemOR]    Script Date: 11/10/2019 00:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_ItemOR](
	[ItemORId] [int] IDENTITY(1,1) NOT NULL,
	[ItemCode] [varchar](20) NULL,
	[ReStockQuantity] [int] NULL,
	[OrNo] [varchar](20) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_tb_ItemOR] PRIMARY KEY CLUSTERED 
(
	[ItemORId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tb_ItemOR] ON
INSERT [dbo].[tb_ItemOR] ([ItemORId], [ItemCode], [ReStockQuantity], [OrNo], [CreatedBy], [CreatedDate]) VALUES (1, N'ITEM-10001', 2, N'ORNO123', N'Admin', CAST(0x0000AADE000A4EB8 AS DateTime))
INSERT [dbo].[tb_ItemOR] ([ItemORId], [ItemCode], [ReStockQuantity], [OrNo], [CreatedBy], [CreatedDate]) VALUES (2, N'ITEM-10001', 999, N'321312', N'Admin', CAST(0x0000AAF9017521E1 AS DateTime))
INSERT [dbo].[tb_ItemOR] ([ItemORId], [ItemCode], [ReStockQuantity], [OrNo], [CreatedBy], [CreatedDate]) VALUES (3, N'ITEM-10002', 100, N'321321', N'Admin', CAST(0x0000AAFA00926434 AS DateTime))
INSERT [dbo].[tb_ItemOR] ([ItemORId], [ItemCode], [ReStockQuantity], [OrNo], [CreatedBy], [CreatedDate]) VALUES (4, N'ITEM-10002', 2, N'1231234', N'Admin', CAST(0x0000AAFA009389DC AS DateTime))
INSERT [dbo].[tb_ItemOR] ([ItemORId], [ItemCode], [ReStockQuantity], [OrNo], [CreatedBy], [CreatedDate]) VALUES (5, N'ITEM-10002', 1, N'312321', N'Admin', CAST(0x0000AAFA00941F58 AS DateTime))
INSERT [dbo].[tb_ItemOR] ([ItemORId], [ItemCode], [ReStockQuantity], [OrNo], [CreatedBy], [CreatedDate]) VALUES (6, N'ITEM-10002', 1, N'dsadsafs', N'Admin', CAST(0x0000AAFA00949DCA AS DateTime))
INSERT [dbo].[tb_ItemOR] ([ItemORId], [ItemCode], [ReStockQuantity], [OrNo], [CreatedBy], [CreatedDate]) VALUES (7, N'ITEM-10002', 1, N'321321', N'Admin', CAST(0x0000AAFA009532CF AS DateTime))
INSERT [dbo].[tb_ItemOR] ([ItemORId], [ItemCode], [ReStockQuantity], [OrNo], [CreatedBy], [CreatedDate]) VALUES (8, N'ITEM-10002', 1, N'876876', N'Admin', CAST(0x0000AAFA009540F2 AS DateTime))
INSERT [dbo].[tb_ItemOR] ([ItemORId], [ItemCode], [ReStockQuantity], [OrNo], [CreatedBy], [CreatedDate]) VALUES (9, N'ITEM-10002', 1, N'676876', N'Admin', CAST(0x0000AAFA0095F563 AS DateTime))
INSERT [dbo].[tb_ItemOR] ([ItemORId], [ItemCode], [ReStockQuantity], [OrNo], [CreatedBy], [CreatedDate]) VALUES (10, N'ITEM-10002', 123, N'fsfdsfdsfds', N'Admin', CAST(0x0000AAFA0096518A AS DateTime))
INSERT [dbo].[tb_ItemOR] ([ItemORId], [ItemCode], [ReStockQuantity], [OrNo], [CreatedBy], [CreatedDate]) VALUES (11, N'ITEM-10002', 123, N'2321321', N'Admin', CAST(0x0000AAFA01609762 AS DateTime))
SET IDENTITY_INSERT [dbo].[tb_ItemOR] OFF
/****** Object:  Table [dbo].[tb_CustomerPayment]    Script Date: 11/10/2019 00:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_CustomerPayment](
	[CustomerPaymentId] [int] IDENTITY(1,1) NOT NULL,
	[TransactionHeaderId] [int] NULL,
	[CustomerCode] [varchar](50) NULL,
	[AmountPaid] [decimal](18, 2) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[PaymentType] [varchar](50) NULL,
	[Cheque] [varchar](50) NULL,
 CONSTRAINT [PK_tb_CustomerPayment] PRIMARY KEY CLUSTERED 
(
	[CustomerPaymentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tb_CustomerPayment] ON
INSERT [dbo].[tb_CustomerPayment] ([CustomerPaymentId], [TransactionHeaderId], [CustomerCode], [AmountPaid], [CreatedBy], [CreatedDate], [PaymentType], [Cheque]) VALUES (1, 4, N'CUST-10001', CAST(200.00 AS Decimal(18, 2)), N'', CAST(0x0000AAF30021C6FC AS DateTime), NULL, NULL)
INSERT [dbo].[tb_CustomerPayment] ([CustomerPaymentId], [TransactionHeaderId], [CustomerCode], [AmountPaid], [CreatedBy], [CreatedDate], [PaymentType], [Cheque]) VALUES (2, 5, N'CUST-10001', CAST(1080.00 AS Decimal(18, 2)), N'', CAST(0x0000AAF300C4FB0E AS DateTime), NULL, NULL)
INSERT [dbo].[tb_CustomerPayment] ([CustomerPaymentId], [TransactionHeaderId], [CustomerCode], [AmountPaid], [CreatedBy], [CreatedDate], [PaymentType], [Cheque]) VALUES (3, 6, N'CUST-10002', CAST(1231.00 AS Decimal(18, 2)), N'', CAST(0x0000AAF300C73F10 AS DateTime), NULL, NULL)
INSERT [dbo].[tb_CustomerPayment] ([CustomerPaymentId], [TransactionHeaderId], [CustomerCode], [AmountPaid], [CreatedBy], [CreatedDate], [PaymentType], [Cheque]) VALUES (4, 4, N'CUST-10001', CAST(300.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[tb_CustomerPayment] ([CustomerPaymentId], [TransactionHeaderId], [CustomerCode], [AmountPaid], [CreatedBy], [CreatedDate], [PaymentType], [Cheque]) VALUES (5, 7, N'CUST-10001', CAST(500.00 AS Decimal(18, 2)), N'john', CAST(0x0000AAF300F78792 AS DateTime), N'', NULL)
INSERT [dbo].[tb_CustomerPayment] ([CustomerPaymentId], [TransactionHeaderId], [CustomerCode], [AmountPaid], [CreatedBy], [CreatedDate], [PaymentType], [Cheque]) VALUES (6, 4, N'CUST-10001', CAST(100.00 AS Decimal(18, 2)), N'john', CAST(0x0000AAF9016C58F8 AS DateTime), N'Cash', NULL)
INSERT [dbo].[tb_CustomerPayment] ([CustomerPaymentId], [TransactionHeaderId], [CustomerCode], [AmountPaid], [CreatedBy], [CreatedDate], [PaymentType], [Cheque]) VALUES (7, 7, N'CUST-10001', CAST(100.00 AS Decimal(18, 2)), N'john', CAST(0x0000AAF9016FBD42 AS DateTime), N'Cash', NULL)
INSERT [dbo].[tb_CustomerPayment] ([CustomerPaymentId], [TransactionHeaderId], [CustomerCode], [AmountPaid], [CreatedBy], [CreatedDate], [PaymentType], [Cheque]) VALUES (8, 7, N'CUST-10001', CAST(400.00 AS Decimal(18, 2)), N'john', CAST(0x0000AAF901718102 AS DateTime), N'Cash', N'')
INSERT [dbo].[tb_CustomerPayment] ([CustomerPaymentId], [TransactionHeaderId], [CustomerCode], [AmountPaid], [CreatedBy], [CreatedDate], [PaymentType], [Cheque]) VALUES (9, 8, N'CUST-10001', CAST(1200.00 AS Decimal(18, 2)), N'sa', CAST(0x0000AB000101FA17 AS DateTime), N'Cash', N'')
SET IDENTITY_INSERT [dbo].[tb_CustomerPayment] OFF
/****** Object:  Table [dbo].[tb_Customer]    Script Date: 11/10/2019 00:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_Customer](
	[CustomerId] [varchar](50) NOT NULL,
	[CustomerCode] [varchar](50) NOT NULL,
	[Name] [varchar](150) NULL,
	[ContactNumber] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tb_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tb_Customer] ([CustomerId], [CustomerCode], [Name], [ContactNumber], [IsActive]) VALUES (N'1', N'CUST-10001', N'john', N'123', 1)
INSERT [dbo].[tb_Customer] ([CustomerId], [CustomerCode], [Name], [ContactNumber], [IsActive]) VALUES (N'2', N'CUST-10002', N'test101', N'2321321', 1)
/****** Object:  Table [dbo].[tb_Category]    Script Date: 11/10/2019 00:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_Category](
	[ItemCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
	[IsActive] [nchar](10) NULL,
 CONSTRAINT [PK_tb_Category] PRIMARY KEY CLUSTERED 
(
	[ItemCategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AuditTrail]    Script Date: 11/10/2019 00:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AuditTrail](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Module] [varchar](50) NULL,
	[Action] [varchar](50) NULL,
	[DateTime] [datetime] NULL,
	[OldValues] [varchar](50) NULL,
	[NewValues] [varchar](50) NULL,
 CONSTRAINT [PK_AuditTrail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AuditTrail] ON
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (1, N'sa', N'Login Form', N'Login', CAST(0x0000AAFA01137B5A AS DateTime), NULL, NULL)
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (2, N'sa', N'Login Form', N'Login', CAST(0x0000AAFA0156184F AS DateTime), N'', N'')
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (3, N'sa', N'Login Form', N'Login', CAST(0x0000AAFA015B5BF3 AS DateTime), N'', N'')
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (4, N'sa', N'Login Form', N'Login', CAST(0x0000AAFA015C2120 AS DateTime), N'', N'')
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (5, N'sa', N'Login Form', N'Login', CAST(0x0000AAFA015C43FB AS DateTime), N'', N'')
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (6, N'sa', N'Login Form', N'Login', CAST(0x0000AAFA015C8DA8 AS DateTime), N'', N'')
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (7, N'sa', N'ReStock Form', N'Restock', CAST(0x0000AAFA01609768 AS DateTime), N'', N'123')
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (8, N'sa', N'ReStock Form', N'OrNo', CAST(0x0000AAFA01609768 AS DateTime), N'', N'2321321')
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (9, N'sa', N'Payment Form', N'Payment', CAST(0x0000AB000101FA18 AS DateTime), N'', N'Transaction-1000006')
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (10, N'sa', N'Login Form', N'Login', CAST(0x0000AB000181C3AE AS DateTime), N'', N'')
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (11, N'sa', N'Login Form', N'Login', CAST(0x0000AB0001832F8B AS DateTime), N'', N'')
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (12, N'sa', N'Login Form', N'Login', CAST(0x0000AB0001842772 AS DateTime), N'', N'')
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (13, N'sa', N'Report Form', N'Report', CAST(0x0000AB000184A95A AS DateTime), N'', N'john_cris_23@yahoo.com')
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (14, N'sa', N'Login Form', N'Login', CAST(0x0000AB00018569AB AS DateTime), N'', N'')
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (15, N'sa', N'Login Form', N'Login', CAST(0x0000AB000185C650 AS DateTime), N'', N'')
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (16, N'sa', N'Login Form', N'Login', CAST(0x0000AB000185D74B AS DateTime), N'', N'')
INSERT [dbo].[AuditTrail] ([ID], [Username], [Module], [Action], [DateTime], [OldValues], [NewValues]) VALUES (17, N'sa', N'Login Form', N'Login', CAST(0x0000AB000185FCFB AS DateTime), N'', N'')
SET IDENTITY_INSERT [dbo].[AuditTrail] OFF
/****** Object:  StoredProcedure [dbo].[getCustomerPayment]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getCustomerPayment]
@CustomerCode varchar(20)
AS
BEGIN

SELECT 
	--a.CustomerPaymentId AS [Payment ID],
	b.TransactionCode,
	b.ORNo,	
	convert(varchar,a.createddate,106) AS TransactionDate ,
	b.Discount,
	b.TotalAmount,
	a.AmountPaid,
	a.PaymentType,
	a.Cheque
	FROM dbo.tb_CustomerPayment a
	LEFT JOIN dbo.tb_TransactionHeader b ON a.transactionHeaderid = b.transactionHeaderid
	where a.customercode =@CustomerCode
	
END
GO
/****** Object:  StoredProcedure [dbo].[getCustomer]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getCustomer]
AS
BEGIN
Select CustomerCode as [Customer Code],Name as [Customer Name], Contactnumber as [Mobile No ]FROM dbo.tb_Customer
END
GO
/****** Object:  StoredProcedure [dbo].[getAuditTrailDateRange]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getAuditTrailDateRange]
@dateTo datetime,
@dateFrom datetime

AS
BEGIN
		
			SELECT ID,Username,Module,Action,DateTime,NewValues AS [Value] FROM AuditTrail 
			 where convert(varchar,datetime,101) between 
		convert(varchar,@dateTo,101) and 
		convert(varchar,@dateFrom,101)
		
END
GO
/****** Object:  StoredProcedure [dbo].[getAuditTrail]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getAuditTrail]
AS
BEGIN
		
		SELECT ID,Username,Module,Action,DateTime,NewValues AS [Value] FROM AuditTrail where 
		convert(varchar,datetime,101) between 
		convert(varchar,getdate(),101) and 
		convert(varchar,getdate(),101)
END
GO
/****** Object:  StoredProcedure [dbo].[rptCustomer]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rptCustomer]
AS
BEGIN
select 
CustomerCode as [Customer Code],
Name,
Contactnumber as [Contact Number]
  from dbo.tb_Customer
END


--select * from dbo.tb_CustomerPayment
GO
/****** Object:  StoredProcedure [dbo].[getTransCodeBalance]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getTransCodeBalance]
@CustomerCode varchar(20)
AS
BEGIN


SELECT *,(TotalAmount - TotalAmountPaid) AS RemainingBalance   FROM
(
select a.transactionheaderid,b.transactionCode,a.customercode,b.TotalAmount,SUM(AmountPaid) AS TotalAmountPaid 
FROM dbo.tb_CustomerPayment a
left join tb_TransactionHeader b On a.transactionheaderid = b.transactionheaderid
WHERE a.customercode = @CustomerCode
group by a.transactionheaderid ,a.customercode,b.transactionCode,b.totalAmount
)x


END
GO
/****** Object:  StoredProcedure [dbo].[getTransactionCode]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getTransactionCode]
AS
BEGIN
DECLARE @transactionCode varchar(50)

SET @transactionCode = (SELECT COUNT(*) FROM dbo.tb_TransactionHeader )
	
	IF @transactionCode = 0 
		BEGIN
		
		SELECT 'Transaction-1000001' AS TransactionCode
		END
		
	ELSE
		BEGIN
		set @transactionCode =(@transactionCode + 1000001)
		set @transactionCode ='Transaction-' + convert(varchar(50),@transactionCode)
		
		SELECT @transactionCode AS TransactionCode
		
		END
		
	


END
GO
/****** Object:  StoredProcedure [dbo].[getRemainingBalance]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getRemainingBalance]
@CustomerCode varchar(20),
@TransactionCode varchar(20)
AS
BEGIN


SELECT *,(TotalAmount - TotalAmountPaid) AS RemainingBalance   FROM
(
select a.transactionheaderid,b.transactionCode,a.customercode,b.TotalAmount,SUM(AmountPaid) AS TotalAmountPaid 
FROM dbo.tb_CustomerPayment a
left join tb_TransactionHeader b On a.transactionheaderid = b.transactionheaderid
WHERE a.customercode = @CustomerCode and b.transactionCode = @TransactionCode
group by a.transactionheaderid ,a.customercode,b.transactionCode,b.totalAmount
)x


END
GO
/****** Object:  StoredProcedure [dbo].[getOrNoDetails]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getOrNoDetails]
@ItemCode varchar(20)
AS
BEGIN
	SELECT ItemOrid as [Id], 
	Restockquantity as [ReStock Quantity],
	Orno as [OR No.],
	createdby AS [Created By], 
	convert(nvarchar, cast(createddate as datetime), 100)  AS [Created Date] 
	FROM dbo.tb_ItemOR where ItemCode = @ItemCode
END
GO
/****** Object:  StoredProcedure [dbo].[getLogin]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getLogin]
@username varchar(50),
@password varchar(50)

AS
BEGIN

SELECT * FROM [tb_users] where Username =@username and [UserPassword] =@password and IsActive =1
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[rptSalesReport]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rptSalesReport]

@Report varchar(20),
@datedaily datetime = NULL,
@month varchar(25)= NULL,
@year varchar(5) = NULL

AS
BEGIN
			IF @Report = 'Daily'
			BEGIN
			DECLARE @datestart datetime
			DECLARE @dateend datetime
			DECLARE @date datetime
			
			SET @date = SUBSTRING(convert(varchar(25), @datedaily, 120),0,11)

			SET @datestart = DATEADD(DAY,-1, SUBSTRING(convert(varchar(25), @date, 120),0,11) + ' 17:00' )
			SET @dateend =  SUBSTRING(convert(varchar(25), @date, 120),0,11) + ' 16:59' 


			SELECT TransactionCode as [Transaction Code],ORNO, convert(varchar,transactionDate,106) AS [Transaction Date],
			 TotalAmount as [Total Amount],CustomerCode as [Customer Code]
			FROM dbo.tb_TransactionHeader 
			where transactionDate >= @datestart and transactionDate <= @dateend 
			
			END
			
			
			ELSE IF @Report = 'Monthly'
			BEGIN
			SET @month = MONTH(@month + ' 1 2016')
			
			SELECT TransactionCode as [Transaction Code],ORNO, convert(varchar,transactionDate,106) AS [Transaction Date], 
			TotalAmount as [Total Amount],CustomerCode as [Customer Code]
			FROM dbo.tb_TransactionHeader 
			where MONTH(transactionDate) = @month  and YEAR(transactionDate) = @year 
			
		
			END
			
			ELSE IF @Report = 'Yearly'
			BEGIN
			SELECT TransactionCode as [Transaction Code],ORNO, convert(varchar,transactionDate,106) AS [Transaction Date], 
			TotalAmount as [Total Amount],CustomerCode as [Customer Code]
			FROM dbo.tb_TransactionHeader 
			where YEAR(transactionDate) = @year 
			
			END

END
GO
/****** Object:  Table [dbo].[tb_Payment]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_Payment](
	[PaymentId] [varchar](50) NOT NULL,
	[TransactionHeaderId] [int] NULL,
	[AmountPaid] [decimal](18, 2) NULL,
	[PaymentTypeId] [int] NULL,
	[CustomerId] [int] NULL,
 CONSTRAINT [PK_tb_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_Items]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_Items](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemCode] [varchar](50) NULL,
	[ItemName] [varchar](100) NULL,
	[ItemDescription] [varchar](150) NULL,
	[Price] [decimal](18, 2) NULL,
	[AvailableQuantity] [int] NULL,
	[StartQuantity] [int] NULL,
	[ItemCategoryId] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_tb_Items] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tb_Items] ON
INSERT [dbo].[tb_Items] ([ItemId], [ItemCode], [ItemName], [ItemDescription], [Price], [AvailableQuantity], [StartQuantity], [ItemCategoryId], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'ITEM-10001', N'dsa', N'', CAST(500.00 AS Decimal(18, 2)), 1001, NULL, NULL, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[tb_Items] ([ItemId], [ItemCode], [ItemName], [ItemDescription], [Price], [AvailableQuantity], [StartQuantity], [ItemCategoryId], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'ITEM-10002', N'ryjyuuyiy', N'', CAST(200.00 AS Decimal(18, 2)), 451, NULL, NULL, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[tb_Items] ([ItemId], [ItemCode], [ItemName], [ItemDescription], [Price], [AvailableQuantity], [StartQuantity], [ItemCategoryId], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'ITEM-10003', N'Screw', N'', CAST(100.00 AS Decimal(18, 2)), 88, NULL, NULL, 1, N'sa', CAST(0x0000AAFA009B849D AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tb_Items] OFF
/****** Object:  StoredProcedure [dbo].[UpdateAuditTrail]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAuditTrail]
@Username varchar(50),
@Module varchar(50),
@Action Varchar(50),
@OldValues varchar(50),
@NewValues varchar(50)
AS
BEGIN
		INSERT INTO AuditTrail(username,module,[Action],[datetime],oldvalues,newvalues) 
		values
		(@Username,@Module,@Action,getdate(),@OldValues,@NewValues)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomer]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCustomer]
@CustomerCode varchar(50)
AS
BEGIN
	
	UPDATE dbo.tb_Customer SET IsActive =0 where CustomerCode = @CustomerCode
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomerPayment]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCustomerPayment]
@TransactionId int,
@CustomerCode varchar(50),
@AmountPaid decimal(18,2),
@CreatedBy varchar(50),
@PaymentType varchar(20),
@Cheque varchar(50) = null
AS
BEGIN
	INSERT INTO dbo.tb_CustomerPayment
	VALUES
	(@TransactionId,@CustomerCode,@AmountPaid,@CreatedBy,getdate(),@PaymentType,@Cheque)
END


--select * from dbo.tb_CustomerPayment
GO
/****** Object:  StoredProcedure [dbo].[UpdateTransactionHeader]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateTransactionHeader]
@TransactionCode varchar(20),
@CustomerCode varchar(50),
@OrNo varchar(100),
@Discount decimal(18,2),
@Total decimal(18,2),
@CreatedBy varchar(100),
@GetId INT OUTPUT
AS
BEGIN
	INSERT INTO dbo.tb_TransactionHeader
	VALUES
	(@TransactionCode,@CustomerCode,@OrNo,@Total,GETDATE(),@CreatedBy,@Discount)
	
	Select @GetId = SCOPE_IDENTITY()
	SELECT @GetId AS TransactionId
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTransactionDetails]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateTransactionDetails]
@TransactionId int,
@ItemCode varchar(20),
@OrderQty int


AS
BEGIN
	INSERT INTO dbo.tb_TransactionDetail
	VALUES
	(@ItemCode,@TransactionId,@OrderQty)
	
	
	UPDATE dbo.tb_Items SET AvailableQuantity = AvailableQuantity - @OrderQty
	WHERE ItemCode = @ItemCode
	
	

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStocks]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStocks]
@ItemCode varchar(20),
@Stock int,
@OrNo varchar(50)
AS
BEGIN
	Update dbo.tb_Items SET AvailableQuantity = AvailableQuantity + @Stock
	WHERE ItemCode = @ItemCode
	
	INSERT INTO dbo.tb_ItemOR 
	VALUES
	(@ItemCode,@Stock,@OrNo,'Admin',getdate())
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateInventory]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateInventory]

@ItemCode varchar(50),
@ItemName varchar(50),
@Stock int,
@Price decimal = NULL,
@ItemDescription varchar(150),
@Createdby varchar(50)

AS
BEGIN

DECLARE @itemcount int
DECLARE @itemID varchar(50)

	IF EXISTS(SELECT itemcode FROM tb_Items where ItemCode = @ItemCode)
		BEGIN
		UPDATE 	tb_Items SET ItemName =@ItemName ,AvailableQuantity =@Stock, [ItemDescription] = @ItemDescription,
				modifiedby = @Createdby , modifieddate = getdate()
		WHERE ItemCode = @ItemCode
		END 

	ELSE
	BEGIN

	SET @itemcount = (SELECT COUNT(*) FROM tb_Items )
	
	IF @itemcount = 0 
		BEGIN
		INSERT tb_Items 
		(itemcode,itemname,AvailableQuantity,price,[ItemDescription],Isactive,createdby,createddate)
		values
		('ITEM-10001',@ItemName,@Stock,@Price,@ItemDescription,1,@Createdby ,getdate())
		END
		
	ELSE
		BEGIN
		set @itemcount =(@itemcount + 10001)
		set @itemID ='ITEM-' + convert(varchar(50),@itemcount)
		
		INSERT tb_Items 
		(itemcode,itemname,AvailableQuantity,price,[ItemDescription],Isactive,createdby,createddate)
		values
		(@itemID,@ItemName,@Stock,@Price,@ItemDescription,1,@Createdby ,getdate())
		
		END
		
	END
	
		
		
		
		

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCustomer]

@CustomerCode varchar(50),
@CustomerName varchar(50),
@MobileNo varchar(20)


AS
BEGIN

DECLARE @customercount int
DECLARE @customerID varchar(50)

	IF EXISTS(SELECT CustomerCode FROM tb_Customer where CustomerCode = @CustomerCode)
		BEGIN
		UPDATE 	tb_Customer SET Name =@CustomerName ,ContactNumber =@MobileNo
		WHERE CustomerCode = @CustomerCode
		END 

	ELSE
	BEGIN

	SET @customercount = (SELECT COUNT(*) FROM tb_Items )
	
	IF @customercount = 0 
		BEGIN
		INSERT tb_Customer 
		(Customercode,Name,ContactNumber,Isactive)
		values
		('CUST-10001',@CustomerName,@MobileNo,1)
		END
		
	ELSE
		BEGIN
		set @customercount =(@customercount + 10001)
		set @customerID ='CUST-' + convert(varchar(50),@customercount)
		
		INSERT tb_Customer 
		(Customercode,Name,ContactNumber,Isactive)
		values
		(@customerID,@CustomerName,@MobileNo,1)
		
		END
		
	END
	
		
		
		
		

END
GO
/****** Object:  StoredProcedure [dbo].[rptInventory]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rptInventory]
AS
BEGIN
SelecT 
ItemCode as[Item Code]
,ItemName as [Item Name]
,Price 
,AvailableQuantity as [Stock Quantity]
,CreatedBy 
,CreatedDate FROM dbo.tb_Items
where IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[getItemOrder]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getItemOrder]
@TransactionCode varchar(20)
AS
BEGIN
DECLARE @headerId int

SET @headerId = (SELECT transactionheaderid FROM tb_TransactionHeader where transactionCode = @TransactionCode)

select b.itemcode,b.itemname,b.price,Orderqty
	from dbo.tb_TransactionDetail a
	left join dbo.tb_Items b on a.itemcode= b.itemcode
	where a.transactionheaderid = @headerId
	
	
	END
GO
/****** Object:  StoredProcedure [dbo].[getInventoryCashier]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getInventoryCashier]


AS

BEGIN
	
	SELECT 
	0 as [CHK1],
	Itemcode as [Item Code],
	Itemname as [Item Name],
	AvailableQuantity as [Stock],
	Price as [Price] ,
	'' as [Order] 
	FROM tb_Items where IsActive =1 order by itemcode ASC

END
GO
/****** Object:  StoredProcedure [dbo].[getInventory]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getInventory]


AS

BEGIN
	
	SELECT Itemcode as [Item Code],
	Itemname as [Item Name],
	AvailableQuantity as [Stock],
	Price as [Price],
	Createdby as [Created By],
	convert(nvarchar, cast(createddate as datetime), 100)  AS [Created Date] 
	FROM tb_Items where IsActive =1 order by itemcode ASC




END
GO
/****** Object:  StoredProcedure [dbo].[DeleteItem]    Script Date: 11/10/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteItem]
@ItemCode varchar(50)
AS
BEGIN
	
	UPDATE dbo.tb_Items SET IsActive =0 where ItemCode = @ItemCode
END
GO
/****** Object:  ForeignKey [FK_tb_ItemOR_tb_ItemOR]    Script Date: 11/10/2019 00:00:53 ******/
ALTER TABLE [dbo].[tb_ItemOR]  WITH CHECK ADD  CONSTRAINT [FK_tb_ItemOR_tb_ItemOR] FOREIGN KEY([ItemORId])
REFERENCES [dbo].[tb_ItemOR] ([ItemORId])
GO
ALTER TABLE [dbo].[tb_ItemOR] CHECK CONSTRAINT [FK_tb_ItemOR_tb_ItemOR]
GO
/****** Object:  ForeignKey [FK_tb_Payment_tb_PaymentType]    Script Date: 11/10/2019 00:01:08 ******/
ALTER TABLE [dbo].[tb_Payment]  WITH CHECK ADD  CONSTRAINT [FK_tb_Payment_tb_PaymentType] FOREIGN KEY([PaymentTypeId])
REFERENCES [dbo].[tb_PaymentType] ([PaymentTypeId])
GO
ALTER TABLE [dbo].[tb_Payment] CHECK CONSTRAINT [FK_tb_Payment_tb_PaymentType]
GO
/****** Object:  ForeignKey [FK_tb_Payment_tb_TransactionHeader]    Script Date: 11/10/2019 00:01:08 ******/
ALTER TABLE [dbo].[tb_Payment]  WITH CHECK ADD  CONSTRAINT [FK_tb_Payment_tb_TransactionHeader] FOREIGN KEY([TransactionHeaderId])
REFERENCES [dbo].[tb_TransactionHeader] ([TransactionHeaderId])
GO
ALTER TABLE [dbo].[tb_Payment] CHECK CONSTRAINT [FK_tb_Payment_tb_TransactionHeader]
GO
/****** Object:  ForeignKey [FK_tb_Items_tb_Category]    Script Date: 11/10/2019 00:01:08 ******/
ALTER TABLE [dbo].[tb_Items]  WITH CHECK ADD  CONSTRAINT [FK_tb_Items_tb_Category] FOREIGN KEY([ItemCategoryId])
REFERENCES [dbo].[tb_Category] ([ItemCategoryId])
GO
ALTER TABLE [dbo].[tb_Items] CHECK CONSTRAINT [FK_tb_Items_tb_Category]
GO
