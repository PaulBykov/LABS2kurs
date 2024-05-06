SELECT Группы.* from Группы
	WHERE Количество_студентов >= any(select Количество_студентов from Группы
									WHERE Специальность like 'ПОИТ')