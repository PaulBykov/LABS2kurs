CREATE VIEW [���������� ���2] WITH SCHEMABINDING 
	AS SELECT g.�����_������[������],
			  count(*)[����� ���]
	FROM dbo.����� k JOIN dbo.������ g
		ON k.�����_������ = g.�����_������
	GROUP BY g.�����_������