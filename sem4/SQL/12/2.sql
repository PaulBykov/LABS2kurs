BEGIN TRANSACTION;

BEGIN TRY
    INSERT INTO Курсы (Идентификатор, Номер_группы, Код_преподавателя, Предмет, Тип_занятия)
    VALUES (45, 4, 2, 'Матанализ', 'ЛК');

    COMMIT TRANSACTION;
    PRINT 'Транзакция успешно выполнена.';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'Произошла ошибка: ' + ERROR_MESSAGE();
END CATCH;
