CREATE TRIGGER TR_TEACHER_DEL 
	ON ������������� AFTER DELETE
AS BEGIN
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

DELETE ������������� where �������������.������� = '������'
SELECT * FROM AUTDIT
