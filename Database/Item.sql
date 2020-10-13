CREATE TABLE [dbo].[Item]
(
    [item_id] INT NOT NULL PRIMARY KEY IDENTITY(0, 1),
    [user_id] INT FOREIGN KEY REFERENCES [dbo].[User] ([user_id]),
    [name]      NVARCHAR (50) NULL, 
    [listing_price] DECIMAL NULL, 
    [description] NVARCHAR(MAX) NULL, 
    [category] int FOREIGN KEY REFERENCES [dbo].[Category] ([category_id]), 
    [like_count] NCHAR(10) NULL DEFAULT 0, 
    [img_path] NVARCHAR(50) NULL DEFAULT 'default.jpg'
)
