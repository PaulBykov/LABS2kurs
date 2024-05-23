
CREATE TRIGGER TR_TEACHER_DEL1
	ON ������������� AFTER DELETE
AS BEGIN
	PRINT ('!!! TR_TEACHER_DEL1 ���������')
    INSERT INTO AUTDIT (STMT, TRNAME, CC)
    SELECT 
        'DEL',
        'TR_TEACHER_DEL',  -- ��� ��������
        CONCAT('���=', CAST(i.��� AS varchar(50)), 
               ', �������=', i.�������, 
               ', ���=', i.���, 
               ', �������=', i.�������) 
    FROM deleted i;
END;


CREATE TRIGGER TR_TEACHER_DEL2
	ON ������������� AFTER DELETE
AS BEGIN
	PRINT ('!!! TR_TEACHER_DEL2 ���������')
    INSERT INTO AUTDIT (STMT, TRNAME, CC)
    SELECT 
        'DEL',
        'TR_TEACHER_DEL',  -- ��� ��������
        CONCAT('���=', CAST(i.��� AS varchar(50)), 
               ', �������=', i.�������, 
               ', ���=', i.���, 
               ', �������=', i.�������) 
    FROM deleted i;
END;


CREATE TRIGGER TR_TEACHER_DEL3
	ON ������������� AFTER DELETE
AS BEGIN
	PRINT ('!!! TR_TEACHER_DEL3 ���������')
    INSERT INTO AUTDIT (STMT, TRNAME, CC)
    SELECT 
        'DEL',
        'TR_TEACHER_DEL',  -- ��� ��������
        CONCAT('���=', CAST(i.��� AS varchar(50)), 
               ', �������=', i.�������, 
               ', ���=', i.���, 
               ', �������=', i.�������) 
    FROM deleted i;
END;


--������ ���������
select t.name, e.type_desc 
         from sys.triggers  t join  sys.trigger_events e  
              on t.object_id = e.object_id  
                      where	OBJECT_NAME(t.parent_id) = '�������������' 
							and e.type_desc = 'DELETE' ;  


exec  SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL3', 
	                        @order = 'First', @stmttype = 'DELETE';

exec  SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL2', 
	                        @order = 'Last', @stmttype = 'DELETE';

