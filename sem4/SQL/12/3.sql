BEGIN TRANSACTION;

BEGIN TRY
    SAVE TRANSACTION SavePoint1;

	INSERT INTO Курсы (Идентификатор, Номер_группы, Код_преподавателя, Предмет, Тип_занятия)
    VALUES (41, 4, 2, 'Матан', 'ЛК');
	
    SAVE TRANSACTION SavePoint2;

    UPDATE Группы
    SET Количество_студентов = '2' --тип данных
    WHERE Номер_группы = 4;

    COMMIT TRAN;
    PRINT 'Транзакция успешно выполнена.';
END TRY
BEGIN CATCH
    PRINT 'Произошла ошибка: ' + ERROR_MESSAGE();
    PRINT 'Откат к точке сохранения';
    
	BEGIN TRY
		ROLLBACK TRAN SavePoint2;
		PRINT 'Откатились до SP2'
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN SavePoint1;
		PRINT 'Откатились до SP1'
	END CATCH

END CATCH;