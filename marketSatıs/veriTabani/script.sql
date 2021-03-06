USE [master]
GO
/****** Object:  Database [Satis]    Script Date: 21.12.2019 23:41:51 ******/
CREATE DATABASE [Satis]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Satis', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.EDA1\MSSQL\DATA\Satis.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Satis_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.EDA1\MSSQL\DATA\Satis_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Satis] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Satis].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Satis] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Satis] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Satis] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Satis] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Satis] SET ARITHABORT OFF 
GO
ALTER DATABASE [Satis] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Satis] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Satis] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Satis] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Satis] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Satis] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Satis] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Satis] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Satis] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Satis] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Satis] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Satis] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Satis] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Satis] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Satis] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Satis] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Satis] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Satis] SET RECOVERY FULL 
GO
ALTER DATABASE [Satis] SET  MULTI_USER 
GO
ALTER DATABASE [Satis] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Satis] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Satis] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Satis] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Satis] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Satis] SET QUERY_STORE = OFF
GO
USE [Satis]
GO
/****** Object:  Table [dbo].[Cashier]    Script Date: 21.12.2019 23:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cashier](
	[cashierID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[surname] [nvarchar](20) NOT NULL,
	[tcNo] [nvarchar](11) NOT NULL,
	[gsm] [nvarchar](20) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[salary] [int] NOT NULL,
	[userName] [nvarchar](30) NOT NULL,
	[password] [nvarchar](30) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblKasiyer] PRIMARY KEY CLUSTERED 
(
	[cashierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 21.12.2019 23:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[categoryID] [int] IDENTITY(1,1) NOT NULL,
	[categoryName] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblKategori] PRIMARY KEY CLUSTERED 
(
	[categoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 21.12.2019 23:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[surname] [nvarchar](20) NOT NULL,
	[tcNo] [nvarchar](11) NOT NULL,
	[gsm] [nvarchar](20) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblMüsteri] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 21.12.2019 23:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[orderID] [int] IDENTITY(1,1) NOT NULL,
	[customerID] [int] NOT NULL,
	[cashierID] [int] NOT NULL,
	[orderDate] [datetime] NOT NULL,
	[totalPrice] [float] NOT NULL,
 CONSTRAINT [PK_TblSiparis] PRIMARY KEY CLUSTERED 
(
	[orderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 21.12.2019 23:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[orderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[orderID] [int] NOT NULL,
	[productID] [int] NOT NULL,
	[unitPrice] [float] NOT NULL,
	[count] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[orderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 21.12.2019 23:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[productID] [int] IDENTITY(1,1) NOT NULL,
	[supplierID] [int] NOT NULL,
	[categoryID] [int] NOT NULL,
	[productName] [nvarchar](30) NOT NULL,
	[unitPrice] [float] NOT NULL,
	[discount] [int] NOT NULL,
	[discontinued] [bit] NOT NULL,
	[dateOfAdded] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[stock] [int] NOT NULL,
 CONSTRAINT [PK_TblUrun] PRIMARY KEY CLUSTERED 
(
	[productID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 21.12.2019 23:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[stockID] [int] IDENTITY(1,1) NOT NULL,
	[productID] [int] NOT NULL,
	[count] [int] NOT NULL,
	[dateOfAdded] [datetime] NOT NULL,
 CONSTRAINT [PK_TblStok] PRIMARY KEY CLUSTERED 
(
	[stockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 21.12.2019 23:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[supplierID] [int] IDENTITY(1,1) NOT NULL,
	[companyName] [nvarchar](20) NOT NULL,
	[supplierNameSurname] [nvarchar](30) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[gsm] [nvarchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblSatici] PRIMARY KEY CLUSTERED 
(
	[supplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 21.12.2019 23:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](30) NOT NULL,
	[password] [nvarchar](30) NOT NULL,
	[userType] [int] NOT NULL,
 CONSTRAINT [PK_TblGiris] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cashier] ON 

INSERT [dbo].[Cashier] ([cashierID], [name], [surname], [tcNo], [gsm], [address], [salary], [userName], [password], [IsActive]) VALUES (5, N'busra', N'fasf', N'1111111111', N'(222) 222-2222', N'kartal', 2000, N'busra.cinar', N'1234', 1)
INSERT [dbo].[Cashier] ([cashierID], [name], [surname], [tcNo], [gsm], [address], [salary], [userName], [password], [IsActive]) VALUES (6, N'eda', N'al', N'1111', N'(111) 111-1111', N'kartal', 1000, N'eda', N'1', 1)
SET IDENTITY_INSERT [dbo].[Cashier] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([categoryID], [categoryName], [Description], [IsActive]) VALUES (1, N'ambalaj', N'kdjggf', 1)
INSERT [dbo].[Category] ([categoryID], [categoryName], [Description], [IsActive]) VALUES (2, N'gıda', N'fdsgh', 1)
INSERT [dbo].[Category] ([categoryID], [categoryName], [Description], [IsActive]) VALUES (3, N'içecek', N'ojgdsgj', 1)
INSERT [dbo].[Category] ([categoryID], [categoryName], [Description], [IsActive]) VALUES (4, N'bilgisayar', N'dfsg', 0)
INSERT [dbo].[Category] ([categoryID], [categoryName], [Description], [IsActive]) VALUES (5, N'manav', N'kdsj', 1)
INSERT [dbo].[Category] ([categoryID], [categoryName], [Description], [IsActive]) VALUES (6, N'kırtasiye', N'sg', 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [name], [surname], [tcNo], [gsm], [address], [IsActive]) VALUES (1, N'ab  müşterisi', N'abc', N'12345', N'(111) 111-1111', N'kadıköy', 1)
INSERT [dbo].[Customer] ([CustomerID], [name], [surname], [tcNo], [gsm], [address], [IsActive]) VALUES (3, N'esma', N'fgdefgd', N'1233', N'(111) 111-1111', N'kartal', 1)
INSERT [dbo].[Customer] ([CustomerID], [name], [surname], [tcNo], [gsm], [address], [IsActive]) VALUES (4, N'busra', N'cınar', N'1111111', N'(222) 222-2222', N'beşiktaş', 1)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([orderID], [customerID], [cashierID], [orderDate], [totalPrice]) VALUES (57, 4, 6, CAST(N'2019-12-20T00:10:19.487' AS DateTime), 675)
INSERT [dbo].[Order] ([orderID], [customerID], [cashierID], [orderDate], [totalPrice]) VALUES (58, 3, 6, CAST(N'2019-12-20T09:02:24.900' AS DateTime), 45)
INSERT [dbo].[Order] ([orderID], [customerID], [cashierID], [orderDate], [totalPrice]) VALUES (59, 3, 6, CAST(N'2019-12-21T22:33:50.570' AS DateTime), 25)
INSERT [dbo].[Order] ([orderID], [customerID], [cashierID], [orderDate], [totalPrice]) VALUES (60, 3, 6, CAST(N'2019-12-21T22:49:43.420' AS DateTime), 5)
INSERT [dbo].[Order] ([orderID], [customerID], [cashierID], [orderDate], [totalPrice]) VALUES (61, 3, 6, CAST(N'2019-12-21T23:07:06.540' AS DateTime), 130)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([orderDetailID], [orderID], [productID], [unitPrice], [count]) VALUES (98, 57, 2, 15, 5)
INSERT [dbo].[OrderDetail] ([orderDetailID], [orderID], [productID], [unitPrice], [count]) VALUES (99, 57, 9, 10, 10)
INSERT [dbo].[OrderDetail] ([orderDetailID], [orderID], [productID], [unitPrice], [count]) VALUES (100, 57, 10, 25, 10)
INSERT [dbo].[OrderDetail] ([orderDetailID], [orderID], [productID], [unitPrice], [count]) VALUES (101, 57, 11, 25, 10)
INSERT [dbo].[OrderDetail] ([orderDetailID], [orderID], [productID], [unitPrice], [count]) VALUES (102, 58, 9, 10, 2)
INSERT [dbo].[OrderDetail] ([orderDetailID], [orderID], [productID], [unitPrice], [count]) VALUES (103, 58, 5, 5, 5)
INSERT [dbo].[OrderDetail] ([orderDetailID], [orderID], [productID], [unitPrice], [count]) VALUES (104, 59, 9, 10, 2)
INSERT [dbo].[OrderDetail] ([orderDetailID], [orderID], [productID], [unitPrice], [count]) VALUES (105, 59, 5, 5, 1)
INSERT [dbo].[OrderDetail] ([orderDetailID], [orderID], [productID], [unitPrice], [count]) VALUES (106, 60, 5, 5, 1)
INSERT [dbo].[OrderDetail] ([orderDetailID], [orderID], [productID], [unitPrice], [count]) VALUES (107, 61, 5, 5, 1)
INSERT [dbo].[OrderDetail] ([orderDetailID], [orderID], [productID], [unitPrice], [count]) VALUES (108, 61, 10, 25, 5)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([productID], [supplierID], [categoryID], [productName], [unitPrice], [discount], [discontinued], [dateOfAdded], [IsActive], [stock]) VALUES (1, 5, 1, N'a ürünü', 10, 0, 0, CAST(N'2019-12-19T21:05:36.627' AS DateTime), 1, 0)
INSERT [dbo].[Product] ([productID], [supplierID], [categoryID], [productName], [unitPrice], [discount], [discontinued], [dateOfAdded], [IsActive], [stock]) VALUES (2, 5, 1, N'b ürünü', 15, 0, 0, CAST(N'2019-12-19T21:05:51.097' AS DateTime), 1, 0)
INSERT [dbo].[Product] ([productID], [supplierID], [categoryID], [productName], [unitPrice], [discount], [discontinued], [dateOfAdded], [IsActive], [stock]) VALUES (3, 6, 2, N'çubuk kraker', 5, 0, 0, CAST(N'2019-12-19T21:06:12.713' AS DateTime), 1, 0)
INSERT [dbo].[Product] ([productID], [supplierID], [categoryID], [productName], [unitPrice], [discount], [discontinued], [dateOfAdded], [IsActive], [stock]) VALUES (4, 5, 2, N'sakız', 2, 0, 0, CAST(N'2019-12-19T21:07:23.740' AS DateTime), 1, 0)
INSERT [dbo].[Product] ([productID], [supplierID], [categoryID], [productName], [unitPrice], [discount], [discontinued], [dateOfAdded], [IsActive], [stock]) VALUES (5, 6, 5, N'elma 1kg', 5, 0, 0, CAST(N'2019-12-19T21:07:41.920' AS DateTime), 1, 2)
INSERT [dbo].[Product] ([productID], [supplierID], [categoryID], [productName], [unitPrice], [discount], [discontinued], [dateOfAdded], [IsActive], [stock]) VALUES (6, 6, 2, N'muz 1kg', 10, 0, 0, CAST(N'2019-12-19T21:07:54.933' AS DateTime), 1, 0)
INSERT [dbo].[Product] ([productID], [supplierID], [categoryID], [productName], [unitPrice], [discount], [discontinued], [dateOfAdded], [IsActive], [stock]) VALUES (7, 6, 5, N'armut 1kg', 6, 0, 0, CAST(N'2019-12-19T21:08:10.793' AS DateTime), 1, 0)
INSERT [dbo].[Product] ([productID], [supplierID], [categoryID], [productName], [unitPrice], [discount], [discontinued], [dateOfAdded], [IsActive], [stock]) VALUES (8, 7, 3, N'kola', 5, 0, 0, CAST(N'2019-12-19T21:08:40.987' AS DateTime), 1, 10)
INSERT [dbo].[Product] ([productID], [supplierID], [categoryID], [productName], [unitPrice], [discount], [discontinued], [dateOfAdded], [IsActive], [stock]) VALUES (9, 7, 3, N'meyve suyu', 10, 0, 0, CAST(N'2019-12-19T21:08:55.873' AS DateTime), 1, 6)
INSERT [dbo].[Product] ([productID], [supplierID], [categoryID], [productName], [unitPrice], [discount], [discontinued], [dateOfAdded], [IsActive], [stock]) VALUES (10, 7, 6, N'kalem', 25, 0, 0, CAST(N'2019-12-19T21:09:10.933' AS DateTime), 1, 5)
INSERT [dbo].[Product] ([productID], [supplierID], [categoryID], [productName], [unitPrice], [discount], [discontinued], [dateOfAdded], [IsActive], [stock]) VALUES (11, 7, 6, N'defter', 25, 0, 0, CAST(N'2019-12-19T21:10:31.963' AS DateTime), 1, 20)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([stockID], [productID], [count], [dateOfAdded]) VALUES (34, 2, 5, CAST(N'2019-12-20T00:08:59.917' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productID], [count], [dateOfAdded]) VALUES (35, 10, 20, CAST(N'2019-12-20T00:09:05.300' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productID], [count], [dateOfAdded]) VALUES (36, 11, 30, CAST(N'2019-12-20T00:09:13.243' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productID], [count], [dateOfAdded]) VALUES (37, 9, 20, CAST(N'2019-12-20T00:09:22.533' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productID], [count], [dateOfAdded]) VALUES (38, 5, 10, CAST(N'2019-12-20T09:01:14.177' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productID], [count], [dateOfAdded]) VALUES (39, 8, 10, CAST(N'2019-12-21T22:34:15.140' AS DateTime))
SET IDENTITY_INSERT [dbo].[Stock] OFF
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([supplierID], [companyName], [supplierNameSurname], [address], [gsm], [IsActive]) VALUES (5, N'x şirketi', N'hasan yılmaz', N'İstanbul', N'(312) 487-8202', 1)
INSERT [dbo].[Supplier] ([supplierID], [companyName], [supplierNameSurname], [address], [gsm], [IsActive]) VALUES (6, N'y şirketi', N'fatma ak', N'Bursa', N'(333) 333-3333', 1)
INSERT [dbo].[Supplier] ([supplierID], [companyName], [supplierNameSurname], [address], [gsm], [IsActive]) VALUES (7, N'abc grup', N'ayşe al', N'Trabzon', N'(444) 444-4444', 1)
SET IDENTITY_INSERT [dbo].[Supplier] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([userID], [userName], [password], [userType]) VALUES (1, N'admin', N'12345', 1)
INSERT [dbo].[Users] ([userID], [userName], [password], [userType]) VALUES (2, N'busra.cinar', N'1234', 2)
INSERT [dbo].[Users] ([userID], [userName], [password], [userType]) VALUES (3, N'eda', N'1', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_TblSiparis_TblKasiyer] FOREIGN KEY([cashierID])
REFERENCES [dbo].[Cashier] ([cashierID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_TblSiparis_TblKasiyer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_TblSiparis_TblMüsteri] FOREIGN KEY([customerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_TblSiparis_TblMüsteri]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_TblSiparisDetay_TblSiparis] FOREIGN KEY([orderID])
REFERENCES [dbo].[Order] ([orderID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_TblSiparisDetay_TblSiparis]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_TblSiparisDetay_TblUrun] FOREIGN KEY([productID])
REFERENCES [dbo].[Product] ([productID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_TblSiparisDetay_TblUrun]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_TblUrun_TblKategori] FOREIGN KEY([categoryID])
REFERENCES [dbo].[Category] ([categoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_TblUrun_TblKategori]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_TblUrun_TblSatici] FOREIGN KEY([supplierID])
REFERENCES [dbo].[Supplier] ([supplierID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_TblUrun_TblSatici]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_TblStok_TblUrun] FOREIGN KEY([productID])
REFERENCES [dbo].[Product] ([productID])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_TblStok_TblUrun]
GO
USE [master]
GO
ALTER DATABASE [Satis] SET  READ_WRITE 
GO
