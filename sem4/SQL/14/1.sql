CREATE FUNCTION GetDisziplinsByTeacher (@name nvarchar(50)) returns int
as begin
	DECLARE @res int = 0;
	set @res = (
			SELECT count(*)
			FROM ����� 
			INNER JOIN ������������� ON �����.���_������������� = �������������.���
			WHERE RTRIM(�������������.���) = RTRIM(@name)
	);

	return @res;
end;


declare @f int = dbo.GetDisziplinsByTeacher('�����')
print @f