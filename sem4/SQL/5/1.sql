SELECT * FROM ����� 
		 WHERE �����.���_������� = '��' 
				AND �����_������ IN (SELECT �����_������ FROM ������
									 WHERE(������������� like '����%'))