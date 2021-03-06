USE [master]
GO
/****** Object:  Database [Ventas]    Script Date: 21/05/2017 22:45:24 ******/
CREATE DATABASE [Ventas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ventas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.NAZARETH\MSSQL\DATA\Ventas.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Ventas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.NAZARETH\MSSQL\DATA\Ventas_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Ventas] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ventas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ventas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ventas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ventas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ventas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ventas] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ventas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ventas] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Ventas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ventas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ventas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ventas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ventas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ventas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ventas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ventas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ventas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ventas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ventas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ventas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ventas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ventas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ventas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ventas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ventas] SET RECOVERY FULL 
GO
ALTER DATABASE [Ventas] SET  MULTI_USER 
GO
ALTER DATABASE [Ventas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ventas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ventas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ventas] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Ventas', N'ON'
GO
USE [Ventas]
GO
/****** Object:  Table [dbo].[CEstadoArticulo]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CEstadoArticulo](
	[IdEstado] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](256) NOT NULL,
 CONSTRAINT [PK_CEstadoArticulo] PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CMarcaVehiculo]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CMarcaVehiculo](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](256) NOT NULL,
 CONSTRAINT [PK_CMarcaVehiculo] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CPeriodoPago]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CPeriodoPago](
	[IdPeriodoPago] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](256) NOT NULL,
 CONSTRAINT [PK_CPeriodoPago] PRIMARY KEY CLUSTERED 
(
	[IdPeriodoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CTipoArticulo]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CTipoArticulo](
	[IdTipoArticulo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](256) NOT NULL,
 CONSTRAINT [PK_CTipoArticulo] PRIMARY KEY CLUSTERED 
(
	[IdTipoArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CTipoPago]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CTipoPago](
	[IdTipoPago] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](256) NOT NULL,
 CONSTRAINT [PK_CTipoPago] PRIMARY KEY CLUSTERED 
(
	[IdTipoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CTipoVehiculo]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CTipoVehiculo](
	[IdTipo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](256) NOT NULL,
 CONSTRAINT [PK_CTipoVehiculo] PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CTipoVenta]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CTipoVenta](
	[IdTipoVenta] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](256) NOT NULL,
 CONSTRAINT [PK_CTipoVenta] PRIMARY KEY CLUSTERED 
(
	[IdTipoVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CTransmision]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CTransmision](
	[IdTransmision] [smallint] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CTransmision] PRIMARY KEY CLUSTERED 
(
	[IdTransmision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TArticulo]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TArticulo](
	[IdArticulo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](4000) NOT NULL,
	[Valor] [decimal](18, 0) NOT NULL,
	[IdTipo] [int] NOT NULL,
	[IdEstado] [int] NOT NULL,
	[IdCliente] [int] NULL,
 CONSTRAINT [PK_TArticulo] PRIMARY KEY CLUSTERED 
(
	[IdArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TCliente]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TCliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](100) NOT NULL,
	[Nombre] [varchar](256) NOT NULL,
	[PrimerApellido] [varchar](256) NOT NULL,
	[SegundoApellido] [varchar](256) NULL,
	[Direccion] [varchar](4000) NULL,
	[Correo] [varchar](512) NULL,
 CONSTRAINT [PK_TCliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TCompra]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TCompra](
	[IdCliente] [int] NOT NULL,
	[Placa] [varchar](50) NOT NULL,
	[Monto] [decimal](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_TCompra] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[Placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TFinanciamiento]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TFinanciamiento](
	[IdFinanciamiento] [int] IDENTITY(1,1) NOT NULL,
	[Interes] [smallint] NOT NULL,
	[Plazo] [smallint] NOT NULL,
	[IdPeriodoPago] [int] NOT NULL,
	[Descripcion] [varchar](2000) NULL,
	[IdVenta] [int] NULL,
 CONSTRAINT [PK_Financiamiento] PRIMARY KEY CLUSTERED 
(
	[IdFinanciamiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TPagoFinanciamiento]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TPagoFinanciamiento](
	[IdPagoFinan] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NOT NULL,
	[IdTipoPago] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Monto] [decimal](18, 0) NULL,
	[IdFinanciamiento] [int] NOT NULL,
 CONSTRAINT [PK_TPago] PRIMARY KEY CLUSTERED 
(
	[IdPagoFinan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTelefonoCliente]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TTelefonoCliente](
	[IdTelefono] [smallint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](256) NULL,
	[IdCliente] [int] NOT NULL,
 CONSTRAINT [PK_TTelefonoCliente] PRIMARY KEY CLUSTERED 
(
	[IdTelefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TUsuario]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TUsuario](
	[Usuario] [varchar](128) NOT NULL,
	[Contrasenia] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TUsuario] PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TVehiculo]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TVehiculo](
	[Placa] [varchar](50) NOT NULL,
	[IdMarca] [int] NOT NULL,
	[Anio] [int] NOT NULL,
	[Estilo] [varchar](1000) NULL,
	[IdTransmision] [smallint] NULL,
	[Modelo] [varchar](1000) NULL,
	[NumPuertas] [tinyint] NULL,
	[IdTipoVehiculo] [int] NOT NULL,
	[Valor] [decimal](18, 0) NOT NULL,
	[IdTipoArticulo] [int] NOT NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_TVehiculo] PRIMARY KEY CLUSTERED 
(
	[Placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TVenta]    Script Date: 21/05/2017 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TVenta](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [decimal](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Saldo] [decimal](18, 0) NOT NULL,
	[Placa] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TVenta] PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[TCompra]  WITH CHECK ADD  CONSTRAINT [FK_TCompra_TCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[TCliente] ([IdCliente])
GO
ALTER TABLE [dbo].[TCompra] CHECK CONSTRAINT [FK_TCompra_TCliente]
GO
ALTER TABLE [dbo].[TCompra]  WITH CHECK ADD  CONSTRAINT [FK_TCompra_TVehiculo] FOREIGN KEY([Placa])
REFERENCES [dbo].[TVehiculo] ([Placa])
GO
ALTER TABLE [dbo].[TCompra] CHECK CONSTRAINT [FK_TCompra_TVehiculo]
GO
ALTER TABLE [dbo].[TFinanciamiento]  WITH CHECK ADD  CONSTRAINT [FK_Financiamiento_CPeriodoPago] FOREIGN KEY([IdPeriodoPago])
REFERENCES [dbo].[CPeriodoPago] ([IdPeriodoPago])
GO
ALTER TABLE [dbo].[TFinanciamiento] CHECK CONSTRAINT [FK_Financiamiento_CPeriodoPago]
GO
ALTER TABLE [dbo].[TFinanciamiento]  WITH CHECK ADD  CONSTRAINT [FK_TFinanciamiento_TVenta] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[TVenta] ([IdVenta])
GO
ALTER TABLE [dbo].[TFinanciamiento] CHECK CONSTRAINT [FK_TFinanciamiento_TVenta]
GO
ALTER TABLE [dbo].[TPagoFinanciamiento]  WITH CHECK ADD  CONSTRAINT [FK_TPago_CTipoPago] FOREIGN KEY([IdTipoPago])
REFERENCES [dbo].[CTipoPago] ([IdTipoPago])
GO
ALTER TABLE [dbo].[TPagoFinanciamiento] CHECK CONSTRAINT [FK_TPago_CTipoPago]
GO
ALTER TABLE [dbo].[TPagoFinanciamiento]  WITH CHECK ADD  CONSTRAINT [FK_TPago_Financiamiento] FOREIGN KEY([IdFinanciamiento])
REFERENCES [dbo].[TFinanciamiento] ([IdFinanciamiento])
GO
ALTER TABLE [dbo].[TPagoFinanciamiento] CHECK CONSTRAINT [FK_TPago_Financiamiento]
GO
ALTER TABLE [dbo].[TTelefonoCliente]  WITH CHECK ADD  CONSTRAINT [FK_TTelefonoCliente_TCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[TCliente] ([IdCliente])
GO
ALTER TABLE [dbo].[TTelefonoCliente] CHECK CONSTRAINT [FK_TTelefonoCliente_TCliente]
GO
ALTER TABLE [dbo].[TVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_TVehiculo_CEstadoArticulo] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[CEstadoArticulo] ([IdEstado])
GO
ALTER TABLE [dbo].[TVehiculo] CHECK CONSTRAINT [FK_TVehiculo_CEstadoArticulo]
GO
ALTER TABLE [dbo].[TVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_TVehiculo_CMarcaVehiculo] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[CMarcaVehiculo] ([IdMarca])
GO
ALTER TABLE [dbo].[TVehiculo] CHECK CONSTRAINT [FK_TVehiculo_CMarcaVehiculo]
GO
ALTER TABLE [dbo].[TVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_TVehiculo_CTipoArticulo] FOREIGN KEY([IdTipoArticulo])
REFERENCES [dbo].[CTipoArticulo] ([IdTipoArticulo])
GO
ALTER TABLE [dbo].[TVehiculo] CHECK CONSTRAINT [FK_TVehiculo_CTipoArticulo]
GO
ALTER TABLE [dbo].[TVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_TVehiculo_CTipoVehiculo] FOREIGN KEY([IdTipoVehiculo])
REFERENCES [dbo].[CTipoVehiculo] ([IdTipo])
GO
ALTER TABLE [dbo].[TVehiculo] CHECK CONSTRAINT [FK_TVehiculo_CTipoVehiculo]
GO
ALTER TABLE [dbo].[TVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_TVehiculo_CTransmision] FOREIGN KEY([IdTransmision])
REFERENCES [dbo].[CTransmision] ([IdTransmision])
GO
ALTER TABLE [dbo].[TVehiculo] CHECK CONSTRAINT [FK_TVehiculo_CTransmision]
GO
ALTER TABLE [dbo].[TVenta]  WITH CHECK ADD  CONSTRAINT [FK_TVenta_CTipoVenta] FOREIGN KEY([IdTipoVenta])
REFERENCES [dbo].[CTipoVenta] ([IdTipoVenta])
GO
ALTER TABLE [dbo].[TVenta] CHECK CONSTRAINT [FK_TVenta_CTipoVenta]
GO
ALTER TABLE [dbo].[TVenta]  WITH CHECK ADD  CONSTRAINT [FK_TVenta_TCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[TCliente] ([IdCliente])
GO
ALTER TABLE [dbo].[TVenta] CHECK CONSTRAINT [FK_TVenta_TCliente]
GO
ALTER TABLE [dbo].[TVenta]  WITH CHECK ADD  CONSTRAINT [FK_TVenta_TVehiculo] FOREIGN KEY([Placa])
REFERENCES [dbo].[TVehiculo] ([Placa])
GO
ALTER TABLE [dbo].[TVenta] CHECK CONSTRAINT [FK_TVenta_TVehiculo]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registra los estados que puede tener un artículo del inventario para venta: propiedad, vendido, solo venta (no propiedad)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CEstadoArticulo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registra las marcas de vehiculos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMarcaVehiculo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registra los periodos de Pago: Mensual, BiMensual, Trimestral…' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CPeriodoPago'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registra el tipo de articulo en inventario: vehículo, prestamos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CTipoArticulo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registra los tipos de pago: ordinario, extraordinario, arreglo de pago' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CTipoPago'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registra los Tipos de Vehiculo: Automovil, Camion, Moto, etc' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CTipoVehiculo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registra los tipos de venta: financiado, Contado…' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CTipoVenta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registra los detalles de los artículos disponibles en el local' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TArticulo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registra los datos de los clientes que adquieren servicios del local' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TCliente'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registra los pagos que hacen periódicamente los clientes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TPagoFinanciamiento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registra los diferentes números de teléfono del cliente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TTelefonoCliente'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registra los usuarios que tendrán acceso a la aplicación ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUsuario'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MA: Manual, AU: Automatico, AM: ambos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TVehiculo', @level2type=N'COLUMN',@level2name=N'IdTransmision'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registra los vehiculos, hereda de Articulo al ser un articulo mas, ero se le da mas detalle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TVehiculo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registra el detalle de la venta de algun articulo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TVenta'
GO
USE [master]
GO
ALTER DATABASE [Ventas] SET  READ_WRITE 
GO
