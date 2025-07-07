
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/13/2025 22:06:24
-- Generated from EDMX file: C:\Users\abdul\OneDrive\Desktop\EF_PROJE\MF_Proje\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Galeri];
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

-- Creating table 'ArabalarSet'
CREATE TABLE [dbo].[ArabalarSet] (
    [ArabaNo] int IDENTITY(1,1) NOT NULL,
    [Marka] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Fiyat] decimal(18,0)  NOT NULL,
    [BayiNo] int  NULL
);
GO

-- Creating table 'BayilerSet'
CREATE TABLE [dbo].[BayilerSet] (
    [BayiNo] int IDENTITY(1,1) NOT NULL,
    [BayiAdi] nvarchar(max)  NOT NULL,
    [BayiAdres] nvarchar(max)  NOT NULL,
    [BayiCiro] nvarchar(max)  NOT NULL,
    [Adet] nvarchar(max)  NOT NULL,
    [KullaniciNo] int  NOT NULL
);
GO

-- Creating table 'KullanicilarSet'
CREATE TABLE [dbo].[KullanicilarSet] (
    [KullaniciNo] int IDENTITY(1,1) NOT NULL,
    [KullaniciAdi] nvarchar(max)  NOT NULL,
    [Sifre] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ArabaNo] in table 'ArabalarSet'
ALTER TABLE [dbo].[ArabalarSet]
ADD CONSTRAINT [PK_ArabalarSet]
    PRIMARY KEY CLUSTERED ([ArabaNo] ASC);
GO

-- Creating primary key on [BayiNo] in table 'BayilerSet'
ALTER TABLE [dbo].[BayilerSet]
ADD CONSTRAINT [PK_BayilerSet]
    PRIMARY KEY CLUSTERED ([BayiNo] ASC);
GO

-- Creating primary key on [KullaniciNo] in table 'KullanicilarSet'
ALTER TABLE [dbo].[KullanicilarSet]
ADD CONSTRAINT [PK_KullanicilarSet]
    PRIMARY KEY CLUSTERED ([KullaniciNo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BayiNo] in table 'ArabalarSet'
ALTER TABLE [dbo].[ArabalarSet]
ADD CONSTRAINT [FK_ArabalarBayiler]
    FOREIGN KEY ([BayiNo])
    REFERENCES [dbo].[BayilerSet]
        ([BayiNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArabalarBayiler'
CREATE INDEX [IX_FK_ArabalarBayiler]
ON [dbo].[ArabalarSet]
    ([BayiNo]);
GO

-- Creating foreign key on [KullaniciNo] in table 'BayilerSet'
ALTER TABLE [dbo].[BayilerSet]
ADD CONSTRAINT [FK_KullanicilarBayiler]
    FOREIGN KEY ([KullaniciNo])
    REFERENCES [dbo].[KullanicilarSet]
        ([KullaniciNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KullanicilarBayiler'
CREATE INDEX [IX_FK_KullanicilarBayiler]
ON [dbo].[BayilerSet]
    ([KullaniciNo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

