USE [master]
GO
/****** Object:  Database [CountriesAndCapitals]    Script Date: 31.03.2024 15:34:45 ******/
CREATE DATABASE [CountriesAndCapitals]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CountriesAndCapitals', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CountriesAndCapitals.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CountriesAndCapitals_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CountriesAndCapitals_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CountriesAndCapitals] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CountriesAndCapitals].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CountriesAndCapitals] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET ARITHABORT OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CountriesAndCapitals] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CountriesAndCapitals] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CountriesAndCapitals] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CountriesAndCapitals] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET RECOVERY FULL 
GO
ALTER DATABASE [CountriesAndCapitals] SET  MULTI_USER 
GO
ALTER DATABASE [CountriesAndCapitals] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CountriesAndCapitals] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CountriesAndCapitals] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CountriesAndCapitals] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CountriesAndCapitals] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CountriesAndCapitals] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CountriesAndCapitals', N'ON'
GO
ALTER DATABASE [CountriesAndCapitals] SET QUERY_STORE = ON
GO
ALTER DATABASE [CountriesAndCapitals] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CountriesAndCapitals]
GO
/****** Object:  Table [dbo].[Capitals]    Script Date: 31.03.2024 15:34:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Capitals](
	[capital_id] [int] IDENTITY(1,1) NOT NULL,
	[capital_name] [varchar](255) NOT NULL,
	[country_id] [int] NULL,
	[population] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[capital_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 31.03.2024 15:34:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[city_id] [int] IDENTITY(1,1) NOT NULL,
	[city_name] [varchar](255) NOT NULL,
	[country_id] [int] NULL,
	[population] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[city_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 31.03.2024 15:34:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[country_id] [int] IDENTITY(1,1) NOT NULL,
	[country_name] [varchar](255) NOT NULL,
	[population] [int] NOT NULL,
	[area] [float] NOT NULL,
	[isEurope] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[country_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Capitals] ON 

INSERT [dbo].[Capitals] ([capital_id], [capital_name], [country_id], [population]) VALUES (1, N'Washington D.C.', 1, 705749)
INSERT [dbo].[Capitals] ([capital_id], [capital_name], [country_id], [population]) VALUES (2, N'Ottawa', 2, 934243)
INSERT [dbo].[Capitals] ([capital_id], [capital_name], [country_id], [population]) VALUES (3, N'Paris', 3, 2148000)
INSERT [dbo].[Capitals] ([capital_id], [capital_name], [country_id], [population]) VALUES (4, N'Berlin', 4, 3748000)
INSERT [dbo].[Capitals] ([capital_id], [capital_name], [country_id], [population]) VALUES (5, N'Beijing', 5, 21707000)
SET IDENTITY_INSERT [dbo].[Capitals] OFF
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([city_id], [city_name], [country_id], [population]) VALUES (1, N'New York City', 1, 8337000)
INSERT [dbo].[Cities] ([city_id], [city_name], [country_id], [population]) VALUES (2, N'Toronto', 2, 2731571)
INSERT [dbo].[Cities] ([city_id], [city_name], [country_id], [population]) VALUES (3, N'Marseille', 3, 869815)
INSERT [dbo].[Cities] ([city_id], [city_name], [country_id], [population]) VALUES (4, N'Hamburg', 4, 1841179)
INSERT [dbo].[Cities] ([city_id], [city_name], [country_id], [population]) VALUES (5, N'Shanghai', 5, 27058479)
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([country_id], [country_name], [population], [area], [isEurope]) VALUES (1, N'USA', 331000000, 9833520, 0)
INSERT [dbo].[Countries] ([country_id], [country_name], [population], [area], [isEurope]) VALUES (2, N'Canada', 38000000, 9984670, 0)
INSERT [dbo].[Countries] ([country_id], [country_name], [population], [area], [isEurope]) VALUES (3, N'France', 67000000, 551695, 1)
INSERT [dbo].[Countries] ([country_id], [country_name], [population], [area], [isEurope]) VALUES (4, N'Germany', 83000000, 357022, 1)
INSERT [dbo].[Countries] ([country_id], [country_name], [population], [area], [isEurope]) VALUES (5, N'China', 1444000000, 9596961, NULL)
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
ALTER TABLE [dbo].[Capitals]  WITH CHECK ADD FOREIGN KEY([country_id])
REFERENCES [dbo].[Countries] ([country_id])
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD FOREIGN KEY([country_id])
REFERENCES [dbo].[Countries] ([country_id])
GO
USE [master]
GO
ALTER DATABASE [CountriesAndCapitals] SET  READ_WRITE 
GO
