
CREATE TRIGGER TR_TEACHER_DEL1
	ON Преподаватели AFTER DELETE
AS BEGIN
	PRINT ('!!! TR_TEACHER_DEL1 отработал')
    INSERT INTO AUTDIT (STMT, TRNAME, CC)
    SELECT 
        'DEL',
        'TR_TEACHER_DEL',  -- Имя триггера
        CONCAT('Код=', CAST(i.Код AS varchar(50)), 
               ', Фамилия=', i.Фамилия, 
               ', Имя=', i.Имя, 
               ', Телефон=', i.Телефон) 
    FROM deleted i;
END;


CREATE TRIGGER TR_TEACHER_DEL2
	ON Преподаватели AFTER DELETE
AS BEGIN
	PRINT ('!!! TR_TEACHER_DEL2 отработал')
    INSERT INTO AUTDIT (STMT, TRNAME, CC)
    SELECT 
        'DEL',
        'TR_TEACHER_DEL',  -- Имя триггера
        CONCAT('Код=', CAST(i.Код AS varchar(50)), 
               ', Фамилия=', i.Фамилия, 
               ', Имя=', i.Имя, 
               ', Телефон=', i.Телефон) 
    FROM deleted i;
END;


CREATE TRIGGER TR_TEACHER_DEL3
	ON Преподаватели AFTER DELETE
AS BEGIN
	PRINT ('!!! TR_TEACHER_DEL3 отработал')
    INSERT INTO AUTDIT (STMT, TRNAME, CC)
    SELECT 
        'DEL',
        'TR_TEACHER_DEL',  -- Имя триггера
        CONCAT('Код=', CAST(i.Код AS varchar(50)), 
               ', Фамилия=', i.Фамилия, 
               ', Имя=', i.Имя, 
               ', Телефон=', i.Телефон) 
    FROM deleted i;
END;


--Список триггеров
select t.name, e.type_desc 
         from sys.triggers  t join  sys.trigger_events e  
              on t.object_id = e.object_id  
                      where	OBJECT_NAME(t.parent_id) = 'Преподаватели' 
							and e.type_desc = 'DELETE' ;  


exec  SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL3', 
	                        @order = 'First', @stmttype = 'DELETE';

exec  SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL2', 
	                        @order = 'Last', @stmttype = 'DELETE';

