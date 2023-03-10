USE [KayaBank]
GO
/****** Object:  Table [dbo].[BrachInformations]    Script Date: 8.01.2023 00:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BrachInformations](
	[BranchNo] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [varchar](50) NULL,
	[BranchCity] [varchar](50) NULL,
	[BranchDistrict] [varchar](50) NULL,
	[BranchManager] [varchar](50) NULL,
	[BranchContact] [varchar](50) NULL,
 CONSTRAINT [PK_BrachInformations] PRIMARY KEY CLUSTERED 
(
	[BranchNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerInformations]    Script Date: 8.01.2023 00:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerInformations](
	[CustomerNumber] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NULL,
	[CustomerPassword] [char](6) NULL,
	[CustomerPhone] [char](11) NULL,
	[CustomerMail] [varchar](50) NULL,
	[CustomerAdres] [varchar](50) NULL,
 CONSTRAINT [PK_CustomerInformations] PRIMARY KEY CLUSTERED 
(
	[CustomerNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DebtInformations]    Script Date: 8.01.2023 00:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DebtInformations](
	[DebtNumber] [int] IDENTITY(1,1) NOT NULL,
	[DebtAmount] [decimal](19, 4) NULL,
	[DebtMaturity] [int] NULL,
	[CustomerNumber] [int] NULL,
 CONSTRAINT [PK_DebtInformations] PRIMARY KEY CLUSTERED 
(
	[DebtNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 8.01.2023 00:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentNumber] [int] IDENTITY(1,1) NOT NULL,
	[PaymentType] [varchar](50) NULL,
	[PaymentTotal] [decimal](19, 4) NULL,
	[DebtNumber] [int] NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DebtInformations]  WITH CHECK ADD  CONSTRAINT [FK_DebtInformation_CustomerInformation] FOREIGN KEY([CustomerNumber])
REFERENCES [dbo].[CustomerInformations] ([CustomerNumber])
GO
ALTER TABLE [dbo].[DebtInformations] CHECK CONSTRAINT [FK_DebtInformation_CustomerInformation]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_DebtInformation] FOREIGN KEY([DebtNumber])
REFERENCES [dbo].[DebtInformations] ([DebtNumber])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_DebtInformation]
GO
