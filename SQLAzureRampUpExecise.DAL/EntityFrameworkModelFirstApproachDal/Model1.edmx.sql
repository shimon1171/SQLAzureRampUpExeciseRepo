
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/20/2019 11:36:51
-- Generated from EDMX file: D:\Project\SQLAzureRampUpExeciseRepo\SQLAzureRampUpExeciseRepo\SQLAzureRampUpExecise.DAL\EntityFrameworkModelFirstApproachDal\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SQLAzureRampUpExeciseLocalHostEFDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [CompanyName] nvarchar(max)  NOT NULL,
    [RestaurantName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrderInfoes'
CREATE TABLE [dbo].[OrderInfoes] (
    [OrderInfoID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Time] datetime  NOT NULL,
    [OrderUserID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [OrderInfoID] in table 'OrderInfoes'
ALTER TABLE [dbo].[OrderInfoes]
ADD CONSTRAINT [PK_OrderInfoes]
    PRIMARY KEY CLUSTERED ([OrderInfoID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OrderUserID] in table 'OrderInfoes'
ALTER TABLE [dbo].[OrderInfoes]
ADD CONSTRAINT [FK_OrderOrderInfo]
    FOREIGN KEY ([OrderUserID])
    REFERENCES [dbo].[Orders]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderInfo'
CREATE INDEX [IX_FK_OrderOrderInfo]
ON [dbo].[OrderInfoes]
    ([OrderUserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------