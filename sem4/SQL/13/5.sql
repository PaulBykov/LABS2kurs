CREATE PROCEDURE DisziplinsByTeacher @name nvarchar(50)
AS
BEGIN
    BEGIN TRY
        -- Проверяем, есть ли курсы для указанного преподавателя
        IF EXISTS (
            SELECT * 
            FROM Курсы 
            INNER JOIN Преподаватели ON Курсы.Код_преподавателя = Преподаватели.Код
            WHERE RTRIM(Преподаватели.Имя) = RTRIM(@name)
        )
			BEGIN
				SELECT Курсы.*
				FROM Курсы 
				INNER JOIN Преподаватели ON Курсы.Код_преподавателя = Преподаватели.Код
				WHERE RTRIM(Преподаватели.Имя) = RTRIM(@name);
			END
        ELSE
			BEGIN
				PRINT 'Курсы для указанного преподавателя не найдены.';
			END
    END TRY
    BEGIN CATCH
        -- Обработка ошибок
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        -- Вывод сообщения об ошибке
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;



EXEC DisziplinsByTeacher @name='Павел'
EXEC DisziplinsByTeacher @name='Артур'