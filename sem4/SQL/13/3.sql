


ALTER PROCEDURE Disziplins @p varchar(20)
as
begin
	DECLARE @k int = (select count(*) from Курсы where Предмет = @p)
	select * from Курсы where Предмет = @p;
	RETURN @k
end;


CREATE TABLE #Kurses(
	Идентификатор int primary key,
	Номер_группы int foreign key references Группы(Номер_группы),
	Код_преподавателя int foreign key references Преподаватели(Код),
	Предмет nvarchar(20),
	Тип_занятия nvarchar(20),
)

SELECT * FROM #Kurses

INSERT #Kurses exec Disziplins @p = 'ООП'
INSERT #Kurses exec Disziplins @p = 'БД'


SELECT * FROM #Kurses

