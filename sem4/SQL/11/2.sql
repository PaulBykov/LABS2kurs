-- Создание временной таблицы для демонстрации
CREATE TABLE #Курсы
(
    Номер_группы INT,
    Предмет NVARCHAR(100)
)

-- Вставка данных во временную таблицу
INSERT INTO #Курсы (Номер_группы, Предмет)
VALUES
    (1, 'Дисциплина 1'),
    (1, 'Дисциплина 2'),
    (2, 'Дисциплина 3'),
    (2, 'Дисциплина 4'),
    (3, 'Дисциплина 5')

-- Глобальный курсор
DECLARE @GlobalSubject NVARCHAR(100)
DECLARE GlobalSubjectCursor CURSOR GLOBAL FOR
	SELECT Предмет
	FROM #Курсы
OPEN GlobalSubjectCursor
FETCH NEXT FROM GlobalSubjectCursor INTO @GlobalSubject
PRINT 'Глобальный курсор:'
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT @GlobalSubject
    FETCH NEXT FROM GlobalSubjectCursor INTO @GlobalSubject
END
CLOSE GlobalSubjectCursor
DEALLOCATE GlobalSubjectCursor

-- Локальный курсор
DECLARE @LocalSubject NVARCHAR(100)
DECLARE LocalSubjectCursor CURSOR LOCAL FOR
	SELECT Предмет
	FROM #Курсы
OPEN LocalSubjectCursor
FETCH NEXT FROM LocalSubjectCursor INTO @LocalSubject
PRINT 'Локальный курсор:'
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT @LocalSubject
    FETCH NEXT FROM LocalSubjectCursor INTO @LocalSubject
END
CLOSE LocalSubjectCursor
DEALLOCATE LocalSubjectCursor

-- Удаление временной таблицы
DROP TABLE #Курсы