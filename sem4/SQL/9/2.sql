DECLARE @avg float(4) = (select avg(Количество_студентов) from Группы)
DECLARE @sum float(4) = (select sum(Количество_студентов) from Группы)

DECLARE @r1 int,
		@r2 int,
		@r3 float;

IF @sum > 100
begin
	SELECT @r1 = (SELECT CAST(COUNT(*) as numeric(8, 3)) FROM Группы),
		   @r2 = (SELECT CAST(COUNT(*) as numeric(8, 3)) FROM Группы WHERE Количество_студентов < @avg);
	
	SET @r3 = (@r2 / CAST(@r1 as float)) * 100;

	PRINT 'Общее кол-во групп: ' + cast(@r1 as varchar(10));
	PRINT 'Кол-во групп размером меньше avg: ' + cast(@r2 as varchar(10));
	PRINT 'Процент групп размером меньше avg: ' + cast(@r3 as varchar(10)) + '%';
end
else print('<=100');
