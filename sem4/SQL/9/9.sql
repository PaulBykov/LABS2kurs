BEGIN TRY
	UPDATE Группы SET Специальность = 'НЕТ'
			WHERE Номер_группы > 'a'	
END TRY
BEGIN CATCH
	PRINT 'Ошибка номер: ' + CAST(ERROR_NUMBER() AS VARCHAR(40))
	PRINT 'Текст ошибки: ' + CAST(ERROR_MESSAGE() AS VARCHAR(40))
	PRINT 'На строке: ' + CAST(ERROR_LINE() AS VARCHAR(40))
	PRINT 'В процедуре: ' + CAST(ERROR_PROCEDURE() AS VARCHAR(40))
	PRINT 'Серьезность:' + CAST(ERROR_SEVERITY() AS VARCHAR(40))
	PRINT 'Состояние: ' + CAST(ERROR_STATE() AS VARCHAR(40))
END CATCH;