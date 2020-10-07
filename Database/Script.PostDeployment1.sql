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
