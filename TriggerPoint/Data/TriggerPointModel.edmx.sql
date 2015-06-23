
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/26/2015 09:02:03
-- Generated from EDMX file: B:\Workshop\trigger point\cv\TriggerPoint\SVN\trunk\TriggerPoint\TriggerPoint\Data\TriggerPointModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Nirav];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Tbl_Pivote_Tbl_ScriptMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tbl_Pivote] DROP CONSTRAINT [FK_Tbl_Pivote_Tbl_ScriptMaster];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[FK_Tbl_Script_Tbl_ScriptMaster]', 'F') IS NOT NULL
    ALTER TABLE [TriggerPointModelStoreContainer].[Tbl_Script] DROP CONSTRAINT [FK_Tbl_Script_Tbl_ScriptMaster];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Tbl_Average]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_Average];
GO
IF OBJECT_ID(N'[dbo].[Tbl_AverageParameters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_AverageParameters];
GO
IF OBJECT_ID(N'[dbo].[Tbl_BollingerBand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_BollingerBand];
GO
IF OBJECT_ID(N'[dbo].[Tbl_config_ColumnMapings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_config_ColumnMapings];
GO
IF OBJECT_ID(N'[dbo].[Tbl_config_ColumnMapings_EOD]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_config_ColumnMapings_EOD];
GO
IF OBJECT_ID(N'[dbo].[Tbl_EODData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_EODData];
GO
IF OBJECT_ID(N'[dbo].[Tbl_ErrorDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_ErrorDetail];
GO
IF OBJECT_ID(N'[dbo].[Tbl_FormulaPortfolio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_FormulaPortfolio];
GO
IF OBJECT_ID(N'[dbo].[Tbl_MACD]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_MACD];
GO
IF OBJECT_ID(N'[dbo].[Tbl_MACDFilters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_MACDFilters];
GO
IF OBJECT_ID(N'[dbo].[Tbl_MACDParameters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_MACDParameters];
GO
IF OBJECT_ID(N'[dbo].[Tbl_Master]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_Master];
GO
IF OBJECT_ID(N'[dbo].[Tbl_Pivote]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_Pivote];
GO
IF OBJECT_ID(N'[dbo].[Tbl_Portfolio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_Portfolio];
GO
IF OBJECT_ID(N'[dbo].[Tbl_RSI]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_RSI];
GO
IF OBJECT_ID(N'[dbo].[Tbl_RSIParameters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_RSIParameters];
GO
IF OBJECT_ID(N'[dbo].[Tbl_Script_archive]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_Script_archive];
GO
IF OBJECT_ID(N'[dbo].[Tbl_ScriptMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_ScriptMaster];
GO
IF OBJECT_ID(N'[dbo].[Tbl_ScriptPortfolio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_ScriptPortfolio];
GO
IF OBJECT_ID(N'[dbo].[Tbl_ScriptUpload]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_ScriptUpload];
GO
IF OBJECT_ID(N'[dbo].[Tbl_ScriptUploadMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_ScriptUploadMaster];
GO
IF OBJECT_ID(N'[dbo].[Tbl_SplitMergeHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_SplitMergeHistory];
GO
IF OBJECT_ID(N'[dbo].[Tbl_Stochastic]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_Stochastic];
GO
IF OBJECT_ID(N'[dbo].[Tbl_Swing]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_Swing];
GO
IF OBJECT_ID(N'[dbo].[Tbl_SwingParameters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_SwingParameters];
GO
IF OBJECT_ID(N'[dbo].[Tbl_SystemSetting]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_SystemSetting];
GO
IF OBJECT_ID(N'[dbo].[Tbl_User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_User];
GO
IF OBJECT_ID(N'[dbo].[Tbl_UserDefineFormula]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_UserDefineFormula];
GO
IF OBJECT_ID(N'[dbo].[Tbl_UserType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_UserType];
GO
IF OBJECT_ID(N'[dbo].[Tbl_Volatility]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tbl_Volatility];
GO
IF OBJECT_ID(N'[dbo].[TestTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestTable];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[Tbl_config_Settings]', 'U') IS NOT NULL
    DROP TABLE [TriggerPointModelStoreContainer].[Tbl_config_Settings];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[Tbl_Script]', 'U') IS NOT NULL
    DROP TABLE [TriggerPointModelStoreContainer].[Tbl_Script];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[Tbl_Script_Ami]', 'U') IS NOT NULL
    DROP TABLE [TriggerPointModelStoreContainer].[Tbl_Script_Ami];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[Tbl_Script10Min]', 'U') IS NOT NULL
    DROP TABLE [TriggerPointModelStoreContainer].[Tbl_Script10Min];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[Tbl_Script120Min]', 'U') IS NOT NULL
    DROP TABLE [TriggerPointModelStoreContainer].[Tbl_Script120Min];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[Tbl_Script15Min]', 'U') IS NOT NULL
    DROP TABLE [TriggerPointModelStoreContainer].[Tbl_Script15Min];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[Tbl_Script1Min]', 'U') IS NOT NULL
    DROP TABLE [TriggerPointModelStoreContainer].[Tbl_Script1Min];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[Tbl_Script20Min]', 'U') IS NOT NULL
    DROP TABLE [TriggerPointModelStoreContainer].[Tbl_Script20Min];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[Tbl_Script30Min]', 'U') IS NOT NULL
    DROP TABLE [TriggerPointModelStoreContainer].[Tbl_Script30Min];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[Tbl_Script45Min]', 'U') IS NOT NULL
    DROP TABLE [TriggerPointModelStoreContainer].[Tbl_Script45Min];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[Tbl_Script5Min]', 'U') IS NOT NULL
    DROP TABLE [TriggerPointModelStoreContainer].[Tbl_Script5Min];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[Tbl_Script60Min]', 'U') IS NOT NULL
    DROP TABLE [TriggerPointModelStoreContainer].[Tbl_Script60Min];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[Tbl_Script885Min]', 'U') IS NOT NULL
    DROP TABLE [TriggerPointModelStoreContainer].[Tbl_Script885Min];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[Tbl_Script90Min]', 'U') IS NOT NULL
    DROP TABLE [TriggerPointModelStoreContainer].[Tbl_Script90Min];
GO
IF OBJECT_ID(N'[TriggerPointModelStoreContainer].[Tbl_ScriptEOD]', 'U') IS NOT NULL
    DROP TABLE [TriggerPointModelStoreContainer].[Tbl_ScriptEOD];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Tbl_Average'
CREATE TABLE [dbo].[Tbl_Average] (
    [AverageID] int IDENTITY(1,1) NOT NULL,
    [AverageName] varchar(50)  NULL,
    [IsDelete] bit  NULL
);
GO

-- Creating table 'Tbl_AverageParameters'
CREATE TABLE [dbo].[Tbl_AverageParameters] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AverageID] int  NULL,
    [Period] float  NULL,
    [Type] int  NULL,
    [IsExposional] bit  NULL
);
GO

-- Creating table 'Tbl_BollingerBand'
CREATE TABLE [dbo].[Tbl_BollingerBand] (
    [BollingerBandID] int IDENTITY(1,1) NOT NULL,
    [BollingerBandName] nvarchar(50)  NOT NULL,
    [Period] float  NULL,
    [StdDiv] float  NULL,
    [IsDelete] bit  NULL
);
GO

-- Creating table 'Tbl_config_ColumnMapings'
CREATE TABLE [dbo].[Tbl_config_ColumnMapings] (
    [dbcolumns] varchar(100)  NULL,
    [csvcolumns] varchar(100)  NULL,
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Tbl_config_ColumnMapings_EOD'
CREATE TABLE [dbo].[Tbl_config_ColumnMapings_EOD] (
    [dbcolumns] varchar(100)  NULL,
    [csvcolumns] varchar(100)  NULL,
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Tbl_EODData'
CREATE TABLE [dbo].[Tbl_EODData] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NOT NULL,
    [OPEN] decimal(19,4)  NULL,
    [HIGH] decimal(19,4)  NULL,
    [LOW] decimal(19,4)  NULL,
    [CLOSE] decimal(19,4)  NULL,
    [LAST] decimal(19,4)  NULL,
    [TOTTRDQTY] decimal(19,4)  NULL,
    [TOTTRDVAL] decimal(19,4)  NULL,
    [TIMESTAMP] datetime  NULL,
    [TOTALTRADES] decimal(19,4)  NULL
);
GO

-- Creating table 'Tbl_ErrorDetail'
CREATE TABLE [dbo].[Tbl_ErrorDetail] (
    [ErrorID] int IDENTITY(1,1) NOT NULL,
    [URL] varchar(500)  NULL,
    [Error] varchar(max)  NULL,
    [ErrorDate] datetime  NULL,
    [IsDelete] bit  NOT NULL,
    [Status] int  NULL
);
GO

-- Creating table 'Tbl_FormulaPortfolio'
CREATE TABLE [dbo].[Tbl_FormulaPortfolio] (
    [FormulaPortID] int IDENTITY(1,1) NOT NULL,
    [FormulaName] nvarchar(500)  NULL,
    [FormulaID] int  NULL,
    [MstName] varchar(500)  NULL,
    [MstID] int  NULL,
    [PortfolioID] int  NULL,
    [UserID] int  NULL,
    [Enterdate] datetime  NULL
);
GO

-- Creating table 'Tbl_MACD'
CREATE TABLE [dbo].[Tbl_MACD] (
    [MACDID] int IDENTITY(1,1) NOT NULL,
    [MACDName] varchar(50)  NULL,
    [IsDelete] bit  NULL
);
GO

-- Creating table 'Tbl_MACDFilters'
CREATE TABLE [dbo].[Tbl_MACDFilters] (
    [BaseLine] varchar(10)  NULL,
    [PercentageValue] float  NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    [MACDID] int  NULL,
    [IsPercentage] bit  NULL,
    [IsBaseLine] bit  NULL
);
GO

-- Creating table 'Tbl_MACDParameters'
CREATE TABLE [dbo].[Tbl_MACDParameters] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NULL,
    [Value] float  NULL,
    [MACDID] int  NULL
);
GO

-- Creating table 'Tbl_Master'
CREATE TABLE [dbo].[Tbl_Master] (
    [MstID] int IDENTITY(1,1) NOT NULL,
    [MstName] varchar(100)  NULL
);
GO

-- Creating table 'Tbl_Pivote'
CREATE TABLE [dbo].[Tbl_Pivote] (
    [PivoteID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NOT NULL,
    [Datefor] datetime  NOT NULL,
    [CalculatedDatetime] datetime  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [Pivotpoint] decimal(19,4)  NULL,
    [R1] decimal(19,4)  NULL,
    [R_Mid_1] decimal(19,4)  NULL,
    [R2] decimal(19,4)  NULL,
    [R_Mid_2] decimal(19,4)  NULL,
    [R3] decimal(19,4)  NULL,
    [R_Mid_3] decimal(19,4)  NULL,
    [R4] decimal(19,4)  NULL,
    [R_Mid_4] decimal(19,4)  NULL,
    [S1] decimal(19,4)  NULL,
    [S_Mid_1] decimal(19,4)  NULL,
    [S2] decimal(19,4)  NULL,
    [S_Mid_2] decimal(19,4)  NULL,
    [S3] decimal(19,4)  NULL,
    [S_Mid_3] decimal(19,4)  NULL,
    [S4] decimal(19,4)  NULL,
    [S_Mid_4] decimal(19,4)  NULL
);
GO

-- Creating table 'Tbl_Portfolio'
CREATE TABLE [dbo].[Tbl_Portfolio] (
    [PortfolioID] int IDENTITY(1,1) NOT NULL,
    [PortfolioName] varchar(500)  NULL,
    [CreatedDate] datetime  NULL,
    [UserID] int  NULL,
    [IsDelete] bit  NULL
);
GO

-- Creating table 'Tbl_RSI'
CREATE TABLE [dbo].[Tbl_RSI] (
    [RSIID] int IDENTITY(1,1) NOT NULL,
    [RSIName] varchar(50)  NULL,
    [IsDelete] bit  NULL
);
GO

-- Creating table 'Tbl_RSIParameters'
CREATE TABLE [dbo].[Tbl_RSIParameters] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NULL,
    [Value] float  NULL,
    [RSIID] int  NULL
);
GO

-- Creating table 'Tbl_Script_archive'
CREATE TABLE [dbo].[Tbl_Script_archive] (
    [ID] int  NOT NULL,
    [Company] int  NULL,
    [Datetime] datetime  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [ArchiveDate] datetime  NULL
);
GO

-- Creating table 'Tbl_ScriptMaster'
CREATE TABLE [dbo].[Tbl_ScriptMaster] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ScriptName] varchar(100)  NULL,
    [IsDelete] bit  NOT NULL,
    [Exchange] varchar(50)  NULL,
    [ScripCod] float  NULL
);
GO

-- Creating table 'Tbl_ScriptPortfolio'
CREATE TABLE [dbo].[Tbl_ScriptPortfolio] (
    [ScriptPortID] int IDENTITY(1,1) NOT NULL,
    [ScriptID] int  NULL,
    [PortfolioID] int  NULL,
    [UserID] int  NULL,
    [EnterDate] datetime  NULL
);
GO

-- Creating table 'Tbl_ScriptUpload'
CREATE TABLE [dbo].[Tbl_ScriptUpload] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Exchange] varchar(50)  NULL,
    [SCRIPNAME] varchar(100)  NULL,
    [LastTradedPrice] float  NULL,
    [LastTradedDate] datetime  NULL,
    [LastTradedTime] datetime  NULL,
    [Volume] float  NULL,
    [TurnOver] float  NULL,
    [OpenInterest] float  NULL,
    [LastTradedDateTime] datetime  NULL,
    [ScripCod] float  NULL
);
GO

-- Creating table 'Tbl_ScriptUploadMaster'
CREATE TABLE [dbo].[Tbl_ScriptUploadMaster] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Exchange] nvarchar(50)  NULL,
    [ScripCod] float  NULL,
    [SCRIPNAME] varchar(100)  NULL,
    [LastTradedPrice] float  NULL,
    [LastTradedDate] datetime  NULL,
    [LastTradedTime] datetime  NULL,
    [Volume] float  NULL,
    [TurnOver] float  NULL,
    [OpenInterest] float  NULL,
    [LastTradedDateTime] datetime  NULL
);
GO

-- Creating table 'Tbl_SplitMergeHistory'
CREATE TABLE [dbo].[Tbl_SplitMergeHistory] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ScriptID] int  NOT NULL,
    [SplitMergeType] int  NOT NULL,
    [EffectDate] datetime  NULL,
    [ReplacedScriptID] int  NULL,
    [SplitValue] varchar(10)  NULL,
    [SplitBeforeDate] datetime  NULL
);
GO

-- Creating table 'Tbl_Stochastic'
CREATE TABLE [dbo].[Tbl_Stochastic] (
    [StochasticID] int IDENTITY(1,1) NOT NULL,
    [StochasticName] varchar(50)  NOT NULL,
    [IsDelete] bit  NULL
);
GO

-- Creating table 'Tbl_StochasticParameters'
CREATE TABLE [dbo].[Tbl_StochasticParameters] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NULL,
    [Value] float  NULL,
    [StochasticID] int  NOT NULL
);
GO

-- Creating table 'Tbl_SystemSetting'
CREATE TABLE [dbo].[Tbl_SystemSetting] (
    [SettingID] int IDENTITY(1,1) NOT NULL,
    [Code] varchar(50)  NULL,
    [Name] nvarchar(100)  NULL,
    [Description] varchar(8000)  NULL,
    [Type] nvarchar(100)  NULL,
    [Value] nvarchar(500)  NULL,
    [IsDelete] bit  NOT NULL
);
GO

-- Creating table 'Tbl_User'
CREATE TABLE [dbo].[Tbl_User] (
    [IDUser] int IDENTITY(1,1) NOT NULL,
    [IDUserType] int  NOT NULL,
    [UserName] varchar(100)  NOT NULL,
    [Email] varchar(100)  NULL,
    [Password] varchar(50)  NULL,
    [IsActive] bit  NULL,
    [IsDelete] bit  NULL,
    [CreationDate] datetime  NULL,
    [CreationBy] int  NULL,
    [ModifyDate] datetime  NULL,
    [ModifyBy] int  NULL
);
GO

-- Creating table 'Tbl_UserDefineFormula'
CREATE TABLE [dbo].[Tbl_UserDefineFormula] (
    [FormulaID] int IDENTITY(1,1) NOT NULL,
    [Formula] varchar(5000)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [IDUser] int  NOT NULL,
    [FormulaName] varchar(50)  NOT NULL,
    [IsDelete] bit  NULL
);
GO

-- Creating table 'Tbl_UserType'
CREATE TABLE [dbo].[Tbl_UserType] (
    [IDUserType] int IDENTITY(1,1) NOT NULL,
    [UserType] varchar(50)  NOT NULL
);
GO

-- Creating table 'Tbl_Volatility'
CREATE TABLE [dbo].[Tbl_Volatility] (
    [VolatilityID] int IDENTITY(1,1) NOT NULL,
    [VolatilityName] nvarchar(50)  NULL,
    [Value] float  NULL,
    [IsDelete] bit  NULL,
    [MasterID] int  NULL
);
GO

-- Creating table 'TestTables'
CREATE TABLE [dbo].[TestTables] (
    [Id] int  NOT NULL,
    [Name] nchar(10)  NULL,
    [subject] nchar(10)  NULL
);
GO

-- Creating table 'Tbl_config_Settings'
CREATE TABLE [dbo].[Tbl_config_Settings] (
    [id] int IDENTITY(1,1) NOT NULL,
    [setting_name] varchar(100)  NULL,
    [setting_value] varchar(100)  NULL
);
GO

-- Creating table 'Tbl_Script'
CREATE TABLE [dbo].[Tbl_Script] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NULL,
    [Datetime] datetime  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [TurnOver] decimal(19,4)  NULL,
    [OpenInterest] int  NULL,
    [Su_Volume] int  NULL,
    [Su_TurnOver] decimal(19,4)  NULL,
    [Su_OpenIntrest] int  NULL,
    [Entry_Time] time  NULL
);
GO

-- Creating table 'Tbl_Script_Ami'
CREATE TABLE [dbo].[Tbl_Script_Ami] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NULL,
    [Datetime] datetime  NULL,
    [ScriptName] varchar(100)  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [TurnOver] decimal(19,4)  NULL,
    [OpenInterest] int  NULL,
    [Entry_Time] time  NULL
);
GO

-- Creating table 'Tbl_Script10Min'
CREATE TABLE [dbo].[Tbl_Script10Min] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NULL,
    [Datetime] datetime  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [TurnOver] decimal(19,4)  NULL,
    [OpenInterest] int  NULL,
    [Track_Time] time  NULL,
    [Entry_Time] time  NULL
);
GO

-- Creating table 'Tbl_Script120Min'
CREATE TABLE [dbo].[Tbl_Script120Min] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NULL,
    [Datetime] datetime  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [TurnOver] decimal(19,4)  NULL,
    [OpenInterest] int  NULL,
    [Track_Time] time  NULL,
    [Entry_Time] time  NULL
);
GO

-- Creating table 'Tbl_Script15Min'
CREATE TABLE [dbo].[Tbl_Script15Min] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NULL,
    [Datetime] datetime  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [TurnOver] decimal(19,4)  NULL,
    [OpenInterest] int  NULL,
    [Track_Time] time  NULL,
    [Entry_Time] time  NULL
);
GO

-- Creating table 'Tbl_Script1Min'
CREATE TABLE [dbo].[Tbl_Script1Min] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NULL,
    [Datetime] datetime  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [TurnOver] decimal(19,4)  NULL,
    [OpenInterest] int  NULL,
    [Track_Time] time  NULL,
    [Entry_Time] time  NULL
);
GO

-- Creating table 'Tbl_Script20Min'
CREATE TABLE [dbo].[Tbl_Script20Min] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NULL,
    [Datetime] datetime  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [TurnOver] decimal(19,4)  NULL,
    [OpenInterest] int  NULL,
    [Track_Time] time  NULL,
    [Entry_Time] time  NULL
);
GO

-- Creating table 'Tbl_Script30Min'
CREATE TABLE [dbo].[Tbl_Script30Min] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NULL,
    [Datetime] datetime  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [TurnOver] decimal(19,4)  NULL,
    [OpenInterest] int  NULL,
    [Track_Time] time  NULL,
    [Entry_Time] time  NULL
);
GO

-- Creating table 'Tbl_Script45Min'
CREATE TABLE [dbo].[Tbl_Script45Min] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NULL,
    [Datetime] datetime  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [TurnOver] decimal(19,4)  NULL,
    [OpenInterest] int  NULL,
    [Track_Time] time  NULL,
    [Entry_Time] time  NULL
);
GO

-- Creating table 'Tbl_Script5Min'
CREATE TABLE [dbo].[Tbl_Script5Min] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NULL,
    [Datetime] datetime  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [TurnOver] decimal(19,4)  NULL,
    [OpenInterest] int  NULL,
    [Track_Time] time  NULL,
    [Entry_Time] time  NULL
);
GO

-- Creating table 'Tbl_Script60Min'
CREATE TABLE [dbo].[Tbl_Script60Min] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NULL,
    [Datetime] datetime  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [TurnOver] decimal(19,4)  NULL,
    [OpenInterest] int  NULL,
    [Track_Time] time  NULL,
    [Entry_Time] time  NULL
);
GO

-- Creating table 'Tbl_Script885Min'
CREATE TABLE [dbo].[Tbl_Script885Min] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NULL,
    [Datetime] datetime  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [TurnOver] decimal(19,4)  NULL,
    [OpenInterest] int  NULL,
    [Track_Time] time  NULL,
    [Entry_Time] time  NULL
);
GO

-- Creating table 'Tbl_Script90Min'
CREATE TABLE [dbo].[Tbl_Script90Min] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NULL,
    [Datetime] datetime  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [TurnOver] decimal(19,4)  NULL,
    [OpenInterest] int  NULL,
    [Track_Time] time  NULL,
    [Entry_Time] time  NULL
);
GO

-- Creating table 'Tbl_ScriptEOD'
CREATE TABLE [dbo].[Tbl_ScriptEOD] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Company] int  NULL,
    [Datetime] datetime  NULL,
    [OpenReadings] decimal(19,4)  NULL,
    [HighReadings] decimal(19,4)  NULL,
    [LowReadings] decimal(19,4)  NULL,
    [CloseReadings] decimal(19,4)  NULL,
    [Volume] int  NULL,
    [TurnOver] decimal(19,4)  NULL,
    [OpenInterest] int  NULL,
    [Track_Time] time  NULL,
    [Entry_Time] time  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Tbl_Swing'
CREATE TABLE [dbo].[Tbl_Swing] (
    [SwingID] int IDENTITY(1,1) NOT NULL,
    [SwingName] varchar(50)  NOT NULL,
    [IsDelete] bit  NULL
);
GO

-- Creating table 'Tbl_SwingParameters'
CREATE TABLE [dbo].[Tbl_SwingParameters] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SwingID] int  NULL,
    [LimitMove] float  NULL,
    [TimePeriod] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AverageID] in table 'Tbl_Average'
ALTER TABLE [dbo].[Tbl_Average]
ADD CONSTRAINT [PK_Tbl_Average]
    PRIMARY KEY CLUSTERED ([AverageID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_AverageParameters'
ALTER TABLE [dbo].[Tbl_AverageParameters]
ADD CONSTRAINT [PK_Tbl_AverageParameters]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [BollingerBandID] in table 'Tbl_BollingerBand'
ALTER TABLE [dbo].[Tbl_BollingerBand]
ADD CONSTRAINT [PK_Tbl_BollingerBand]
    PRIMARY KEY CLUSTERED ([BollingerBandID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_config_ColumnMapings'
ALTER TABLE [dbo].[Tbl_config_ColumnMapings]
ADD CONSTRAINT [PK_Tbl_config_ColumnMapings]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_config_ColumnMapings_EOD'
ALTER TABLE [dbo].[Tbl_config_ColumnMapings_EOD]
ADD CONSTRAINT [PK_Tbl_config_ColumnMapings_EOD]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_EODData'
ALTER TABLE [dbo].[Tbl_EODData]
ADD CONSTRAINT [PK_Tbl_EODData]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ErrorID] in table 'Tbl_ErrorDetail'
ALTER TABLE [dbo].[Tbl_ErrorDetail]
ADD CONSTRAINT [PK_Tbl_ErrorDetail]
    PRIMARY KEY CLUSTERED ([ErrorID] ASC);
GO

-- Creating primary key on [FormulaPortID] in table 'Tbl_FormulaPortfolio'
ALTER TABLE [dbo].[Tbl_FormulaPortfolio]
ADD CONSTRAINT [PK_Tbl_FormulaPortfolio]
    PRIMARY KEY CLUSTERED ([FormulaPortID] ASC);
GO

-- Creating primary key on [MACDID] in table 'Tbl_MACD'
ALTER TABLE [dbo].[Tbl_MACD]
ADD CONSTRAINT [PK_Tbl_MACD]
    PRIMARY KEY CLUSTERED ([MACDID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_MACDFilters'
ALTER TABLE [dbo].[Tbl_MACDFilters]
ADD CONSTRAINT [PK_Tbl_MACDFilters]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_MACDParameters'
ALTER TABLE [dbo].[Tbl_MACDParameters]
ADD CONSTRAINT [PK_Tbl_MACDParameters]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [MstID] in table 'Tbl_Master'
ALTER TABLE [dbo].[Tbl_Master]
ADD CONSTRAINT [PK_Tbl_Master]
    PRIMARY KEY CLUSTERED ([MstID] ASC);
GO

-- Creating primary key on [PivoteID] in table 'Tbl_Pivote'
ALTER TABLE [dbo].[Tbl_Pivote]
ADD CONSTRAINT [PK_Tbl_Pivote]
    PRIMARY KEY CLUSTERED ([PivoteID] ASC);
GO

-- Creating primary key on [PortfolioID] in table 'Tbl_Portfolio'
ALTER TABLE [dbo].[Tbl_Portfolio]
ADD CONSTRAINT [PK_Tbl_Portfolio]
    PRIMARY KEY CLUSTERED ([PortfolioID] ASC);
GO

-- Creating primary key on [RSIID] in table 'Tbl_RSI'
ALTER TABLE [dbo].[Tbl_RSI]
ADD CONSTRAINT [PK_Tbl_RSI]
    PRIMARY KEY CLUSTERED ([RSIID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_RSIParameters'
ALTER TABLE [dbo].[Tbl_RSIParameters]
ADD CONSTRAINT [PK_Tbl_RSIParameters]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_Script_archive'
ALTER TABLE [dbo].[Tbl_Script_archive]
ADD CONSTRAINT [PK_Tbl_Script_archive]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_ScriptMaster'
ALTER TABLE [dbo].[Tbl_ScriptMaster]
ADD CONSTRAINT [PK_Tbl_ScriptMaster]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ScriptPortID] in table 'Tbl_ScriptPortfolio'
ALTER TABLE [dbo].[Tbl_ScriptPortfolio]
ADD CONSTRAINT [PK_Tbl_ScriptPortfolio]
    PRIMARY KEY CLUSTERED ([ScriptPortID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_ScriptUpload'
ALTER TABLE [dbo].[Tbl_ScriptUpload]
ADD CONSTRAINT [PK_Tbl_ScriptUpload]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_ScriptUploadMaster'
ALTER TABLE [dbo].[Tbl_ScriptUploadMaster]
ADD CONSTRAINT [PK_Tbl_ScriptUploadMaster]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_SplitMergeHistory'
ALTER TABLE [dbo].[Tbl_SplitMergeHistory]
ADD CONSTRAINT [PK_Tbl_SplitMergeHistory]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [StochasticID] in table 'Tbl_Stochastic'
ALTER TABLE [dbo].[Tbl_Stochastic]
ADD CONSTRAINT [PK_Tbl_Stochastic]
    PRIMARY KEY CLUSTERED ([StochasticID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_StochasticParameters'
ALTER TABLE [dbo].[Tbl_StochasticParameters]
ADD CONSTRAINT [PK_Tbl_StochasticParameters]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [SettingID] in table 'Tbl_SystemSetting'
ALTER TABLE [dbo].[Tbl_SystemSetting]
ADD CONSTRAINT [PK_Tbl_SystemSetting]
    PRIMARY KEY CLUSTERED ([SettingID] ASC);
GO

-- Creating primary key on [IDUser] in table 'Tbl_User'
ALTER TABLE [dbo].[Tbl_User]
ADD CONSTRAINT [PK_Tbl_User]
    PRIMARY KEY CLUSTERED ([IDUser] ASC);
GO

-- Creating primary key on [FormulaID] in table 'Tbl_UserDefineFormula'
ALTER TABLE [dbo].[Tbl_UserDefineFormula]
ADD CONSTRAINT [PK_Tbl_UserDefineFormula]
    PRIMARY KEY CLUSTERED ([FormulaID] ASC);
GO

-- Creating primary key on [IDUserType] in table 'Tbl_UserType'
ALTER TABLE [dbo].[Tbl_UserType]
ADD CONSTRAINT [PK_Tbl_UserType]
    PRIMARY KEY CLUSTERED ([IDUserType] ASC);
GO

-- Creating primary key on [VolatilityID] in table 'Tbl_Volatility'
ALTER TABLE [dbo].[Tbl_Volatility]
ADD CONSTRAINT [PK_Tbl_Volatility]
    PRIMARY KEY CLUSTERED ([VolatilityID] ASC);
GO

-- Creating primary key on [Id] in table 'TestTables'
ALTER TABLE [dbo].[TestTables]
ADD CONSTRAINT [PK_TestTables]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Tbl_config_Settings'
ALTER TABLE [dbo].[Tbl_config_Settings]
ADD CONSTRAINT [PK_Tbl_config_Settings]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_Script'
ALTER TABLE [dbo].[Tbl_Script]
ADD CONSTRAINT [PK_Tbl_Script]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_Script_Ami'
ALTER TABLE [dbo].[Tbl_Script_Ami]
ADD CONSTRAINT [PK_Tbl_Script_Ami]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_Script10Min'
ALTER TABLE [dbo].[Tbl_Script10Min]
ADD CONSTRAINT [PK_Tbl_Script10Min]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_Script120Min'
ALTER TABLE [dbo].[Tbl_Script120Min]
ADD CONSTRAINT [PK_Tbl_Script120Min]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_Script15Min'
ALTER TABLE [dbo].[Tbl_Script15Min]
ADD CONSTRAINT [PK_Tbl_Script15Min]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_Script1Min'
ALTER TABLE [dbo].[Tbl_Script1Min]
ADD CONSTRAINT [PK_Tbl_Script1Min]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_Script20Min'
ALTER TABLE [dbo].[Tbl_Script20Min]
ADD CONSTRAINT [PK_Tbl_Script20Min]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_Script30Min'
ALTER TABLE [dbo].[Tbl_Script30Min]
ADD CONSTRAINT [PK_Tbl_Script30Min]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_Script45Min'
ALTER TABLE [dbo].[Tbl_Script45Min]
ADD CONSTRAINT [PK_Tbl_Script45Min]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_Script5Min'
ALTER TABLE [dbo].[Tbl_Script5Min]
ADD CONSTRAINT [PK_Tbl_Script5Min]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_Script60Min'
ALTER TABLE [dbo].[Tbl_Script60Min]
ADD CONSTRAINT [PK_Tbl_Script60Min]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_Script885Min'
ALTER TABLE [dbo].[Tbl_Script885Min]
ADD CONSTRAINT [PK_Tbl_Script885Min]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_Script90Min'
ALTER TABLE [dbo].[Tbl_Script90Min]
ADD CONSTRAINT [PK_Tbl_Script90Min]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_ScriptEOD'
ALTER TABLE [dbo].[Tbl_ScriptEOD]
ADD CONSTRAINT [PK_Tbl_ScriptEOD]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [SwingID] in table 'Tbl_Swing'
ALTER TABLE [dbo].[Tbl_Swing]
ADD CONSTRAINT [PK_Tbl_Swing]
    PRIMARY KEY CLUSTERED ([SwingID] ASC);
GO

-- Creating primary key on [ID] in table 'Tbl_SwingParameters'
ALTER TABLE [dbo].[Tbl_SwingParameters]
ADD CONSTRAINT [PK_Tbl_SwingParameters]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Company] in table 'Tbl_Pivote'
ALTER TABLE [dbo].[Tbl_Pivote]
ADD CONSTRAINT [FK_Tbl_Pivote_Tbl_ScriptMaster]
    FOREIGN KEY ([Company])
    REFERENCES [dbo].[Tbl_ScriptMaster]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tbl_Pivote_Tbl_ScriptMaster'
CREATE INDEX [IX_FK_Tbl_Pivote_Tbl_ScriptMaster]
ON [dbo].[Tbl_Pivote]
    ([Company]);
GO

-- Creating foreign key on [Company] in table 'Tbl_Script'
ALTER TABLE [dbo].[Tbl_Script]
ADD CONSTRAINT [FK_Tbl_Script_Tbl_ScriptMaster]
    FOREIGN KEY ([Company])
    REFERENCES [dbo].[Tbl_ScriptMaster]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tbl_Script_Tbl_ScriptMaster'
CREATE INDEX [IX_FK_Tbl_Script_Tbl_ScriptMaster]
ON [dbo].[Tbl_Script]
    ([Company]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------