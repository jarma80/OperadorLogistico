USE [master]
GO
/****** Object:  Database [OperadorLogistico]    Script Date: 22/06/2020 06:28:02 p. m. ******/
CREATE DATABASE [OperadorLogistico]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OperadorLogistico', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\OperadorLogistico.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OperadorLogistico_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\OperadorLogistico_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OperadorLogistico] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OperadorLogistico].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OperadorLogistico] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OperadorLogistico] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OperadorLogistico] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OperadorLogistico] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OperadorLogistico] SET ARITHABORT OFF 
GO
ALTER DATABASE [OperadorLogistico] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OperadorLogistico] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OperadorLogistico] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OperadorLogistico] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OperadorLogistico] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OperadorLogistico] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OperadorLogistico] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OperadorLogistico] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OperadorLogistico] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OperadorLogistico] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OperadorLogistico] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OperadorLogistico] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OperadorLogistico] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OperadorLogistico] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OperadorLogistico] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OperadorLogistico] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OperadorLogistico] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OperadorLogistico] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OperadorLogistico] SET  MULTI_USER 
GO
ALTER DATABASE [OperadorLogistico] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OperadorLogistico] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OperadorLogistico] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OperadorLogistico] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OperadorLogistico] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OperadorLogistico] SET QUERY_STORE = OFF
GO
USE [OperadorLogistico]
GO
/****** Object:  Table [dbo].[OperadoresLogisticos]    Script Date: 22/06/2020 06:28:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperadoresLogisticos](
	[idUser] [nvarchar](30) NOT NULL,
	[userName] [nvarchar](25) NOT NULL,
	[textPass] [nvarchar](30) NOT NULL,
	[fistName] [nvarchar](30) NOT NULL,
	[lastName] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Telefono] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationalStatus]    Script Date: 22/06/2020 06:28:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationalStatus](
	[idOperationalStatus] [smallint] NOT NULL,
	[Status] [varchar](35) NOT NULL,
 CONSTRAINT [PK_OperationalStatus] PRIMARY KEY CLUSTERED 
(
	[idOperationalStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operations]    Script Date: 22/06/2020 06:28:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operations](
	[idOperation] [varchar](15) NOT NULL,
	[idUser] [varchar](30) NOT NULL,
	[idOperationType] [smallint] NOT NULL,
	[idOperationStatus] [smallint] NOT NULL,
	[operationDate] [datetime] NOT NULL,
	[numOp] [int] IDENTITY(1,1) NOT NULL,
	[operationPercent] [varchar](3) NOT NULL,
	[idLogisticOperator] [varchar](30) NOT NULL,
	[invoiceFilePath] [varchar](75) NULL,
 CONSTRAINT [PK_Operations] PRIMARY KEY CLUSTERED 
(
	[idOperation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationType]    Script Date: 22/06/2020 06:28:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationType](
	[idOperationType] [smallint] NOT NULL,
	[Type] [varchar](20) NOT NULL,
 CONSTRAINT [PK_OperationType] PRIMARY KEY CLUSTERED 
(
	[idOperationType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22/06/2020 06:28:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[idUser] [nvarchar](30) NOT NULL,
	[userName] [nvarchar](25) NOT NULL,
	[textPass] [nvarchar](30) NOT NULL,
	[fistName] [nvarchar](30) NOT NULL,
	[lastName] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Telefono] [bigint] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[OperadoresLogisticos] ([idUser], [userName], [textPass], [fistName], [lastName], [Name], [Email], [Telefono]) VALUES (N'GUFK900126MHGRTR09', N'admin', N'admin', N'Gutierrez', N'Fragoso', N'Karina', N'kgutierrez@itess.edu.mx', 7715555555)
GO
INSERT [dbo].[OperationalStatus] ([idOperationalStatus], [Status]) VALUES (1, N'Carga')
GO
INSERT [dbo].[OperationalStatus] ([idOperationalStatus], [Status]) VALUES (2, N'Transito
')
GO
INSERT [dbo].[OperationalStatus] ([idOperationalStatus], [Status]) VALUES (3, N'Entrega')
GO
INSERT [dbo].[OperationalStatus] ([idOperationalStatus], [Status]) VALUES (4, N'Revalidación')
GO
INSERT [dbo].[OperationalStatus] ([idOperationalStatus], [Status]) VALUES (5, N'Desconsolidación')
GO
INSERT [dbo].[OperationalStatus] ([idOperationalStatus], [Status]) VALUES (6, N'Previo')
GO
INSERT [dbo].[OperationalStatus] ([idOperationalStatus], [Status]) VALUES (7, N'Programación de Despacho
')
GO
INSERT [dbo].[OperationalStatus] ([idOperationalStatus], [Status]) VALUES (8, N'Despacho')
GO
INSERT [dbo].[OperationalStatus] ([idOperationalStatus], [Status]) VALUES (9, N'Facturación')
GO
SET IDENTITY_INSERT [dbo].[Operations] ON 
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_001', N'GABJ800126HHGRTR09', 1, 2, CAST(N'2020-04-28T19:24:41.260' AS DateTime), 1, N'75', N'GUFK900126MHGRTR09', NULL)
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_002', N'GABJ800126HHGRTR09', 1, 9, CAST(N'2020-04-28T21:06:12.520' AS DateTime), 2, N'100', N'GUFK900126MHGRTR09', N'CYL_2020_002-cnn-02.png')
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_003', N'GABJ800126HHGRTR09', 1, 9, CAST(N'2020-04-28T21:06:22.203' AS DateTime), 3, N'100', N'GUFK900126MHGRTR09', N'CYL_2020_003-2016Loncomilla.pdf')
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_004', N'GABJ800126HHGRTR09', 2, 9, CAST(N'2020-05-01T17:43:45.507' AS DateTime), 4, N'100', N'GUFK900126MHGRTR09', N'CYL_2020_004-Arduino-to-ESP8266.jpg')
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_005', N'GABJ800126HHGRTR09', 2, 9, CAST(N'2020-05-02T21:46:00.903' AS DateTime), 5, N'100', N'GUFK900126MHGRTR09', N'CYL_2020_005-PROYECTOS.xlsx')
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_006', N'GABJ800126HHGRTR09', 1, 7, CAST(N'2020-05-03T21:35:07.087' AS DateTime), 6, N'50', N'GUFK900126MHGRTR09', NULL)
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_007', N'GABJ800126HHGRTR09', 1, 1, CAST(N'2020-05-03T23:47:54.640' AS DateTime), 7, N'10', N'GUFK900126MHGRTR09', NULL)
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_008', N'VECA810822HHGRTB65', 2, 4, CAST(N'2020-05-03T23:52:19.193' AS DateTime), 8, N'25', N'GUFK900126MHGRTR09', NULL)
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_009', N'BACS601108MHGRTA85', 1, 4, CAST(N'2020-05-04T18:05:42.107' AS DateTime), 9, N'10', N'GUFK900126MHGRTR09', NULL)
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_010', N'GOFJ901530HHGRTR01', 1, 7, CAST(N'2020-05-04T22:32:42.380' AS DateTime), 10, N'50', N'GUFK900126MHGRTR09', NULL)
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_011', N'RIPA850516HHGRTR08', 1, 4, CAST(N'2020-05-05T15:31:20.310' AS DateTime), 11, N'10', N'GUFK900126MHGRTR09', NULL)
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_012', N'GABJ800126HHGRTR09', 1, 4, CAST(N'2020-05-05T16:37:38.583' AS DateTime), 12, N'10', N'GUFK900126MHGRTR09', NULL)
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_013', N'GABJ800126HHGRTR09', 1, 9, CAST(N'2020-05-05T16:50:14.903' AS DateTime), 13, N'100', N'GUFK900126MHGRTR09', N'CYL_2020_013-examen.png')
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_014', N'VASO960211HHGRTR04', 2, 2, CAST(N'2020-05-05T16:58:08.430' AS DateTime), 14, N'50', N'GUFK900126MHGRTR09', NULL)
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_015', N'VASO960211HHGRTR04', 1, 4, CAST(N'2020-05-05T17:04:07.467' AS DateTime), 15, N'10', N'GUFK900126MHGRTR09', NULL)
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_016', N'PEMJ651102HHGRTR09', 1, 9, CAST(N'2020-05-12T20:16:33.217' AS DateTime), 16, N'100', N'GUFK900126MHGRTR09', NULL)
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_017', N'PEMJ651102HHGRTR09', 2, 1, CAST(N'2020-05-12T20:18:09.610' AS DateTime), 17, N'25', N'GUFK900126MHGRTR09', NULL)
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_018', N'GABJ800126HHGRTR09', 1, 9, CAST(N'2020-05-17T18:20:25.430' AS DateTime), 18, N'100', N'GUFK900126MHGRTR09', NULL)
GO
INSERT [dbo].[Operations] ([idOperation], [idUser], [idOperationType], [idOperationStatus], [operationDate], [numOp], [operationPercent], [idLogisticOperator], [invoiceFilePath]) VALUES (N'CYL_2020_019', N'COGR751223HHGRTR04', 1, 4, CAST(N'2020-06-22T17:39:48.767' AS DateTime), 19, N'10', N'GUFK900126MHGRTR09', NULL)
GO
SET IDENTITY_INSERT [dbo].[Operations] OFF
GO
INSERT [dbo].[OperationType] ([idOperationType], [Type]) VALUES (1, N'Aduana-Logística')
GO
INSERT [dbo].[OperationType] ([idOperationType], [Type]) VALUES (2, N'Logística')
GO
INSERT [dbo].[Users] ([idUser], [userName], [textPass], [fistName], [lastName], [Name], [Email], [Telefono]) VALUES (N'BACS601108MHGRTA85', N'sebe', N'ninguno', N'Bautista', N'Cruz', N'Sebera', N'bacs60@gmail.com', 7735555555)
GO
INSERT [dbo].[Users] ([idUser], [userName], [textPass], [fistName], [lastName], [Name], [Email], [Telefono]) VALUES (N'COGR751223HHGRTR04', N'rcortezg', N'NOTIENE', N'Cortéz', N'Gonzalez', N'Román', N'rcortezg@gmail.com', 88888888)
GO
INSERT [dbo].[Users] ([idUser], [userName], [textPass], [fistName], [lastName], [Name], [Email], [Telefono]) VALUES (N'GABJ800126HHGRTR09', N'armando', N'sinpassword', N'García', N'Bautista', N'Jorge Armando', N'jgarciab@itsoeh.edu.mx', 7731798374)
GO
INSERT [dbo].[Users] ([idUser], [userName], [textPass], [fistName], [lastName], [Name], [Email], [Telefono]) VALUES (N'GOFJ901530HHGRTR01', N'jgonzalez', N'notiene', N'González', N'Fuentes', N'Juan Carlos', N'jc-bass@hotmail.com', 7711111111)
GO
INSERT [dbo].[Users] ([idUser], [userName], [textPass], [fistName], [lastName], [Name], [Email], [Telefono]) VALUES (N'PEMJ651102HHGRTR09', N'jperez', N'notiene', N'Pérez', N'Mota', N'Jose', N'jperz@hotmail.com', 773888888)
GO
INSERT [dbo].[Users] ([idUser], [userName], [textPass], [fistName], [lastName], [Name], [Email], [Telefono]) VALUES (N'RIPA850516HHGRTR08', N'alriosp', N'notiene', N'Ríos', N'Pérez', N'Alberto', N'alriosp@hotmail.com', 7702222222)
GO
INSERT [dbo].[Users] ([idUser], [userName], [textPass], [fistName], [lastName], [Name], [Email], [Telefono]) VALUES (N'VASO960211HHGRTR04', N'oscarvs', N'notiene', N'Vázquez', N'Sánchez', N'Oscar', N'oscarinvs96@gmail.com', 7112323212)
GO
INSERT [dbo].[Users] ([idUser], [userName], [textPass], [fistName], [lastName], [Name], [Email], [Telefono]) VALUES (N'VECA810822HHGRTB65', N'chido', N'notiene', N'Velázquez', N'Escamilla', N'Arminda', N'prince999@hotmail.com', 7714444444)
GO
USE [master]
GO
ALTER DATABASE [OperadorLogistico] SET  READ_WRITE 
GO
