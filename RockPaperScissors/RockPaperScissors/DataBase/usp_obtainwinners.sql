ALTER PROCEDURE usp_obtainwinners
	@ai_quant int = 10
AS	
BEGIN

	SELECT TOP (@ai_quant) w.Name,
	w.Score  
	FROM dbo.Winner w
	ORDER BY w.SCORE

END