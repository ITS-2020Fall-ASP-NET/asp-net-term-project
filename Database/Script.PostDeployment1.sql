/*
Post-Deployment Script Template                            
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.        
 Use SQLCMD syntax to include a file in the post-deployment script.            
 Example:      :r .\myfile.sql                                
 Use SQLCMD syntax to reference a variable in the post-deployment script.        
 Example:      :setvar TableName MyTable                            
               SELECT * FROM [$(TableName)]                    
--------------------------------------------------------------------------------------
*/

MERGE INTO [dbo].[User] AS Target
USING (VALUES 
        (1, 'Hansol', 'Jo', '12341234', 'hansol.jo@gmail.com', 0)
)
AS Source (user_id, fname, lname, passwd, email, reputation)
ON Target.user_id = Source.user_id
WHEN NOT MATCHED BY TARGET THEN
INSERT (user_id, fname, lname, passwd, email, reputation)
VALUES (user_id, fname, lname, passwd, email, reputation);


/* Categories */

MERGE INTO [dbo].[Category] AS Target
USING (VALUES 
        (0, 'Baby'),
        (1, 'Beauty'),
        (2, 'Books'),
        (3, 'Camera & Photo'),
        (4, 'Clothing & Accessories'),
        (5, 'Consumer Electronics'),
        (6, 'Grocery & Gourmet Foods'),
        (7, 'Health & Personal Care'),
        (8, 'Home & Garden'),
        (10, 'Industrial & Scientific'),
        (11, 'Luggage & Travel Accessories'),
        (12, 'Musical Instruments'),
        (13, 'Office Products'),
        (14, 'Outdoors'),
        (15, 'Personal Computers'),
        (16, 'Pet Supplies'),
        (17, 'Shoes, Handbags, & Sunglasses'),
        (18, 'Software'),
        (19, 'Sports'),
        (20, 'Tools & Home Improvement'),
        (21, 'Toys'),
        (22, 'Video Games')
)
AS Source (category_id, category_name)
ON Target.category_id = Source.category_id
WHEN NOT MATCHED BY TARGET THEN
INSERT (category_id, category_name)
VALUES (category_id, category_name);