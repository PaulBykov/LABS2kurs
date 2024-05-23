
DECLARE @c int = 0
DECLARE @flag char = 'c'

SET IMPLICIT_TRANSACTIONS  ON
SELECT * FROM Курсы;
	set @c = (select count(*) from Курсы);
	print 'количество курсов: ' + cast( @c as varchar(2));
	if @flag = 'c'  commit;                   
		   else   rollback;                  
SET IMPLICIT_TRANSACTIONS  OFF 
