CREATE TABLE [dbo].[Customers] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50)  NOT NULL,
    [Company]        NVARCHAR (MAX) NOT NULL,
    [NumberEmployee] INT            NOT NULL,
    [Email]          NVARCHAR (MAX) NOT NULL,
    [RegisterDate]   DATETIME       NOT NULL,
    [Description]    NVARCHAR (MAX) NULL,
    [Status]         BIT            NOT NULL,
    [Phone]          NVARCHAR (11)  NOT NULL,
    CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED ([ID] ASC)
);





