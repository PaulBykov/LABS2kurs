DECLARE @SubjectList NVARCHAR(MAX) = ''
DECLARE @SubjectName NVARCHAR(100)


DECLARE SubjectCursor CURSOR FOR
SELECT RTRIM(Предмет) AS SubjectName
FROM Курсы AS C
INNER JOIN Группы AS G ON C.Номер_группы = G.номер_группы
WHERE G.специальность = 'ПОИТ'


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

SELECT @SubjectList AS Список_дисциплин