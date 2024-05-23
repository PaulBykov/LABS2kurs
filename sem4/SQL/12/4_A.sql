-- A ---
	set transaction isolation level READ UNCOMMITTED 
	begin transaction 
	-------------------------- t1 ------------------
	select @@SPID, 'insert Курсы' 'результат', * 
		from Курсы where Предмет = 'БД';
	
	select @@SPID, 'update Курсы'  'результат',  *
		from Курсы   where Предмет = 'ООП';
	
	commit; 
	-------------------------- t2 -----------------
