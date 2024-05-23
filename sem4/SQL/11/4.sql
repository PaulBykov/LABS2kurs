-- Создание курсора с атрибутом SCROLL
DECLARE @CourseID INT
DECLARE ScrollCursor CURSOR SCROLL FOR
SELECT Идентификатор
FROM Курсы

-- Открытие курсора
OPEN ScrollCursor

-- Извлечение первого значения (FIRST)
FETCH FIRST FROM ScrollCursor INTO @CourseID
PRINT 'Первый Курс ID: ' + CAST(@CourseID AS VARCHAR(10))

-- Извлечение следующего значения (NEXT)
FETCH NEXT FROM ScrollCursor INTO @CourseID
PRINT 'Следующий Курс ID: ' + CAST(@CourseID AS VARCHAR(10))

-- Извлечение предыдущего значения (PRIOR)
FETCH PRIOR FROM ScrollCursor INTO @CourseID
PRINT 'Предыдущий Курс ID: ' + CAST(@CourseID AS VARCHAR(10))

-- Извлечение последнего значения (LAST)
FETCH LAST FROM ScrollCursor INTO @CourseID
PRINT 'Последний Курс ID: ' + CAST(@CourseID AS VARCHAR(10))

-- Извлечение значения по абсолютной позиции (ABSOLUTE 2)
FETCH ABSOLUTE 2 FROM ScrollCursor INTO @CourseID
PRINT 'Курс ID на позиции 2: ' + CAST(@CourseID AS VARCHAR(10))

-- Извлечение значения по относительной позиции (RELATIVE -1)
FETCH RELATIVE -1 FROM ScrollCursor INTO @CourseID
PRINT 'Курс ID на одну позицию назад от текущей: ' + CAST(@CourseID AS VARCHAR(10))

-- Закрытие и удаление курсора
CLOSE ScrollCursor
DEALLOCATE ScrollCursor