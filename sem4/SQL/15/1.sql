CREATE TABLE AUTDIT
(
	ID int identity,
	STMT varchar(20),
	check (STMT in ('INS', 'DEL', 'UPD')),
	TRNAME varchar(50),
	CC varchar(300)
)


CREATE TRIGGER TR_TEACHER_INS 
	ON Преподаватели AFTER INSERT
AS BEGIN
	print ('!!!   TR_TEACHER_INS ОТРАБОТАЛ');
    INSERT INTO AUTDIT (STMT, TRNAME, CC)
    SELECT 
        'INS',
        'TR_TEACHER_INS',  -- Имя триггера
        CONCAT('Код=', CAST(i.Код AS varchar(50)), 
               ', Фамилия=', i.Фамилия, 
               ', Имя=', i.Имя, 
               ', Телефон=', i.Телефон) 
    FROM inserted i;
END;


INSERT Преподаватели values(
	9, 'Смелов', 'Владимир', '321666666'
)
SELECT * FROM AUTDIT

