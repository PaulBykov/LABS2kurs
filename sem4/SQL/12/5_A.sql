-- A ---
set transaction isolation level READ COMMITTED 
begin transaction 
select count(*) from ����� 	where ������� = '��';
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
select  'update ������'  '���������', count(*)
	                           from �����  where ������� = '��';

commit; 


