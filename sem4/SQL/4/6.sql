SELECT *
FROM Курсы
CROSS JOIN Группы
WHERE Курсы.Номер_группы = Группы.Номер_группы;
