BEGIN TRY
	UPDATE ������ SET ������������� = '���'
			WHERE �����_������ > 'a'	
END TRY
BEGIN CATCH
	PRINT '������ �����: ' + CAST(ERROR_NUMBER() AS VARCHAR(40))
	PRINT '����� ������: ' + CAST(ERROR_MESSAGE() AS VARCHAR(40))
	PRINT '�� ������: ' + CAST(ERROR_LINE() AS VARCHAR(40))
	PRINT '� ���������: ' + CAST(ERROR_PROCEDURE() AS VARCHAR(40))
	PRINT '�����������:' + CAST(ERROR_SEVERITY() AS VARCHAR(40))
	PRINT '���������: ' + CAST(ERROR_STATE() AS VARCHAR(40))
END CATCH;