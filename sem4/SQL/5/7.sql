SELECT Группы.* from Группы
	WHERE Количество_студентов > all(select Количество_студентов from Группы
									WHERE Специальность like 'ИСИТ')