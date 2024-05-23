-- Создание динамического курсора
DECLARE @CourseID INT
DECLARE DynamicCursor CURSOR DYNAMIC FOR
SELECT Идентификатор
FROM Курсы

-- Открытие курсора
OPEN DynamicCursor

-- Извлечение первого значения
FETCH NEXT FROM DynamicCursor INTO @CourseID
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Курс ID: ' + CAST(@CourseID AS VARCHAR(10))
    -- Обновление данных в таблице Преподаватели
    UPDATE Преподаватели
    SET Телефон = '0987654321'
    WHERE Код = 1
    -- Извлечение следующего значения
    FETCH NEXT FROM DynamicCursor INTO @CourseID
END

-- Закрытие и удаление курсора
CLOSE DynamicCursor
DEALLOCATE DynamicCursor