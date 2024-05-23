
CREATE PROCEDURE DisziplinsAdd
    @a int,
    @b int,
    @c int,
	@d nvarchar(50),
	@e nvarchar(50)
AS
BEGIN
	BEGIN TRY
		INSERT INTO Курсы
		VALUES (@a, @b, @c, @d, @e)
	END TRY
	begin catch
		print 'сообщение об ошибке: ' + cast(error_message() as varchar(8));
		print 'уровень серьезности: ' + cast(error_severity() as varchar(6));
		print 'состояние: ' + cast(error_state() as varchar(8));
		print 'номер строки: ' + cast(error_line() as varchar(8));
		if error_procedure() is not null
			print 'имя процедуры: ' + error_procedure();
		return -1;
	end catch;
END

EXEC DisziplinsAdd @a = 26, @b=1, @c = 1, @d='СД', @e='ЛР';