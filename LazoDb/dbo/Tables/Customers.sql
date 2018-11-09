CREATE TABLE [dbo].[Customers] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50)  NOT NULL,
    [Company]        NVARCHAR (MAX) NOT NULL,
    [NumberEmployee] INT            NOT NULL,
    [Address]        NVARCHAR (100) NOT NULL,
    [Email]          NVARCHAR (MAX) NOT NULL,
    [Status]         BIT            NOT NULL,
    [RegisterDate]   DATETIME       DEFAULT ('1900-01-01T00:00:00.000') NOT NULL,
    [Description]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED ([ID] ASC)
);



