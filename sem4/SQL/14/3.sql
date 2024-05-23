CREATE FUNCTION GetDisziplinListByTeacherAndGroup (
    @name nvarchar(50),
    @groupNumber int
) RETURNS @result TABLE (������� nvarchar(100))
AS
BEGIN
    IF @name IS NULL AND @groupNumber IS NULL
		BEGIN
			INSERT INTO @result
			SELECT DISTINCT �����.�������
			FROM �����;
		END
    ELSE IF @name IS NULL
		BEGIN
			INSERT INTO @result
			SELECT DISTINCT �����.�������
			FROM �����
			LEFT OUTER JOIN ������ ON �����.�����_������ = ������.�����_������
			WHERE �����.�����_������ = @groupNumber;
		END
    ELSE IF @groupNumber IS NULL
		BEGIN
			INSERT INTO @result
			SELECT DISTINCT �����.�������
			FROM �����
			LEFT OUTER JOIN ������������� ON �����.���_������������� = �������������.���
			WHERE RTRIM(�������������.���) = RTRIM(@name);
		END
    ELSE
		BEGIN
			INSERT INTO @result
			SELECT DISTINCT �����.�������
			FROM �����
			INNER JOIN ������������� ON �����.���_������������� = �������������.���
			INNER JOIN ������ ON �����.�����_������ = ������.�����_������
			WHERE RTRIM(�������������.���) = RTRIM(@name)
			  AND �����.�����_������ = @groupNumber;
		END

    RETURN;
END;


select * from dbo.GetDisziplinListByTeacherAndGroup('�����', 4)

select * from dbo.GetDisziplinListByTeacherAndGroup('�����', NULL)

select * from dbo.GetDisziplinListByTeacherAndGroup(NULL, 4)


select * from dbo.GetDisziplinListByTeacherAndGroup(NULL, NULL)

