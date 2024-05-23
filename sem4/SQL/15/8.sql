

CREATE TRIGGER TR_KURSE_DEL
	on Курсы instead of DELETE
			as raiserror(N'Я запрещаю вам удалять пары', 10, 1);

DELETE Курсы WHERE Курсы.Тип_занятия = 'БД'


