use �����_4
CREATE TABLE ������(
	�����_������ int primary key,
	������������� nvarchar(20),
	����������_��������� int,
);

CREATE TABLE �������������(
	��� int primary key,
	������� nvarchar(20) not null,
	��� nvarchar(20),
	������� nvarchar(20) unique,
);

CREATE TABLE �����(
	������������� int primary key,
	�����_������ int foreign key references ������(�����_������),
	���_������������� int foreign key references �������������(���),
	������� nvarchar(20),
	���_������� nvarchar(20),
);