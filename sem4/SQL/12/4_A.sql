-- A ---
	set transaction isolation level READ UNCOMMITTED 
	begin transaction 
	-------------------------- t1 ------------------
	select @@SPID, 'insert �����' '���������', * 
		from ����� where ������� = '��';
	
	select @@SPID, 'update �����'  '���������',  *
		from �����   where ������� = '���';
	
	commit; 
	-------------------------- t2 -----------------
