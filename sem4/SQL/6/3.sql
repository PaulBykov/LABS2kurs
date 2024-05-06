SELECT *
FROM(SELECT CASE WHEN Группы.Количество_студентов between 1 and 25 then 'Студентов < 25'
	WHEN Группы.Количество_студентов between 25 and 45 then 'От 25 до 45'
	ELSE 'Перебор'
	END [Кол-во студентов], COUNT(*)[Кол-во групп]
FROM Группы GROUP BY CASE
	WHEN Группы.Количество_студентов between 1 and 25 then 'Студентов < 25'
	WHEN Группы.Количество_студентов between 25 and 45 then 'От 25 до 45'
	ELSE 'Перебор'	
END) as T
	ORDER BY CASE [Кол-во студентов]
		WHEN 'Студентов < 25' THEN 3
		WHEN 'От 25 до 45' THEN 2
		WHEN 'Перебор' THEN 1
		ELSE 0
		END