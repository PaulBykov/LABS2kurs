
SELECT CASE
		WHEN ����������_��������� between 0 and 20 then '����'
		WHEN ����������_��������� between 20 and 35 then '������'
		WHEN ����������_��������� > 35 then '�����'
		ELSE '���������'
		END ������_������, count(*)[����������_�����]
	FROM ������
	GROUP BY CASE
		WHEN ����������_��������� between 0 and 20 then '����'
		WHEN ����������_��������� between 20 and 35 then '������'
		WHEN ����������_��������� > 35 then '�����'
		ELSE '���������'
		end