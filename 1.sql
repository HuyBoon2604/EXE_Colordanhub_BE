USE [master]
GO
/****** Object:  Database [BookingDance]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE DATABASE [BookingDance]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookingDance', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BookingDance.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookingDance_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BookingDance_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BookingDance] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookingDance].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookingDance] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookingDance] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookingDance] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookingDance] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookingDance] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookingDance] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BookingDance] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookingDance] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookingDance] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookingDance] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookingDance] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookingDance] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookingDance] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookingDance] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookingDance] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookingDance] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookingDance] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookingDance] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookingDance] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookingDance] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookingDance] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BookingDance] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookingDance] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookingDance] SET  MULTI_USER 
GO
ALTER DATABASE [BookingDance] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookingDance] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookingDance] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookingDance] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookingDance] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookingDance] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BookingDance] SET QUERY_STORE = ON
GO
ALTER DATABASE [BookingDance] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BookingDance]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/27/2024 3:02:02 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 12/27/2024 3:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [nvarchar](50) NOT NULL,
	[RoleId] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[DateOfBirth] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreateAt] [datetime2](7) NULL,
	[UpdateAt] [datetime2](7) NULL,
	[DeleteAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 12/27/2024 3:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [nvarchar](50) NOT NULL,
	[AccountId] [nvarchar](50) NOT NULL,
	[StudioId] [nvarchar](50) NULL,
	[BookingDate] [nvarchar](max) NULL,
	[CheckIn] [nvarchar](max) NULL,
	[CheckOut] [nvarchar](max) NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[IsActive] [bit] NULL,
	[CreateAt] [datetime2](7) NULL,
	[UpdateAt] [datetime2](7) NULL,
	[DeleteAt] [datetime2](7) NULL,
	[ClassId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/27/2024 3:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [nvarchar](50) NOT NULL,
	[CategoryDescription] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NULL,
	[CreateAt] [datetime2](7) NULL,
	[UpdateAt] [datetime2](7) NULL,
	[DeleteAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassDances]    Script Date: 12/27/2024 3:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassDances](
	[Id] [nvarchar](50) NOT NULL,
	[StudioId] [nvarchar](50) NOT NULL,
	[ClassName] [nvarchar](max) NULL,
	[Pricing] [decimal](18, 2) NULL,
	[Description] [nvarchar](max) NULL,
	[TimeStart] [nvarchar](max) NULL,
	[TimeEnd] [nvarchar](max) NULL,
	[DateStart] [nvarchar](max) NULL,
	[DateEnd] [nvarchar](max) NULL,
 CONSTRAINT [PK_ClassDances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Histories]    Script Date: 12/27/2024 3:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Histories](
	[Id] [nvarchar](50) NOT NULL,
	[PaymentId] [nvarchar](50) NOT NULL,
	[Day] [nvarchar](max) NOT NULL,
	[Datetime] [datetime2](7) NOT NULL,
	[Pricing] [decimal](18, 2) NOT NULL,
	[IsActive] [bit] NULL,
	[CreateAt] [datetime2](7) NULL,
	[UpdateAt] [datetime2](7) NULL,
	[DeleteAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Histories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notis]    Script Date: 12/27/2024 3:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notis](
	[Id] [nvarchar](50) NOT NULL,
	[NotiDescription] [nvarchar](max) NOT NULL,
	[AccountId] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NULL,
	[CreateAt] [datetime2](7) NULL,
	[UpdateAt] [datetime2](7) NULL,
	[DeleteAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Notis] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/27/2024 3:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [nvarchar](50) NOT NULL,
	[BookingId] [nvarchar](50) NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NULL,
	[CreateAt] [datetime2](7) NULL,
	[UpdateAt] [datetime2](7) NULL,
	[DeleteAt] [datetime2](7) NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 12/27/2024 3:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [nvarchar](50) NOT NULL,
	[OrderId] [nvarchar](50) NOT NULL,
	[TransactionCode] [nvarchar](max) NOT NULL,
	[TransDate] [datetime2](7) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NULL,
	[CreateAt] [datetime2](7) NULL,
	[UpdateAt] [datetime2](7) NULL,
	[DeleteAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 12/27/2024 3:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [nvarchar](50) NOT NULL,
	[AccountId] [nvarchar](50) NOT NULL,
	[StudioId] [nvarchar](50) NOT NULL,
	[ReviewMessage] [nvarchar](max) NOT NULL,
	[Rating] [real] NOT NULL,
	[ReviewDate] [datetime2](7) NOT NULL,
	[IsActive] [bit] NULL,
	[CreateAt] [datetime2](7) NULL,
	[UpdateAt] [datetime2](7) NULL,
	[DeleteAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 12/27/2024 3:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](50) NOT NULL,
	[RoleName] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NULL,
	[CreateAt] [datetime2](7) NULL,
	[UpdateAt] [datetime2](7) NULL,
	[DeleteAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sizes]    Script Date: 12/27/2024 3:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sizes](
	[Id] [nvarchar](50) NOT NULL,
	[SizeDescription] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Sizes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Studios]    Script Date: 12/27/2024 3:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Studios](
	[Id] [nvarchar](50) NOT NULL,
	[AccountId] [nvarchar](50) NULL,
	[CategoryId] [nvarchar](50) NULL,
	[Pricing] [decimal](18, 2) NULL,
	[StudioName] [nvarchar](max) NULL,
	[StudioAddress] [nvarchar](max) NULL,
	[StudioDescription] [nvarchar](max) NULL,
	[ImageStudio] [nvarchar](max) NULL,
	[RatingId] [nvarchar](max) NULL,
	[StudioSize] [nvarchar](max) NULL,
	[Capacity] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreateAt] [datetime2](7) NULL,
	[UpdateAt] [datetime2](7) NULL,
	[DeleteAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Studios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vouchers]    Script Date: 12/27/2024 3:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vouchers](
	[Id] [nvarchar](50) NOT NULL,
	[AccountId] [nvarchar](50) NOT NULL,
	[StudioId] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Status] [bit] NOT NULL,
	[IsActive] [bit] NULL,
	[CreateAt] [datetime2](7) NULL,
	[UpdateAt] [datetime2](7) NULL,
	[DeleteAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Vouchers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241206125701_FIXdataBookingStudioAccount', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241206130200_deleteTableChat', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241207081408_allowNuLL', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241208094501_fix_db_Phone', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241210071916_fix_time_date_booking', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241210081349_fix_time_date_booking_2', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241210111910_fixStrinGDATA', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241217152943_add_data_Order_description_amount', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241220045609_deleteAmountInOrderTable', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241220054218_AddClassDance', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241222133216_fix_data_Payment', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241222134359_fix_data_Status_string', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241222144444_fix_data_NotNull_Booking', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241222152119_fix_data_Null_Booking', N'8.0.6')
GO
INSERT [dbo].[Accounts] ([Id], [RoleId], [UserName], [Password], [Email], [Phone], [DateOfBirth], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'AC3b58a', N'3', N'admin', N'$2a$11$wSvL0D6LzZF1ouvBBevmje2mH1xWVmv.FjPnVsdtta5neVxuPMF5O', N'admin', NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [UserName], [Password], [Email], [Phone], [DateOfBirth], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'AC3ba67', N'1', N'a', N'$2a$11$G4zVy4IkkFROZN5UYj3zOuz3Ancb0WnR3/.fIZaNEogTmYrgzRt9a', N'a', NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [UserName], [Password], [Email], [Phone], [DateOfBirth], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'AC4ec18', N'1', N'customer1', N'$2a$11$kYNIQ2dT9PT3KkavDLrrWeBkatjuherI9x/.i15MYdSnJWnuLPcl6', N'customer1', NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [UserName], [Password], [Email], [Phone], [DateOfBirth], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'ACc83db', N'2', N'studio3', N'$2a$11$qJt/DwJAcKlyNHtiYnrcUun1gy6q7gX.NmnJiVm6NRBQ/51qXe6Bm', N'studio3', NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [UserName], [Password], [Email], [Phone], [DateOfBirth], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'ACe3ca6', N'1', N'customer2', N'$2a$11$98uJmoiPObVXyNjScv864.rgJY4.t9nL3dlJN/ySpXuCPBBZtzDii', N'customer2', NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [UserName], [Password], [Email], [Phone], [DateOfBirth], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'ACf59fe', N'2', N'studio2', N'$2a$11$.FO4lyiFWjwr1GHuVgc2NeXJPlb7HV0VIxkeZCBNbjmHpGIIEZjQe', N'studio2', NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[Bookings] ([Id], [AccountId], [StudioId], [BookingDate], [CheckIn], [CheckOut], [TotalPrice], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [ClassId]) VALUES (N'0c2a7798-a1e5-4c58-878f-6208b552d01c', N'AC3b58a', N'stu1', N'string', N'string', N'string', CAST(3330.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bookings] ([Id], [AccountId], [StudioId], [BookingDate], [CheckIn], [CheckOut], [TotalPrice], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [ClassId]) VALUES (N'2d72831d-86a3-402d-ac30-f0b7986ef48b', N'AC4ec18', N'stu1', N'12/08', N'12', N'13', CAST(100000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bookings] ([Id], [AccountId], [StudioId], [BookingDate], [CheckIn], [CheckOut], [TotalPrice], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [ClassId]) VALUES (N'52b53', N'AC4ec18', NULL, N'string', N'string', N'string', CAST(3000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, N'class1')
INSERT [dbo].[Bookings] ([Id], [AccountId], [StudioId], [BookingDate], [CheckIn], [CheckOut], [TotalPrice], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [ClassId]) VALUES (N'56d55534-9edc-49bc-908f-6701735fc247', N'ACe3ca6', N'stu1', N'string', N'string', N'string', CAST(3000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bookings] ([Id], [AccountId], [StudioId], [BookingDate], [CheckIn], [CheckOut], [TotalPrice], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [ClassId]) VALUES (N'7fcd6', N'AC4ec18', N'stu1', N'string', N'string', N'string', CAST(3000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bookings] ([Id], [AccountId], [StudioId], [BookingDate], [CheckIn], [CheckOut], [TotalPrice], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [ClassId]) VALUES (N'980b3781-1e1f-47d3-bc1e-a22b76e77851', N'ACc83db', N'stu2', N'string', N'string', N'string', CAST(220.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bookings] ([Id], [AccountId], [StudioId], [BookingDate], [CheckIn], [CheckOut], [TotalPrice], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [ClassId]) VALUES (N'98487620-0966-4a98-9cf7-327bb32b5a67', N'ACe3ca6', N'stu1', N'string', N'string', N'string', CAST(2000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bookings] ([Id], [AccountId], [StudioId], [BookingDate], [CheckIn], [CheckOut], [TotalPrice], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [ClassId]) VALUES (N'9bf513fb-0383-47d3-ba07-df5dc1f5516c', N'AC4ec18', N'stu1', N'string', N'string', N'string', CAST(2000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bookings] ([Id], [AccountId], [StudioId], [BookingDate], [CheckIn], [CheckOut], [TotalPrice], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [ClassId]) VALUES (N'ads', N'AC4ec18', N'stu2', N'sdfd', N'sdf', N'sdfsd', CAST(4000.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, N'class1')
INSERT [dbo].[Bookings] ([Id], [AccountId], [StudioId], [BookingDate], [CheckIn], [CheckOut], [TotalPrice], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [ClassId]) VALUES (N'BK3bc17', N'AC4ec18', N'stu1', N'2024-12-10 00:00:00.0000000', N'08:17:53.4250000', N'08:18:53.4250000', CAST(123000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bookings] ([Id], [AccountId], [StudioId], [BookingDate], [CheckIn], [CheckOut], [TotalPrice], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [ClassId]) VALUES (N'c49a14ec-3281-4f26-82cb-fd0be1d6b098', N'AC4ec18', N'stu1', N'string', N'string', N'string', CAST(2230.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bookings] ([Id], [AccountId], [StudioId], [BookingDate], [CheckIn], [CheckOut], [TotalPrice], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [ClassId]) VALUES (N'c7259f2e-9498-4947-93db-3182013c60d0', N'AC3b58a', N'stu2', N'string', N'string', N'string', CAST(220.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bookings] ([Id], [AccountId], [StudioId], [BookingDate], [CheckIn], [CheckOut], [TotalPrice], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [ClassId]) VALUES (N'dbe7f5d8-5d33-4f00-ae73-156e32d19b59', N'AC4ec18', N'stu2', N'string', N'string', N'string', CAST(3000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bookings] ([Id], [AccountId], [StudioId], [BookingDate], [CheckIn], [CheckOut], [TotalPrice], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [ClassId]) VALUES (N'gdfgfd', N'AC4ec18', NULL, N'ádas', N'ádas', N'ádas', CAST(3000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, N'class1')
GO
INSERT [dbo].[ClassDances] ([Id], [StudioId], [ClassName], [Pricing], [Description], [TimeStart], [TimeEnd], [DateStart], [DateEnd]) VALUES (N'class1', N'stu1', N'Master TikTok Dance', CAST(10000.00 AS Decimal(18, 2)), N'sadddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd', N'9:00', N'11:00', N'12/12/2024', N'12/03/2025')
INSERT [dbo].[ClassDances] ([Id], [StudioId], [ClassName], [Pricing], [Description], [TimeStart], [TimeEnd], [DateStart], [DateEnd]) VALUES (N'class2', N'stu2', N'Dance Practice HipHop', CAST(110000.00 AS Decimal(18, 2)), N'alskdjaldasfalfhjlefhlwjliqwjfliqwjfliqwjfi', N'9:00', N'11:00', N'12/12/2024', N'12/03/2025')
GO
INSERT [dbo].[Orders] ([Id], [BookingId], [OrderDate], [Status], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [Description]) VALUES (N'ashdq2', N'0c2a7798-a1e5-4c58-878f-6208b552d01c', CAST(N'2024-12-11T14:27:10.5160518' AS DateTime2), N'1', NULL, NULL, NULL, NULL, N'test tien')
INSERT [dbo].[Orders] ([Id], [BookingId], [OrderDate], [Status], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [Description]) VALUES (N'Ord00bae', N'52b53', CAST(N'2024-12-22T22:24:41.1581778' AS DateTime2), N'Waiting', NULL, NULL, NULL, NULL, N'Account da Booking success Studio Name ')
INSERT [dbo].[Orders] ([Id], [BookingId], [OrderDate], [Status], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [Description]) VALUES (N'Ord4ab09', N'52b53', CAST(N'2024-12-23T16:57:29.2043888' AS DateTime2), N'Waiting', NULL, NULL, NULL, NULL, N'Account AC4ec18 Booking Success Studio: ')
INSERT [dbo].[Orders] ([Id], [BookingId], [OrderDate], [Status], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [Description]) VALUES (N'Ord65238', N'c49a14ec-3281-4f26-82cb-fd0be1d6b098', CAST(N'2024-12-22T20:47:39.2257015' AS DateTime2), N'Pending', NULL, NULL, NULL, NULL, N'Account da Booking success Studio Name ')
INSERT [dbo].[Orders] ([Id], [BookingId], [OrderDate], [Status], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [Description]) VALUES (N'Ordb5a09', N'dbe7f5d8-5d33-4f00-ae73-156e32d19b59', CAST(N'2024-12-22T20:50:16.9459557' AS DateTime2), N'Waiting', NULL, NULL, NULL, NULL, N'Account da Booking success Studio Name ')
INSERT [dbo].[Orders] ([Id], [BookingId], [OrderDate], [Status], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [Description]) VALUES (N'Ordb67a0', N'9bf513fb-0383-47d3-ba07-df5dc1f5516c', CAST(N'2024-12-20T11:59:47.5819953' AS DateTime2), N'1', NULL, NULL, NULL, NULL, N'Your Order')
INSERT [dbo].[Orders] ([Id], [BookingId], [OrderDate], [Status], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [Description]) VALUES (N'Ordcff86', N'0c2a7798-a1e5-4c58-878f-6208b552d01c', CAST(N'2024-12-22T22:41:04.6405933' AS DateTime2), N'Waiting', NULL, NULL, NULL, NULL, N'AccountAC3b58aBooking Success Studio:stu1')
INSERT [dbo].[Orders] ([Id], [BookingId], [OrderDate], [Status], [IsActive], [CreateAt], [UpdateAt], [DeleteAt], [Description]) VALUES (N'order2', N'56d55534-9edc-49bc-908f-6701735fc247', CAST(N'2024-12-20T12:00:00.0000000' AS DateTime2), N'1', NULL, NULL, NULL, NULL, N'order2test')
GO
INSERT [dbo].[Payments] ([Id], [OrderId], [TransactionCode], [TransDate], [Status], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'235615e5-68e2-4a93-bd97-8d4066ff9ef5', N'Ordb5a09', N'1734875430', CAST(N'2024-12-22T13:50:30.7549232' AS DateTime2), N'Pending', NULL, NULL, NULL, NULL)
INSERT [dbo].[Payments] ([Id], [OrderId], [TransactionCode], [TransDate], [Status], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'6426b2bc-3cc6-40a1-8eca-d1c2c340f744', N'order2', N'1734875086', CAST(N'2024-12-22T13:44:46.9422732' AS DateTime2), N'Waiting', NULL, NULL, NULL, NULL)
INSERT [dbo].[Payments] ([Id], [OrderId], [TransactionCode], [TransDate], [Status], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'88fffcea-d246-4e8c-8cc0-b959421f95e1', N'Ord65238', N'1734875279', CAST(N'2024-12-22T13:47:59.5346665' AS DateTime2), N'Waiting', NULL, NULL, NULL, NULL)
INSERT [dbo].[Payments] ([Id], [OrderId], [TransactionCode], [TransDate], [Status], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'90ee7fd7-ea41-4cf2-adc4-4b1101ece50e', N'Ordb5a09', N'1734876161', CAST(N'2024-12-22T14:02:41.7468932' AS DateTime2), N'Waiting', NULL, NULL, NULL, NULL)
INSERT [dbo].[Payments] ([Id], [OrderId], [TransactionCode], [TransDate], [Status], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'a9a1cffd-c5e4-499a-8336-9431f044ebe7', N'Ord00bae', N'1734881098', CAST(N'2024-12-22T15:24:58.4904553' AS DateTime2), N'Waiting', NULL, NULL, NULL, NULL)
INSERT [dbo].[Payments] ([Id], [OrderId], [TransactionCode], [TransDate], [Status], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'd00ee739-8772-4f9e-9123-431a23895d9d', N'ashdq2', N'1734874565', CAST(N'2024-12-22T13:36:05.6864775' AS DateTime2), N'0', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Roles] ([Id], [RoleName], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'1', N'Customer', 1, NULL, NULL, NULL)
INSERT [dbo].[Roles] ([Id], [RoleName], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'2', N'Studio', 1, NULL, NULL, NULL)
INSERT [dbo].[Roles] ([Id], [RoleName], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'3', N'Admin', 1, NULL, NULL, NULL)
GO
INSERT [dbo].[Studios] ([Id], [AccountId], [CategoryId], [Pricing], [StudioName], [StudioAddress], [StudioDescription], [ImageStudio], [RatingId], [StudioSize], [Capacity], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'stu1', N'ACf59fe', NULL, CAST(200000.00 AS Decimal(18, 2)), N'ABC STDUIO', N'123 Nguyen Trai Quan 1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Studios] ([Id], [AccountId], [CategoryId], [Pricing], [StudioName], [StudioAddress], [StudioDescription], [ImageStudio], [RatingId], [StudioSize], [Capacity], [IsActive], [CreateAt], [UpdateAt], [DeleteAt]) VALUES (N'stu2', N'ACc83db', NULL, CAST(300000.00 AS Decimal(18, 2)), N'STUDIO VIP', N'123 Nguyen Trai Quan 1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Accounts_RoleId]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_Accounts_RoleId] ON [dbo].[Accounts]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Bookings_AccountId]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bookings_AccountId] ON [dbo].[Bookings]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Bookings_ClassId]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bookings_ClassId] ON [dbo].[Bookings]
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Bookings_StudioId]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bookings_StudioId] ON [dbo].[Bookings]
(
	[StudioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ClassDances_StudioId]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClassDances_StudioId] ON [dbo].[ClassDances]
(
	[StudioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Histories_PaymentId]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_Histories_PaymentId] ON [dbo].[Histories]
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Notis_AccountId]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_Notis_AccountId] ON [dbo].[Notis]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Orders_BookingId]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_BookingId] ON [dbo].[Orders]
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Payments_OrderId]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_OrderId] ON [dbo].[Payments]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Reviews_AccountId]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reviews_AccountId] ON [dbo].[Reviews]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Reviews_StudioId]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reviews_StudioId] ON [dbo].[Reviews]
(
	[StudioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Studios_AccountId]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_Studios_AccountId] ON [dbo].[Studios]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Studios_CategoryId]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_Studios_CategoryId] ON [dbo].[Studios]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Vouchers_AccountId]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_Vouchers_AccountId] ON [dbo].[Vouchers]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Vouchers_StudioId]    Script Date: 12/27/2024 3:02:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_Vouchers_StudioId] ON [dbo].[Vouchers]
(
	[StudioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (N'') FOR [Description]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Roles_RoleId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Accounts_AccountId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_ClassDances_ClassId] FOREIGN KEY([ClassId])
REFERENCES [dbo].[ClassDances] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_ClassDances_ClassId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Studios_StudioId] FOREIGN KEY([StudioId])
REFERENCES [dbo].[Studios] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Studios_StudioId]
GO
ALTER TABLE [dbo].[ClassDances]  WITH CHECK ADD  CONSTRAINT [FK_ClassDances_Studios_StudioId] FOREIGN KEY([StudioId])
REFERENCES [dbo].[Studios] ([Id])
GO
ALTER TABLE [dbo].[ClassDances] CHECK CONSTRAINT [FK_ClassDances_Studios_StudioId]
GO
ALTER TABLE [dbo].[Histories]  WITH CHECK ADD  CONSTRAINT [FK_Histories_Payments_PaymentId] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payments] ([Id])
GO
ALTER TABLE [dbo].[Histories] CHECK CONSTRAINT [FK_Histories_Payments_PaymentId]
GO
ALTER TABLE [dbo].[Notis]  WITH CHECK ADD  CONSTRAINT [FK_Notis_Accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Notis] CHECK CONSTRAINT [FK_Notis_Accounts_AccountId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Bookings_BookingId] FOREIGN KEY([BookingId])
REFERENCES [dbo].[Bookings] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Bookings_BookingId]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Orders_OrderId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Accounts_AccountId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Studios_StudioId] FOREIGN KEY([StudioId])
REFERENCES [dbo].[Studios] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Studios_StudioId]
GO
ALTER TABLE [dbo].[Studios]  WITH CHECK ADD  CONSTRAINT [FK_Studios_Accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Studios] CHECK CONSTRAINT [FK_Studios_Accounts_AccountId]
GO
ALTER TABLE [dbo].[Studios]  WITH CHECK ADD  CONSTRAINT [FK_Studios_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Studios] CHECK CONSTRAINT [FK_Studios_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Vouchers]  WITH CHECK ADD  CONSTRAINT [FK_Vouchers_Accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Vouchers] CHECK CONSTRAINT [FK_Vouchers_Accounts_AccountId]
GO
ALTER TABLE [dbo].[Vouchers]  WITH CHECK ADD  CONSTRAINT [FK_Vouchers_Studios_StudioId] FOREIGN KEY([StudioId])
REFERENCES [dbo].[Studios] ([Id])
GO
ALTER TABLE [dbo].[Vouchers] CHECK CONSTRAINT [FK_Vouchers_Studios_StudioId]
GO
USE [master]
GO
ALTER DATABASE [BookingDance] SET  READ_WRITE 
GO
