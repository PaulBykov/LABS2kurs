BEGIN TRANSACTION;

BEGIN TRY
    SAVE TRANSACTION SavePoint1;

	INSERT INTO ����� (�������������, �����_������, ���_�������������, �������, ���_�������)
    VALUES (41, 4, 2, '�����', '��');
	
    SAVE TRANSACTION SavePoint2;

    UPDATE ������
    SET ����������_��������� = '2' --��� ������
    WHERE �����_������ = 4;

    COMMIT TRAN;
    PRINT '���������� ������� ���������.';
END TRY
BEGIN CATCH
    PRINT '��������� ������: ' + ERROR_MESSAGE();
    PRINT '����� � ����� ����������';
    
	BEGIN TRY
		ROLLBACK TRAN SavePoint2;
		PRINT '���������� �� SP2'
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN SavePoint1;
		PRINT '���������� �� SP1'
	END CATCH

END CATCH;