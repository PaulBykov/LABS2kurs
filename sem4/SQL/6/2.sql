SELECT �������������.�������,
	   max(����������_���������)[���� ���-��],
	   min(����������_���������)[��� ���-��],
	   avg(����������_���������)[�� ���-��],
	   sum(����������_���������)[����� ���������],
	   count(*)[���������� �����]
FROM ������������� INNER JOIN �����
		on ���_������������� = �������������.���
		INNER JOIN ������
			on �����.�����_������ = ������.�����_������
		group by �������������.�������