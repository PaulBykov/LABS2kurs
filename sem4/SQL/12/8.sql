BEGIN TRAN
	SELECT count(*) FROM �����
	
	BEGIN TRAN
			INSERT ����� values(37, 2, 2, '���', '��')
			commit

IF @@TRANCOUNT > 0
    ROLLBACK;
ELSE
    COMMIT;


SELECT count(*) FROM �����