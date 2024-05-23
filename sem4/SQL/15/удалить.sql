

DECLARE @tableName NVARCHAR(128) = N'Преподаватели';

DECLARE @triggerName NVARCHAR(128);

DECLARE triggerCursor CURSOR FOR
SELECT name FROM sys.triggers WHERE parent_id = OBJECT_ID(@tableName);

OPEN triggerCursor;

FETCH NEXT FROM triggerCursor INTO @triggerName;

WHILE @@FETCH_STATUS = 0
BEGIN
    EXEC('DROP TRIGGER ' + @triggerName);

    FETCH NEXT FROM triggerCursor INTO @triggerName;
END;

CLOSE triggerCursor;

DEALLOCATE triggerCursor;