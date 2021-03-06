﻿CREATE TABLE [dbo].[Sale]
(
    [Id] INT NOT NULL  IDENTITY, 
    [CashierId] NVARCHAR(128) NOT NULL, 
    [SaleDate] DATETIME2(3) NOT NULL, 
    [SubTotal] MONEY NOT NULL, 
    [Tax] MONEY NOT NULL, 
    [Total] MONEY NOT NULL, 
    CONSTRAINT [FK_Sale_ToUser] FOREIGN KEY (CashierId) REFERENCES [User](Id), 
    CONSTRAINT [PK_Sale] PRIMARY KEY ([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'ID of User Table',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Sale',
    @level2type = N'COLUMN',
    @level2name = N'CashierId'