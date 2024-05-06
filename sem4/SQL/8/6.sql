CREATE VIEW [Количество пар2] WITH SCHEMABINDING 
	AS SELECT g.Номер_группы[Группа],
			  count(*)[Колво пар]
	FROM dbo.Курсы k JOIN dbo.Группы g
		ON k.Номер_группы = g.Номер_группы
	GROUP BY g.Номер_группы