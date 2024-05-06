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


CREATE  index #temp_Inculde on #tempTable(GROUP_FIELD) INCLUDE (COUNT_FIELD);
SELECT COUNT_FIELD, GROUP_FIELD from #tempTable where COUNT_FIELD>15000

DROP TABLE #tempTable