

CREATE PROCEDURE Disziplins as
begin
	declare @k int = (select count(*) from �����)
	select * from �����;
	return @k;
end;


declare @a int = 0;
EXEC @a = Disziplins;
print '���-�� ������: ' + cast(@a as varchar(3))