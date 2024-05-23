-- A ---
set transaction isolation level READ COMMITTED 
begin transaction 
select count(*) from Курсы 	where Предмет = 'БД';
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
select  'update Заказы'  'результат', count(*)
	                           from Курсы  where Предмет = 'БД';

commit; 


