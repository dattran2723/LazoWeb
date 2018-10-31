CREATE TABLE [dbo].[Customers] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50)  NULL,
    [Company]        NVARCHAR (50)  NULL,
    [NumberEmployee] INT            NULL,
    [Address]        NVARCHAR (100) NULL,
    [Email]          NVARCHAR (50)  NULL,
    [Status]         BIT            NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([ID] ASC)
);

