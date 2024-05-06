use Быков_4

exec sp_helpindex 'Группы'

CREATE TABLE #tempTable
(
    GROUP_FIELD int,
    SPECIALITY_FIELD varchar(50),
	COUNT_FIELD int
);

CHECKPOINT;

DBCC DROPCLEANBUFFERS;

SET NOCOUNT ON
DECLARE @i int = 0
WHILE @i < 1000
BEGIN
	INSERT #tempTable(GROUP_FIELD, SPECIALITY_FIELD, COUNT_FIELD)
	VALUES (@i + 10, 'test' + cast(@i as char), floor(40 * rand()))
	SET @i += 1
END

SELECT * FROM #tempTable;
	

DROP TABLE #tempTable
CREATE CLUSTERED INDEX #EXPLRE_CL ON #tempTable(GROUP_FIELD ASC);