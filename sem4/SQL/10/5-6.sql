use tempdb;

--drop table #tempTable
CREATE TABLE #tempTable
(
    GROUP_FIELD int,
    SPECIALITY_FIELD varchar(50),
	COUNT_FIELD int
);

set nocount on;
declare @i int = 0;
while   @i < 1000
begin
       INSERT #tempTable(GROUP_FIELD, SPECIALITY_FIELD, COUNT_FIELD)
		VALUES (@i + 10, 'test' + cast(@i as char), floor(40 * rand()))
		SET @i += 1
end;


SELECT COUNT(*) FROM #tempTable;
CREATE INDEX #tempTable_GROUP_FIELD on #tempTable(GROUP_FIELD)
--drop index #tempTable_GROUP_FIELD on #tempTable

INSERT top(200000) #tempTable(GROUP_FIELD, SPECIALITY_FIELD, COUNT_FIELD) select GROUP_FIELD, NULL, COUNT_FIELD from #tempTable;

SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'TEMPDB'),
OBJECT_ID(N'#tempTable'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;




ALTER INDEX #tempTable_GROUP_FIELD ON #tempTable reorganize

ALTER INDEX  #tempTable_GROUP_FIELD ON #tempTable rebuild with (online = off)





drop index #tempTable_GROUP_FIELD on #tempTable
drop index IX_EX6 on #tempTable


create index IX_EX6 on #tempTable (GROUP_FIELD) with (fillfactor = 10)


set nocount on;
declare @i1 int = 0;
while   @i1 < 20000
begin
       INSERT #tempTable(GROUP_FIELD, SPECIALITY_FIELD, COUNT_FIELD)
		VALUES (@i1 + 10, 'test' + cast(@i1 as char), floor(40 * rand()))
		SET @i1 += 1
end;



SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'TEMPDB'),
OBJECT_ID(N'#tempTable'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;
