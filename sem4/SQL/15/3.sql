CREATE TRIGGER TR_TEACHER_UPD
	ON ������������� AFTER UPDATE
AS BEGIN
    INSERT INTO AUTDIT (STMT, TRNAME, CC)
    SELECT 
        'UPD',
        'TR_TEACHER_UPD',  -- ��� ��������
        CONCAT('��:   ���=', CAST(i.��� AS varchar(50)), 
               ', �������=', i.�������, 
               ', ���=', i.���, 
               ', �������=', i.�������,
			   '   �����: ',
			   '���=', CAST(j.��� AS varchar(50)), 
               ', �������=', j.�������, 
               ', ���=', j.���, 
               ', �������=', j.�������
		) 
    FROM deleted i, inserted j;
END;


UPDATE �������������
	SET ������� = '���?'
	WHERE ������� = '������';

SELECT * FROM AUTDIT
