DECLARE @SubjectList NVARCHAR(MAX) = ''
DECLARE @SubjectName NVARCHAR(100)


DECLARE SubjectCursor CURSOR FOR
SELECT RTRIM(�������) AS SubjectName
FROM ����� AS C
INNER JOIN ������ AS G ON C.�����_������ = G.�����_������
WHERE G.������������� = '����'


OPEN SubjectCursor
FETCH NEXT FROM SubjectCursor INTO @SubjectName
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @SubjectList = @SubjectList + ', ' + @SubjectName
    FETCH NEXT FROM SubjectCursor INTO @SubjectName
END

CLOSE SubjectCursor
DEALLOCATE SubjectCursor

SET @SubjectList = RTRIM(STUFF(@SubjectList, 1, 2, ''))

SELECT @SubjectList AS ������_���������