-- A ---
          set transaction isolation level  REPEATABLE READ 
	begin transaction 
	select Номер_группы from Курсы where Предмет = 'БД';
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	select  case
          when Номер_группы = 4 then 'insert  Заказы'  
		  else ' ' 
	end 'результат', Номер_группы from Курсы where Предмет = 'БД';
	commit; 

