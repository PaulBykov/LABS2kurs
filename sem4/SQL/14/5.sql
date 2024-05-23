
CREATE FUNCTION dbo.COUNT_KURSES(@specname nvarchar(50)) returns int
as begin	
	declare @c int = 0;
	SELECT @c = COUNT(*) 
				FROM Курсы
				inner join Группы on Курсы.Номер_группы = Группы.Номер_группы
				WHERE Группы.Специальность = @specname
				GROUP BY Группы.Номер_группы
	return @c;
end;

CREATE FUNCTION dbo.COUNT_GROUPS(@specname nvarchar(50)) returns int
as begin	
	declare @c int = 0;
	SELECT @c = COUNT(*) FROM Группы WHERE Специальность = @specname;
	return @c;
end;

CREATE FUNCTION dbo.COUNT_TEACHERS() returns int
as begin	
	declare @c int = 0;
	SELECT @c = COUNT(*) FROM Преподаватели;
	return @c;
end;




CREATE FUNCTION SPEC_REPORT(@c int) RETURNS @fr TABLE (
    [Специальность] varchar(50),  
    [Количество групп] int, 
    [Количество курсов] int
)
AS BEGIN
    DECLARE cc CURSOR STATIC FOR 
        SELECT Специальность
        FROM Группы 
        WHERE Количество_студентов > @c;

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