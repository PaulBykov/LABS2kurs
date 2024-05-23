CREATE FUNCTION GetDisziplinsByTeacher (@name nvarchar(50)) returns int
as begin
	DECLARE @res int = 0;
	set @res = (
			SELECT count(*)
			FROM Курсы 
			INNER JOIN Преподаватели ON Курсы.Код_преподавателя = Преподаватели.Код
			WHERE RTRIM(Преподаватели.Имя) = RTRIM(@name)
	);

	return @res;
end;


declare @f int = dbo.GetDisziplinsByTeacher('Артур')
print @f