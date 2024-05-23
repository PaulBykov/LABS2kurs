ALTER PROCEDURE Disziplins 
    @p varchar(20) = NULL,  -- ������� ��������
    @c INT OUTPUT          -- �������� ��������
AS
BEGIN
    DECLARE @rowCount INT;
    
    SELECT * 
    INTO #TempResults
    FROM �����
    WHERE @p IS NULL OR ������� = @p;
    
    SET @rowCount = (SELECT COUNT(*) FROM #TempResults);
    
    SET @c = @rowCount;
    
    SELECT * FROM #TempResults;
    
    DROP TABLE #TempResults;
END;


-- ������ ������ ���������
DECLARE @resultCount INT;
EXEC Disziplins @p = '���', @c = @resultCount OUTPUT;
PRINT '���-�� ������: ' + CAST(@resultCount AS varchar(10));
