

CREATE TRIGGER TRIGGER_TRAN
			on Преподаватели after INSERT
			as
begin
	print ('!!!   TRIGGER_TRAN отработал')
	rollback;
end


begin tran
	INSERT Преподаватели values(999, 'Тест', 'Отмена транзакции', '11111111111')

	if @@TRANCOUNT > 0
		print('ROLLBACK не состоялся');
	else
		print('окей')
