
CREATE FUNCTION dbo.COUNT_KURSES(@specname nvarchar(50)) returns int
as begin	
	declare @c int = 0;
	SELECT @c = COUNT(*) 
				FROM �����
				inner join ������ on �����.�����_������ = ������.�����_������
				WHERE ������.������������� = @specname
				GROUP BY ������.�����_������
	return @c;
end;

CREATE FUNCTION dbo.COUNT_GROUPS(@specname nvarchar(50)) returns int
as begin	
	declare @c int = 0;
	SELECT @c = COUNT(*) FROM ������ WHERE ������������� = @specname;
	return @c;
end;

CREATE FUNCTION dbo.COUNT_TEACHERS() returns int
as begin	
	declare @c int = 0;
	SELECT @c = COUNT(*) FROM �������������;
	return @c;
end;




CREATE FUNCTION SPEC_REPORT(@c int) RETURNS @fr TABLE (
    [�������������] varchar(50),  
    [���������� �����] int, 
    [���������� ������] int
)
AS BEGIN
    DECLARE cc CURSOR STATIC FOR 
        SELECT �������������
        FROM ������ 
        WHERE ����������_��������� > @c;

    DECLARE @f varchar(50);
    OPEN cc;  
    FETCH cc INTO @f;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        INSERT INTO @fr 
        VALUES(
            @f,  
            dbo.COUNT_KURSES(@f),
            dbo.COUNT_GROUPS(@f)
        ); 

        FETCH cc INTO @f;  
    END;   

    CLOSE cc;
    DEALLOCATE cc;

    RETURN; 
END;



SELECT * FROM dbo.SPEC_REPORT(25);