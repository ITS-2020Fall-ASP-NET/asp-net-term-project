CREATE TABLE [dbo].[like]
(
	[like_id] INT NOT NULL PRIMARY KEY, 
    [user_id] INT NOT NULL, 
    [item_id] INT NOT NULL, 
    CONSTRAINT [user_id] FOREIGN KEY ([user_id]) REFERENCES [User]([user_id]) 
)