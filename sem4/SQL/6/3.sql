SELECT *
FROM(SELECT CASE WHEN ������.����������_��������� between 1 and 25 then '��������� < 25'
	WHEN ������.����������_��������� between 25 and 45 then '�� 25 �� 45'
	ELSE '�������'
	END [���-�� ���������], COUNT(*)[���-�� �����]
FROM ������ GROUP BY CASE
	WHEN ������.����������_��������� between 1 and 25 then '��������� < 25'
	WHEN ������.����������_��������� between 25 and 45 then '�� 25 �� 45'
	ELSE '�������'	
END) as T
	ORDER BY CASE [���-�� ���������]
		WHEN '��������� < 25' THEN 3
		WHEN '�� 25 �� 45' THEN 2
		WHEN '�������' THEN 1
		ELSE 0
		END