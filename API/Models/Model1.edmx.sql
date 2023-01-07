
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/17/2022 22:51:57
-- Generated from EDMX file: C:\Users\Aslihan\Desktop\KayaBank_WepApiCrudMVC\KayaBank_WepApiCrudMVC\API\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KayaBank];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DebtInformation_CustomerInformation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DebtInformation] DROP CONSTRAINT [FK_DebtInformation_CustomerInformation];
GO
IF OBJECT_ID(N'[dbo].[FK_Payments_DebtInformation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Payments] DROP CONSTRAINT [FK_Payments_DebtInformation];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BrachInformation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BrachInformation];
GO
IF OBJECT_ID(N'[dbo].[CustomerInformation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerInformation];
GO
IF OBJECT_ID(N'[dbo].[DebtInformation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DebtInformation];
GO
IF OBJECT_ID(N'[dbo].[Payments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payments];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BrachInformations'
CREATE TABLE [dbo].[BrachInformations] (
    [BranchNo] int IDENTITY(1,1) NOT NULL,
    [BranchName] varchar(50)  NULL,
    [BranchCity] varchar(50)  NULL,
    [BranchDistrict] varchar(50)  NULL,
    [BranchManager] varchar(50)  NULL,
    [BranchContact] varchar(50)  NULL
);
GO

-- Creating table 'CustomerInformations'
CREATE TABLE [dbo].[CustomerInformations] (
    [CustomerNumber] int IDENTITY(1,1) NOT NULL,
    [CustomerName] varchar(50)  NULL,
    [CustomerPassword] char(6)  NULL,
    [CustomerPhone] char(11)  NULL,
    [CustomerMail] varchar(50)  NULL,
    [CustomerAdres] varchar(50)  NULL
);
GO

-- Creating table 'DebtInformations'
CREATE TABLE [dbo].[DebtInformations] (
    [DebtNumber] int IDENTITY(1,1) NOT NULL,
    [DebtAmount] decimal(19,4)  NULL,
    [DebtMaturity] int  NULL,
    [CustomerNumber] int  NULL
);
GO

-- Creating table 'Payments'
CREATE TABLE [dbo].[Payments] (
    [PaymentNumber] int IDENTITY(1,1) NOT NULL,
    [PaymentType] varchar(50)  NULL,
    [PaymentTotal] decimal(19,4)  NULL,
    [DebtNumber] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BranchNo] in table 'BrachInformations'
ALTER TABLE [dbo].[BrachInformations]
ADD CONSTRAINT [PK_BrachInformations]
    PRIMARY KEY CLUSTERED ([BranchNo] ASC);
GO

-- Creating primary key on [CustomerNumber] in table 'CustomerInformations'
ALTER TABLE [dbo].[CustomerInformations]
ADD CONSTRAINT [PK_CustomerInformations]
    PRIMARY KEY CLUSTERED ([CustomerNumber] ASC);
GO

-- Creating primary key on [DebtNumber] in table 'DebtInformations'
ALTER TABLE [dbo].[DebtInformations]
ADD CONSTRAINT [PK_DebtInformations]
    PRIMARY KEY CLUSTERED ([DebtNumber] ASC);
GO

-- Creating primary key on [PaymentNumber] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [PK_Payments]
    PRIMARY KEY CLUSTERED ([PaymentNumber] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerNumber] in table 'DebtInformations'
ALTER TABLE [dbo].[DebtInformations]
ADD CONSTRAINT [FK_DebtInformation_CustomerInformation]
    FOREIGN KEY ([CustomerNumber])
    REFERENCES [dbo].[CustomerInformations]
        ([CustomerNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DebtInformation_CustomerInformation'
CREATE INDEX [IX_FK_DebtInformation_CustomerInformation]
ON [dbo].[DebtInformations]
    ([CustomerNumber]);
GO

-- Creating foreign key on [DebtNumber] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [FK_Payments_DebtInformation]
    FOREIGN KEY ([DebtNumber])
    REFERENCES [dbo].[DebtInformations]
        ([DebtNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Payments_DebtInformation'
CREATE INDEX [IX_FK_Payments_DebtInformation]
ON [dbo].[Payments]
    ([DebtNumber]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------