USE [master]
GO
/****** Object:  Database [MyOpr]    Script Date: 04/07/2022 09:13:39 ******/
CREATE DATABASE [MyOpr]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyOpr', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\MyOpr.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MyOpr_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\MyOpr_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MyOpr] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyOpr].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyOpr] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyOpr] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyOpr] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyOpr] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyOpr] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyOpr] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyOpr] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyOpr] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyOpr] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyOpr] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyOpr] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyOpr] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyOpr] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyOpr] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyOpr] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyOpr] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyOpr] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyOpr] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyOpr] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyOpr] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyOpr] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyOpr] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyOpr] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyOpr] SET  MULTI_USER 
GO
ALTER DATABASE [MyOpr] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyOpr] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyOpr] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyOpr] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MyOpr] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MyOpr]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 04/07/2022 09:13:40 ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [admin]    Script Date: 04/07/2022 09:13:40 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountRoles]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NPP] [nvarchar](450) NULL,
	[RoleId] [nvarchar](450) NULL,
 CONSTRAINT [PK_AccountRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[NPP] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[NPP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnomaliLaporan]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnomaliLaporan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Anomali] [nvarchar](max) NULL,
	[Keterangan] [nvarchar](max) NULL,
	[ServiceId] [int] NOT NULL,
 CONSTRAINT [PK_AnomaliLaporan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nama] [nvarchar](max) NULL,
	[Icon] [nvarchar](max) NULL,
	[IsMainCategory] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contents]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[BodyContent] [nvarchar](max) NULL,
	[PathImage] [nvarchar](max) NULL,
	[PathContent] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Contents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailRegisters]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailRegisters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegisteredFormId] [int] NOT NULL,
	[Revisi] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_DetailRegisters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[NPP] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Gender] [int] NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[ServiceId] [int] NULL,
	[PositionId] [int] NOT NULL,
	[GroupId] [int] NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[NPP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](max) NULL,
	[EventTheme] [nvarchar](max) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Organizer] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtUsers]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NPP] [nvarchar](max) NULL,
	[Nama] [nvarchar](max) NULL,
	[Unit] [nvarchar](max) NULL,
	[Telp] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_ExtUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FileRegisteredIsos]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileRegisteredIsos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[FilePath] [nvarchar](max) NULL,
	[DetailRegisterId] [int] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_FileRegisteredIsos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistoryISOs]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryISOs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[IsoSupportId] [int] NOT NULL,
	[Revision] [int] NOT NULL,
	[FilePath] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_HistoryISOs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ISOCores]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ISOCores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[FilePath] [nvarchar](max) NULL,
	[Revision] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_ISOCores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ISOSupports]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ISOSupports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[ISOCoreId] [int] NOT NULL,
	[RegisteredFormId] [int] NOT NULL,
	[Revision] [int] NULL,
	[FilePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_ISOSupports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KategoriDocuments]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KategoriDocuments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_KategoriDocuments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LaporanHarians]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LaporanHarians](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApprovalId] [int] NOT NULL,
	[TanggalTransaksi] [datetime2](7) NOT NULL,
	[GroupId] [int] NOT NULL,
	[IsAnomaly] [bit] NOT NULL,
	[AnomaliId] [int] NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_LaporanHarians] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[officeLocations]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[officeLocations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_officeLocations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [nvarchar](max) NULL,
	[Grade] [int] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presences]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presences](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NOT NULL,
	[NPP] [nvarchar](450) NULL,
	[ExtUserId] [int] NULL,
	[IsInternal] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Presences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegisteredForms]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegisteredForms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[SubLayananId] [int] NOT NULL,
	[KategoriDocumentId] [int] NOT NULL,
	[NoUrut] [int] NOT NULL,
	[FormNumber] [nvarchar](max) NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_RegisteredForms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedulers]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedulers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Activity] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NULL,
	[StartDate] [datetime2](7) NULL,
	[EndDate] [datetime2](7) NULL,
	[ZoomId] [int] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[ZoomStatusId] [int] NOT NULL,
	[EmployeeNPP] [nvarchar](450) NULL,
	[link] [nvarchar](max) NULL,
 CONSTRAINT [PK_Schedulers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ShortName] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[GroupId] [int] NOT NULL,
	[KategoriService] [int] NOT NULL,
	[SubLayananId] [int] NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sliders]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sliders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Path] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Sliders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Units]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Units](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ServiceId] [int] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zooms]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Zooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZoomStatuses]    Script Date: 04/07/2022 09:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZoomStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_ZoomStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220701085748_DocumentController', N'6.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220701170105_Unit', N'6.0.2')
GO
SET IDENTITY_INSERT [dbo].[AccountRoles] ON 

