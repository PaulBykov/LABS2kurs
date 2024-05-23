CREATE FUNCTION GetTeacherCountBySubject (@subject nvarchar(100))
RETURNS int
AS
BEGIN
    DECLARE @count int;

    IF @subject IS NULL
		BEGIN
			SELECT @count = COUNT(DISTINCT Код)
			FROM Преподаватели;
		END
    ELSE
		BEGIN
			SELECT @count = COUNT(DISTINCT Преподаватели.Код)
			FROM Преподаватели
			inner join Курсы ON Преподаватели.Код = Курсы.Код_преподавателя
			WHERE Курсы.Предмет = @subject;
		END

    RETURN @count;
END;


SELECT dbo.GetTeacherCountBySubject(NULL);

SELECT dbo.GetTeacherCountBySubject('БД');
