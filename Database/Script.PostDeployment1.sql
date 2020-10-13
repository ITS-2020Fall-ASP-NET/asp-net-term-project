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

/* Test address */
/*SET IDENTITY_INSERT [dbo].[Address] ON;*/
MERGE INTO [dbo].[Address] AS Target
USING (VALUES 
        ('2143 Meadowglen Dr', '', '', 53, 5, 'CA', 'L6M4C7')
)
AS Source (Address1, Address2, Address3, City, State, Country, PostalCode)
ON Target.Address1 = Source.Address1
WHEN NOT MATCHED BY TARGET THEN
INSERT (Address1, Address2, Address3, City, State, Country, PostalCode)
VALUES (Address1, Address2, Address3, City, State, Country, PostalCode);

/* Test user */
MERGE INTO [dbo].[User] AS Target
USING (VALUES 
        (0, 'Hansol', 'Jo', '12341234', 'hansol.jo@gmail.com', 0, 0)
)
AS Source (user_id, fname, lname, passwd, email, reputation, address)
ON Target.user_id = Source.user_id
WHEN NOT MATCHED BY TARGET THEN
INSERT (user_id, fname, lname, passwd, email, reputation, address)
VALUES (user_id, fname, lname, passwd, email, reputation, address);

/* Test item */
/*SET IDENTITY_INSERT [dbo].[Item] ON;*/
MERGE INTO [dbo].[Item] AS Target
USING (VALUES 
        (0, 'Intel i7-10700k', 500, 'Bang for bucks', 15, 123, '71P3chRzgNL._AC_UL270_SR234,270_.jpg'),
        (0, 'Samsung EVO 970 Plus', 200, 'Best SSD ever', 15, 321, '31_rkXdQL8L._AC_SY200_.jpg'),
        (0, 'Wi-fi router', 100, 'Mint condition', 5, 22, '41VDUqScJFL.__AC_SY200_.jpg'),
        (0, 'Neon sign deco', 50, 'Skeleton shape', 8, 3, '51L5hC9ntiL._AC_SY200_.jpg'),
        (0, 'Men''s wallet', 10, 'Made in Italy', 4, 12, '51WemmPkikL.__AC_SY200_.jpg'),
        (0, 'Magformers Pow patrol', 110, 'Bought in 2018', 21, 29, '51WH9X2JTBL._AC_SY200_.jpg'),
        (0, 'Bluetooth speakers', 220, 'Sounds great', 5, 209, '412kIhspKgL._AC_SL260_.jpg'),
        (0, 'Asus Vivobook', 320, '128G sdd, 4Gb ram', 15, 42, '4130RrCBUVL.__AC_SY200_.jpg'),
        (0, 'LOL Lights glitter', 5, 'Not opened', 21, 7, '81Lwp3Oj4AL._AC_UL220_SR180,220_.jpg')
)
AS Source (user_id, name, listing_price, description, category, like_count, img_path)
ON Target.name = Source.name
WHEN NOT MATCHED BY TARGET THEN
INSERT (user_id, name, listing_price, description, category, like_count, img_path)
VALUES (user_id, name, listing_price, description, category, like_count, img_path);


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

/* StateLookup */
MERGE INTO [dbo].[StateLookup] AS Target
USING (VALUES 
        (0, 'NL'),
        (1, 'PE'),
        (2, 'NS'),
        (3, 'NB'),
        (4, 'QC'),
        (5, 'ON'),
        (6, 'MB'),
        (7, 'SK'),
        (8, 'AB'),
        (9, 'BC'),
        (10, 'YT'),
        (11, 'NT'),
        (12, 'NU')
)
AS Source (state_id, state_name)
ON Target.state_id = Source.state_id
WHEN NOT MATCHED BY TARGET THEN
INSERT (state_id, state_name)
VALUES (state_id, state_name);

/*
    CityLookup
     - Temporarily only Ontario cities.
*/
MERGE INTO [dbo].[CityLookup] AS Target
USING (VALUES 
        (0 , 'Barrie', 5),
        (1 , 'Belleville', 5),
        (2 , 'Brampton', 5),
        (3 , 'Brant', 5),
        (4 , 'Brantford', 5),
        (5 , 'Brockville', 5),
        (6 , 'Burlington', 5),
        (7 , 'Cambridge', 5),
        (8 , 'Clarence-Rockland', 5),
        (9 , 'Cornwall', 5),
        (10, 'Dryden', 5),
        (11, 'Elliot Lake', 5),
        (12, 'Greater Sudbury', 5),
        (13, 'Guelph', 5),
        (14, 'Haldimand County', 5),
        (15, 'Hamilton', 5),
        (16, 'Kawartha Lakes', 5),
        (17, 'Kenora', 5),
        (18, 'Kingston', 5),
        (19, 'Kitchener', 5),
        (20, 'London', 5),
        (21, 'Markham', 5),
        (22, 'Mississauga', 5),
        (23, 'Niagara Falls', 5),
        (24, 'Norfolk County', 5),
        (25, 'North Bay', 5),
        (26, 'Orillia', 5),
        (27, 'Oshawa', 5),
        (28, 'Ottawa', 5),
        (29, 'Owen Sound', 5),
        (30, 'Pembroke', 5),
        (31, 'Peterborough', 5),
        (32, 'Pickering', 5),
        (33, 'Port Colborne', 5),
        (34, 'Prince Edward County', 5),
        (35, 'Quinte West', 5),
        (36, 'Richmond Hill', 5),
        (37, 'Sarnia', 5),
        (38, 'Sault Ste. Marie', 5),
        (39, 'St. Catharines', 5),
        (40, 'St. Thomas', 5),
        (41, 'Stratford', 5),
        (42, 'Temiskaming Shores', 5),
        (43, 'Thorold', 5),
        (44, 'Thunder Bay', 5),
        (45, 'Timmins', 5),
        (46, 'Toronto', 5),
        (47, 'Vaughan', 5),
        (48, 'Waterloo', 5),
        (49, 'Welland', 5),
        (50, 'Windsor', 5),
        (51, 'Woodstock', 5),
        (52, 'Ajax', 5),
        (53, 'Oakville', 5),
        (54, 'Whitby', 5)
)
AS Source (city_id, city_name, state)
ON Target.city_id = Source.city_id
WHEN NOT MATCHED BY TARGET THEN
INSERT (city_id, city_name, state)
VALUES (city_id, city_name, state);