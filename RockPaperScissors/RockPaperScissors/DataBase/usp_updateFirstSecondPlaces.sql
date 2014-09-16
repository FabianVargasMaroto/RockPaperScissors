CREATE PROCEDURE usp_updateFirstSecondPlaces
	@avc_firstPlaceName varchar(max)
	,@avc_secondPlaceName varchar(max)
AS	
BEGIN

EXEC dbo.usp_updatewinner
	@avc_firstPlaceName,
	3

EXEC dbo.usp_updatewinner
	@avc_secondPlaceName,
	1	
END