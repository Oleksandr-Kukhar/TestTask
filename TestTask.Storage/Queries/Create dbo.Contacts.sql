USE [TestTaskDB]
GO

/****** Object: Table [dbo].[Contacts] Script Date: 10.02.2022 11:08:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contacts] (
    [FirstName] NCHAR (20) NOT NULL,
    [LastName]  NCHAR (20) NOT NULL,
    [Email]     NCHAR (30) NOT NULL,
    [Id]        INT        IDENTITY (1, 1) NOT NULL,
    [AccountId] INT        NOT NULL
);


