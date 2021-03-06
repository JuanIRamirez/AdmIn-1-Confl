USE [Adminsemi]
GO
/****** Object:  Table [dbo].[AlicIva]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlicIva](
	[Codigo] [nvarchar](3) NOT NULL,
	[Descrip] [nvarchar](50) NOT NULL,
	[Alicuo1] [real] NULL,
	[Alicuo2] [real] NULL,
	[Usuario] [nvarchar](50) NULL,
	[FechaMod] [smalldatetime] NULL,
	[AlicIva] [varchar](10) NOT NULL,
 CONSTRAINT [PK_AlicIva] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsienDet]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsienDet](
	[Numero] [int] NOT NULL,
	[Renglon] [smallint] NOT NULL,
	[Cuenta] [varchar](10) NOT NULL,
	[Detalle] [varchar](250) NOT NULL,
	[Debe] [float] NULL,
	[Haber] [float] NULL,
	[Usuario] [varchar](50) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_AsienDet_1] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC,
	[Renglon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsienTmp]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsienTmp](
	[Usuario] [nvarchar](10) NOT NULL,
	[Numero] [int] NOT NULL,
	[Renglon] [smallint] NOT NULL,
	[Cuenta] [nvarchar](10) NOT NULL,
	[Detalle] [nvarchar](50) NOT NULL,
	[Debe] [float] NULL,
	[Haber] [float] NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asientos]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asientos](
	[Numero] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Detalle] [varchar](250) NOT NULL,
	[cFecha] [varchar](8) NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Asientos] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsientosDes]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsientosDes](
	[Numero] [int] NOT NULL,
	[Fecha] [smalldatetime] NULL,
	[Codigo] [nvarchar](50) NULL,
	[Detalle] [nvarchar](50) NULL,
 CONSTRAINT [PK_AsientosDes] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Audit]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Audit](
	[AuditID] [int] IDENTITY(1,1) NOT NULL,
	[AuditDescrip] [varchar](250) NOT NULL,
	[AuditDetalle] [varchar](512) NULL,
	[AuditFecha] [smalldatetime] NOT NULL,
	[AuditProceso] [varchar](50) NOT NULL,
	[AuditSubProc] [varchar](50) NULL,
	[AuditUid] [varchar](25) NOT NULL,
	[AuditPC] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Audit] PRIMARY KEY CLUSTERED 
(
	[AuditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuxReporte]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuxReporte](
	[Propietario] [int] NULL,
	[Propiedad] [int] NULL,
	[Inquilino] [int] NULL,
	[Codigo] [varchar](50) NULL,
	[Concepto] [varchar](10) NULL,
	[Importe] [float] NULL,
	[Uid] [varchar](50) NULL,
	[Host] [varchar](50) NULL,
	[Periodo] [varchar](10) NULL,
	[Saldo] [float] NULL,
	[Numero] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvisoDeuda]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvisoDeuda](
	[FechaAviso] [smalldatetime] NULL,
	[HoraAviso] [nvarchar](5) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvisoHoras]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvisoHoras](
	[HoraAviso] [nvarchar](5) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BancoProp]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BancoProp](
	[Id] [int] NOT NULL,
	[Codigo] [nvarchar](5) NULL,
	[Banco] [nvarchar](40) NULL,
	[Sucursal] [nvarchar](40) NULL,
	[TipoCta] [nvarchar](30) NULL,
	[Cuenta] [nvarchar](50) NULL,
	[Modo] [nvarchar](50) NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bancos]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bancos](
	[Banco] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Sucursal] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Domicilio] [varchar](50) NULL,
	[Contacto] [varchar](50) NULL,
	[Carg_Cont] [varchar](50) NULL,
	[Tel_Contac] [varchar](50) NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Bancos] PRIMARY KEY CLUSTERED 
(
	[Banco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BancosCtas]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BancosCtas](
	[Banco] [smallint] NOT NULL,
	[BancoCta] [nvarchar](10) NOT NULL,
	[Descrip] [varchar](50) NOT NULL,
	[Titular] [varchar](50) NULL,
	[SaldoIni] [float] NOT NULL,
	[FechaSdo] [smalldatetime] NULL,
	[CtaCont] [nvarchar](10) NULL,
	[SaldoAnt] [float] NULL,
	[Usuario] [varchar](20) NULL,
	[FechaMod] [smalldatetime] NULL,
 CONSTRAINT [PK_BancoCta] PRIMARY KEY CLUSTERED 
(
	[Banco] ASC,
	[BancoCta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BancosMov]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BancosMov](
	[Banco] [smallint] NOT NULL,
	[BancoCta] [varchar](20) NOT NULL,
	[TipoMovBco] [smallint] NOT NULL,
	[NroMovBco] [varchar](25) NOT NULL,
	[BancoMovId] [int] IDENTITY(1,1) NOT NULL,
	[FechaEmi] [smalldatetime] NOT NULL,
	[FechaAcr] [smalldatetime] NOT NULL,
	[Debe] [float] NOT NULL,
	[Haber] [float] NULL,
	[Estado] [smallint] NOT NULL,
	[HojaBco] [int] NULL,
	[Detalle] [varchar](250) NULL,
	[BcoCart] [smallint] NULL,
	[CtaCart] [varchar](50) NULL,
	[NroCart] [varchar](25) NULL,
	[Caja] [smallint] NULL,
	[CtaCont] [varchar](15) NULL,
	[CajaInmAdm] [varchar](50) NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[ChCartId] [int] NULL,
 CONSTRAINT [PK_MovBancos] PRIMARY KEY CLUSTERED 
(
	[Banco] ASC,
	[BancoCta] ASC,
	[TipoMovBco] ASC,
	[NroMovBco] ASC,
	[BancoMovId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Barrios]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Barrios](
	[Codigo] [nvarchar](5) NULL,
	[Nombre] [nvarchar](50) NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[BarrioId] [int] IDENTITY(1,1) NOT NULL,
	[BarrioUId] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Caja]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Caja](
	[Caja] [smallint] NOT NULL,
	[Comprob] [varchar](50) NOT NULL,
	[fPago] [varchar](5) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[FechaC] [varchar](8) NOT NULL,
	[Nombre] [varchar](250) NULL,
	[Detalle] [varchar](250) NULL,
	[Entrada] [float] NOT NULL,
	[Salida] [float] NOT NULL,
	[CajaAdm] [bit] NOT NULL,
	[Cuenta] [varchar](12) NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[MovRec] [int] NULL,
	[SaldoRec] [float] NULL,
 CONSTRAINT [PK_Caja] PRIMARY KEY CLUSTERED 
(
	[Caja] ASC,
	[Comprob] ASC,
	[fPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CajaRecCh]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CajaRecCh](
	[Comprob] [varchar](50) NOT NULL,
	[Origen] [varchar](1) NOT NULL,
	[DescBanco] [varchar](50) NULL,
	[Banco] [smallint] NOT NULL,
	[Cuenta] [varchar](50) NOT NULL,
	[Numero] [varchar](25) NOT NULL,
	[Titular] [varchar](50) NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Importe] [float] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_CajaRecCh] PRIMARY KEY CLUSTERED 
(
	[Comprob] ASC,
	[Origen] ASC,
	[Banco] ASC,
	[Cuenta] ASC,
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cajas]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cajas](
	[Caja] [smallint] NOT NULL,
	[Descrip] [varchar](50) NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[Cuenta] [varchar](12) NULL,
	[CtaAdm] [varchar](12) NULL,
	[SdoAnt] [float] NULL,
	[SdoAct] [float] NULL,
	[SubTitulo] [varchar](50) NULL,
	[UltNroMN] [int] NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Cajas] PRIMARY KEY CLUSTERED 
(
	[Caja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatGcias]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatGcias](
	[Codigo] [smallint] NOT NULL,
	[Descrip] [nvarchar](50) NOT NULL,
	[Abrev] [nvarchar](5) NOT NULL,
	[Alicuota] [real] NOT NULL,
	[MinimoImp] [float] NOT NULL,
	[RetMinima] [float] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_CatGcias] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChCartera]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChCartera](
	[ChCartId] [int] IDENTITY(1,1) NOT NULL,
	[Banco] [smallint] NOT NULL,
	[BancoCta] [varchar](50) NOT NULL,
	[ChCartNro] [varchar](25) NOT NULL,
	[Titular] [varchar](50) NULL,
	[FechaEmi] [smalldatetime] NOT NULL,
	[FechaDif] [smalldatetime] NOT NULL,
	[Entrego] [varchar](50) NULL,
	[Importe] [float] NOT NULL,
	[Estado] [smallint] NOT NULL,
	[CajaAdm] [bit] NOT NULL,
	[Detalle] [varchar](250) NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[Caja] [int] NULL,
	[FechaEnt] [smalldatetime] NULL,
	[FechaSal] [smalldatetime] NULL,
	[Comprob] [varchar](50) NULL,
 CONSTRAINT [PK_ChCartera] PRIMARY KEY CLUSTERED 
(
	[ChCartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChCartera0]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChCartera0](
	[ChCartId] [int] IDENTITY(1,1) NOT NULL,
	[Banco] [smallint] NOT NULL,
	[BancoCta] [varchar](50) NOT NULL,
	[ChCartNro] [varchar](25) NOT NULL,
	[Titular] [varchar](50) NULL,
	[FechaEmi] [smalldatetime] NOT NULL,
	[FechaDif] [smalldatetime] NOT NULL,
	[Entrego] [varchar](50) NULL,
	[Importe] [float] NOT NULL,
	[Estado] [smallint] NOT NULL,
	[CajaAdm] [bit] NOT NULL,
	[Detalle] [varchar](250) NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[Caja] [int] NULL,
	[FechaEnt] [smalldatetime] NULL,
	[FechaSal] [smalldatetime] NULL,
	[Comprob] [varchar](50) NULL,
 CONSTRAINT [PK_ChCartera0] PRIMARY KEY CLUSTERED 
(
	[Banco] ASC,
	[BancoCta] ASC,
	[ChCartNro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChLiqPro]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChLiqPro](
	[LiqPro] [int] NOT NULL,
	[Origen] [varchar](1) NOT NULL,
	[DescBanco] [varchar](50) NULL,
	[Banco] [smallint] NOT NULL,
	[Cuenta] [varchar](50) NOT NULL,
	[Numero] [varchar](25) NOT NULL,
	[Titular] [varchar](50) NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Importe] [float] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_ChLiqPro_1] PRIMARY KEY CLUSTERED 
(
	[LiqPro] ASC,
	[Origen] ASC,
	[Banco] ASC,
	[Cuenta] ASC,
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChLiqProTmp]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChLiqProTmp](
	[DescBco] [nvarchar](50) NULL,
	[Usuario] [varchar](20) NULL,
	[Origen] [nvarchar](1) NULL,
	[Banco] [smallint] NULL,
	[Cuenta] [varchar](50) NULL,
	[Numero] [varchar](50) NULL,
	[Titular] [nvarchar](50) NULL,
	[Fecha] [smalldatetime] NULL,
	[Importe] [float] NULL,
	[CtaCont] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChPropios]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChPropios](
	[Banco] [smallint] NOT NULL,
	[BancoCta] [varchar](50) NOT NULL,
	[TipoMovBco] [smallint] NOT NULL,
	[ChPropNro] [varchar](50) NOT NULL,
	[Estado] [smallint] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_ChPropios] PRIMARY KEY CLUSTERED 
(
	[Banco] ASC,
	[BancoCta] ASC,
	[TipoMovBco] ASC,
	[ChPropNro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChPropios0]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChPropios0](
	[Banco] [smallint] NOT NULL,
	[BancoCta] [varchar](50) NOT NULL,
	[TipoMovBco] [smallint] NOT NULL,
	[ChPropNro] [int] NOT NULL,
	[Estado] [smallint] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChRecibo]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChRecibo](
	[ChReciboID] [int] NOT NULL,
	[Banco] [smallint] NOT NULL,
	[Cuenta] [varchar](50) NOT NULL,
	[Numero] [varchar](25) NOT NULL,
	[Titular] [nvarchar](50) NULL,
	[Fecha] [smalldatetime] NULL,
	[Importe] [float] NULL,
	[RboTipo] [nvarchar](1) NULL,
	[RboSucursal] [smallint] NULL,
	[RboNumero] [int] NULL,
	[Usuario] [nvarchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_ChRecibo] PRIMARY KEY CLUSTERED 
(
	[ChReciboID] ASC,
	[Banco] ASC,
	[Cuenta] ASC,
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChReciboDesc]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChReciboDesc](
	[Tipo] [nvarchar](1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Detalle] [varchar](2000) NULL,
	[Usuario] [varchar](50) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_ChReciboDesc] PRIMARY KEY CLUSTERED 
(
	[Tipo] ASC,
	[Sucursal] ASC,
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChReciboDesc2]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChReciboDesc2](
	[Tipo] [nvarchar](1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Detalle] [varchar](1000) NULL,
	[Usuario] [varchar](50) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_ChReciboDesc2] PRIMARY KEY CLUSTERED 
(
	[Tipo] ASC,
	[Sucursal] ASC,
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChReciboTmp]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChReciboTmp](
	[DescBco] [nvarchar](50) NULL,
	[Banco] [smallint] NULL,
	[Cuenta] [nvarchar](10) NULL,
	[Numero] [varchar](25) NULL,
	[Titular] [nvarchar](50) NULL,
	[Fecha] [smalldatetime] NULL,
	[Importe] [float] NULL,
	[Usuario] [nvarchar](10) NULL,
	[PC] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Codigo] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Domicilio] [varchar](50) NULL,
	[Localidad] [varchar](50) NULL,
	[Provincia] [varchar](50) NULL,
	[Contacto] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[eMail] [varchar](50) NULL,
	[TipoIva] [varchar](50) NOT NULL,
	[Cuit] [varchar](15) NULL,
	[CondVenta] [smallint] NOT NULL,
	[Cuenta] [varchar](12) NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CobOtrDet]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CobOtrDet](
	[Tipo] [varchar](1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Renglon] [smallint] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Concepto] [varchar](3) NOT NULL,
	[Detalle] [varchar](250) NOT NULL,
	[Imputacion] [varchar](1) NOT NULL,
	[Importe] [float] NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[CadCuota] [smallint] NULL,
	[aPropiet] [bit] NULL,
 CONSTRAINT [PK_CobOtrDet] PRIMARY KEY CLUSTERED 
(
	[Tipo] ASC,
	[Sucursal] ASC,
	[Numero] ASC,
	[Renglon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CobOtrTmp]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CobOtrTmp](
	[Tipo] [varchar](1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Concepto] [varchar](3) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Detalle] [varchar](50) NOT NULL,
	[Debe] [float] NOT NULL,
	[Haber] [float] NOT NULL,
	[Usuario] [varchar](20) NULL,
	[PC] [varchar](50) NULL,
	[Renglon] [smallint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cobros]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cobros](
	[Comprob] [varchar](3) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Cliente] [int] NOT NULL,
	[SubTotal] [float] NOT NULL,
	[Intereses] [float] NOT NULL,
	[Total] [float] NOT NULL,
	[Efectivo] [float] NOT NULL,
	[Cheques] [float] NOT NULL,
	[Banco] [smallint] NULL,
	[CtaBco] [nvarchar](10) NULL,
	[NroCheque] [nvarchar](15) NULL,
	[FecCheque] [smalldatetime] NULL,
	[Moneda] [nvarchar](3) NOT NULL,
	[Detalle] [text] NULL,
	[Caja] [smallint] NOT NULL,
	[Estado] [smallint] NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[Tipo] [varchar](1) NULL,
	[CobTransf] [float] NULL,
 CONSTRAINT [PK_Cobros] PRIMARY KEY CLUSTERED 
(
	[Comprob] ASC,
	[Sucursal] ASC,
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CobrosDet]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CobrosDet](
	[Comprob] [varchar](3) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Renglon] [smallint] NOT NULL,
	[Cliente] [int] NOT NULL,
	[CliTipo] [nvarchar](1) NOT NULL,
	[CliSucursal] [smallint] NOT NULL,
	[CliNumero] [int] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[Tipo] [varchar](1) NULL,
 CONSTRAINT [PK_CobrosDet] PRIMARY KEY CLUSTERED 
(
	[Comprob] ASC,
	[Sucursal] ASC,
	[Numero] ASC,
	[Renglon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CobrosDetTmp]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CobrosDetTmp](
	[Usuario] [nvarchar](10) NOT NULL,
	[Cliente] [int] NOT NULL,
	[Tipo] [nvarchar](1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Comprob] [nvarchar](3) NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Total] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CobrosOtr]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CobrosOtr](
	[Tipo] [varchar](1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Cliente] [int] NULL,
	[Propietario] [int] NULL,
	[Inquilino] [int] NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Domicilio] [nvarchar](50) NULL,
	[TipoIva] [nvarchar](3) NOT NULL,
	[Cuit] [nvarchar](15) NULL,
	[SubTotal] [float] NOT NULL,
	[Iva1] [float] NOT NULL,
	[Iva2] [float] NOT NULL,
	[Total] [float] NOT NULL,
	[Efectivo] [float] NOT NULL,
	[Cheques] [float] NOT NULL,
	[Banco] [smallint] NULL,
	[CtaBco] [varchar](25) NULL,
	[NroCheque] [varchar](25) NULL,
	[FecCheque] [smalldatetime] NULL,
	[Moneda] [nvarchar](3) NOT NULL,
	[Liquidado] [bit] NOT NULL,
	[LiqPropiet] [int] NOT NULL,
	[LiqInquilino] [int] NULL,
	[Detalle] [ntext] NULL,
	[Caja] [smallint] NOT NULL,
	[Estado] [smallint] NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[Propiedad] [int] NULL,
	[CacId] [int] NULL,
	[CcrId] [int] NULL,
	[CobroOtrId] [int] IDENTITY(1,1) NOT NULL,
	[CooTransf] [float] NULL,
 CONSTRAINT [PK_CobrosOtr] PRIMARY KEY CLUSTERED 
(
	[Tipo] ASC,
	[Sucursal] ASC,
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CobrosOtrCh]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CobrosOtrCh](
	[CobOtrChId] [int] IDENTITY(1,1) NOT NULL,
	[CobroOtrId] [int] NOT NULL,
	[Origen] [varchar](1) NULL,
	[Banco] [smallint] NOT NULL,
	[CuentaBco] [varchar](50) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[CrdUsuario] [varchar](50) NOT NULL,
	[CrdFecMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_CobrosOtrCh] PRIMARY KEY CLUSTERED 
(
	[CobOtrChId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CobrosOtrTr]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CobrosOtrTr](
	[CobroOtrTrID] [int] IDENTITY(1,1) NOT NULL,
	[CobroOtrID] [int] NOT NULL,
	[Banco0] [int] NOT NULL,
	[Cuenta0] [varchar](25) NOT NULL,
	[Titular0] [varchar](50) NOT NULL,
	[Banco1] [int] NOT NULL,
	[Cuenta1] [varchar](25) NOT NULL,
	[FechaTR] [smalldatetime] NOT NULL,
	[NumeroTR] [varchar](25) NOT NULL,
	[ImporteTR] [float] NOT NULL,
	[Usuario] [varchar](25) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_CobrosOtrTR] PRIMARY KEY CLUSTERED 
(
	[CobroOtrTrID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComACob]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComACob](
	[CacId] [int] IDENTITY(1,1) NOT NULL,
	[CacNumero] [int] NOT NULL,
	[CacFecha] [smalldatetime] NOT NULL,
	[CacDetalle] [varchar](250) NULL,
	[Cliente] [int] NULL,
	[Inquilino] [int] NULL,
	[Propietario] [int] NULL,
	[CacTotal] [float] NOT NULL,
	[CacSaldo] [float] NOT NULL,
	[CacCuotas] [smallint] NOT NULL,
	[CacImpCuota] [float] NOT NULL,
	[CacFecCuota] [smalldatetime] NULL,
	[CacUsuario] [varchar](50) NOT NULL,
	[CacFecMod] [smalldatetime] NOT NULL,
	[VentaId] [int] NULL,
 CONSTRAINT [PK_ConcACob] PRIMARY KEY CLUSTERED 
(
	[CacId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComACobDet]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComACobDet](
	[CacId] [int] NOT NULL,
	[CadCuota] [smallint] NOT NULL,
	[CadFecha] [smalldatetime] NULL,
	[Concepto] [varchar](3) NOT NULL,
	[CadDetalle] [varchar](250) NOT NULL,
	[CadImput] [varchar](1) NOT NULL,
	[CadImporte] [float] NULL,
	[CadSaldo] [float] NULL,
	[CadUsuario] [varchar](20) NOT NULL,
	[CadFecMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_ConcACobDet] PRIMARY KEY CLUSTERED 
(
	[CacId] ASC,
	[CadCuota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComACobR]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComACobR](
	[CcrId] [int] IDENTITY(1,1) NOT NULL,
	[CcrNumero] [int] NOT NULL,
	[CcrFecha] [smalldatetime] NOT NULL,
	[CcrDetalle] [varchar](250) NULL,
	[CcrTotal] [float] NOT NULL,
	[CcrUsuario] [varchar](50) NOT NULL,
	[CcrFecMod] [smalldatetime] NOT NULL,
	[CcrEfectivo] [float] NULL,
	[CcrCheques] [float] NULL,
	[Estado] [tinyint] NOT NULL,
 CONSTRAINT [PK_ComACobR] PRIMARY KEY CLUSTERED 
(
	[CcrId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComACobRCh]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComACobRCh](
	[CcrId] [int] NOT NULL,
	[CrdRenglon] [smallint] NOT NULL,
	[Origen] [varchar](1) NULL,
	[Banco] [smallint] NOT NULL,
	[CuentaBco] [varchar](25) NOT NULL,
	[Numero] [varchar](25) NOT NULL,
	[CrdUsuario] [varchar](25) NOT NULL,
	[CrdFecMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_ComACobRCh] PRIMARY KEY CLUSTERED 
(
	[CcrId] ASC,
	[CrdRenglon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComACobRDet]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComACobRDet](
	[CrdId] [int] IDENTITY(1,1) NOT NULL,
	[CcrId] [int] NOT NULL,
	[CobroOtrId] [int] NULL,
	[CompraId] [int] NULL,
	[CrdDetalle] [varchar](250) NOT NULL,
	[CrdDebe] [float] NULL,
	[CrdHaber] [float] NULL,
	[CrdUsuario] [varchar](20) NOT NULL,
	[CrdFecMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_ComACobRDet] PRIMARY KEY CLUSTERED 
(
	[CrdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompInt]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompInt](
	[Codigo] [nvarchar](3) NOT NULL,
	[Descrip] [nvarchar](50) NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_CompInt] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompraOtr]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraOtr](
	[Proveedor] [int] NOT NULL,
	[Comprob] [varchar](50) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[FechaVenc] [smalldatetime] NOT NULL,
	[Propietario] [int] NULL,
	[Propiedad] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[Detalle] [ntext] NULL,
	[Total] [float] NOT NULL,
	[Pagado] [bit] NOT NULL,
	[NroPago] [int] NOT NULL,
	[Liquidado] [bit] NOT NULL,
	[LiqPropiet] [int] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_CompraOtr_1] PRIMARY KEY CLUSTERED 
(
	[Proveedor] ASC,
	[Comprob] ASC,
	[Sucursal] ASC,
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompraOtrDet]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraOtrDet](
	[Proveedor] [int] NOT NULL,
	[Comprob] [varchar](50) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Renglon] [smallint] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Concepto] [varchar](10) NOT NULL,
	[Detalle] [varchar](250) NOT NULL,
	[Imput] [varchar](1) NOT NULL,
	[Importe] [float] NOT NULL,
	[aPropiet] [bit] NOT NULL,
	[Usuario] [varchar](25) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_CompraOtrDet_1] PRIMARY KEY CLUSTERED 
(
	[Proveedor] ASC,
	[Comprob] ASC,
	[Sucursal] ASC,
	[Numero] ASC,
	[Renglon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompraOtrTmp]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraOtrTmp](
	[Proveedor] [int] NULL,
	[Comprob] [nvarchar](25) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Renglon] [smallint] NULL,
	[aPropiet] [bit] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Concepto] [nvarchar](10) NOT NULL,
	[Detalle] [nvarchar](50) NOT NULL,
	[Debe] [float] NOT NULL,
	[Haber] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[CompraId] [int] IDENTITY(1,1) NOT NULL,
	[Comprob] [nvarchar](3) NOT NULL,
	[Proveedor] [int] NOT NULL,
	[CompLetra] [nvarchar](1) NOT NULL,
	[CompSucursal] [smallint] NOT NULL,
	[CompNumero] [int] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[FechaVenc] [smalldatetime] NOT NULL,
	[Periodo] [nvarchar](7) NULL,
	[PerIva] [nvarchar](7) NULL,
	[Nombre] [varchar](50) NOT NULL,
	[TipoIva] [nvarchar](3) NOT NULL,
	[Cuit] [nvarchar](15) NULL,
	[Gravado] [float] NOT NULL,
	[NoGravado] [float] NOT NULL,
	[Iva1] [float] NOT NULL,
	[Iva2] [float] NOT NULL,
	[CompraRNI] [float] NOT NULL,
	[Exento] [float] NOT NULL,
	[Total] [float] NOT NULL,
	[Pagado] [bit] NOT NULL,
	[NroPago] [int] NULL,
	[Detalle] [ntext] NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[CcrId] [int] NULL,
	[RetIva] [float] NULL,
	[RetIB] [float] NULL,
	[RetGan] [float] NULL,
	[Sucursal] [int] NOT NULL,
	[CondVenta] [tinyint] NOT NULL,
	[IngresoID] [int] NULL,
	[Estado] [tinyint] NOT NULL,
	[CompServ] [bit] NOT NULL,
	[TipoComp] [int] NOT NULL,
	[PedidoPrId] [int] NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[Comprob] ASC,
	[Proveedor] ASC,
	[CompLetra] ASC,
	[CompSucursal] ASC,
	[CompNumero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComprasDet]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComprasDet](
	[Proveedor] [int] NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Renglon] [smallint] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Concepto] [varchar](10) NOT NULL,
	[Detalle] [varchar](50) NOT NULL,
	[Imput] [varchar](1) NOT NULL,
	[Importe] [float] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[CompraId] [int] NOT NULL,
 CONSTRAINT [PK_CompraDet] PRIMARY KEY CLUSTERED 
(
	[Proveedor] ASC,
	[Sucursal] ASC,
	[Numero] ASC,
	[Renglon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompraTmp]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraTmp](
	[Proveedor] [int] NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Renglon] [smallint] NOT NULL,
	[Concepto] [nvarchar](10) NOT NULL,
	[Detalle] [nvarchar](50) NOT NULL,
	[Debe] [float] NOT NULL,
	[Haber] [float] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conceptos]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conceptos](
	[Codigo] [varchar](10) NOT NULL,
	[Descrip] [varchar](50) NOT NULL,
	[Accion] [nvarchar](1) NOT NULL,
	[Cuenta] [varchar](50) NULL,
	[CtaAdm] [varchar](50) NULL,
	[Comision] [bit] NOT NULL,
	[Prioridad] [smallint] NULL,
	[ImpDef] [float] NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[ConceptoId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Conceptos] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Config]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Config](
	[Clave] [varchar](50) NOT NULL,
	[Descrip] [varchar](50) NULL,
	[Mostrar] [varchar](50) NULL,
	[Valor] [varchar](250) NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Config] PRIMARY KEY CLUSTERED 
(
	[Clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConfigUsu]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigUsu](
	[CfuUsuario] [varchar](25) NOT NULL,
	[CfuForm] [varchar](32) NOT NULL,
	[CfuControl] [varchar](32) NOT NULL,
	[CfuColName] [varchar](32) NOT NULL,
	[CfuWState] [smallint] NOT NULL,
	[CfuLeft] [smallint] NOT NULL,
	[CfuTop] [smallint] NOT NULL,
	[CfuWidth] [smallint] NOT NULL,
	[CfuHeight] [smallint] NOT NULL,
	[CfuValor] [varchar](250) NULL,
	[CfuFecMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_ConfigUsu] PRIMARY KEY CLUSTERED 
(
	[CfuUsuario] ASC,
	[CfuForm] ASC,
	[CfuControl] ASC,
	[CfuColName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsConcep]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsConcep](
	[Consorcio] [nvarchar](10) NOT NULL,
	[Concepto] [nvarchar](10) NULL,
	[Depart] [nvarchar](10) NULL,
	[Detalle] [nvarchar](50) NOT NULL,
	[Importe] [float] NULL,
	[Imputacion] [nvarchar](1) NOT NULL,
	[Automatico] [bit] NOT NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsDepart]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsDepart](
	[Consorcio] [nvarchar](10) NOT NULL,
	[Codigo] [nvarchar](10) NOT NULL,
	[Descrip] [nvarchar](50) NOT NULL,
	[Piso] [nvarchar](3) NOT NULL,
	[Depart] [nvarchar](3) NOT NULL,
	[Propiedad] [nvarchar](10) NULL,
	[Porcent] [real] NOT NULL,
	[Ocupante] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](25) NULL,
	[TipoIva] [nvarchar](3) NULL,
	[Cuit] [nvarchar](13) NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsFact]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsFact](
	[Periodo] [nvarchar](6) NOT NULL,
	[Consorcio] [nvarchar](10) NOT NULL,
	[Concepto] [nvarchar](3) NOT NULL,
	[Depart] [nvarchar](10) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Detalle] [nvarchar](50) NULL,
	[Importe] [float] NOT NULL,
	[Imputacion] [nvarchar](1) NOT NULL,
	[Liquidado] [bit] NOT NULL,
	[Distrib] [bit] NOT NULL,
	[Automatico] [bit] NOT NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsLiqAux]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsLiqAux](
	[Consorcio] [nvarchar](10) NOT NULL,
	[Depart] [nvarchar](10) NOT NULL,
	[SaldoAnt] [float] NULL,
	[Venc1] [smalldatetime] NULL,
	[Venc2] [smalldatetime] NULL,
	[Venc3] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsLiqDet]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsLiqDet](
	[Tipo] [nvarchar](1) NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Periodo] [nvarchar](6) NOT NULL,
	[Consorcio] [nvarchar](10) NOT NULL,
	[Depart] [nvarchar](10) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Concepto] [nvarchar](3) NOT NULL,
	[Detalle] [nvarchar](50) NULL,
	[ImpTotal] [float] NULL,
	[Importe] [float] NOT NULL,
	[Imputacion] [nvarchar](1) NOT NULL,
	[Liquidado] [bit] NOT NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsLiquid]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsLiquid](
	[Consorcio] [nvarchar](10) NOT NULL,
	[Depart] [nvarchar](10) NOT NULL,
	[Periodo] [nvarchar](6) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Tipo] [nvarchar](1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[SaldoAnt] [float] NOT NULL,
	[Intereses] [float] NOT NULL,
	[SubTotal] [float] NOT NULL,
	[Iva1] [float] NOT NULL,
	[Iva2] [float] NOT NULL,
	[Efectivo] [float] NOT NULL,
	[Cheque] [float] NOT NULL,
	[Total] [float] NOT NULL,
	[Saldo] [float] NOT NULL,
	[Banco] [smallint] NOT NULL,
	[NroCheque] [nvarchar](15) NULL,
	[FecCheque] [smalldatetime] NULL,
	[Detalle] [ntext] NULL,
	[Estado] [smallint] NULL,
	[Caja] [smallint] NOT NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consorcios]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consorcios](
	[Codigo] [nvarchar](10) NOT NULL,
	[Descrip] [nvarchar](50) NOT NULL,
	[Domicilio] [nvarchar](50) NULL,
	[Localidad] [nvarchar](50) NULL,
	[CodPostal] [nvarchar](10) NULL,
	[Provincia] [nvarchar](50) NULL,
	[Admin] [nvarchar](50) NULL,
	[Telefono] [nvarchar](25) NULL,
	[ValorExp] [float] NOT NULL,
	[DiaVenc] [smallint] NOT NULL,
	[PeriodoIni] [nvarchar](6) NOT NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsRetGcias]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsRetGcias](
	[Numero] [int] NULL,
	[Fecha] [smalldatetime] NULL,
	[Propietario] [nvarchar](10) NULL,
	[Periodo] [nvarchar](6) NULL,
	[PeriodoC] [nvarchar](15) NULL,
	[Acumulado] [float] NULL,
	[Neto] [float] NULL,
	[Retenido] [float] NULL,
	[Agente] [nvarchar](30) NULL,
	[DDJJAño] [smallint] NULL,
	[Estado] [smallint] NULL,
	[LiqPropiet] [float] NULL,
	[Usuario] [nvarchar](10) NULL,
	[FechaMod] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contratos]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contratos](
	[Numero] [int] NOT NULL,
	[Texto] [ntext] NULL,
	[Convenio] [ntext] NULL,
	[FechaContrato] [smalldatetime] NULL,
	[FechaC] [nvarchar](8) NULL,
	[PerDesde] [nvarchar](6) NOT NULL,
	[PerHasta] [nvarchar](6) NOT NULL,
	[Propietario] [int] NOT NULL,
	[Inquilino] [int] NOT NULL,
	[Propiedad] [int] NOT NULL,
	[Meses] [smallint] NOT NULL,
	[DiaVenc] [smallint] NOT NULL,
	[Estado] [smallint] NOT NULL,
	[Tipo] [nvarchar](1) NULL,
	[Sucursal] [smallint] NULL,
	[NroFact] [int] NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[Escalon] [tinyint] NULL,
	[MesesEsc] [smallint] NULL,
	[Incremento] [float] NULL,
	[GaranteId] [int] NULL,
	[CtoFecFin] [smalldatetime] NULL,
 CONSTRAINT [PK_Contratos] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContratosAct]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContratosAct](
	[ContratoActId] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [int] NOT NULL,
	[Escalon] [tinyint] NULL,
	[MesesEsc] [smallint] NULL,
	[Incremento] [float] NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_ContratosAct] PRIMARY KEY CLUSTERED 
(
	[ContratoActId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CtaCtePro]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtaCtePro](
	[CtaCteProId] [int] IDENTITY(1,1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Departamento] [smallint] NOT NULL,
	[Proveedor] [int] NOT NULL,
	[TipoComp] [tinyint] NOT NULL,
	[ProSucursal] [smallint] NOT NULL,
	[ProNumero] [int] NOT NULL,
	[Letra] [varchar](1) NULL,
	[Fecha] [smalldatetime] NULL,
	[Debe] [float] NULL,
	[Haber] [float] NULL,
	[FechaVenc] [smalldatetime] NULL,
	[Detalle] [varchar](50) NULL,
	[Pagado] [bit] NOT NULL,
	[CompraID] [int] NULL,
	[PagoID] [int] NULL,
	[Usuario] [varchar](25) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[Saldo] [float] NOT NULL,
	[EmpresaId] [smallint] NULL,
 CONSTRAINT [PK_CtaCtePro] PRIMARY KEY CLUSTERED 
(
	[Proveedor] ASC,
	[TipoComp] ASC,
	[ProSucursal] ASC,
	[ProNumero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresas]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresas](
	[EmpresaID] [int] NOT NULL,
	[EmpNombre] [varchar](50) NOT NULL,
	[EmpRazonSocial] [varchar](250) NOT NULL,
	[EmpDomicilio] [varchar](250) NULL,
	[Localidad] [int] NOT NULL,
	[EmpCPostal] [varchar](15) NULL,
	[EmpTelefonos] [varchar](250) NULL,
	[EmpEMail] [varchar](250) NULL,
	[TipoIva] [smallint] NOT NULL,
	[EmpCuit] [varchar](15) NULL,
	[EmpUsuario] [varchar](50) NOT NULL,
	[EmpFechaMod] [smalldatetime] NOT NULL,
	[EmpGas] [bit] NOT NULL,
 CONSTRAINT [PK_Empresas] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EscContrato]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EscContrato](
	[Escalon] [tinyint] NOT NULL,
	[EscDescrip] [varchar](50) NOT NULL,
	[EscSimbolo] [varchar](10) NOT NULL,
	[EscUsuario] [varchar](50) NOT NULL,
	[EscFecMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_EscContrato] PRIMARY KEY CLUSTERED 
(
	[Escalon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[Estado] [tinyint] NOT NULL,
	[Descrip] [varchar](50) NOT NULL,
	[Compras] [bit] NOT NULL,
	[Ventas] [bit] NOT NULL,
	[Bancos] [bit] NOT NULL,
	[Pagos] [bit] NOT NULL,
	[Egresos] [bit] NOT NULL,
	[Cheques] [bit] NOT NULL,
	[Usuario] [varchar](25) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[Pedidos] [bit] NOT NULL,
	[Remitos] [bit] NULL,
	[DescAlt] [varchar](50) NULL,
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
(
	[Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstChCartera]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstChCartera](
	[Estado] [smallint] NOT NULL,
	[Descrip] [nvarchar](50) NOT NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NULL,
 CONSTRAINT [PK_EstChCartera] PRIMARY KEY CLUSTERED 
(
	[Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstContr]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstContr](
	[Estado] [smallint] NOT NULL,
	[Descrip] [nvarchar](50) NOT NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstLiquid]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstLiquid](
	[Estado] [smallint] NOT NULL,
	[Descrip] [nvarchar](50) NOT NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstMovBco]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstMovBco](
	[Estado] [smallint] NOT NULL,
	[Descrip] [nvarchar](50) NOT NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NULL,
 CONSTRAINT [PK_EstMovBco] PRIMARY KEY CLUSTERED 
(
	[Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstPagos]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstPagos](
	[Estado] [smallint] NOT NULL,
	[Descrip] [nvarchar](50) NOT NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstVentas]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstVentas](
	[Estado] [smallint] NOT NULL,
	[Descrip] [nvarchar](50) NOT NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FactInq]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FactInq](
	[Periodo] [varchar](6) NOT NULL,
	[Propiedad] [int] NOT NULL,
	[Inquilino] [int] NOT NULL,
	[Concepto] [varchar](5) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Detalle] [varchar](250) NULL,
	[Importe] [float] NOT NULL,
	[Saldo] [float] NULL,
	[Imputacion] [nvarchar](1) NOT NULL,
	[Liquidado] [bit] NOT NULL,
	[TipoNroRbo] [varchar](15) NULL,
	[Automatico] [bit] NOT NULL,
	[aPropiet] [bit] NOT NULL,
	[MesPago] [smallint] NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[Propietario] [int] NULL,
	[FactInqID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_FactInq] PRIMARY KEY CLUSTERED 
(
	[Periodo] ASC,
	[Propiedad] ASC,
	[Inquilino] ASC,
	[Concepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Garantias]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Garantias](
	[Inquilino] [int] NULL,
	[DNI] [nvarchar](10) NULL,
	[Nombre] [nvarchar](50) NULL,
	[Domicilio] [nvarchar](50) NULL,
	[Telefono] [nvarchar](20) NULL,
	[Trabajo] [nvarchar](50) NULL,
	[DomTrabajo] [nvarchar](50) NULL,
	[Localidad] [nvarchar](20) NULL,
	[TelTrabajo] [nvarchar](20) NULL,
	[GPagare] [bit] NOT NULL,
	[GHipotecario] [bit] NOT NULL,
	[gPrenda] [bit] NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[GaranteId] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[LocalidadId] [int] NULL,
 CONSTRAINT [PK_Garantias] PRIMARY KEY CLUSTERED 
(
	[GaranteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idiomas]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idiomas](
	[Idioma] [nvarchar](10) NOT NULL,
	[Descrip] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingresos]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingresos](
	[IngresoID] [int] IDENTITY(1,1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Departamento] [smallint] NOT NULL,
	[Proveedor] [int] NOT NULL,
	[RtoSucursal] [smallint] NOT NULL,
	[RtoNumero] [int] NOT NULL,
	[FechaIng] [smalldatetime] NOT NULL,
	[FechaRto] [smalldatetime] NOT NULL,
	[Detalle] [varchar](250) NULL,
	[Estado] [tinyint] NOT NULL,
	[RecTecnica] [int] NOT NULL,
	[OrdCompra] [int] NOT NULL,
	[Destino] [nvarchar](50) NULL,
	[SubTotal] [float] NOT NULL,
	[Bonificacion] [real] NOT NULL,
	[Total] [float] NOT NULL,
	[Auto] [bit] NOT NULL,
	[Usuario] [varchar](25) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[EmpresaId] [smallint] NOT NULL,
 CONSTRAINT [PK_Ingresos] PRIMARY KEY CLUSTERED 
(
	[IngresoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngresosDet]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngresosDet](
	[IngresoID] [int] NOT NULL,
	[RtoRenglon] [smallint] NOT NULL,
	[Producto] [int] NOT NULL,
	[Concepto] [smallint] NOT NULL,
	[Detalle] [varchar](50) NULL,
	[Partida] [varchar](20) NOT NULL,
	[Cantidad] [float] NOT NULL,
	[Saldo] [float] NOT NULL,
	[Costo] [float] NOT NULL,
	[Descuento] [real] NOT NULL,
	[FechaVenc] [smalldatetime] NULL,
	[RenglonOC] [smallint] NOT NULL,
	[Usuario] [varchar](25) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[Bonificacion] [varchar](25) NULL,
	[SubTotal] [varchar](25) NULL,
	[ImpInt] [float] NULL,
	[AlicuoIva] [real] NULL,
 CONSTRAINT [PK_IngresosDet] PRIMARY KEY CLUSTERED 
(
	[IngresoID] ASC,
	[RtoRenglon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InqLiqAux]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InqLiqAux](
	[Recibe] [nvarchar](50) NULL,
	[SonPesos] [nvarchar](100) NULL,
	[Periodo] [nvarchar](20) NULL,
	[Domicilio] [nvarchar](50) NULL,
	[Telefono] [nvarchar](50) NULL,
	[TipoIva] [nvarchar](50) NULL,
	[Cuit] [nvarchar](13) NULL,
	[TIva] [nvarchar](3) NULL,
	[Total] [float] NULL,
	[Pago] [float] NULL,
	[Saldo] [float] NULL,
	[Usuario] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inquilinos]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inquilinos](
	[Codigo] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[DNI] [int] NOT NULL,
	[Telefono] [varchar](25) NULL,
	[Domicilio] [varchar](50) NULL,
	[Localidad] [varchar](50) NULL,
	[UltimoAlquiler] [varchar](50) NULL,
	[TelUltAlquiler] [varchar](50) NULL,
	[Trabajo] [varchar](50) NULL,
	[TelTrabajo] [varchar](25) NULL,
	[DomTrabajo] [varchar](50) NULL,
	[Estado] [varchar](1) NOT NULL,
	[DescEstado] [varchar](50) NULL,
	[TipoIva] [varchar](3) NOT NULL,
	[Cuit] [varchar](15) NULL,
	[Observaciones] [text] NULL,
	[Cuenta] [varchar](12) NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[AgRetGan] [bit] NOT NULL,
	[DocPend] [bit] NULL,
	[InqEMail] [varchar](250) NULL,
 CONSTRAINT [PK_Inquilinos] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiqAux]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiqAux](
	[Recibe] [nvarchar](50) NULL,
	[SonPesos] [varchar](512) NULL,
	[Periodo] [nvarchar](50) NULL,
	[Domicilio] [nvarchar](50) NULL,
	[Telefono] [nvarchar](50) NULL,
	[TipoIva] [nvarchar](50) NULL,
	[Cuit] [nvarchar](13) NULL,
	[TIva] [nvarchar](3) NULL,
	[Subtotal] [float] NULL,
	[Comision] [float] NULL,
	[Iva1] [float] NULL,
	[Iva2] [float] NULL,
	[RetGan] [float] NULL,
	[Total] [float] NULL,
	[Usuario] [varchar](20) NULL,
	[Numero] [int] NULL,
	[Propietario] [varchar](10) NULL,
	[LqxPC] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiqInqCab]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiqInqCab](
	[Periodo] [nvarchar](7) NOT NULL,
	[Propietario] [int] NULL,
	[Propiedad] [int] NULL,
	[Inquilino] [int] NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Tipo] [nvarchar](1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[MesPago] [smallint] NULL,
	[SaldoAnt] [float] NULL,
	[SubTotal] [float] NULL,
	[Intereses] [float] NULL,
	[Iva1] [float] NULL,
	[Iva2] [float] NULL,
	[Total] [float] NOT NULL,
	[Efectivo] [float] NOT NULL,
	[Cheques] [float] NOT NULL,
	[Banco] [smallint] NULL,
	[FecCheque] [smalldatetime] NULL,
	[NroCheque] [nvarchar](15) NULL,
	[Saldo] [float] NOT NULL,
	[Detalle] [ntext] NULL,
	[LiqPropiet] [int] NOT NULL,
	[Liquidado] [bit] NOT NULL,
	[Estado] [smallint] NOT NULL,
	[Caja] [smallint] NOT NULL,
	[Bonos] [float] NULL,
	[cFecha] [nvarchar](8) NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NULL,
	[ChReciboID] [int] NULL,
	[LiqInqTrID] [int] NULL,
	[ImporteTR] [float] NOT NULL,
	[LiqInqID] [int] IDENTITY(1,1) NOT NULL,
	[SaldoPend] [float] NULL,
	[Retencion] [float] NULL,
	[RetencNro] [varchar](25) NULL,
 CONSTRAINT [PK_LiqInqCab] PRIMARY KEY CLUSTERED 
(
	[Tipo] ASC,
	[Sucursal] ASC,
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiqInqCob]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiqInqCob](
	[LicId] [int] IDENTITY(1,1) NOT NULL,
	[LicFecha] [smalldatetime] NOT NULL,
	[LicEfectivo] [float] NULL,
	[LicRetencion] [float] NULL,
	[LicTransferencia] [float] NULL,
	[LicCheques] [float] NULL,
	[LicUid] [varchar](50) NOT NULL,
	[LicFecMod] [smalldatetime] NOT NULL,
	[LiqInqTrId] [int] NULL,
	[Inquilino] [int] NULL,
	[LicSaldo] [float] NULL,
	[LiqPropiet] [int] NOT NULL,
 CONSTRAINT [PK_LiqInqCob] PRIMARY KEY CLUSTERED 
(
	[LicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiqInqCobCh]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiqInqCobCh](
	[LchId] [int] IDENTITY(1,1) NOT NULL,
	[LicId] [int] NOT NULL,
	[ChCarteraId] [int] NOT NULL,
	[LicUid] [varchar](50) NOT NULL,
	[LicFecMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_LiqInqCobCh] PRIMARY KEY CLUSTERED 
(
	[LchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiqInqCobDet]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiqInqCobDet](
	[LcdId] [int] IDENTITY(1,1) NOT NULL,
	[LicId] [int] NOT NULL,
	[LiqInqId] [int] NOT NULL,
	[LcdImpPago] [float] NULL,
	[LcdUid] [varchar](50) NOT NULL,
	[LcdFecMod] [smalldatetime] NOT NULL,
	[LcdSaldo] [float] NULL,
 CONSTRAINT [PK_LiqInqCobDet] PRIMARY KEY CLUSTERED 
(
	[LcdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiqInqDet]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiqInqDet](
	[Tipo] [varchar](1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Renglon] [smallint] NOT NULL,
	[Concepto] [varchar](5) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Detalle] [varchar](250) NULL,
	[Importe] [float] NOT NULL,
	[Imputacion] [varchar](1) NOT NULL,
	[aPropiet] [bit] NOT NULL,
	[Saldo] [float] NULL,
	[LiqPropiet] [int] NULL,
	[Comprob] [varchar](50) NULL,
	[Origen] [smallint] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NULL,
	[LiqInqID] [int] NULL,
	[FactInqID] [int] NULL,
 CONSTRAINT [PK_LiqInqDet] PRIMARY KEY CLUSTERED 
(
	[Tipo] ASC,
	[Sucursal] ASC,
	[Numero] ASC,
	[Renglon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiqInqPPar]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiqInqPPar](
	[LiqInqPParId] [int] IDENTITY(1,1) NOT NULL,
	[LiqInqId] [int] NOT NULL,
	[LPFecha] [smalldatetime] NOT NULL,
	[LPImporte] [float] NOT NULL,
	[LPFechaMod] [smalldatetime] NOT NULL,
	[LPUsuMod] [varchar](50) NOT NULL,
	[LPNombrePC] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LiqInqPPar] PRIMARY KEY CLUSTERED 
(
	[LiqInqPParId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiqInqTR]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiqInqTR](
	[LiqInqTrID] [int] IDENTITY(1,1) NOT NULL,
	[Banco0] [int] NOT NULL,
	[Cuenta0] [varchar](25) NOT NULL,
	[Titular0] [varchar](50) NOT NULL,
	[Banco1] [int] NOT NULL,
	[Cuenta1] [varchar](25) NOT NULL,
	[FechaTR] [smalldatetime] NOT NULL,
	[NumeroTR] [varchar](25) NOT NULL,
	[ImporteTR] [float] NOT NULL,
	[Usuario] [varchar](25) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_LiqInqTR] PRIMARY KEY CLUSTERED 
(
	[LiqInqTrID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiqPropCond]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiqPropCond](
	[LiqPropiet] [int] NOT NULL,
	[Renglon] [smallint] NOT NULL,
	[Propietario] [int] NOT NULL,
	[CodCond] [smallint] NOT NULL,
	[FechaGen] [smalldatetime] NOT NULL,
	[FechaLiq] [smalldatetime] NULL,
	[Concepto] [varchar](3) NOT NULL,
	[Detalle] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Importe] [float] NULL,
	[Porcent] [real] NULL,
	[Credito] [float] NULL,
	[Debito] [float] NULL,
	[Usuario] [varchar](25) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_LiqPropCond] PRIMARY KEY CLUSTERED 
(
	[LiqPropiet] ASC,
	[Renglon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiqPropiet]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiqPropiet](
	[Numero] [int] NOT NULL,
	[Propietario] [int] NOT NULL,
	[Periodo] [varchar](6) NOT NULL,
	[Fecha] [smalldatetime] NULL,
	[FechaC] [varchar](8) NULL,
	[Recibo] [int] NOT NULL,
	[Tipo] [nvarchar](1) NOT NULL,
	[Sucursal] [smallint] NULL,
	[Factura] [int] NULL,
	[Detalle] [text] NULL,
	[Alquiler] [float] NOT NULL,
	[Debe] [float] NOT NULL,
	[Haber] [float] NOT NULL,
	[Comision] [float] NOT NULL,
	[Iva1] [float] NOT NULL,
	[Iva2] [float] NOT NULL,
	[RetGcias] [float] NOT NULL,
	[Total] [float] NOT NULL,
	[Efectivo] [float] NOT NULL,
	[Cheque] [float] NOT NULL,
	[NroCheque] [int] NOT NULL,
	[FecCheque] [smalldatetime] NULL,
	[Banco] [smallint] NULL,
	[CtaBco] [nvarchar](10) NULL,
	[Estado] [smallint] NULL,
	[Caja] [smallint] NOT NULL,
	[NetoCom] [float] NULL,
	[Bonos] [float] NULL,
	[Propiedad] [varchar](10) NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[AlquilerRet] [float] NULL,
	[LiqPropTrId] [int] NULL,
	[ImporteTr] [float] NULL,
	[RetencionInq] [float] NULL,
	[GastosBanc] [float] NULL,
 CONSTRAINT [PK_LiqPropiet] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiqPropietAg]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiqPropietAg](
	[Numero] [int] NOT NULL,
	[LiqPropiet] [int] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_LiqPropietAg] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC,
	[LiqPropiet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiqPropietDet]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiqPropietDet](
	[Numero] [int] NOT NULL,
	[Renglon] [smallint] NOT NULL,
	[Concepto] [varchar](5) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Detalle] [varchar](250) NULL,
	[Importe] [float] NOT NULL,
	[Debe] [float] NOT NULL,
	[Haber] [float] NOT NULL,
	[Saldo] [float] NOT NULL,
	[Comprob] [varchar](50) NULL,
	[Origen] [smallint] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NULL,
 CONSTRAINT [PK_LiqPropietDet] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC,
	[Renglon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiqPropRes]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiqPropRes](
	[Uid] [varchar](50) NOT NULL,
	[Host] [varchar](50) NOT NULL,
	[LiqPropiet] [int] NOT NULL,
	[Fecha] [smalldatetime] NULL,
	[Concepto] [varchar](10) NULL,
	[Detalle] [varchar](250) NULL,
	[Debe] [float] NULL,
	[Haber] [float] NULL,
	[Saldo] [float] NULL,
	[Inquilino] [int] NULL,
	[Propiedad] [int] NULL,
	[Tipo] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiqPropTmp]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiqPropTmp](
	[Usuario] [nvarchar](10) NOT NULL,
	[Periodo] [nvarchar](6) NOT NULL,
	[Propiedad] [nvarchar](10) NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Concepto] [nvarchar](10) NOT NULL,
	[Detalle] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Debe] [float] NULL,
	[Haber] [float] NULL,
	[Tipo] [nvarchar](1) NULL,
	[Sucursal] [smallint] NULL,
	[Numero] [int] NULL,
	[Origen] [tinyint] NULL,
	[Proveedor] [int] NULL,
	[FechaMod] [smalldatetime] NULL,
	[Retencion] [float] NULL,
	[Importe] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiqPropTR]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiqPropTR](
	[LiqPropTrID] [int] IDENTITY(1,1) NOT NULL,
	[Banco0] [int] NULL,
	[Cuenta0] [varchar](25) NULL,
	[Banco1] [int] NULL,
	[Cuenta1] [varchar](25) NULL,
	[Titular1] [varchar](50) NULL,
	[FechaTR] [smalldatetime] NULL,
	[NumeroTR] [varchar](25) NULL,
	[ImporteTR] [float] NOT NULL,
	[Usuario] [varchar](25) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[GastosImp] [float] NULL,
	[GastosSF] [float] NULL,
	[GastosIva] [float] NULL,
	[ImporteNeto] [float] NULL,
 CONSTRAINT [PK_LiqPropTR] PRIMARY KEY CLUSTERED 
(
	[LiqPropTrID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListAdel]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListAdel](
	[ListAdelId] [int] IDENTITY(1,1) NOT NULL,
	[Propietario] [int] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Periodo] [varchar](7) NULL,
	[NumeroLiq] [int] NULL,
	[Detalle] [varchar](250) NULL,
	[Debe] [float] NOT NULL,
	[Haber] [float] NOT NULL,
	[Propiedad] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidad]    Script Date: 10/12/2021 00:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidad](
	[Codigo] [varchar](10) NOT NULL,
	[Descrip] [varchar](50) NOT NULL,
	[Provincia] [varchar](50) NULL,
	[Pais] [smallint] NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[LocalidadId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Localidad] PRIMARY KEY CLUSTERED 
(
	[LocalidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logicos]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logicos](
	[Dato] [bit] NOT NULL,
	[SN] [varchar](10) NULL,
	[VF] [varchar](10) NULL,
	[Comision] [varchar](10) NULL,
	[Marca] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MayorAux]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MayorAux](
	[Usuario] [varchar](20) NOT NULL,
	[CtaMadre] [varchar](15) NULL,
	[Cuenta] [varchar](15) NOT NULL,
	[SdoAnt] [float] NULL,
	[Debe] [float] NULL,
	[Haber] [float] NULL,
	[SaldoD] [float] NULL,
	[SaldoH] [float] NULL,
	[Imput] [varchar](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovBancosAux]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovBancosAux](
	[Banco] [smallint] NOT NULL,
	[Cuenta] [nvarchar](10) NOT NULL,
	[Tipo] [smallint] NOT NULL,
	[Numero] [nvarchar](25) NOT NULL,
	[Debe] [float] NOT NULL,
	[Haber] [float] NULL,
	[Saldo] [float] NOT NULL,
	[Usuario] [nvarchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[NombrePC] [varchar](50) NULL,
	[MovBancoId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ocupaciones]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ocupaciones](
	[Codigo] [nvarchar](3) NOT NULL,
	[Descrip] [nvarchar](50) NOT NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenPago]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenPago](
	[OrdenPagoID] [int] IDENTITY(1,1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[OPNumero] [int] NOT NULL,
	[OPTipo] [varchar](3) NULL,
	[Proveedor] [int] NOT NULL,
	[OPFecha] [smalldatetime] NOT NULL,
	[OPDetalle] [varchar](250) NULL,
	[Estado] [tinyint] NOT NULL,
	[OPTotal] [float] NOT NULL,
	[OPFecPago] [smalldatetime] NULL,
	[OPEfectivo] [float] NULL,
	[OPCheques] [float] NULL,
	[OPUid] [varchar](25) NOT NULL,
	[OPFecMod] [smalldatetime] NOT NULL,
	[Efectivo] [float] NULL,
	[Cheques] [float] NULL,
	[OPTransf] [float] NOT NULL,
 CONSTRAINT [PK_OrdenPago] PRIMARY KEY CLUSTERED 
(
	[OrdenPagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenPagoCH]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenPagoCH](
	[OrdenPagoID] [int] NOT NULL,
	[OPCRenglon] [smallint] NOT NULL,
	[Origen] [varchar](1) NOT NULL,
	[Banco] [int] NOT NULL,
	[Cuenta] [varchar](50) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[OPCUid] [varchar](50) NOT NULL,
	[OPCFecMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_OrdenPagoCH] PRIMARY KEY CLUSTERED 
(
	[OrdenPagoID] ASC,
	[OPCRenglon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenPagoDet]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenPagoDet](
	[OrdenPagoID] [int] NOT NULL,
	[Proveedor] [int] NOT NULL,
	[ProComprob] [varchar](25) NOT NULL,
	[ProSucursal] [smallint] NOT NULL,
	[ProNumero] [int] NOT NULL,
	[OPDUid] [varchar](25) NOT NULL,
	[OPDFecMod] [smalldatetime] NOT NULL,
	[OPImpPago] [float] NOT NULL,
 CONSTRAINT [PK_OrdenPagoDet_1] PRIMARY KEY CLUSTERED 
(
	[Proveedor] ASC,
	[ProComprob] ASC,
	[ProSucursal] ASC,
	[ProNumero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenPagoTR]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenPagoTR](
	[OrdenPagoTrId] [int] IDENTITY(1,1) NOT NULL,
	[OrdenPagoId] [int] NOT NULL,
	[Banco0] [int] NULL,
	[Cuenta0] [varchar](25) NULL,
	[Banco1] [int] NULL,
	[Cuenta1] [varchar](25) NULL,
	[Titular1] [varchar](50) NULL,
	[FechaTR] [smalldatetime] NULL,
	[NumeroTR] [varchar](25) NULL,
	[ImporteTR] [float] NOT NULL,
	[GastosSF] [float] NULL,
	[GastosIva] [float] NULL,
	[GastosImp] [float] NULL,
	[ImporteNeto] [float] NULL,
	[Usuario] [varchar](25) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_OrdenPagoTR] PRIMARY KEY CLUSTERED 
(
	[OrdenPagoTrId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagos]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagos](
	[Comprob] [nvarchar](3) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Proveedor] [int] NOT NULL,
	[SubTotal] [float] NOT NULL,
	[Intereses] [float] NOT NULL,
	[Total] [float] NOT NULL,
	[Efectivo] [float] NOT NULL,
	[Cheques] [float] NOT NULL,
	[Banco] [smallint] NULL,
	[CtaBco] [nvarchar](10) NULL,
	[NroCheque] [nvarchar](15) NULL,
	[FecCheque] [smalldatetime] NULL,
	[Moneda] [nvarchar](3) NOT NULL,
	[Detalle] [ntext] NULL,
	[Caja] [smallint] NOT NULL,
	[Estado] [float] NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PagosDet]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PagosDet](
	[Comprob] [nvarchar](3) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Renglon] [smallint] NOT NULL,
	[Proveedor] [int] NOT NULL,
	[ProComprob] [nvarchar](25) NOT NULL,
	[ProSucursal] [smallint] NOT NULL,
	[ProNumero] [int] NOT NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PagosDetTmp]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PagosDetTmp](
	[Usuario] [nvarchar](10) NOT NULL,
	[Proveedor] [int] NOT NULL,
	[Comprob] [nvarchar](25) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[PerIva] [nvarchar](7) NOT NULL,
	[Tipo] [nvarchar](1) NOT NULL,
	[Total] [float] NOT NULL,
	[Propietario] [varchar](10) NULL,
	[Propiedad] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paises](
	[Codigo] [smallint] NOT NULL,
	[Descrip] [nvarchar](50) NOT NULL,
	[Idioma] [nvarchar](10) NULL,
	[Usuario] [nvarchar](10) NULL,
	[FechaMod] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidosProv]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidosProv](
	[PedidoPrID] [int] IDENTITY(1,1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Departamento] [smallint] NOT NULL,
	[PedidoPrNro] [varchar](25) NOT NULL,
	[Proveedor] [int] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[FechaEnv] [smalldatetime] NULL,
	[Estado] [tinyint] NOT NULL,
	[Observ] [varchar](250) NULL,
	[PedidoID] [int] NULL,
	[Total] [float] NOT NULL,
	[Saldo] [float] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[FechaRec] [smalldatetime] NULL,
	[EmpresaId] [smallint] NOT NULL,
 CONSTRAINT [PK_PedidosProv] PRIMARY KEY CLUSTERED 
(
	[PedidoPrID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[Usuario] [varchar](20) NOT NULL,
	[Objeto] [varchar](50) NOT NULL,
	[UsuMod] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC,
	[Objeto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanCtas]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanCtas](
	[CtaMadre] [varchar](15) NULL,
	[Cuenta] [varchar](15) NOT NULL,
	[CtaAbr] [nvarchar](4) NULL,
	[Descrip] [varchar](50) NOT NULL,
	[DescAbr] [varchar](10) NOT NULL,
	[SdoHab] [varchar](1) NOT NULL,
	[RecAsi] [bit] NOT NULL,
	[oCuenta] [bit] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_PlanCtas] PRIMARY KEY CLUSTERED 
(
	[Cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Propiedades]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Propiedades](
	[Propietario] [int] NOT NULL,
	[Codigo] [int] NOT NULL,
	[Inquilino] [int] NULL,
	[Valor] [float] NOT NULL,
	[Domicilio] [nvarchar](50) NOT NULL,
	[Barrio] [nvarchar](50) NOT NULL,
	[Localidad] [nvarchar](50) NOT NULL,
	[Tipo] [nvarchar](10) NOT NULL,
	[Descripcion] [varchar](2500) NULL,
	[Estado] [nvarchar](10) NULL,
	[TipoAlq] [nvarchar](1) NOT NULL,
	[NomCat] [nvarchar](20) NULL,
	[Comision] [real] NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Propiedades] PRIMARY KEY CLUSTERED 
(
	[Propietario] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropiedConc]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropiedConc](
	[Propiedad] [int] NOT NULL,
	[Concepto] [varchar](3) NOT NULL,
	[FecDesde] [smalldatetime] NOT NULL,
	[Detalle] [varchar](250) NULL,
	[Importe] [float] NOT NULL,
	[Imputacion] [varchar](1) NOT NULL,
	[Automatico] [bit] NOT NULL,
	[aPropiet] [bit] NOT NULL,
	[aPagar] [bit] NOT NULL,
	[noInquilino] [bit] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropietAg]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropietAg](
	[PropietAgId] [int] IDENTITY(1,1) NOT NULL,
	[PagDescrip] [varchar](50) NOT NULL,
	[PagUsuario] [varchar](50) NOT NULL,
	[PagFecMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_PropietAg] PRIMARY KEY CLUSTERED 
(
	[PropietAgId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropietAgDet]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropietAgDet](
	[PropietAgId] [int] NOT NULL,
	[Propietario] [int] NOT NULL,
	[PadUsuario] [varchar](50) NOT NULL,
	[PadFecMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_PropietAgDet] PRIMARY KEY CLUSTERED 
(
	[PropietAgId] ASC,
	[Propietario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Propietarios]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Propietarios](
	[Codigo] [int] NOT NULL,
	[Dni] [int] NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Barrio] [nvarchar](50) NULL,
	[Domicilio] [nvarchar](50) NULL,
	[Localidad] [varchar](64) NULL,
	[Telefono] [nvarchar](25) NULL,
	[Tel_Emp] [nvarchar](15) NULL,
	[Tel_Movil] [nvarchar](25) NULL,
	[eMail] [nvarchar](50) NULL,
	[CUIT] [nvarchar](13) NULL,
	[Empresa] [nvarchar](50) NULL,
	[DomEmp] [nvarchar](50) NULL,
	[emailEmp] [nvarchar](50) NULL,
	[Condicion] [nvarchar](30) NOT NULL,
	[LocEmp] [varchar](64) NULL,
	[TipoIva] [nvarchar](3) NOT NULL,
	[TipoFactura] [nvarchar](15) NULL,
	[FormaPago] [nvarchar](15) NULL,
	[CatGcias] [smallint] NOT NULL,
	[Comision] [real] NOT NULL,
	[Cuenta] [nvarchar](10) NULL,
	[CtaAdl] [nvarchar](10) NULL,
	[Observaciones] [ntext] NULL,
	[Banco] [nvarchar](25) NULL,
	[TipoCta] [nvarchar](10) NULL,
	[NroCta] [nvarchar](25) NULL,
	[NombreCta] [nvarchar](50) NULL,
	[CBU] [nvarchar](50) NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[Estado] [nvarchar](1) NULL,
	[Legajo] [varchar](50) NULL,
	[DocPend] [bit] NULL,
	[FechaNac] [varchar](50) NULL,
	[AlicGan] [real] NULL,
	[LocalidadId] [int] NULL,
 CONSTRAINT [PK_Propietarios] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropietCond]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropietCond](
	[Propietario] [int] NOT NULL,
	[CodCond] [smallint] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Dni] [int] NULL,
	[Domicilio] [nvarchar](50) NULL,
	[Localidad] [nvarchar](50) NULL,
	[Telefono] [nvarchar](25) NULL,
	[CUIT] [nvarchar](13) NULL,
	[TipoIva] [varchar](3) NULL,
	[PorcCond] [real] NULL,
	[Usuario] [varchar](20) NULL,
	[FechaMod] [smalldatetime] NULL,
 CONSTRAINT [PK_PropietCond] PRIMARY KEY CLUSTERED 
(
	[Propietario] ASC,
	[CodCond] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropietCondConc]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropietCondConc](
	[Propietario] [int] NOT NULL,
	[CodCond] [smallint] NOT NULL,
	[Concepto] [nvarchar](3) NOT NULL,
	[Detalle] [nvarchar](50) NULL,
	[Porcent] [real] NULL,
	[Debito] [float] NULL,
	[Credito] [float] NULL,
	[Usuario] [nvarchar](10) NULL,
	[FechaMod] [smalldatetime] NULL,
 CONSTRAINT [PK_PropietCondConc] PRIMARY KEY CLUSTERED 
(
	[Propietario] ASC,
	[CodCond] ASC,
	[Concepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProvCasual]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProvCasual](
	[Codigo] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Domicilio] [nvarchar](50) NULL,
	[TipoIva] [nvarchar](3) NOT NULL,
	[Cuit] [nvarchar](15) NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[Codigo] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Domicilio] [varchar](50) NULL,
	[Localidad] [varchar](50) NULL,
	[Provincia] [varchar](50) NULL,
	[Contacto] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[eMail] [varchar](100) NULL,
	[TipoIva] [varchar](3) NOT NULL,
	[Cuit] [varchar](15) NULL,
	[CondVenta] [smallint] NOT NULL,
	[Cuenta] [varchar](15) NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[Cod_Postal] [varchar](10) NULL,
	[Dias] [smallint] NULL,
	[AlicIva] [varchar](3) NOT NULL,
	[Proveedor] [int] IDENTITY(1,1) NOT NULL,
	[Inactivo] [bit] NOT NULL,
	[EmpresaId] [smallint] NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recepcion]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recepcion](
	[RecepcionID] [int] IDENTITY(1,1) NOT NULL,
	[RecTipo] [varchar](1) NOT NULL,
	[Inquilino] [int] NULL,
	[Propietario] [int] NULL,
	[Proveedor] [int] NULL,
	[RecNombre] [varchar](50) NOT NULL,
	[RecFecha] [smalldatetime] NOT NULL,
	[RecEstado] [varchar](1) NOT NULL,
	[RecAtiende] [varchar](50) NULL,
	[RecDetalle] [varchar](1000) NOT NULL,
	[RecObserv] [text] NULL,
	[RecUid] [varchar](25) NOT NULL,
	[RecFecMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Recepcion] PRIMARY KEY CLUSTERED 
(
	[RecepcionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RepVarios]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RepVarios](
	[Usuario] [nvarchar](10) NOT NULL,
	[Clave] [nvarchar](50) NULL,
	[Campo1] [nvarchar](100) NULL,
	[Campo2] [nvarchar](100) NULL,
	[Campo3] [nvarchar](100) NULL,
	[Debe] [float] NULL,
	[Haber] [float] NULL,
	[Nivel] [smallint] NULL,
	[ClaveRep] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RepVariosAux]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RepVariosAux](
	[Usuario] [nvarchar](10) NOT NULL,
	[Titulo] [nvarchar](50) NULL,
	[SubTitulo] [nvarchar](50) NULL,
	[FecDesde] [smalldatetime] NULL,
	[FecHasta] [smalldatetime] NULL,
	[Desde] [nvarchar](50) NULL,
	[Hasta] [nvarchar](50) NULL,
	[SdoAnt] [float] NULL,
	[Debe] [float] NULL,
	[Haber] [float] NULL,
	[Saldo] [float] NULL,
	[Logo] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResALiqProp]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResALiqProp](
	[Propietario] [int] NULL,
	[Propiedad] [int] NULL,
	[Inquilino] [int] NULL,
	[Tipo] [varchar](50) NULL,
	[Sucursal] [smallint] NULL,
	[Numero] [int] NULL,
	[Renglon] [smallint] NULL,
	[Fecha] [smalldatetime] NULL,
	[Periodo] [varchar](10) NULL,
	[Concepto] [varchar](50) NULL,
	[Detalle] [varchar](250) NULL,
	[Nombre] [varchar](250) NULL,
	[Debe] [float] NULL,
	[Haber] [float] NULL,
	[Importe] [float] NULL,
	[Saldo] [float] NULL,
	[Origen] [tinyint] NULL,
	[Proveedor] [int] NULL,
	[Retencion] [float] NULL,
	[LicId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResAlqAnual]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResAlqAnual](
	[Propietario] [varchar](10) NOT NULL,
	[Propiedad] [varchar](10) NOT NULL,
	[Inquilino] [varchar](10) NOT NULL,
	[PerVenc] [varchar](10) NOT NULL,
	[Anio1] [float] NULL,
	[Anio2] [float] NULL,
	[Anio3] [float] NULL,
	[Iva1] [float] NULL,
	[Iva2] [float] NULL,
	[Iva3] [float] NULL,
	[Tipo] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResumenCaja]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResumenCaja](
	[Cuenta] [varchar](15) NOT NULL,
	[Descrip] [varchar](50) NULL,
	[Entrada] [float] NULL,
	[Salida] [float] NULL,
	[Saldo] [float] NULL,
	[Cantidad] [int] NULL,
	[CtaMadre] [bit] NOT NULL,
	[Imput] [varchar](1) NOT NULL,
	[NroCta] [smallint] NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_ResumenCaja] PRIMARY KEY CLUSTERED 
(
	[Cuenta] ASC,
	[Imput] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RetGcias]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RetGcias](
	[Numero] [int] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Propietario] [int] NOT NULL,
	[Periodo] [nvarchar](6) NOT NULL,
	[PeriodoC] [nvarchar](15) NOT NULL,
	[Acumulado] [float] NOT NULL,
	[Neto] [float] NOT NULL,
	[Retenido] [float] NOT NULL,
	[Agente] [nvarchar](30) NOT NULL,
	[DDJJAño] [smallint] NOT NULL,
	[Estado] [smallint] NULL,
	[LiqPropiet] [float] NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_RetGcias] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SucBco]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SucBco](
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](40) NULL,
	[numero] [nvarchar](40) NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_SucBco] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoComp]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoComp](
	[Codigo] [varchar](3) NOT NULL,
	[Descrip] [varchar](50) NOT NULL,
	[Imput] [nvarchar](1) NOT NULL,
	[ParaFact] [bit] NOT NULL,
	[CompPago] [bit] NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[TipoComp] [int] IDENTITY(1,1) NOT NULL,
	[DescAbrev] [varchar](3) NULL,
 CONSTRAINT [PK_TipoComp] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoIva]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoIva](
	[Codigo] [varchar](3) NOT NULL,
	[Descrip] [varchar](50) NOT NULL,
	[EmiteComp] [varchar](10) NULL,
	[RecibeComp] [varchar](10) NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[TipoIva] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TipoIva] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoMovBco]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoMovBco](
	[TipoMovBco] [smallint] NOT NULL,
	[Descrip] [nvarchar](50) NOT NULL,
	[Imput] [nvarchar](1) NOT NULL,
	[TipoMov] [nvarchar](2) NULL,
	[Cuenta] [nvarchar](10) NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoProp]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProp](
	[Codigo] [nvarchar](10) NOT NULL,
	[Descrip] [nvarchar](40) NOT NULL,
	[Usuario] [nvarchar](10) NOT NULL,
	[FechaMod] [smalldatetime] NULL,
	[TipoPropId] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tmp_ANGY_20211101256298]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tmp_ANGY_20211101256298](
	[Banco0] [int] NOT NULL,
	[Cuenta0] [varchar](25) NOT NULL,
	[Titular] [varchar](50) NOT NULL,
	[Banco1] [int] NOT NULL,
	[Cuenta1] [varchar](25) NOT NULL,
	[FechaTR] [smalldatetime] NOT NULL,
	[NumeroTR] [varchar](25) NOT NULL,
	[ImporteTR] [float] NOT NULL,
	[GastosImp] [float] NULL,
	[GastosSF] [float] NULL,
	[GastosIva] [float] NULL,
	[ImporteNeto] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tmp_cristina_20211101129864]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tmp_cristina_20211101129864](
	[Banco0] [int] NOT NULL,
	[Cuenta0] [varchar](25) NOT NULL,
	[Titular] [varchar](50) NOT NULL,
	[Banco1] [int] NOT NULL,
	[Cuenta1] [varchar](25) NOT NULL,
	[FechaTR] [smalldatetime] NOT NULL,
	[NumeroTR] [varchar](25) NOT NULL,
	[ImporteTR] [float] NOT NULL,
	[GastosImp] [float] NULL,
	[GastosSF] [float] NULL,
	[GastosIva] [float] NULL,
	[ImporteNeto] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tmp_cristina_20211101161064]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tmp_cristina_20211101161064](
	[Banco0] [int] NOT NULL,
	[Cuenta0] [varchar](25) NOT NULL,
	[Titular] [varchar](50) NOT NULL,
	[Banco1] [int] NOT NULL,
	[Cuenta1] [varchar](25) NOT NULL,
	[FechaTR] [smalldatetime] NOT NULL,
	[NumeroTR] [varchar](25) NOT NULL,
	[ImporteTR] [float] NOT NULL,
	[GastosImp] [float] NULL,
	[GastosSF] [float] NULL,
	[GastosIva] [float] NULL,
	[ImporteNeto] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tmp_cristina_20211101335060]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tmp_cristina_20211101335060](
	[Tipo] [varchar](1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tmp_cristina_20211101426381]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tmp_cristina_20211101426381](
	[Banco0] [int] NOT NULL,
	[Cuenta0] [varchar](25) NOT NULL,
	[Titular] [varchar](50) NOT NULL,
	[Banco1] [int] NOT NULL,
	[Cuenta1] [varchar](25) NOT NULL,
	[FechaTR] [smalldatetime] NOT NULL,
	[NumeroTR] [varchar](25) NOT NULL,
	[ImporteTR] [float] NOT NULL,
	[GastosImp] [float] NULL,
	[GastosSF] [float] NULL,
	[GastosIva] [float] NULL,
	[ImporteNeto] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tmp_cristina_2021110163132]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tmp_cristina_2021110163132](
	[Banco0] [int] NOT NULL,
	[Cuenta0] [varchar](25) NOT NULL,
	[Titular] [varchar](50) NOT NULL,
	[Banco1] [int] NOT NULL,
	[Cuenta1] [varchar](25) NOT NULL,
	[FechaTR] [smalldatetime] NOT NULL,
	[NumeroTR] [varchar](25) NOT NULL,
	[ImporteTR] [float] NOT NULL,
	[GastosImp] [float] NULL,
	[GastosSF] [float] NULL,
	[GastosIva] [float] NULL,
	[ImporteNeto] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tmp_cristina_20211101845119]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tmp_cristina_20211101845119](
	[Banco0] [int] NOT NULL,
	[Cuenta0] [varchar](25) NOT NULL,
	[Titular] [varchar](50) NOT NULL,
	[Banco1] [int] NOT NULL,
	[Cuenta1] [varchar](25) NOT NULL,
	[FechaTR] [smalldatetime] NOT NULL,
	[NumeroTR] [varchar](25) NOT NULL,
	[ImporteTR] [float] NOT NULL,
	[GastosImp] [float] NULL,
	[GastosSF] [float] NULL,
	[GastosIva] [float] NULL,
	[ImporteNeto] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Traductor]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Traductor](
	[Control] [nvarchar](20) NOT NULL,
	[Palabra] [nvarchar](20) NULL,
	[Descrip] [nvarchar](50) NULL,
	[ENGLISH] [nvarchar](50) NULL,
	[ESPAÑOL] [nvarchar](128) NULL,
	[Sistema] [nvarchar](10) NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Traductor] PRIMARY KEY CLUSTERED 
(
	[Control] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Usuario] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
	[Permisos] [bit] NULL,
	[Admin] [bit] NULL,
	[UsuMod] [varchar](50) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[Tipo] [nvarchar](1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Comprob] [nvarchar](3) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Cliente] [int] NULL,
	[Inquilino] [nvarchar](10) NULL,
	[Popietario] [nvarchar](10) NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[TipoIva] [nvarchar](3) NOT NULL,
	[Cuit] [nvarchar](13) NULL,
	[Gravado] [float] NULL,
	[NoGravado] [float] NULL,
	[Exento] [float] NULL,
	[Iva1] [float] NULL,
	[Iva2] [float] NULL,
	[Total] [float] NULL,
	[Detalle] [ntext] NULL,
	[LiqPropiet] [int] NOT NULL,
	[Estado] [smallint] NOT NULL,
	[NroCobro] [int] NULL,
	[Usuario] [varchar](20) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[VentaId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[Tipo] ASC,
	[Sucursal] ASC,
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentasCh]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentasCh](
	[Tipo] [varchar](1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Banco] [smallint] NOT NULL,
	[Cuenta] [varchar](50) NOT NULL,
	[ChNumero] [varchar](50) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_VentasCh] PRIMARY KEY CLUSTERED 
(
	[Tipo] ASC,
	[Sucursal] ASC,
	[Numero] ASC,
	[Banco] ASC,
	[Cuenta] ASC,
	[ChNumero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentasDet]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentasDet](
	[Tipo] [nvarchar](1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Renglon] [smallint] NOT NULL,
	[Concepto] [varchar](10) NOT NULL,
	[Detalle] [varchar](250) NULL,
	[Cantidad] [float] NULL,
	[Precio] [float] NULL,
	[Descuento] [float] NULL,
	[Usuario] [varchar](50) NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_VentasDet] PRIMARY KEY CLUSTERED 
(
	[Tipo] ASC,
	[Sucursal] ASC,
	[Numero] ASC,
	[Renglon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentasTmp]    Script Date: 10/12/2021 00:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentasTmp](
	[Tipo] [nvarchar](1) NOT NULL,
	[Sucursal] [smallint] NOT NULL,
	[Numero] [int] NOT NULL,
	[Renglon] [smallint] NOT NULL,
	[Concepto] [nvarchar](10) NOT NULL,
	[Detalle] [varchar](50) NULL,
	[Cantidad] [float] NULL,
	[Precio] [float] NULL,
	[Descuento] [float] NULL,
	[Usuario] [nvarchar](10) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AlicIva] ADD  DEFAULT ('') FOR [AlicIva]
GO
ALTER TABLE [dbo].[AvisoDeuda] ADD  CONSTRAINT [DF__AvisoDeud__Fecha__1A34DF26]  DEFAULT ('31/01/2006 16:42:28') FOR [FechaMod]
GO
ALTER TABLE [dbo].[AvisoHoras] ADD  CONSTRAINT [DF__AvisoHora__Fecha__1B29035F]  DEFAULT ('31/01/2006 16:42:28') FOR [FechaMod]
GO
ALTER TABLE [dbo].[BancoProp] ADD  CONSTRAINT [DF__BancoProp__Fecha__1C1D2798]  DEFAULT ('31/01/2006 16:42:28') FOR [FechaMod]
GO
ALTER TABLE [dbo].[BancosCtas] ADD  CONSTRAINT [DF_BancoCta_SaldoIni]  DEFAULT ((0)) FOR [SaldoIni]
GO
ALTER TABLE [dbo].[BancosCtas] ADD  CONSTRAINT [DF_BancoCta_SaldoAnt]  DEFAULT ((0)) FOR [SaldoAnt]
GO
ALTER TABLE [dbo].[Barrios] ADD  CONSTRAINT [DF__Barrios__FechaMo__1D114BD1]  DEFAULT ('31/01/2006 16:42:28') FOR [FechaMod]
GO
ALTER TABLE [dbo].[Caja] ADD  CONSTRAINT [DF_Caja_Entrada]  DEFAULT ((0)) FOR [Entrada]
GO
ALTER TABLE [dbo].[Caja] ADD  CONSTRAINT [DF_Caja_Salida]  DEFAULT ((0)) FOR [Salida]
GO
ALTER TABLE [dbo].[Caja] ADD  CONSTRAINT [DF_Caja_CajaAdm]  DEFAULT ((0)) FOR [CajaAdm]
GO
ALTER TABLE [dbo].[Cajas] ADD  CONSTRAINT [DF_Cajas_SdoAnt]  DEFAULT ((0)) FOR [SdoAnt]
GO
ALTER TABLE [dbo].[Cajas] ADD  CONSTRAINT [DF_Cajas_SdoAct]  DEFAULT ((0)) FOR [SdoAct]
GO
ALTER TABLE [dbo].[Cajas] ADD  CONSTRAINT [DF_Cajas_UltNroMN]  DEFAULT ((0)) FOR [UltNroMN]
GO
ALTER TABLE [dbo].[CatGcias] ADD  CONSTRAINT [DF_CatGcias_Alicuota]  DEFAULT ((0)) FOR [Alicuota]
GO
ALTER TABLE [dbo].[CatGcias] ADD  CONSTRAINT [DF_CatGcias_MinimoImp]  DEFAULT ((0)) FOR [MinimoImp]
GO
ALTER TABLE [dbo].[CatGcias] ADD  CONSTRAINT [DF_CatGcias_RetMinima]  DEFAULT ((0)) FOR [RetMinima]
GO
ALTER TABLE [dbo].[ChCartera] ADD  CONSTRAINT [DF_ChCartera_Importe]  DEFAULT ((0)) FOR [Importe]
GO
ALTER TABLE [dbo].[ChCartera] ADD  CONSTRAINT [DF_ChCartera_CajaAdm]  DEFAULT ((0)) FOR [CajaAdm]
GO
ALTER TABLE [dbo].[ChCartera] ADD  DEFAULT ((0)) FOR [Caja]
GO
ALTER TABLE [dbo].[ChCartera0] ADD  CONSTRAINT [DF_ChCartera_Importe0]  DEFAULT ((0)) FOR [Importe]
GO
ALTER TABLE [dbo].[ChCartera0] ADD  CONSTRAINT [DF_ChCartera_CajaAdm0]  DEFAULT ((0)) FOR [CajaAdm]
GO
ALTER TABLE [dbo].[ChCartera0] ADD  DEFAULT ((0)) FOR [Caja]
GO
ALTER TABLE [dbo].[CobOtrDet] ADD  DEFAULT ((0)) FOR [aPropiet]
GO
ALTER TABLE [dbo].[CobrosOtr] ADD  CONSTRAINT [DF_CobrosOtr_Liquidado]  DEFAULT ((0)) FOR [Liquidado]
GO
ALTER TABLE [dbo].[CobrosOtr] ADD  CONSTRAINT [DF_CobrosOtr_LiqPropiet]  DEFAULT ((0)) FOR [LiqPropiet]
GO
ALTER TABLE [dbo].[CobrosOtr] ADD  CONSTRAINT [DF_CobrosOtr_LiqInquilino]  DEFAULT ((0)) FOR [LiqInquilino]
GO
ALTER TABLE [dbo].[CobrosOtr] ADD  CONSTRAINT [DF_CobrosOtr_Estado]  DEFAULT ((0)) FOR [Estado]
GO
ALTER TABLE [dbo].[ComACobR] ADD  DEFAULT ((0)) FOR [Estado]
GO
ALTER TABLE [dbo].[CompraOtr] ADD  CONSTRAINT [DF_CompraOtr_Proveedor]  DEFAULT ((0)) FOR [Proveedor]
GO
ALTER TABLE [dbo].[CompraOtr] ADD  CONSTRAINT [DF_CompraOtr_Pagado]  DEFAULT ((0)) FOR [Pagado]
GO
ALTER TABLE [dbo].[CompraOtr] ADD  CONSTRAINT [DF_CompraOtr_NroPago]  DEFAULT ((0)) FOR [NroPago]
GO
ALTER TABLE [dbo].[CompraOtr] ADD  CONSTRAINT [DF_CompraOtr_Liquidado]  DEFAULT ((0)) FOR [Liquidado]
GO
ALTER TABLE [dbo].[CompraOtr] ADD  CONSTRAINT [DF_CompraOtr_LiqPropiet]  DEFAULT ((0)) FOR [LiqPropiet]
GO
ALTER TABLE [dbo].[CompraOtrDet] ADD  CONSTRAINT [DF_CompraOtrDet_Proveedor]  DEFAULT ((0)) FOR [Proveedor]
GO
ALTER TABLE [dbo].[CompraOtrDet] ADD  CONSTRAINT [DF_CompraOtrDet_aPropiet]  DEFAULT ((0)) FOR [aPropiet]
GO
ALTER TABLE [dbo].[Compras] ADD  CONSTRAINT [DF_Compras_Pagado]  DEFAULT ((0)) FOR [Pagado]
GO
ALTER TABLE [dbo].[Compras] ADD  DEFAULT ((0)) FOR [Sucursal]
GO
ALTER TABLE [dbo].[Compras] ADD  DEFAULT ((1)) FOR [CondVenta]
GO
ALTER TABLE [dbo].[Compras] ADD  DEFAULT ((0)) FOR [Estado]
GO
ALTER TABLE [dbo].[Compras] ADD  DEFAULT ((1)) FOR [CompServ]
GO
ALTER TABLE [dbo].[Compras] ADD  DEFAULT ((1)) FOR [TipoComp]
GO
ALTER TABLE [dbo].[ComprasDet] ADD  DEFAULT ((0)) FOR [CompraId]
GO
ALTER TABLE [dbo].[Config] ADD  CONSTRAINT [DF__Config__FechaMod__1E05700A]  DEFAULT ('31/01/2006 16:42:28') FOR [FechaMod]
GO
ALTER TABLE [dbo].[ConfigUsu] ADD  DEFAULT ((0)) FOR [CfuWState]
GO
ALTER TABLE [dbo].[ConfigUsu] ADD  DEFAULT ((0)) FOR [CfuLeft]
GO
ALTER TABLE [dbo].[ConfigUsu] ADD  DEFAULT ((0)) FOR [CfuTop]
GO
ALTER TABLE [dbo].[ConfigUsu] ADD  DEFAULT ((0)) FOR [CfuWidth]
GO
ALTER TABLE [dbo].[ConfigUsu] ADD  DEFAULT ((0)) FOR [CfuHeight]
GO
ALTER TABLE [dbo].[Contratos] ADD  CONSTRAINT [DF__Contratos__Escal__21D600EE]  DEFAULT ((0)) FOR [Escalon]
GO
ALTER TABLE [dbo].[Contratos] ADD  CONSTRAINT [DF__Contratos__Meses__22CA2527]  DEFAULT ((0)) FOR [MesesEsc]
GO
ALTER TABLE [dbo].[Contratos] ADD  CONSTRAINT [DF__Contratos__Incre__23BE4960]  DEFAULT ((0)) FOR [Incremento]
GO
ALTER TABLE [dbo].[FactInq] ADD  CONSTRAINT [DF_FactInq_Liquidado]  DEFAULT ((0)) FOR [Liquidado]
GO
ALTER TABLE [dbo].[FactInq] ADD  CONSTRAINT [DF_FactInq_Automatico]  DEFAULT ((0)) FOR [Automatico]
GO
ALTER TABLE [dbo].[FactInq] ADD  CONSTRAINT [DF_FactInq_aPropiet]  DEFAULT ((0)) FOR [aPropiet]
GO
ALTER TABLE [dbo].[FactInq] ADD  CONSTRAINT [DF_FactInq_MesPago]  DEFAULT ((0)) FOR [MesPago]
GO
ALTER TABLE [dbo].[Garantias] ADD  CONSTRAINT [DF__Garantias__Fecha__1EF99443]  DEFAULT ('31/01/2006 16:42:28') FOR [FechaMod]
GO
ALTER TABLE [dbo].[Garantias] ADD  DEFAULT ('sa') FOR [Usuario]
GO
ALTER TABLE [dbo].[Inquilinos] ADD  CONSTRAINT [DF_Inquilinos_DNI]  DEFAULT ((0)) FOR [DNI]
GO
ALTER TABLE [dbo].[Inquilinos] ADD  CONSTRAINT [DF__Inquilino__AgRet__184C96B4]  DEFAULT ((0)) FOR [AgRetGan]
GO
ALTER TABLE [dbo].[Inquilinos] ADD  CONSTRAINT [DF__Inquilino__DocPe__7E57BA87]  DEFAULT ((0)) FOR [DocPend]
GO
ALTER TABLE [dbo].[LiqInqCab] ADD  CONSTRAINT [DF_LiqInqCab_Periodo]  DEFAULT ((0)) FOR [Periodo]
GO
ALTER TABLE [dbo].[LiqInqCab] ADD  CONSTRAINT [DF_LiqInqCab_LiqPropiet]  DEFAULT ((0)) FOR [LiqPropiet]
GO
ALTER TABLE [dbo].[LiqInqCab] ADD  CONSTRAINT [DF_LiqInqCab_Liquidado_1]  DEFAULT ((0)) FOR [Liquidado]
GO
ALTER TABLE [dbo].[LiqInqCab] ADD  CONSTRAINT [DF_LiqInqCab_ImporteTR]  DEFAULT ((0)) FOR [ImporteTR]
GO
ALTER TABLE [dbo].[LiqInqCab] ADD  CONSTRAINT [DF__LiqInqCab__Saldo__0D99FE17]  DEFAULT ((0)) FOR [SaldoPend]
GO
ALTER TABLE [dbo].[LiqInqCob] ADD  DEFAULT ((0)) FOR [LicSaldo]
GO
ALTER TABLE [dbo].[LiqInqCob] ADD  DEFAULT ((0)) FOR [LiqPropiet]
GO
ALTER TABLE [dbo].[LiqInqDet] ADD  CONSTRAINT [DF_LiqInqDet_aPropiet]  DEFAULT ((0)) FOR [aPropiet]
GO
ALTER TABLE [dbo].[LiqInqDet] ADD  CONSTRAINT [DF_LiqInqDet_LiqPropiet]  DEFAULT ((0)) FOR [LiqPropiet]
GO
ALTER TABLE [dbo].[ListAdel] ADD  CONSTRAINT [DF_ListAdel_Debe]  DEFAULT ((0)) FOR [Debe]
GO
ALTER TABLE [dbo].[ListAdel] ADD  CONSTRAINT [DF_ListAdel_Haber]  DEFAULT ((0)) FOR [Haber]
GO
ALTER TABLE [dbo].[OrdenPago] ADD  CONSTRAINT [DF__OrdenPago__Estad__5649C92D]  DEFAULT ((0)) FOR [Estado]
GO
ALTER TABLE [dbo].[OrdenPago] ADD  DEFAULT ((0)) FOR [OPTransf]
GO
ALTER TABLE [dbo].[OrdenPagoDet] ADD  CONSTRAINT [DF__OrdenPago__OPImp__14E61A24]  DEFAULT ((0)) FOR [OPImpPago]
GO
ALTER TABLE [dbo].[PlanCtas] ADD  CONSTRAINT [DF_PlanCtas_RecAsi]  DEFAULT ((0)) FOR [RecAsi]
GO
ALTER TABLE [dbo].[PlanCtas] ADD  CONSTRAINT [DF_PlanCtas_oCuenta]  DEFAULT ((0)) FOR [oCuenta]
GO
ALTER TABLE [dbo].[PropiedConc] ADD  CONSTRAINT [DF_PropiedConc_Automatico]  DEFAULT ((0)) FOR [Automatico]
GO
ALTER TABLE [dbo].[PropiedConc] ADD  CONSTRAINT [DF_PropiedConc_aPropiet]  DEFAULT ((0)) FOR [aPropiet]
GO
ALTER TABLE [dbo].[PropiedConc] ADD  CONSTRAINT [DF_PropiedConc_aPagar]  DEFAULT ((0)) FOR [aPagar]
GO
ALTER TABLE [dbo].[PropiedConc] ADD  CONSTRAINT [DF_PropiedConc_noInquilino]  DEFAULT ((0)) FOR [noInquilino]
GO
ALTER TABLE [dbo].[Propietarios] ADD  CONSTRAINT [DF__Propietar__DocPe__7F4BDEC0]  DEFAULT ((0)) FOR [DocPend]
GO
ALTER TABLE [dbo].[PropietCond] ADD  CONSTRAINT [DF_PropietCond_Dni]  DEFAULT ((0)) FOR [Dni]
GO
ALTER TABLE [dbo].[PropietCond] ADD  CONSTRAINT [DF_PropietCond_PorcCond]  DEFAULT ((0)) FOR [PorcCond]
GO
ALTER TABLE [dbo].[Proveedores] ADD  CONSTRAINT [DF_Proveedores_CondVenta]  DEFAULT ((0)) FOR [CondVenta]
GO
ALTER TABLE [dbo].[Proveedores] ADD  DEFAULT ('GEN') FOR [AlicIva]
GO
ALTER TABLE [dbo].[Proveedores] ADD  DEFAULT ((0)) FOR [Inactivo]
GO
ALTER TABLE [dbo].[SucBco] ADD  CONSTRAINT [DF__SucBco__FechaMod__1FEDB87C]  DEFAULT ('31/01/2006 16:42:28') FOR [FechaMod]
GO
ALTER TABLE [dbo].[Traductor] ADD  DEFAULT ('02/10/2015 14:37:23') FOR [FechaMod]
GO
ALTER TABLE [dbo].[Ventas] ADD  CONSTRAINT [DF_Ventas_LiqPropiet]  DEFAULT ((0)) FOR [LiqPropiet]
GO
ALTER TABLE [dbo].[Ventas] ADD  CONSTRAINT [DF_Ventas_Estado]  DEFAULT ((0)) FOR [Estado]
GO
ALTER TABLE [dbo].[Ventas] ADD  CONSTRAINT [DF_Ventas_NroCobro]  DEFAULT ((0)) FOR [NroCobro]
GO
ALTER TABLE [dbo].[LiqInqCobCh]  WITH NOCHECK ADD  CONSTRAINT [FK_LiqInqCobCh_ChCartera] FOREIGN KEY([ChCarteraId])
REFERENCES [dbo].[ChCartera] ([ChCartId])
GO
ALTER TABLE [dbo].[LiqInqCobCh] CHECK CONSTRAINT [FK_LiqInqCobCh_ChCartera]
GO
ALTER TABLE [dbo].[LiqPropietDet]  WITH CHECK ADD  CONSTRAINT [FK_LiqPropietDet_LiqPropiet] FOREIGN KEY([Numero])
REFERENCES [dbo].[LiqPropiet] ([Numero])
GO
ALTER TABLE [dbo].[LiqPropietDet] CHECK CONSTRAINT [FK_LiqPropietDet_LiqPropiet]
GO
