-- Создание статического курсора
DECLARE @CourseID INT
DECLARE StaticCursor CURSOR STATIC FOR
SELECT Идентификатор
FROM Курсы

-- Открытие курсора
OPEN StaticCursor

-- Извлечение первого значения
FETCH NEXT FROM StaticCursor INTO @CourseID
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Курс ID: ' + CAST(@CourseID AS VARCHAR(10))
    -- Извлечение следующего значения
    FETCH NEXT FROM StaticCursor INTO @CourseID
END

-- Закрытие и удаление курсора
CLOSE StaticCursor
DEALLOCATE StaticCursor

-- Обновление данных в таблице Преподаватели
UPDATE Преподаватели
SET Телефон = '1234567890'
WHERE Код = 1