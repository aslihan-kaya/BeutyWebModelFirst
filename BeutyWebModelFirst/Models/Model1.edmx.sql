
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/06/2022 16:00:33
-- Generated from EDMX file: C:\Users\Aslihan\OneDrive\Masaüstü\ModelFirstWebSite\BeutyWebModelFirst\BeutyWebModelFirst\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BeautyShop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SaticiBilgileriUyeBilgileri]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UyeBilgileriSet] DROP CONSTRAINT [FK_SaticiBilgileriUyeBilgileri];
GO
IF OBJECT_ID(N'[dbo].[FK_SaticiBilgileriUrunler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UrunlerSet] DROP CONSTRAINT [FK_SaticiBilgileriUrunler];
GO
IF OBJECT_ID(N'[dbo].[FK_UrunlerUrunBilgileri]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UrunBilgileriSet] DROP CONSTRAINT [FK_UrunlerUrunBilgileri];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[SaticiBilgileriSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SaticiBilgileriSet];
GO
IF OBJECT_ID(N'[dbo].[UyeBilgileriSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UyeBilgileriSet];
GO
IF OBJECT_ID(N'[dbo].[UrunlerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UrunlerSet];
GO
IF OBJECT_ID(N'[dbo].[UrunBilgileriSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UrunBilgileriSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SaticiBilgileriSet'
CREATE TABLE [dbo].[SaticiBilgileriSet] (
    [SaticiId] int IDENTITY(1,1) NOT NULL,
    [SaticiAdSoyad] nvarchar(max)  NOT NULL,
    [SaticiTelefon] nvarchar(max)  NOT NULL,
    [SaticiAdres] nvarchar(max)  NOT NULL,
    [SaticiMail] nvarchar(max)  NOT NULL,
    [SaticiSifre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UyeBilgileriSet'
CREATE TABLE [dbo].[UyeBilgileriSet] (
    [UyeId] int IDENTITY(1,1) NOT NULL,
    [UyeAdSoyad] nvarchar(max)  NOT NULL,
    [UyeTelefon] nvarchar(max)  NOT NULL,
    [UyeAdres] nvarchar(max)  NOT NULL,
    [UyeMail] nvarchar(max)  NOT NULL,
    [UyeSifre] nvarchar(max)  NOT NULL,
    [SaticiId] nvarchar(max)  NOT NULL,
    [SaticiBilgileriSaticiId] int  NOT NULL
);
GO

-- Creating table 'UrunlerSet'
CREATE TABLE [dbo].[UrunlerSet] (
    [UrunId] int IDENTITY(1,1) NOT NULL,
    [UrunAdi] nvarchar(max)  NOT NULL,
    [Urunkodu] nvarchar(max)  NOT NULL,
    [SaticiId] nvarchar(max)  NOT NULL,
    [SaticiBilgileriSaticiId] int  NOT NULL
);
GO

-- Creating table 'UrunBilgileriSet'
CREATE TABLE [dbo].[UrunBilgileriSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UretimTarihi] nvarchar(max)  NOT NULL,
    [SKT] nvarchar(max)  NOT NULL,
    [Urunid] nvarchar(max)  NOT NULL,
    [UrunlerUrunId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [SaticiId] in table 'SaticiBilgileriSet'
ALTER TABLE [dbo].[SaticiBilgileriSet]
ADD CONSTRAINT [PK_SaticiBilgileriSet]
    PRIMARY KEY CLUSTERED ([SaticiId] ASC);
GO

-- Creating primary key on [UyeId] in table 'UyeBilgileriSet'
ALTER TABLE [dbo].[UyeBilgileriSet]
ADD CONSTRAINT [PK_UyeBilgileriSet]
    PRIMARY KEY CLUSTERED ([UyeId] ASC);
GO

-- Creating primary key on [UrunId] in table 'UrunlerSet'
ALTER TABLE [dbo].[UrunlerSet]
ADD CONSTRAINT [PK_UrunlerSet]
    PRIMARY KEY CLUSTERED ([UrunId] ASC);
GO

-- Creating primary key on [Id] in table 'UrunBilgileriSet'
ALTER TABLE [dbo].[UrunBilgileriSet]
ADD CONSTRAINT [PK_UrunBilgileriSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SaticiBilgileriSaticiId] in table 'UyeBilgileriSet'
ALTER TABLE [dbo].[UyeBilgileriSet]
ADD CONSTRAINT [FK_SaticiBilgileriUyeBilgileri]
    FOREIGN KEY ([SaticiBilgileriSaticiId])
    REFERENCES [dbo].[SaticiBilgileriSet]
        ([SaticiId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SaticiBilgileriUyeBilgileri'
CREATE INDEX [IX_FK_SaticiBilgileriUyeBilgileri]
ON [dbo].[UyeBilgileriSet]
    ([SaticiBilgileriSaticiId]);
GO

-- Creating foreign key on [SaticiBilgileriSaticiId] in table 'UrunlerSet'
ALTER TABLE [dbo].[UrunlerSet]
ADD CONSTRAINT [FK_SaticiBilgileriUrunler]
    FOREIGN KEY ([SaticiBilgileriSaticiId])
    REFERENCES [dbo].[SaticiBilgileriSet]
        ([SaticiId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SaticiBilgileriUrunler'
CREATE INDEX [IX_FK_SaticiBilgileriUrunler]
ON [dbo].[UrunlerSet]
    ([SaticiBilgileriSaticiId]);
GO

-- Creating foreign key on [UrunlerUrunId] in table 'UrunBilgileriSet'
ALTER TABLE [dbo].[UrunBilgileriSet]
ADD CONSTRAINT [FK_UrunlerUrunBilgileri]
    FOREIGN KEY ([UrunlerUrunId])
    REFERENCES [dbo].[UrunlerSet]
        ([UrunId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UrunlerUrunBilgileri'
CREATE INDEX [IX_FK_UrunlerUrunBilgileri]
ON [dbo].[UrunBilgileriSet]
    ([UrunlerUrunId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------