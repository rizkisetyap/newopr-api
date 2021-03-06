USE [master]
GO
/****** Object:  Database [MyOpr]    Script Date: 13/06/2022 09:27:54 ******/
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
ALTER DATABASE [MyOpr] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [MyOpr] SET ANSI_NULLS ON 
GO
ALTER DATABASE [MyOpr] SET ANSI_PADDING ON 
GO
ALTER DATABASE [MyOpr] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [MyOpr] SET ARITHABORT ON 
GO
ALTER DATABASE [MyOpr] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyOpr] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyOpr] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyOpr] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyOpr] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [MyOpr] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [MyOpr] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyOpr] SET QUOTED_IDENTIFIER ON 
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
ALTER DATABASE [MyOpr] SET RECOVERY FULL 
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
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 13/06/2022 09:27:54 ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\DevMyOpr]    Script Date: 13/06/2022 09:27:54 ******/
CREATE USER [IIS APPPOOL\DevMyOpr] FOR LOGIN [IIS APPPOOL\devmyopr] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [admin]    Script Date: 13/06/2022 09:27:54 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\DevMyOpr]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13/06/2022 09:27:54 ******/
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
/****** Object:  Table [dbo].[AccountRoles]    Script Date: 13/06/2022 09:27:54 ******/
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
/****** Object:  Table [dbo].[Accounts]    Script Date: 13/06/2022 09:27:54 ******/
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
/****** Object:  Table [dbo].[Categories]    Script Date: 13/06/2022 09:27:54 ******/
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
/****** Object:  Table [dbo].[Contents]    Script Date: 13/06/2022 09:27:54 ******/
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
/****** Object:  Table [dbo].[Employees]    Script Date: 13/06/2022 09:27:54 ******/
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
	[GroupId] [int] NOT NULL,
	[PositionId] [int] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[NPP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 13/06/2022 09:27:54 ******/
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
/****** Object:  Table [dbo].[ExtUsers]    Script Date: 13/06/2022 09:27:54 ******/
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
/****** Object:  Table [dbo].[Groups]    Script Date: 13/06/2022 09:27:54 ******/
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
/****** Object:  Table [dbo].[HistoryISOs]    Script Date: 13/06/2022 09:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryISOs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsoSupportId] [int] NOT NULL,
	[FilePath] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_HistoryISOs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ISOCores]    Script Date: 13/06/2022 09:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ISOCores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[FilePath] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_ISOCores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ISOSupports]    Script Date: 13/06/2022 09:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ISOSupports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ISOCoreId] [int] NOT NULL,
	[RegisteredFormId] [int] NOT NULL,
	[FormNumber] [nvarchar](max) NULL,
	[FilePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_ISOSupports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[officeLocations]    Script Date: 13/06/2022 09:27:54 ******/
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
/****** Object:  Table [dbo].[Positions]    Script Date: 13/06/2022 09:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
	[Grade] [int] NOT NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presences]    Script Date: 13/06/2022 09:27:54 ******/
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
/****** Object:  Table [dbo].[RegisteredForms]    Script Date: 13/06/2022 09:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegisteredForms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ServiceId] [int] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_RegisteredForms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 13/06/2022 09:27:54 ******/
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
/****** Object:  Table [dbo].[Schedulers]    Script Date: 13/06/2022 09:27:54 ******/
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
	[ZoomStatusId] [int] NOT NULL,
 CONSTRAINT [PK_Schedulers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 13/06/2022 09:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[GroupId] [int] NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sliders]    Script Date: 13/06/2022 09:27:54 ******/
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
/****** Object:  Table [dbo].[Zooms]    Script Date: 13/06/2022 09:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Zooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZoomStatuses]    Script Date: 13/06/2022 09:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZoomStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_ZoomStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220404083125_addInitialMigration', N'6.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220405075132_addSliderModel', N'6.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220406023021_addUserRole', N'6.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220406060853_revisedPosition', N'6.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220504060141_addnewModels', N'6.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220517075354_addOfficeLocation', N'6.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220518022845_addDateofBirthToEmployee', N'6.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220518040452_BirthDayColumn', N'6.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220613022042_DocumentIso', N'6.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220613022141_ZoomSchedulers', N'6.0.2')
GO
INSERT [dbo].[Accounts] ([NPP], [UserName], [Password]) VALUES (N'102131', N'102131', N'$2b$10$i0.mrp6cbZC6rUgalMefSOPXmCZaQL3pRFS1ZG9E6sS.Y8bVs998i')
INSERT [dbo].[Accounts] ([NPP], [UserName], [Password]) VALUES (N'102138', N'102138', N'$2b$10$1DAD7oXGhZV2Py0VhazTjud.E03REfndNbCDUMYBUjP0Zmamryuqe')
INSERT [dbo].[Accounts] ([NPP], [UserName], [Password]) VALUES (N'102139', N'102139', N'$2b$10$qNZQP7fsw6H1cHE4OcjbsOTxntB.5wc.bG8m/Lnq3vyU6Qe2CzagW')
INSERT [dbo].[Accounts] ([NPP], [UserName], [Password]) VALUES (N'Sincere@april.biz', N'Sincere@april.biz', N'$2b$10$/d6TDwOgND7mIG5ghIF2J.o8cHgahURla.bp04bAYCng3hX0vTKT.')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (1, N'BNI', N'63478', 1, CAST(N'2020-08-19T09:52:28.2170000' AS DateTime2), CAST(N'2022-02-04T08:10:14.1070000' AS DateTime2), NULL, 1)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (2, N'OPR', N'63073', 1, CAST(N'2020-08-19T11:44:14.0870000' AS DateTime2), CAST(N'2022-02-04T08:10:39.5300000' AS DateTime2), NULL, 0)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (3, N'ISO', N'983709', 1, CAST(N'2020-08-19T11:46:52.7770000' AS DateTime2), CAST(N'2022-02-04T08:11:08.7470000' AS DateTime2), NULL, 0)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (4, N'Dokumen ISO', N'983709', 1, CAST(N'2020-08-19T13:24:42.6170000' AS DateTime2), CAST(N'2022-02-04T08:11:18.0770000' AS DateTime2), NULL, 0)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (5, N'Siaga Covid', N'983709', 1, CAST(N'2020-08-19T13:26:18.3400000' AS DateTime2), CAST(N'2022-02-04T08:11:23.0130000' AS DateTime2), NULL, 0)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (8, N'Test Category Updated', NULL, 0, CAST(N'2022-05-12T01:30:22.8934909' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (9, N'test', N'63478', 1, CAST(N'2022-05-17T11:29:36.9170000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (10, N'Other', N'63478', 1, CAST(N'2022-05-17T12:04:35.1240000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (11, N'test', N'63478', 0, CAST(N'2022-05-17T12:05:58.1480000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (12, N'john doe1', N'983709', 0, CAST(N'2022-05-17T12:43:36.2520000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (13, N'Test', N'63478', 0, CAST(N'2022-05-17T12:51:00.7760000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (14, N'Produk 1', N'63478', 1, CAST(N'2022-05-17T12:52:31.8170000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (15, N'Farrel', N'63478', 1, CAST(N'2022-05-18T05:06:36.0770000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (16, N'john doe1', N'63478', 1, CAST(N'2022-05-18T05:58:30.6490000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (17, N'Lokawisata Baturaden', N'63478', 1, CAST(N'2022-05-18T05:59:37.0960000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (18, N'Baturaden', N'63478', 0, CAST(N'2022-05-18T06:41:18.5660000' AS DateTime2), CAST(N'2022-05-18T06:41:52.1820000' AS DateTime2), NULL, 1)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (19, N'Test', N'63478', 1, CAST(N'2022-05-19T04:05:39.8550000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (20, N'test', N'63478', 1, CAST(N'2022-05-23T01:43:32.1730000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (21, N'Test category', N'123Test', 1, CAST(N'2022-05-23T04:30:14.0380000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Categories] ([Id], [Nama], [Icon], [IsMainCategory], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (22, N'OK', N'983709', 1, CAST(N'2022-05-24T09:20:10.8300000' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Contents] ON 

INSERT [dbo].[Contents] ([Id], [Title], [BodyContent], [PathImage], [PathContent], [CategoryId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (1, N'Test update', N'Lorem Ipsum', N'path/to/img', N'path/to/content', 8, CAST(N'2022-05-12T09:20:38.4476443' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Contents] ([Id], [Title], [BodyContent], [PathImage], [PathContent], [CategoryId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (2, N'Content 2', N'Lorem ipsum 2', N'path/to/image2', N'path/to/content2', 8, CAST(N'2022-05-11T18:34:15.5080000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Contents] ([Id], [Title], [BodyContent], [PathImage], [PathContent], [CategoryId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (4, N'Content 3', N'Lorem ipsum 3', N'path/to/image3', N'path/to/content2', 1, CAST(N'2022-05-11T18:34:15.5080000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Contents] ([Id], [Title], [BodyContent], [PathImage], [PathContent], [CategoryId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (8, N'test', N'# test', N'path/image', N'path/file', 2, CAST(N'2022-05-24T17:10:48.3666715' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Contents] ([Id], [Title], [BodyContent], [PathImage], [PathContent], [CategoryId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (9, N'Test', N'# test', N'path/image', N'path/file', 2, CAST(N'2022-05-24T20:39:57.7380516' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Contents] ([Id], [Title], [BodyContent], [PathImage], [PathContent], [CategoryId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (10, N'test', N'# hello', N'path/image', N'path/file', 2, CAST(N'2022-05-24T20:52:55.9566114' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Contents] ([Id], [Title], [BodyContent], [PathImage], [PathContent], [CategoryId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (11, N'test', N'# helo', N'path/image', N'path/file', 2, CAST(N'2022-05-24T20:54:23.6865062' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Contents] ([Id], [Title], [BodyContent], [PathImage], [PathContent], [CategoryId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (12, N'ok', N'# test', N'path/image', N'path/file', 2, CAST(N'2022-05-24T20:56:14.2275209' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Contents] ([Id], [Title], [BodyContent], [PathImage], [PathContent], [CategoryId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (13, N'Ok', N'# test ok', N'path/image', N'path/file', 3, CAST(N'2022-05-24T20:56:48.8521038' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Contents] ([Id], [Title], [BodyContent], [PathImage], [PathContent], [CategoryId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (14, N'Test 2', N'# yes', N'path/image', N'path/file', 4, CAST(N'2022-05-24T20:59:39.0064304' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Contents] ([Id], [Title], [BodyContent], [PathImage], [PathContent], [CategoryId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (16, N'Test', N'# oke upload', N'path/image', N'path/file', 2, CAST(N'2022-05-24T21:14:55.7817918' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Contents] ([Id], [Title], [BodyContent], [PathImage], [PathContent], [CategoryId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (19, N'Test', N'# oke', N'path/image', N'path/file', 3, CAST(N'2022-05-24T23:21:31.2035846' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Contents] ([Id], [Title], [BodyContent], [PathImage], [PathContent], [CategoryId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (20, N'Test', N'# test', N'D:\Aplikasi BNI 2022\MyOPR\My-OPR\public\upload\content\images\20.xlsx', N'D:\Aplikasi BNI 2022\MyOPR\My-OPR\public\upload\content\file\20.xlsx', 3, CAST(N'2022-05-24T23:23:14.5321585' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Contents] ([Id], [Title], [BodyContent], [PathImage], [PathContent], [CategoryId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (21, N'Halal Bihalal IdulFitri', N'# Test', N'public\upload\content\images\21.png', N'public\upload\content\file\21.pdf', 2, CAST(N'2022-05-24T23:28:34.9616713' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Contents] ([Id], [Title], [BodyContent], [PathImage], [PathContent], [CategoryId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (22, N'konten dengan no file Updated', N'# no file include
update gambar
tambah gambar', N'public\upload\content\images\Image Konten - 22.jpeg', N'public\upload\content\file\File Konten - 22.xlsx', 2, CAST(N'2022-05-24T23:45:46.6887882' AS DateTime2), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Contents] OFF
GO
INSERT [dbo].[Employees] ([NPP], [FirstName], [LastName], [PhoneNumber], [Gender], [GroupId], [PositionId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete], [DateOfBirth]) VALUES (N'102131', N'Aldian', N'Dasilva Yuda Saputra', N'081310321505', 0, 1, 10, CAST(N'2022-04-06T08:17:49.4510000' AS DateTime2), CAST(N'2022-04-06T08:17:49.4510000' AS DateTime2), CAST(N'2022-04-06T08:17:49.4510000' AS DateTime2), 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([NPP], [FirstName], [LastName], [PhoneNumber], [Gender], [GroupId], [PositionId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete], [DateOfBirth]) VALUES (N'102138', N'Foo', N'Bazzz', N'08123456789', 0, 1, 10, CAST(N'2022-04-06T08:17:49.4510000' AS DateTime2), NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([NPP], [FirstName], [LastName], [PhoneNumber], [Gender], [GroupId], [PositionId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete], [DateOfBirth]) VALUES (N'102139', N'John', N'Doe', N'08123456789', 0, 1, 10, CAST(N'2022-04-06T08:17:49.4510000' AS DateTime2), NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([NPP], [FirstName], [LastName], [PhoneNumber], [Gender], [GroupId], [PositionId], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete], [DateOfBirth]) VALUES (N'Sincere@april.biz', N'Foo', N'Bazzz', N'08123456789', 0, 1, 10, CAST(N'2022-04-06T08:17:49.4510000' AS DateTime2), NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([Id], [EventName], [EventTheme], [StartDate], [EndDate], [Organizer], [Location], [IsActive], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (1, N'BNI OPR', N'Anniversary BNI', CAST(N'2022-05-19T17:00:00.0000000' AS DateTime2), CAST(N'2022-05-20T05:59:00.0000000' AS DateTime2), N'Divisi OPR', N'Plaza BNI BSD', 1, CAST(N'2022-05-18T15:03:23.8817120' AS DateTime2), CAST(N'2022-05-20T10:42:24.1600000' AS DateTime2), NULL, 1)
INSERT [dbo].[Events] ([Id], [EventName], [EventTheme], [StartDate], [EndDate], [Organizer], [Location], [IsActive], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (2, N'Coba tambah data dari frontend', N'React', CAST(N'2022-05-18T09:51:14.6120000' AS DateTime2), CAST(N'2022-05-18T17:00:00.0000000' AS DateTime2), N'Facebook', N'Serpong', 1, CAST(N'2022-05-18T16:51:35.0532139' AS DateTime2), CAST(N'2022-05-19T17:19:39.9410000' AS DateTime2), NULL, 1)
INSERT [dbo].[Events] ([Id], [EventName], [EventTheme], [StartDate], [EndDate], [Organizer], [Location], [IsActive], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (3, N'Test', N'k', CAST(N'2022-05-23T01:23:31.5520000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Divisi OPR', N'Plaza BNI', 1, CAST(N'2022-05-23T08:24:13.2400223' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Events] ([Id], [EventName], [EventTheme], [StartDate], [EndDate], [Organizer], [Location], [IsActive], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (4, N'Test event', N'test theme', CAST(N'2022-05-23T03:53:24.9220000' AS DateTime2), CAST(N'2022-05-23T03:53:24.9220000' AS DateTime2), N'Bni', N'BSD', 1, CAST(N'2022-05-23T03:53:47.6540000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Events] ([Id], [EventName], [EventTheme], [StartDate], [EndDate], [Organizer], [Location], [IsActive], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (5, N'Event 2', N'Event 2 tema', CAST(N'2022-05-23T03:54:17.8760000' AS DateTime2), CAST(N'2022-05-23T03:54:17.8760000' AS DateTime2), N'OPR', N'Plaza BNI', 1, CAST(N'2022-05-23T03:54:49.1270000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Events] ([Id], [EventName], [EventTheme], [StartDate], [EndDate], [Organizer], [Location], [IsActive], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (6, N'BNI OPR', N'opr', CAST(N'2022-05-24T10:11:52.3180000' AS DateTime2), CAST(N'2022-05-24T10:11:52.3180000' AS DateTime2), N'opr', N'plaza bni lt 14', 1, CAST(N'2022-05-24T10:12:14.6450000' AS DateTime2), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([Id], [GroupName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (1, N'PGO', CAST(N'2022-04-06T04:14:19.9830000' AS DateTime2), CAST(N'2022-04-06T04:14:19.9830000' AS DateTime2), CAST(N'2022-04-06T04:14:19.9830000' AS DateTime2), 0)
INSERT [dbo].[Groups] ([Id], [GroupName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (3, N'Group 4', CAST(N'2022-05-12T10:14:21.3259889' AS DateTime2), CAST(N'2022-04-06T04:14:19.9830000' AS DateTime2), NULL, 1)
INSERT [dbo].[Groups] ([Id], [GroupName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (4, N'Group 3', CAST(N'2022-04-06T04:14:19.9830000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Groups] ([Id], [GroupName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (5, NULL, CAST(N'2022-05-12T16:10:38.6152270' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Groups] ([Id], [GroupName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (6, N'OJR', CAST(N'2022-05-12T09:11:40.4620000' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Groups] ([Id], [GroupName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (7, N'PNJ', CAST(N'2022-05-12T09:12:13.1110000' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Groups] ([Id], [GroupName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (8, N'PPM', CAST(N'2022-05-12T09:16:49.3800000' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Groups] ([Id], [GroupName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (9, N'PPM', CAST(N'2022-05-12T09:16:55.2910000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Groups] ([Id], [GroupName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (10, N'PPG', CAST(N'2022-05-12T09:17:33.1890000' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Groups] ([Id], [GroupName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (11, N'PP', CAST(N'2022-05-12T09:19:44.2960000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Groups] ([Id], [GroupName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (12, N'OKE', CAST(N'2022-05-24T11:18:01.0603319' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Groups] ([Id], [GroupName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (13, N'OKE', CAST(N'2022-05-24T16:15:23.1276563' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Groups] ([Id], [GroupName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (14, N'Test', CAST(N'2022-05-27T10:56:32.4389351' AS DateTime2), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
SET IDENTITY_INSERT [dbo].[officeLocations] ON 

INSERT [dbo].[officeLocations] ([Id], [Name], [Address], [Latitude], [Longitude], [Description]) VALUES (1, N'Plaza BNI BSD', N'Jl. Pahlawan Seribu No.5, Lengkong Gudang, Kec. Serpong, Kota Tangerang Selatan, Banten 15310', -6.2959092, 106.6659466, N'Tetap patuhi protokol kesehatan')
INSERT [dbo].[officeLocations] ([Id], [Name], [Address], [Latitude], [Longitude], [Description]) VALUES (2, N'Test', N'BSD', -6.2959092, 106.6659466, N'ok')
SET IDENTITY_INSERT [dbo].[officeLocations] OFF
GO
SET IDENTITY_INSERT [dbo].[Positions] ON 

INSERT [dbo].[Positions] ([Id], [PositionName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete], [Grade]) VALUES (10, NULL, CAST(N'2022-05-12T09:17:33.1890000' AS DateTime2), NULL, NULL, 1, 0)
INSERT [dbo].[Positions] ([Id], [PositionName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete], [Grade]) VALUES (11, N'admin', CAST(N'2022-05-24T04:53:13.7760000' AS DateTime2), NULL, NULL, 0, 10)
INSERT [dbo].[Positions] ([Id], [PositionName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete], [Grade]) VALUES (12, N'Pimkel', CAST(N'2022-05-24T04:57:35.7120000' AS DateTime2), NULL, NULL, 0, 0)
INSERT [dbo].[Positions] ([Id], [PositionName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete], [Grade]) VALUES (13, N'OK', CAST(N'2022-05-24T04:58:37.7370000' AS DateTime2), NULL, NULL, 1, 1)
INSERT [dbo].[Positions] ([Id], [PositionName], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete], [Grade]) VALUES (14, N'admin', CAST(N'2022-05-24T09:13:15.3480000' AS DateTime2), NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Positions] OFF
GO
SET IDENTITY_INSERT [dbo].[Sliders] ON 

INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (1, N'Test', N'path/to/slider', CAST(N'2022-05-24T03:12:57.7300000' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (2, N'', N'', CAST(N'2022-05-24T03:20:06.9630000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (3, N'', N'', CAST(N'2022-05-24T03:20:07.9460000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (4, N'', N'', CAST(N'2022-05-24T03:20:08.6980000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (5, N'', N'', CAST(N'2022-05-24T03:20:09.3800000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (6, N'', N'', CAST(N'2022-05-24T03:20:09.9810000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (7, N'', N'', CAST(N'2022-05-24T03:20:10.1420000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (8, N'', N'', CAST(N'2022-05-24T03:20:10.2820000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (9, N'', N'', CAST(N'2022-05-24T03:20:10.4150000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (10, N'', N'', CAST(N'2022-05-24T03:20:10.5430000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (11, N'', N'', CAST(N'2022-05-24T03:20:10.6770000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (12, N'', N'', CAST(N'2022-05-24T03:20:10.8220000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (13, N'', N'', CAST(N'2022-05-24T03:20:10.9430000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (14, N'', N'', CAST(N'2022-05-24T03:20:11.0700000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (15, N'', N'', CAST(N'2022-05-24T03:20:11.2120000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (16, N'', N'', CAST(N'2022-05-24T03:20:11.4290000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (17, N'', N'', CAST(N'2022-05-24T03:20:23.9850000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (18, N'Upload image', N'public\upload\slider/Slider - 18.png', CAST(N'2022-05-25T16:31:29.4381579' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (19, N'Test', N'public\upload\slider19_WhatsApp Image 2022-05-23 at 08.38.55.jpeg.jpeg', CAST(N'2022-05-25T16:34:41.8198576' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Sliders] ([Id], [Title], [Path], [CreateDate], [UpdateDate], [DeleteDate], [IsDelete]) VALUES (20, N'Test 2', N'public\upload\slider20_sql.png.png', CAST(N'2022-05-25T16:35:48.7169970' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Sliders] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AccountRoles_NPP]    Script Date: 13/06/2022 09:27:54 ******/
CREATE NONCLUSTERED INDEX [IX_AccountRoles_NPP] ON [dbo].[AccountRoles]
(
	[NPP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AccountRoles_RoleId]    Script Date: 13/06/2022 09:27:54 ******/
CREATE NONCLUSTERED INDEX [IX_AccountRoles_RoleId] ON [dbo].[AccountRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contents_CategoryId]    Script Date: 13/06/2022 09:27:54 ******/
CREATE NONCLUSTERED INDEX [IX_Contents_CategoryId] ON [dbo].[Contents]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employees_GroupId]    Script Date: 13/06/2022 09:27:54 ******/
CREATE NONCLUSTERED INDEX [IX_Employees_GroupId] ON [dbo].[Employees]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employees_PositionId]    Script Date: 13/06/2022 09:27:54 ******/
CREATE NONCLUSTERED INDEX [IX_Employees_PositionId] ON [dbo].[Employees]
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HistoryISOs_IsoSupportId]    Script Date: 13/06/2022 09:27:54 ******/
CREATE NONCLUSTERED INDEX [IX_HistoryISOs_IsoSupportId] ON [dbo].[HistoryISOs]
(
	[IsoSupportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ISOSupports_ISOCoreId]    Script Date: 13/06/2022 09:27:54 ******/
CREATE NONCLUSTERED INDEX [IX_ISOSupports_ISOCoreId] ON [dbo].[ISOSupports]
(
	[ISOCoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ISOSupports_RegisteredFormId]    Script Date: 13/06/2022 09:27:54 ******/
CREATE NONCLUSTERED INDEX [IX_ISOSupports_RegisteredFormId] ON [dbo].[ISOSupports]
(
	[RegisteredFormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Presences_EventId]    Script Date: 13/06/2022 09:27:54 ******/
CREATE NONCLUSTERED INDEX [IX_Presences_EventId] ON [dbo].[Presences]
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Presences_ExtUserId]    Script Date: 13/06/2022 09:27:54 ******/
CREATE NONCLUSTERED INDEX [IX_Presences_ExtUserId] ON [dbo].[Presences]
(
	[ExtUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Presences_NPP]    Script Date: 13/06/2022 09:27:54 ******/
CREATE NONCLUSTERED INDEX [IX_Presences_NPP] ON [dbo].[Presences]
(
	[NPP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RegisteredForms_ServiceId]    Script Date: 13/06/2022 09:27:54 ******/
CREATE NONCLUSTERED INDEX [IX_RegisteredForms_ServiceId] ON [dbo].[RegisteredForms]
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Schedulers_ZoomId]    Script Date: 13/06/2022 09:27:54 ******/
CREATE NONCLUSTERED INDEX [IX_Schedulers_ZoomId] ON [dbo].[Schedulers]
(
	[ZoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Schedulers_ZoomStatusId]    Script Date: 13/06/2022 09:27:54 ******/
CREATE NONCLUSTERED INDEX [IX_Schedulers_ZoomStatusId] ON [dbo].[Schedulers]
(
	[ZoomStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Service_GroupId]    Script Date: 13/06/2022 09:27:54 ******/
CREATE NONCLUSTERED INDEX [IX_Service_GroupId] ON [dbo].[Service]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DateOfBirth]
GO
ALTER TABLE [dbo].[Positions] ADD  DEFAULT ((0)) FOR [Grade]
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
ALTER TABLE [dbo].[Contents]  WITH CHECK ADD  CONSTRAINT [FK_Contents_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contents] CHECK CONSTRAINT [FK_Contents_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Groups_GroupId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Positions_PositionId] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Positions_PositionId]
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
ALTER TABLE [dbo].[RegisteredForms]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredForms_Service_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RegisteredForms] CHECK CONSTRAINT [FK_RegisteredForms_Service_ServiceId]
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
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Groups_GroupId]
GO
/****** Object:  StoredProcedure [dbo].[SP_RolesList]    Script Date: 13/06/2022 09:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RolesList]
	@Npp varchar(50)
AS
	SELECT ar.NPP as Npp, r.RoleName as RoleName FROM AccountRoles ar 
	join Roles r on ar.RoleId = r.Id
	where ar.NPP = @Npp
RETURN 0
GO
USE [master]
GO
ALTER DATABASE [MyOpr] SET  READ_WRITE 
GO
