-- A ---
          set transaction isolation level SERIALIZABLE 
	begin transaction 
	delete ����� where ������� = '��';  
          insert ����� values (15,  2,  1,  10,  '��',  '��');
          update ����� set ������� = '����' where ������� = '���';
          select  �����_������ from �����  where ������� = '��';
	-------------------------- t1 -----------------
	select  �����_������ from �����  where ������� = '��';
	-------------------------- t2 ------------------ 
	commit; 	
