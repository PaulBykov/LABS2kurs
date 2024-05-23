CREATE TRIGGER TR_TEACHER_DEL 
	ON Преподаватели AFTER DELETE
AS BEGIN
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

DELETE Преподаватели where Преподаватели.Фамилия = 'Смелов'
SELECT * FROM AUTDIT
