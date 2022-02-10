USE [TestTaskDB]
GO

/****** Object: Table [dbo].[Incidents] Script Date: 10.02.2022 11:08:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Incidents] (
    [Name]        UNIQUEIDENTIFIER NOT NULL,
    [Description] NCHAR (50)       NOT NULL
);


