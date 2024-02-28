USE [master]
GO
/****** Object:  Database [Store2]    Script Date: 21.01.2024 18:03:02 ******/
CREATE DATABASE [Store2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Store2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Store2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Store2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Store2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Store2] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Store2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Store2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Store2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Store2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Store2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Store2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Store2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Store2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Store2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Store2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Store2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Store2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Store2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Store2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Store2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Store2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Store2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Store2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Store2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Store2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Store2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Store2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Store2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Store2] SET RECOVERY FULL 
GO
ALTER DATABASE [Store2] SET  MULTI_USER 
GO
ALTER DATABASE [Store2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Store2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Store2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Store2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Store2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Store2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Store2', N'ON'
GO
ALTER DATABASE [Store2] SET QUERY_STORE = ON
GO
ALTER DATABASE [Store2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Store2]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 21.01.2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[street] [nvarchar](50) NULL,
	[id_city] [int] NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 21.01.2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 21.01.2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[id_region] [int] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 21.01.2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 21.01.2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_product] [int] NULL,
	[id_supplier] [int] NULL,
	[price] [int] NULL,
	[quantity] [int] NULL,
	[date_of_delivery] [datetime] NULL,
 CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 21.01.2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[percent] [int] NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Measurements]    Script Date: 21.01.2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measurements](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Measurements] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producer]    Script Date: 21.01.2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[id_address] [int] NULL,
 CONSTRAINT [PK_Producer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 21.01.2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[id_category] [int] NULL,
	[id_producer] [int] NULL,
	[id_measurement] [int] NULL,
	[id_discount] [int] NULL,
	[price] [int] NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 21.01.2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[id_country] [int] NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 21.01.2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_product] [int] NULL,
	[price] [int] NULL,
	[quantity] [int] NULL,
	[date_of_sale] [datetime] NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 21.01.2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[id_address] [int] NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([id], [street], [id_city]) VALUES (1, N'Haharina Avenue', 1)
INSERT [dbo].[Address] ([id], [street], [id_city]) VALUES (2, N'Krupnicza Street', 2)
INSERT [dbo].[Address] ([id], [street], [id_city]) VALUES (3, N'Mittelweg Street', 3)
INSERT [dbo].[Address] ([id], [street], [id_city]) VALUES (4, N'Newton Street', 4)
INSERT [dbo].[Address] ([id], [street], [id_city]) VALUES (5, N'Bulevardul 1 Mai', 5)
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [name]) VALUES (1, N'Dairy')
INSERT [dbo].[Category] ([id], [name]) VALUES (2, N'Meat')
INSERT [dbo].[Category] ([id], [name]) VALUES (3, N'Confectionery')
INSERT [dbo].[Category] ([id], [name]) VALUES (4, N'Alcohol')
INSERT [dbo].[Category] ([id], [name]) VALUES (5, N'Fruit')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([id], [name], [id_region]) VALUES (1, N'Odesa', 1)
INSERT [dbo].[City] ([id], [name], [id_region]) VALUES (2, N'Wroclaw', 2)
INSERT [dbo].[City] ([id], [name], [id_region]) VALUES (3, N'Gamburg', 3)
INSERT [dbo].[City] ([id], [name], [id_region]) VALUES (4, N'Manchester', 4)
INSERT [dbo].[City] ([id], [name], [id_region]) VALUES (5, N'Constanta', 5)
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([id], [name]) VALUES (1, N'Ukraine')
INSERT [dbo].[Country] ([id], [name]) VALUES (2, N'Poland')
INSERT [dbo].[Country] ([id], [name]) VALUES (3, N'Germany')
INSERT [dbo].[Country] ([id], [name]) VALUES (4, N'United Kingdom')
INSERT [dbo].[Country] ([id], [name]) VALUES (5, N'Romania')
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Delivery] ON 

