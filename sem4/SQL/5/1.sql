SELECT * FROM Курсы 
		 WHERE Курсы.Тип_занятия = 'ЛБ' 
				AND Номер_группы IN (SELECT Номер_группы FROM Группы
									 WHERE(Специальность like 'ПОИТ%'))