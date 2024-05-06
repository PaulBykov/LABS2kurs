use Быков_4
CREATE TABLE Группы(
	Номер_группы int primary key,
	Специальность nvarchar(20),
	Количество_студентов int,
);

CREATE TABLE Преподаватели(
	Код int primary key,
	Фамилия nvarchar(20) not null,
	Имя nvarchar(20),
	Телефон nvarchar(20) unique,
);

CREATE TABLE Курсы(
	Идентификатор int primary key,
	Номер_группы int foreign key references Группы(Номер_группы),
	Код_преподавателя int foreign key references Преподаватели(Код),
	Предмет nvarchar(20),
	Тип_занятия nvarchar(20),
);