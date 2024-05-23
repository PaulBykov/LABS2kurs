CREATE FUNCTION GetTeacherCountBySubject (@subject nvarchar(100))
RETURNS int
AS
BEGIN
    DECLARE @count int;

    IF @subject IS NULL
		BEGIN
			SELECT @count = COUNT(DISTINCT ���)
			FROM �������������;
		END
    ELSE
		BEGIN
			SELECT @count = COUNT(DISTINCT �������������.���)
			FROM �������������
			inner join ����� ON �������������.��� = �����.���_�������������
			WHERE �����.������� = @subject;
		END

    RETURN @count;
END;


SELECT dbo.GetTeacherCountBySubject(NULL);

SELECT dbo.GetTeacherCountBySubject('��');
