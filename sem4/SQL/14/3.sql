CREATE FUNCTION GetDisziplinListByTeacherAndGroup (
    @name nvarchar(50),
    @groupNumber int
) RETURNS @result TABLE (Предмет nvarchar(100))
AS
BEGIN
    IF @name IS NULL AND @groupNumber IS NULL
		BEGIN
			INSERT INTO @result
			SELECT DISTINCT Курсы.Предмет
			FROM Курсы;
		END
    ELSE IF @name IS NULL
		BEGIN
			INSERT INTO @result
			SELECT DISTINCT Курсы.Предмет
			FROM Курсы
			LEFT OUTER JOIN Группы ON Курсы.Номер_группы = Группы.Номер_группы
			WHERE Курсы.Номер_группы = @groupNumber;
		END
    ELSE IF @groupNumber IS NULL
		BEGIN
			INSERT INTO @result
			SELECT DISTINCT Курсы.Предмет
			FROM Курсы
			LEFT OUTER JOIN Преподаватели ON Курсы.Код_преподавателя = Преподаватели.Код
			WHERE RTRIM(Преподаватели.Имя) = RTRIM(@name);
		END
    ELSE
		BEGIN
			INSERT INTO @result
			SELECT DISTINCT Курсы.Предмет
			FROM Курсы
			INNER JOIN Преподаватели ON Курсы.Код_преподавателя = Преподаватели.Код
			INNER JOIN Группы ON Курсы.Номер_группы = Группы.Номер_группы
			WHERE RTRIM(Преподаватели.Имя) = RTRIM(@name)
			  AND Курсы.Номер_группы = @groupNumber;
		END

    RETURN;
END;


select * from dbo.GetDisziplinListByTeacherAndGroup('Артур', 4)

select * from dbo.GetDisziplinListByTeacherAndGroup('Артур', NULL)

select * from dbo.GetDisziplinListByTeacherAndGroup(NULL, 4)


select * from dbo.GetDisziplinListByTeacherAndGroup(NULL, NULL)

