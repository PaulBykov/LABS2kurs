CREATE TABLE #TEMP(
	Student_id int,
	Fullname nvarchar(40)
)


SET NOCOUNT ON;
DECLARE @i int = 0;
WHILE @i < 10
	begin
		INSERT #TEMP(Student_id, Fullname)
			values(@i, 'Человек Без Имени');
		SET @i = @i + 1;
	end;


DECLARE @j int = 0;
DECLARE @out nvarchar(40) = '';
WHILE @j < 10
	begin
		SET @out = (SELECT TOP(1) Fullname FROM #TEMP WHERE Student_id = @j);
		PRINT(cast(@j as varchar(5)) + space(2) + @out);
		SET @j = @j + 1;
	end;