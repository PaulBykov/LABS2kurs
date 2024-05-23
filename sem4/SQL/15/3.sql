CREATE TRIGGER TR_TEACHER_UPD
	ON Преподаватели AFTER UPDATE
AS BEGIN
    INSERT INTO AUTDIT (STMT, TRNAME, CC)
    SELECT 
        'UPD',
        'TR_TEACHER_UPD',  -- Имя триггера
        CONCAT('ДО:   Код=', CAST(i.Код AS varchar(50)), 
               ', Фамилия=', i.Фамилия, 
               ', Имя=', i.Имя, 
               ', Телефон=', i.Телефон,
			   '   ПОСЛЕ: ',
			   'Код=', CAST(j.Код AS varchar(50)), 
               ', Фамилия=', j.Фамилия, 
               ', Имя=', j.Имя, 
               ', Телефон=', j.Телефон
		) 
    FROM deleted i, inserted j;
END;


UPDATE Преподаватели
	SET Фамилия = 'Кто?'
	WHERE Фамилия = 'Смелов';

SELECT * FROM AUTDIT
