CREATE TABLE [dbo].[Item]
(
    [item_id] INT NOT NULL PRIMARY KEY,
    [user_id] INT FOREIGN KEY REFERENCES [dbo].[User] ([user_id]),
    [name]      NVARCHAR (50) NULL, 
    [listing_price] DECIMAL NULL, 
    [description] NVARCHAR(MAX) NULL, 
    [category] int FOREIGN KEY REFERENCES [dbo].[Category] ([category_id]), 
    [like_count] NCHAR(10) NULL, 
    [img_path] NVARCHAR(50) NULL
)
