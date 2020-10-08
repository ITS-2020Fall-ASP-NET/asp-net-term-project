CREATE TABLE [dbo].[CityLookup]
(
    [city_id] INT NOT NULL PRIMARY KEY,
    [city_name] VARCHAR(100) NOT NULL, 
    [state] INT NOT NULL, 
    CONSTRAINT [FK_CityLookup_StateLookup] FOREIGN KEY ([state]) REFERENCES [StateLookup]([state_id])
)
