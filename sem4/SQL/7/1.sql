SELECT �����_������, �������, count(*) [���������� �������]
	FROM �����
	WHERE �����_������ IN (4, 5)
	GROUP BY ROLLUP (�����_������, �������);