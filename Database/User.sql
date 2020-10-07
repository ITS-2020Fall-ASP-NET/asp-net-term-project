CREATE TABLE [dbo].[User]
(
    [user_id] INT NOT NULL PRIMARY KEY, 
    [fname] NVARCHAR(50) NULL,
    [lname] NVARCHAR(50) NULL,
    [passwd] NCHAR(10) NULL, 
    [email] NVARCHAR(50) NULL, 
    [reputation] DECIMAL NULL
)
