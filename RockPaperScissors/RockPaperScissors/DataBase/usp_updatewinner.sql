CREATE PROCEDURE usp_updatewinners
	@avc_first varchar(max),
    @avc_second varchar(max),
    @ai_firstScore int,
    @ai_secondScore int
AS	
BEGIN

                      IF EXISTS (SELECT 1 FROM WINNERS
                                WHERE NAME = @avc_first)
                        BEGIN
                            UPDATE WINNERS
                                SET SCORE += @ai_firstScore 
                                WHERE NAME = @avc_first
                        END
                      ELSE INSERT INTO WINNERS(NAME,SCORE)
                      SELECT @avc_first, @ai_firstScore
                      
                      IF EXISTS (SELECT 1 FROM WINNERS 
                                WHERE NAME = @avc_second)
                        BEGIN
                            UPDATE WINNERS
                                SET SCORE += @ai_secondScore
                                WHERE NAME = @avc_second
                        END
                    ELSE INSERT INTO WINNERS(NAME,SCORE)
                      SELECT @avc_second, @ai_secondScore";

END