INSERT [dbo].[Delivery] ([id], [id_product], [id_supplier], [price], [quantity], [date_of_delivery]) VALUES (1, 1, 1, 300, 200, CAST(N'2023-05-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Delivery] ([id], [id_product], [id_supplier], [price], [quantity], [date_of_delivery]) VALUES (2, 2, 1, 100, 300, CAST(N'2023-08-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Delivery] ([id], [id_product], [id_supplier], [price], [quantity], [date_of_delivery]) VALUES (3, 3, 2, 700, 300, CAST(N'2023-09-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Delivery] ([id], [id_product], [id_supplier], [price], [quantity], [date_of_delivery]) VALUES (4, 4, 2, 500, 400, CAST(N'2023-07-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Delivery] ([id], [id_product], [id_supplier], [price], [quantity], [date_of_delivery]) VALUES (5, 5, 3, 400, 500, CAST(N'2023-11-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Delivery] ([id], [id_product], [id_supplier], [price], [quantity], [date_of_delivery]) VALUES (6, 6, 4, 800, 200, CAST(N'2023-12-29T00:00:00.000' AS DateTime))
INSERT [dbo].[Delivery] ([id], [id_product], [id_supplier], [price], [quantity], [date_of_delivery]) VALUES (7, 7, 5, 10000, 4, CAST(N'2023-12-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Delivery] ([id], [id_product], [id_supplier], [price], [quantity], [date_of_delivery]) VALUES (8, 8, 5, 200, 600, CAST(N'2023-10-30T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Delivery] OFF
GO
SET IDENTITY_INSERT [dbo].[Discount] ON 

INSERT [dbo].[Discount] ([id], [name], [percent]) VALUES (1, N'None', 0)
INSERT [dbo].[Discount] ([id], [name], [percent]) VALUES (2, N'Small', 15)
INSERT [dbo].[Discount] ([id], [name], [percent]) VALUES (3, N'Average', 25)
INSERT [dbo].[Discount] ([id], [name], [percent]) VALUES (4, N'Super', 50)
INSERT [dbo].[Discount] ([id], [name], [percent]) VALUES (5, N'Mega', 70)
SET IDENTITY_INSERT [dbo].[Discount] OFF
GO
SET IDENTITY_INSERT [dbo].[Measurements] ON 

INSERT [dbo].[Measurements] ([id], [name], [description]) VALUES (1, N'Weight', N'Measure of the heaviness of a product')
INSERT [dbo].[Measurements] ([id], [name], [description]) VALUES (2, N'Volume', N'Measure of the amount of space occupied by a product in three dimensions')
INSERT [dbo].[Measurements] ([id], [name], [description]) VALUES (3, N'Dimensions', N'Measure for packaged goods')
INSERT [dbo].[Measurements] ([id], [name], [description]) VALUES (4, N'Nutritional', N'Measure for calories, fat, protein, carbohydrates, etc')
INSERT [dbo].[Measurements] ([id], [name], [description]) VALUES (5, N'Temperature', N'Measure for food temperature')
SET IDENTITY_INSERT [dbo].[Measurements] OFF
GO
SET IDENTITY_INSERT [dbo].[Producer] ON 

INSERT [dbo].[Producer] ([id], [name], [id_address]) VALUES (1, N'Odesa FPP', 1)
INSERT [dbo].[Producer] ([id], [name], [id_address]) VALUES (2, N'Wroclaw PF', 2)
INSERT [dbo].[Producer] ([id], [name], [id_address]) VALUES (3, N'Germany Product Factory', 3)
INSERT [dbo].[Producer] ([id], [name], [id_address]) VALUES (4, N'English Products', 4)
INSERT [dbo].[Producer] ([id], [name], [id_address]) VALUES (5, N'Romanian FPP', 5)
SET IDENTITY_INSERT [dbo].[Producer] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [name], [id_category], [id_producer], [id_measurement], [id_discount], [price], [quantity]) VALUES (1, N'Milk', 1, 1, 2, 1, 35, 100)
INSERT [dbo].[Product] ([id], [name], [id_category], [id_producer], [id_measurement], [id_discount], [price], [quantity]) VALUES (2, N'Yoghurt', 1, 3, 2, 1, 20, 200)
INSERT [dbo].[Product] ([id], [name], [id_category], [id_producer], [id_measurement], [id_discount], [price], [quantity]) VALUES (3, N'Beef', 2, 5, 1, 2, 50, 300)
INSERT [dbo].[Product] ([id], [name], [id_category], [id_producer], [id_measurement], [id_discount], [price], [quantity]) VALUES (4, N'Lamb', 2, 5, 1, 5, 60, 250)
INSERT [dbo].[Product] ([id], [name], [id_category], [id_producer], [id_measurement], [id_discount], [price], [quantity]) VALUES (5, N'Cake', 3, 1, 1, 4, 100, 400)
INSERT [dbo].[Product] ([id], [name], [id_category], [id_producer], [id_measurement], [id_discount], [price], [quantity]) VALUES (6, N'Sweets', 3, 2, 1, 3, 30, 600)
INSERT [dbo].[Product] ([id], [name], [id_category], [id_producer], [id_measurement], [id_discount], [price], [quantity]) VALUES (7, N'Whisky', 4, 4, 2, 4, 2500, 15)
INSERT [dbo].[Product] ([id], [name], [id_category], [id_producer], [id_measurement], [id_discount], [price], [quantity]) VALUES (8, N'Apple', 5, 2, 1, 2, 25, 500)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Region] ON 

INSERT [dbo].[Region] ([id], [name], [id_country]) VALUES (1, N'Odes''ka oblast''', 1)
INSERT [dbo].[Region] ([id], [name], [id_country]) VALUES (2, N'Lower Silesia', 2)
INSERT [dbo].[Region] ([id], [name], [id_country]) VALUES (3, N'Gamburg', 3)
INSERT [dbo].[Region] ([id], [name], [id_country]) VALUES (4, N'England', 4)
INSERT [dbo].[Region] ([id], [name], [id_country]) VALUES (5, N'Constanta region', 5)
SET IDENTITY_INSERT [dbo].[Region] OFF
GO
SET IDENTITY_INSERT [dbo].[Sale] ON 

INSERT [dbo].[Sale] ([id], [id_product], [price], [quantity], [date_of_sale]) VALUES (1, 1, 105, 3, CAST(N'2024-01-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Sale] ([id], [id_product], [price], [quantity], [date_of_sale]) VALUES (2, 2, 40, 2, CAST(N'2024-01-14T00:00:00.000' AS DateTime))
INSERT [dbo].[Sale] ([id], [id_product], [price], [quantity], [date_of_sale]) VALUES (3, 3, 255, 6, CAST(N'2024-01-13T00:00:00.000' AS DateTime))
INSERT [dbo].[Sale] ([id], [id_product], [price], [quantity], [date_of_sale]) VALUES (4, 4, 126, 7, CAST(N'2024-01-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Sale] ([id], [id_product], [price], [quantity], [date_of_sale]) VALUES (5, 5, 400, 8, CAST(N'2024-01-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Sale] ([id], [id_product], [price], [quantity], [date_of_sale]) VALUES (6, 6, 90, 4, CAST(N'2024-01-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Sale] ([id], [id_product], [price], [quantity], [date_of_sale]) VALUES (7, 7, 1250, 1, CAST(N'2024-01-09T00:00:00.000' AS DateTime))
INSERT [dbo].[Sale] ([id], [id_product], [price], [quantity], [date_of_sale]) VALUES (8, 8, 570, 5, CAST(N'2024-01-08T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sale] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([id], [name], [id_address]) VALUES (1, N'Ukrainian delivery', 1)
INSERT [dbo].[Supplier] ([id], [name], [id_address]) VALUES (2, N'Polish Products', 2)
INSERT [dbo].[Supplier] ([id], [name], [id_address]) VALUES (3, N'German food', 3)
INSERT [dbo].[Supplier] ([id], [name], [id_address]) VALUES (4, N'"Royal quality"', 4)
INSERT [dbo].[Supplier] ([id], [name], [id_address]) VALUES (5, N'Romanian delivery', 5)
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_City] FOREIGN KEY([id_city])
REFERENCES [dbo].[City] ([id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_City]
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_Region] FOREIGN KEY([id_region])
REFERENCES [dbo].[Region] ([id])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_Region]
GO
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD  CONSTRAINT [FK_Delivery_Product] FOREIGN KEY([id_product])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Delivery] CHECK CONSTRAINT [FK_Delivery_Product]
GO
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD  CONSTRAINT [FK_Delivery_Supplier] FOREIGN KEY([id_supplier])
REFERENCES [dbo].[Supplier] ([id])
GO
ALTER TABLE [dbo].[Delivery] CHECK CONSTRAINT [FK_Delivery_Supplier]
GO
ALTER TABLE [dbo].[Producer]  WITH CHECK ADD  CONSTRAINT [FK_Producer_Address] FOREIGN KEY([id_address])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[Producer] CHECK CONSTRAINT [FK_Producer_Address]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([id_category])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Discount] FOREIGN KEY([id_discount])
REFERENCES [dbo].[Discount] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Discount]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Measurements] FOREIGN KEY([id_measurement])
REFERENCES [dbo].[Measurements] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Measurements]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Producer] FOREIGN KEY([id_producer])
REFERENCES [dbo].[Producer] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Producer]
GO
ALTER TABLE [dbo].[Region]  WITH CHECK ADD  CONSTRAINT [FK_Region_Country] FOREIGN KEY([id_country])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Region] CHECK CONSTRAINT [FK_Region_Country]
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD  CONSTRAINT [FK_Sale_Product] FOREIGN KEY([id_product])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Sale] CHECK CONSTRAINT [FK_Sale_Product]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_Address] FOREIGN KEY([id_address])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplier_Address]
GO
USE [master]
GO
ALTER DATABASE [Store2] SET  READ_WRITE 
GO