-- =============================================
-- Author:		Tomas Filip
-- Create date: 22/01/2015
-- Description:	Copies computer info to another country
-- =============================================
CREATE PROCEDURE uspCopyComputerInfo 
	-- Add the parameters for the stored procedure here
	@CopyFromCountryId UNIQUEIDENTIFIER, 
	@CopyToCountryId UNIQUEIDENTIFIER,
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ComputerInfos TABLE(
		Price BIGINT,
		[Description] NVARCHAR(MAX),
		ComputerId UNIQUEIDENTIFIER
	)

	--Copy it to temp table first
	INSERT INTO @ComputerInfos
	SELECT	Price, [Description], ComputerId
	FROM	dbo.ComputerInfo
	WHERE	CountryId = @CopyFromCountryId

	INSERT INTO dbo.ComputerInfo
	SELECT	NEWID(), --Id
			Price,
			Description,
			@CopyToCountryId,
			ComputerId,
			0, -- IsDeleted
			GETDATE(), -- creation time
			GETDATE(), --Last modification time
			@UserId, -- Created By Id
			@UserId -- Modified By Id
	FROM	@ComputerInfos
END
GO
