CREATE TABLE AUTDIT
(
	ID int identity,
	STMT varchar(20),
	check (STMT in ('INS', 'DEL', 'UPD')),
	TRNAME varchar(50),
	CC varchar(300)
)


CREATE TRIGGER TR_TEACHER_INS 
	ON ������������� AFTER INSERT
AS BEGIN
	print ('!!!   TR_TEACHER_INS ���������');
    INSERT INTO AUTDIT (STMT, TRNAME, CC)
    SELECT 
        'INS',
        'TR_TEACHER_INS',  -- ��� ��������
        CONCAT('���=', CAST(i.��� AS varchar(50)), 
               ', �������=', i.�������, 
               ', ���=', i.���, 
               ', �������=', i.�������) 
    FROM inserted i;
END;


INSERT ������������� values(
	9, '������', '��������', '321666666'
)
SELECT * FROM AUTDIT

