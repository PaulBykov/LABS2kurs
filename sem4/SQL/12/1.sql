
DECLARE @c int = 0
DECLARE @flag char = 'c'

SET IMPLICIT_TRANSACTIONS  ON
SELECT * FROM �����;
	set @c = (select count(*) from �����);
	print '���������� ������: ' + cast( @c as varchar(2));
	if @flag = 'c'  commit;                   
		   else   rollback;                  
SET IMPLICIT_TRANSACTIONS  OFF 
