CREATE TABLE [dbo].[Address]
(
    address_id  INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    Address1    VARCHAR(120) NOT NULL,
    Address2    VARCHAR(120),
    Address3    VARCHAR(120),
    City        INT,
    State       INT,
    Country     CHAR(2) NOT NULL,
    PostalCode  VARCHAR(16) NOT NULL, 

    CONSTRAINT [FK_Address_CityLookup] FOREIGN KEY ([City]) REFERENCES [CityLookup]([city_id]), 
    CONSTRAINT [FK_Address_StateLookup] FOREIGN KEY ([State]) REFERENCES [StateLookup]([state_id])
)
