USE [TestTaskDB]
GO

/****** Object: Table [dbo].[Accounts] Script Date: 10.02.2022 11:06:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Accounts] (
    [Name]         NCHAR (20)       NOT NULL,
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [IncidentName] UNIQUEIDENTIFIER NULL
);


