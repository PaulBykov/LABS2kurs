


ALTER PROCEDURE Disziplins @p varchar(20)
as
begin
	DECLARE @k int = (select count(*) from ����� where ������� = @p)
	select * from ����� where ������� = @p;
	RETURN @k
end;


CREATE TABLE #Kurses(
	������������� int primary key,
	�����_������ int foreign key references ������(�����_������),
	���_������������� int foreign key references �������������(���),
	������� nvarchar(20),
	���_������� nvarchar(20),
)

SELECT * FROM #Kurses

INSERT #Kurses exec Disziplins @p = '���'
INSERT #Kurses exec Disziplins @p = '��'


SELECT * FROM #Kurses

