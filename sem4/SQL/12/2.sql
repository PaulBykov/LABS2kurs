BEGIN TRANSACTION;

BEGIN TRY
    INSERT INTO ����� (�������������, �����_������, ���_�������������, �������, ���_�������)
    VALUES (45, 4, 2, '���������', '��');

    COMMIT TRANSACTION;
    PRINT '���������� ������� ���������.';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT '��������� ������: ' + ERROR_MESSAGE();
END CATCH;
