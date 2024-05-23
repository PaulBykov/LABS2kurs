CREATE PROCEDURE DisziplinsByTeacher @name nvarchar(50)
AS
BEGIN
    BEGIN TRY
        -- ���������, ���� �� ����� ��� ���������� �������������
        IF EXISTS (
            SELECT * 
            FROM ����� 
            INNER JOIN ������������� ON �����.���_������������� = �������������.���
            WHERE RTRIM(�������������.���) = RTRIM(@name)
        )
			BEGIN
				SELECT �����.*
				FROM ����� 
				INNER JOIN ������������� ON �����.���_������������� = �������������.���
				WHERE RTRIM(�������������.���) = RTRIM(@name);
			END
        ELSE
			BEGIN
				PRINT '����� ��� ���������� ������������� �� �������.';
			END
    END TRY
    BEGIN CATCH
        -- ��������� ������
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        -- ����� ��������� �� ������
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;



EXEC DisziplinsByTeacher @name='�����'
EXEC DisziplinsByTeacher @name='�����'