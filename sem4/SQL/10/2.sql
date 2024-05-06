use Быков_4

CREATE TABLE #tempTable
(
    GROUP_FIELD int,
    SPECIALITY_FIELD varchar(50),
	COUNT_FIELD int
);


set nocount on;
declare @i int = 0;
while   @i < 20000
begin
       INSERT #tempTable(GROUP_FIELD, SPECIALITY_FIELD, COUNT_FIELD)
		VALUES (@i + 10, 'test' + cast(@i as char), floor(40 * rand()))
		SET @i += 1
end;

CREATE index #tempTable_nonClus on #tempTable(GROUP_FIELD, SPECIALITY_FIELD, COUNT_FIELD);

SELECT * from  #tempTable where  GROUP_FIELD > 1500 and  GROUP_FIELD < 19500;
SELECT * from  #tempTable order by  GROUP_FIELD, COUNT_FIELD;

SELECT * from  #tempTable where  GROUP_FIELD = 556 and  COUNT_FIELD > 3;