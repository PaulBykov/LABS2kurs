
SELECT CASE
		WHEN Количество_студентов between 0 and 20 then 'мало'
		WHEN Количество_студентов between 20 and 35 then 'средне'
		WHEN Количество_студентов > 35 then 'много'
		ELSE 'непонятно'
		END Статус_группы, count(*)[Количество_групп]
	FROM Группы
	GROUP BY CASE
		WHEN Количество_студентов between 0 and 20 then 'мало'
		WHEN Количество_студентов between 20 and 35 then 'средне'
		WHEN Количество_студентов > 35 then 'много'
		ELSE 'непонятно'
		end