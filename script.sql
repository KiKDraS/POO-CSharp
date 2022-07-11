USE [master]
GO
/****** Object:  Database [pokemon]    Script Date: 11/7/2022 17:46:29 ******/
CREATE DATABASE [pokemon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'pokemon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\pokemon.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'pokemon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\pokemon_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [pokemon] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [pokemon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [pokemon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [pokemon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [pokemon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [pokemon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [pokemon] SET ARITHABORT OFF 
GO
ALTER DATABASE [pokemon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [pokemon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [pokemon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [pokemon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [pokemon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [pokemon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [pokemon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [pokemon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [pokemon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [pokemon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [pokemon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [pokemon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [pokemon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [pokemon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [pokemon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [pokemon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [pokemon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [pokemon] SET RECOVERY FULL 
GO
ALTER DATABASE [pokemon] SET  MULTI_USER 
GO
ALTER DATABASE [pokemon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [pokemon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [pokemon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [pokemon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [pokemon] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [pokemon] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'pokemon', N'ON'
GO
ALTER DATABASE [pokemon] SET QUERY_STORE = OFF
GO
USE [pokemon]
GO
/****** Object:  Table [dbo].[entrenadores]    Script Date: 11/7/2022 17:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[entrenadores](
	[entrenador_id] [int] IDENTITY(1,1) NOT NULL,
	[entrenador_nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_entrenadores] PRIMARY KEY CLUSTERED 
(
	[entrenador_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pokedex]    Script Date: 11/7/2022 17:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pokedex](
	[pokemon_id] [int] IDENTITY(1,1) NOT NULL,
	[entrenador_id] [int] NOT NULL,
	[pokemon_base_id] [int] NOT NULL,
	[pokemon_nombre] [nvarchar](50) NULL,
	[pokemon_vida] [int] NOT NULL,
	[pokemon_exp] [int] NOT NULL,
	[is_aviable] [bit] NOT NULL,
	[is_active] [bit] NOT NULL,
 CONSTRAINT [PK_pokedex] PRIMARY KEY CLUSTERED 
(
	[pokemon_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pokemons_base]    Script Date: 11/7/2022 17:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pokemons_base](
	[pokemon_base_id] [int] IDENTITY(1,1) NOT NULL,
	[pokemon_familia] [nvarchar](50) NOT NULL,
	[vida_base] [int] NOT NULL,
	[golpe_base] [int] NOT NULL,
	[etapa_actual] [int] NOT NULL,
 CONSTRAINT [PK_pokemons_base] PRIMARY KEY CLUSTERED 
(
	[pokemon_base_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[pokedex]  WITH CHECK ADD  CONSTRAINT [FK_pokedex_entrenadores] FOREIGN KEY([entrenador_id])
REFERENCES [dbo].[entrenadores] ([entrenador_id])
GO
ALTER TABLE [dbo].[pokedex] CHECK CONSTRAINT [FK_pokedex_entrenadores]
GO
ALTER TABLE [dbo].[pokedex]  WITH CHECK ADD  CONSTRAINT [FK_pokedex_pokemons_base] FOREIGN KEY([pokemon_base_id])
REFERENCES [dbo].[pokemons_base] ([pokemon_base_id])
GO
ALTER TABLE [dbo].[pokedex] CHECK CONSTRAINT [FK_pokedex_pokemons_base]
GO
USE [master]
GO
ALTER DATABASE [pokemon] SET  READ_WRITE 
GO
