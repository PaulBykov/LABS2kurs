SELECT Группы.* FROM Группы
		WHERE not exists (SELECT * FROM Курсы
							WHERE Курсы.Номер_группы = Группы.Номер_группы)