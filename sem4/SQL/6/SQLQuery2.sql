SELECT �����.�������, round(avg(cast(������.����������_��������� as float(4))), 2) as ��_�����_���������
	FROM �����
	JOIN ������ ON �����.�����_������ = ������.�����_������
		GROUP BY �����.�������, �����.���_�������
			HAVING �����.���_������� = '��'
		ORDER BY �����.�������