USE [master]
GO
/****** Object:  Database [AtacanOteli]    Script Date: 21.12.2024 13:51:14 ******/
CREATE DATABASE [AtacanOteli]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AtacanOteli', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS02\MSSQL\DATA\AtacanOteli.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AtacanOteli_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS02\MSSQL\DATA\AtacanOteli_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [AtacanOteli] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AtacanOteli].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AtacanOteli] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AtacanOteli] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AtacanOteli] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AtacanOteli] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AtacanOteli] SET ARITHABORT OFF 
GO
ALTER DATABASE [AtacanOteli] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AtacanOteli] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AtacanOteli] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AtacanOteli] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AtacanOteli] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AtacanOteli] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AtacanOteli] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AtacanOteli] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AtacanOteli] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AtacanOteli] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AtacanOteli] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AtacanOteli] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AtacanOteli] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AtacanOteli] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AtacanOteli] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AtacanOteli] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AtacanOteli] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AtacanOteli] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AtacanOteli] SET  MULTI_USER 
GO
ALTER DATABASE [AtacanOteli] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AtacanOteli] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AtacanOteli] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AtacanOteli] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AtacanOteli] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AtacanOteli] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AtacanOteli] SET QUERY_STORE = ON
GO
ALTER DATABASE [AtacanOteli] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [AtacanOteli]
GO
/****** Object:  Table [dbo].[AdminGiris]    Script Date: 21.12.2024 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminGiris](
	[Kullanici] [nvarchar](50) NULL,
	[Sifre] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faturalar]    Script Date: 21.12.2024 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faturalar](
	[Elektrik] [int] NULL,
	[Su] [int] NULL,
	[İnternet] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesajlar]    Script Date: 21.12.2024 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesajlar](
	[Mesajid] [int] IDENTITY(1,1) NOT NULL,
	[Adsoyad] [varchar](50) NULL,
	[Mesaj] [varchar](1500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MusteriEkle]    Script Date: 21.12.2024 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MusteriEkle](
	[Musteriid] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [varchar](15) NULL,
	[Soyadi] [varchar](20) NULL,
	[Cinsiyet] [varchar](5) NULL,
	[Telefon] [varchar](15) NULL,
	[Mail] [varchar](50) NULL,
	[TC] [varchar](12) NULL,
	[OdaNo] [varchar](5) NULL,
	[Ucret] [int] NULL,
	[GirisTarihi] [date] NULL,
	[CikisTarihi] [date] NULL,
	[VipSecenekler] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oda101]    Script Date: 21.12.2024 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda101](
	[Adi] [varchar](50) NULL,
	[Soyadi] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oda102]    Script Date: 21.12.2024 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda102](
	[Adi] [varchar](50) NULL,
	[Soyadi] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oda103]    Script Date: 21.12.2024 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda103](
	[Adi] [nvarchar](50) NULL,
	[Soyadi] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oda104]    Script Date: 21.12.2024 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda104](
	[Adi] [varchar](50) NULL,
	[Soyadi] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oda105]    Script Date: 21.12.2024 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda105](
	[Adi] [varchar](50) NULL,
	[Soyadi] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oda106]    Script Date: 21.12.2024 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda106](
	[Adi] [nvarchar](50) NULL,
	[Soyadi] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oda107]    Script Date: 21.12.2024 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda107](
	[Adi] [varchar](50) NULL,
	[Soyadi] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oda108]    Script Date: 21.12.2024 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda108](
	[Adi] [varchar](50) NULL,
	[Soyadi] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oda109]    Script Date: 21.12.2024 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda109](
	[Adi] [varchar](50) NULL,
	[Soyadi] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stoklar]    Script Date: 21.12.2024 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stoklar](
	[Gida] [int] NULL,
	[İcecek] [int] NULL,
	[Cerezler] [int] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[AdminGiris] ([Kullanici], [Sifre]) VALUES (N'admin', N'1234')
GO
INSERT [dbo].[Faturalar] ([Elektrik], [Su], [İnternet]) VALUES (600, 500, 120)
INSERT [dbo].[Faturalar] ([Elektrik], [Su], [İnternet]) VALUES (300, 200, 120)
INSERT [dbo].[Faturalar] ([Elektrik], [Su], [İnternet]) VALUES (450, 250, 120)
GO
SET IDENTITY_INSERT [dbo].[Mesajlar] ON 

INSERT [dbo].[Mesajlar] ([Mesajid], [Adsoyad], [Mesaj]) VALUES (1, N'Eylül Naz', N'Odalarda klima mutlaka olmalı. Yöneticiye bildirin.')
INSERT [dbo].[Mesajlar] ([Mesajid], [Adsoyad], [Mesaj]) VALUES (3, N'Burhan Altıntop', N'Bayıldım.')
SET IDENTITY_INSERT [dbo].[Mesajlar] OFF
GO
SET IDENTITY_INSERT [dbo].[MusteriEkle] ON 

INSERT [dbo].[MusteriEkle] ([Musteriid], [Adi], [Soyadi], [Cinsiyet], [Telefon], [Mail], [TC], [OdaNo], [Ucret], [GirisTarihi], [CikisTarihi], [VipSecenekler]) VALUES (1072, N'meryem', N'kireç', N'Kadın', N'(558) 765-4567', N'meryemkirec1@gmail.com', N'98765098765', N'102', 15000, CAST(N'2024-12-19' AS Date), CAST(N'2024-12-22' AS Date), N'pool')
INSERT [dbo].[MusteriEkle] ([Musteriid], [Adi], [Soyadi], [Cinsiyet], [Telefon], [Mail], [TC], [OdaNo], [Ucret], [GirisTarihi], [CikisTarihi], [VipSecenekler]) VALUES (1073, N'emre', N'lam', N'Erkek', N'(553) 765-4567', N'emrelllam@gmail.com', N'58765456789', N'106', 35000, CAST(N'2024-12-19' AS Date), CAST(N'2024-12-26' AS Date), N'')
INSERT [dbo].[MusteriEkle] ([Musteriid], [Adi], [Soyadi], [Cinsiyet], [Telefon], [Mail], [TC], [OdaNo], [Ucret], [GirisTarihi], [CikisTarihi], [VipSecenekler]) VALUES (1074, N'süreyya', N'atacan', N'Kadın', N'(531) 345-6765', N'süreyyaatacan@hotmail.com', N'11111111111', N'107', 5000, CAST(N'2024-12-19' AS Date), CAST(N'2024-12-20' AS Date), N'')
SET IDENTITY_INSERT [dbo].[MusteriEkle] OFF
GO
INSERT [dbo].[Oda102] ([Adi], [Soyadi]) VALUES (N'meryem', N'kireç')
GO
INSERT [dbo].[Oda106] ([Adi], [Soyadi]) VALUES (N'emre', N'lam')
GO
INSERT [dbo].[Oda107] ([Adi], [Soyadi]) VALUES (N'süreyya', N'atacan')
GO
INSERT [dbo].[Stoklar] ([Gida], [İcecek], [Cerezler]) VALUES (100, 200, 50)
INSERT [dbo].[Stoklar] ([Gida], [İcecek], [Cerezler]) VALUES (450, 350, 80)
INSERT [dbo].[Stoklar] ([Gida], [İcecek], [Cerezler]) VALUES (400, 250, 150)
GO
USE [master]
GO
ALTER DATABASE [AtacanOteli] SET  READ_WRITE 
GO
