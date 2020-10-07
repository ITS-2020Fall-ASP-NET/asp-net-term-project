CREATE TABLE [dbo].[Transaction]
(
    [trans_id] INT NOT NULL PRIMARY KEY, 
    [buyer_id] INT NULL, 
    [seller_id] INT NULL,
    [item_id] INT NULL,
    [price] DECIMAL(18, 0) NULL, 
    [date] DATETIME NULL, 
    [status] INT NULL, 
    CONSTRAINT [FK_Transaction_Buyer] FOREIGN KEY ([buyer_id]) REFERENCES [dbo].[User]([user_id]), 
    CONSTRAINT [FK_Transaction_Seller] FOREIGN KEY ([buyer_id]) REFERENCES [dbo].[User]([user_id]), 
    CONSTRAINT [FK_Transaction_Item] FOREIGN KEY ([item_id]) REFERENCES [dbo].[Item]([item_id])

)
