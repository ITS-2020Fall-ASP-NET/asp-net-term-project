CREATE TABLE [dbo].[like]
(
	[like_id] INT NOT NULL PRIMARY KEY, 
    [user_id] INT NOT NULL, 
    [item_id] INT NOT NULL, 
    CONSTRAINT [FK_Like_user_id] FOREIGN KEY ([user_id]) REFERENCES [dbo].[User]([user_id]), 
    CONSTRAINT [FK_Like_item_id] FOREIGN KEY ([item_id]) REFERENCES [dbo].[Item]([item_id])
)