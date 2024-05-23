
CREATE TRIGGER TR_DDL_PREVENT_CREATE_DROP_TABLE 
				ON DATABASE
				FOR CREATE_TABLE, DROP_TABLE
AS BEGIN
    DECLARE @EventData XML;
    SET @EventData = EVENTDATA();

    DECLARE @EventType NVARCHAR(100);
    DECLARE @ObjectType NVARCHAR(100);
    DECLARE @ObjectName NVARCHAR(100);
    DECLARE @Message NVARCHAR(4000);


    SET @EventType = @EventData.value('(/EVENT_INSTANCE/EventType)[1]', 'NVARCHAR(100)');
    SET @ObjectType = @EventData.value('(/EVENT_INSTANCE/ObjectType)[1]', 'NVARCHAR(100)');
    SET @ObjectName = @EventData.value('(/EVENT_INSTANCE/ObjectName)[1]', 'NVARCHAR(100)');


    SET @Message = 'Тип события: ' + @EventType + 
                   ', Имя объекта: ' + @ObjectName + 
                   ', Тип объекта: ' + @ObjectType + 
                   '. Операция запрещена: создание и удаление таблиц не допускается.';


    RAISERROR(@Message, 16, 1);


    ROLLBACK;
END;

