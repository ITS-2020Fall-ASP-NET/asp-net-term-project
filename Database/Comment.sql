CREATE TABLE [dbo].[Comment]
(
    [comment_id] INT NOT NULL PRIMARY KEY, 
    [item_id] INT FOREIGN KEY REFERENCES [dbo].[Item] ([item_id]), 
    [parent_comment] INT NULL
)
