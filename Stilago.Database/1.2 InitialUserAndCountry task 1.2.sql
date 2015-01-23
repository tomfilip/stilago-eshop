BEGIN TRAN

DECLARE @userId UNIQUEIDENTIFIER
SET		@userId = NEWID()

DECLARE @countryId UNIQUEIDENTIFIER
SET		@countryId = NEWID()


--Default Countries
INSERT INTO dbo.Country
(Id, Name, Culture)
VALUES
(@countryId, 'United Kingdom', 'en'),
(NEWID(), 'Slovakia', 'sk')

--Default User
INSERT INTO dbo.[User]
(Id, FirstName, LastName, CountryId)
VALUES
(@userId, 'Tomas', 'Filip', @countryId)

COMMIT