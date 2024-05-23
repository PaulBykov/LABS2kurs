BEGIN TRAN
	SELECT count(*) FROM Курсы
	
	BEGIN TRAN
			INSERT Курсы values(37, 2, 2, 'ООП', 'ЛР')
			commit

IF @@TRANCOUNT > 0
    ROLLBACK;
ELSE
    COMMIT;


SELECT count(*) FROM Курсы