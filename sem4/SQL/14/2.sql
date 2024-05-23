CREATE FUNCTION GetDisziplinListByTeacher (@name nvarchar(50)) returns nvarchar(300)
as begin
	DECLARE @res nvarchar(300) = '';
	SELECT @res = STRING_AGG(�����.�������, ', ')
			FROM ����� 
			INNER JOIN ������������� ON �����.���_������������� = �������������.���
			WHERE RTRIM(�������������.���) = RTRIM('�����')
			GROUP BY �������������.���
	return @res;
end;

declare @r nvarchar(300) = dbo.GetDisziplinListByTeacher('�����')
print @r