INSERT [dbo].[AccountRoles] ([Id], [NPP], [RoleId]) VALUES (1, N'80001', N'1')
INSERT [dbo].[AccountRoles] ([Id], [NPP], [RoleId]) VALUES (2, N'80001', N'2')
INSERT [dbo].[AccountRoles] ([Id], [NPP], [RoleId]) VALUES (3, N'80001', N'3')
INSERT [dbo].[AccountRoles] ([Id], [NPP], [RoleId]) VALUES (4, N'80002', N'2')
INSERT [dbo].[AccountRoles] ([Id], [NPP], [RoleId]) VALUES (5, N'80002', N'3')
SET IDENTITY_INSERT [dbo].[AccountRoles] OFF
GO
INSERT [dbo].[Accounts] ([NPP], [UserName], [Password]) VALUES (N'80001', N'80001', N'$2b$10$EByb/hzc.oZHHdlubpn7qO7FbJQxlg.6gz0Z2/.LrG7CLDgyZ/UI.')
INSERT [dbo].[Accounts] ([NPP], [UserName], [Password]) VALUES (N'80002', N'80002', N'$2b$10$SLmGPJ2IDM4GpTGpULWgg.0b4xFVyw2Ojp1EyL5o39C1t4GjJRes6')
GO
INSERT [dbo].[Employees] ([NPP], [FirstName], [LastName], [PhoneNumber], [Gender], [DateOfBirth], [ServiceId], [PositionId], [GroupId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (N'80001', N'Administrator', N'1', N'-', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 3, 1, NULL, CAST(N'2022-07-01T16:31:51.3505355' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Employees] ([NPP], [FirstName], [LastName], [PhoneNumber], [Gender], [DateOfBirth], [ServiceId], [PositionId], [GroupId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (N'80002', N'user', N'satu', N'08129992293', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 4, 1, NULL, CAST(N'2022-07-04T08:27:42.7834910' AS DateTime2), NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([Id], [GroupName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (1, N'PGO', CAST(N'2022-07-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Groups] ([Id], [GroupName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (2, N'OJR', CAST(N'2022-07-01T16:55:13.7149811' AS DateTime2), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
SET IDENTITY_INSERT [dbo].[KategoriDocuments] ON 

INSERT [dbo].[KategoriDocuments] ([Id], [Name], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (1, N'Document Inti', CAST(N'2022-07-01T22:58:42.3036540' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[KategoriDocuments] ([Id], [Name], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (2, N'Document Utama', CAST(N'2022-07-01T22:59:22.5034610' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[KategoriDocuments] ([Id], [Name], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (3, N'Document Pendukung', CAST(N'2022-07-01T22:59:33.9170542' AS DateTime2), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[KategoriDocuments] OFF
GO
SET IDENTITY_INSERT [dbo].[Positions] ON 

INSERT [dbo].[Positions] ([Id], [PositionName], [Grade], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (1, N'Asisten', 1, CAST(N'2022-07-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Positions] OFF
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (N'1', N'Admin')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (N'2', N'User')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (N'3', N'Peserta')
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([Id], [Name], [ShortName], [IsDelete], [GroupId], [KategoriService], [SubLayananId]) VALUES (3, N'PPG', N'PPG', 0, 1, 0, 1)
INSERT [dbo].[Services] ([Id], [Name], [ShortName], [IsDelete], [GroupId], [KategoriService], [SubLayananId]) VALUES (4, N'Garansi Bank', N'GB', 0, 2, 0, NULL)
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[Units] ON 

INSERT [dbo].[Units] ([Id], [Name], [ServiceId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (1, N'PPG', 1, CAST(N'2022-07-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Units] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AccountRoles_NPP]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_AccountRoles_NPP] ON [dbo].[AccountRoles]
(
	[NPP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AccountRoles_RoleId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_AccountRoles_RoleId] ON [dbo].[AccountRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AnomaliLaporan_ServiceId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_AnomaliLaporan_ServiceId] ON [dbo].[AnomaliLaporan]
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contents_CategoryId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_Contents_CategoryId] ON [dbo].[Contents]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetailRegisters_RegisteredFormId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_DetailRegisters_RegisteredFormId] ON [dbo].[DetailRegisters]
(
	[RegisteredFormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employees_GroupId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_Employees_GroupId] ON [dbo].[Employees]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employees_PositionId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_Employees_PositionId] ON [dbo].[Employees]
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employees_ServiceId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_Employees_ServiceId] ON [dbo].[Employees]
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FileRegisteredIsos_DetailRegisterId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_FileRegisteredIsos_DetailRegisterId] ON [dbo].[FileRegisteredIsos]
(
	[DetailRegisterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HistoryISOs_IsoSupportId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_HistoryISOs_IsoSupportId] ON [dbo].[HistoryISOs]
(
	[IsoSupportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ISOSupports_ISOCoreId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_ISOSupports_ISOCoreId] ON [dbo].[ISOSupports]
(
	[ISOCoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ISOSupports_RegisteredFormId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_ISOSupports_RegisteredFormId] ON [dbo].[ISOSupports]
(
	[RegisteredFormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LaporanHarians_AnomaliId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_LaporanHarians_AnomaliId] ON [dbo].[LaporanHarians]
(
	[AnomaliId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LaporanHarians_GroupId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_LaporanHarians_GroupId] ON [dbo].[LaporanHarians]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Presences_EventId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_Presences_EventId] ON [dbo].[Presences]
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Presences_ExtUserId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_Presences_ExtUserId] ON [dbo].[Presences]
(
	[ExtUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Presences_NPP]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_Presences_NPP] ON [dbo].[Presences]
(
	[NPP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RegisteredForms_KategoriDocumentId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_RegisteredForms_KategoriDocumentId] ON [dbo].[RegisteredForms]
(
	[KategoriDocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RegisteredForms_ServiceId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_RegisteredForms_ServiceId] ON [dbo].[RegisteredForms]
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RegisteredForms_SubLayananId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_RegisteredForms_SubLayananId] ON [dbo].[RegisteredForms]
(
	[SubLayananId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Schedulers_EmployeeNPP]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_Schedulers_EmployeeNPP] ON [dbo].[Schedulers]
(
	[EmployeeNPP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Schedulers_ZoomId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_Schedulers_ZoomId] ON [dbo].[Schedulers]
(
	[ZoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Schedulers_ZoomStatusId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_Schedulers_ZoomStatusId] ON [dbo].[Schedulers]
(
	[ZoomStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Services_GroupId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_Services_GroupId] ON [dbo].[Services]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Services_SubLayananId]    Script Date: 04/07/2022 09:13:40 ******/
CREATE NONCLUSTERED INDEX [IX_Services_SubLayananId] ON [dbo].[Services]
(
	[SubLayananId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccountRoles]  WITH CHECK ADD  CONSTRAINT [FK_AccountRoles_Accounts_NPP] FOREIGN KEY([NPP])
REFERENCES [dbo].[Accounts] ([NPP])
GO
ALTER TABLE [dbo].[AccountRoles] CHECK CONSTRAINT [FK_AccountRoles_Accounts_NPP]
GO
ALTER TABLE [dbo].[AccountRoles]  WITH CHECK ADD  CONSTRAINT [FK_AccountRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[AccountRoles] CHECK CONSTRAINT [FK_AccountRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Employees_NPP] FOREIGN KEY([NPP])
REFERENCES [dbo].[Employees] ([NPP])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Employees_NPP]
GO
ALTER TABLE [dbo].[AnomaliLaporan]  WITH CHECK ADD  CONSTRAINT [FK_AnomaliLaporan_Services_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AnomaliLaporan] CHECK CONSTRAINT [FK_AnomaliLaporan_Services_ServiceId]
GO
ALTER TABLE [dbo].[Contents]  WITH CHECK ADD  CONSTRAINT [FK_Contents_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contents] CHECK CONSTRAINT [FK_Contents_Categories_CategoryId]
GO
ALTER TABLE [dbo].[DetailRegisters]  WITH CHECK ADD  CONSTRAINT [FK_DetailRegisters_RegisteredForms_RegisteredFormId] FOREIGN KEY([RegisteredFormId])
REFERENCES [dbo].[RegisteredForms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetailRegisters] CHECK CONSTRAINT [FK_DetailRegisters_RegisteredForms_RegisteredFormId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Groups_GroupId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Positions_PositionId] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Positions_PositionId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Services_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Services_ServiceId]
GO
ALTER TABLE [dbo].[FileRegisteredIsos]  WITH CHECK ADD  CONSTRAINT [FK_FileRegisteredIsos_DetailRegisters_DetailRegisterId] FOREIGN KEY([DetailRegisterId])
REFERENCES [dbo].[DetailRegisters] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FileRegisteredIsos] CHECK CONSTRAINT [FK_FileRegisteredIsos_DetailRegisters_DetailRegisterId]
GO
ALTER TABLE [dbo].[HistoryISOs]  WITH CHECK ADD  CONSTRAINT [FK_HistoryISOs_ISOSupports_IsoSupportId] FOREIGN KEY([IsoSupportId])
REFERENCES [dbo].[ISOSupports] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HistoryISOs] CHECK CONSTRAINT [FK_HistoryISOs_ISOSupports_IsoSupportId]
GO
ALTER TABLE [dbo].[ISOSupports]  WITH CHECK ADD  CONSTRAINT [FK_ISOSupports_ISOCores_ISOCoreId] FOREIGN KEY([ISOCoreId])
REFERENCES [dbo].[ISOCores] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ISOSupports] CHECK CONSTRAINT [FK_ISOSupports_ISOCores_ISOCoreId]
GO
ALTER TABLE [dbo].[ISOSupports]  WITH CHECK ADD  CONSTRAINT [FK_ISOSupports_RegisteredForms_RegisteredFormId] FOREIGN KEY([RegisteredFormId])
REFERENCES [dbo].[RegisteredForms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ISOSupports] CHECK CONSTRAINT [FK_ISOSupports_RegisteredForms_RegisteredFormId]
GO
ALTER TABLE [dbo].[LaporanHarians]  WITH CHECK ADD  CONSTRAINT [FK_LaporanHarians_AnomaliLaporan_AnomaliId] FOREIGN KEY([AnomaliId])
REFERENCES [dbo].[AnomaliLaporan] ([Id])
GO
ALTER TABLE [dbo].[LaporanHarians] CHECK CONSTRAINT [FK_LaporanHarians_AnomaliLaporan_AnomaliId]
GO
ALTER TABLE [dbo].[LaporanHarians]  WITH CHECK ADD  CONSTRAINT [FK_LaporanHarians_Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LaporanHarians] CHECK CONSTRAINT [FK_LaporanHarians_Groups_GroupId]
GO
ALTER TABLE [dbo].[Presences]  WITH CHECK ADD  CONSTRAINT [FK_Presences_Employees_NPP] FOREIGN KEY([NPP])
REFERENCES [dbo].[Employees] ([NPP])
GO
ALTER TABLE [dbo].[Presences] CHECK CONSTRAINT [FK_Presences_Employees_NPP]
GO
ALTER TABLE [dbo].[Presences]  WITH CHECK ADD  CONSTRAINT [FK_Presences_Events_EventId] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Presences] CHECK CONSTRAINT [FK_Presences_Events_EventId]
GO
ALTER TABLE [dbo].[Presences]  WITH CHECK ADD  CONSTRAINT [FK_Presences_ExtUsers_ExtUserId] FOREIGN KEY([ExtUserId])
REFERENCES [dbo].[ExtUsers] ([Id])
GO
ALTER TABLE [dbo].[Presences] CHECK CONSTRAINT [FK_Presences_ExtUsers_ExtUserId]
GO
ALTER TABLE [dbo].[RegisteredForms]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredForms_KategoriDocuments_KategoriDocumentId] FOREIGN KEY([KategoriDocumentId])
REFERENCES [dbo].[KategoriDocuments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RegisteredForms] CHECK CONSTRAINT [FK_RegisteredForms_KategoriDocuments_KategoriDocumentId]
GO
ALTER TABLE [dbo].[RegisteredForms]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredForms_Services_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RegisteredForms] CHECK CONSTRAINT [FK_RegisteredForms_Services_ServiceId]
GO
ALTER TABLE [dbo].[RegisteredForms]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredForms_Units_SubLayananId] FOREIGN KEY([SubLayananId])
REFERENCES [dbo].[Units] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RegisteredForms] CHECK CONSTRAINT [FK_RegisteredForms_Units_SubLayananId]
GO
ALTER TABLE [dbo].[Schedulers]  WITH CHECK ADD  CONSTRAINT [FK_Schedulers_Employees_EmployeeNPP] FOREIGN KEY([EmployeeNPP])
REFERENCES [dbo].[Employees] ([NPP])
GO
ALTER TABLE [dbo].[Schedulers] CHECK CONSTRAINT [FK_Schedulers_Employees_EmployeeNPP]
GO
ALTER TABLE [dbo].[Schedulers]  WITH CHECK ADD  CONSTRAINT [FK_Schedulers_Zooms_ZoomId] FOREIGN KEY([ZoomId])
REFERENCES [dbo].[Zooms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Schedulers] CHECK CONSTRAINT [FK_Schedulers_Zooms_ZoomId]
GO
ALTER TABLE [dbo].[Schedulers]  WITH CHECK ADD  CONSTRAINT [FK_Schedulers_ZoomStatuses_ZoomStatusId] FOREIGN KEY([ZoomStatusId])
REFERENCES [dbo].[ZoomStatuses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Schedulers] CHECK CONSTRAINT [FK_Schedulers_ZoomStatuses_ZoomStatusId]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Groups_GroupId]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Units_SubLayananId] FOREIGN KEY([SubLayananId])
REFERENCES [dbo].[Units] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Units_SubLayananId]
GO
USE [master]
GO
ALTER DATABASE [MyOpr] SET  READ_WRITE 
GO
