

CREATE PROCEDURE Disziplins as
begin
	declare @k int = (select count(*) from Курсы)
	select * from Курсы;
	return @k;
end;


declare @a int = 0;
EXEC @a = Disziplins;
print 'кол-во курсов: ' + cast(@a as varchar(3))