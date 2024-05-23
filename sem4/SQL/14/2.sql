CREATE FUNCTION GetDisziplinListByTeacher (@name nvarchar(50)) returns nvarchar(300)
as begin
	DECLARE @res nvarchar(300) = '';
	SELECT @res = STRING_AGG(Курсы.Предмет, ', ')
			FROM Курсы 
			INNER JOIN Преподаватели ON Курсы.Код_преподавателя = Преподаватели.Код
			WHERE RTRIM(Преподаватели.Имя) = RTRIM('Артур')
			GROUP BY Преподаватели.Имя
	return @res;
end;

declare @r nvarchar(300) = dbo.GetDisziplinListByTeacher('Артур')
print @r