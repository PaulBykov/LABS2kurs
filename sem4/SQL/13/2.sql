ALTER PROCEDURE Disziplins 
    @p varchar(20) = NULL,  -- Входной параметр
    @c INT OUTPUT          -- Выходной параметр
AS
BEGIN
    DECLARE @rowCount INT;
    
    SELECT * 
    INTO #TempResults
    FROM Курсы
    WHERE @p IS NULL OR предмет = @p;
    
    SET @rowCount = (SELECT COUNT(*) FROM #TempResults);
    
    SET @c = @rowCount;
    
    SELECT * FROM #TempResults;
    
    DROP TABLE #TempResults;
END;


-- Пример вызова процедуры
DECLARE @resultCount INT;
EXEC Disziplins @p = 'ООП', @c = @resultCount OUTPUT;
PRINT 'кол-во курсов: ' + CAST(@resultCount AS varchar(10));
