-- A ---
          set transaction isolation level  REPEATABLE READ 
	begin transaction 
	select �����_������ from ����� where ������� = '��';
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	select  case
          when �����_������ = 4 then 'insert  ������'  
		  else ' ' 
	end '���������', �����_������ from ����� where ������� = '��';
	commit; 

