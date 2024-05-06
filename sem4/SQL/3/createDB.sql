USE master
go
CREATE database Быков_3
on primary
	(name=N'Bykov3_mdf', filename=N'D:\LABS2\sem4\SQL\3\Bykov3_mdf.mdf',
	size=2048Kb, maxsize=UNLIMITED, filegrowth=25%),
	(name=N'Bykov3_ndf', filename=N'D:\LABS2\sem4\SQL\3\Bykov3_ndf.ndf',
	size=1024Kb, maxsize=1Gb, filegrowth=128KB),
	filegroup FG1
	(name=N'Bykov3_fg1_1', filename=N'D:\LABS2\sem4\SQL\3\Bykov3_fg1.mdf',
	size=1024Kb, maxsize=UNLIMITED, filegrowth=25%),
	(name=N'Bykov3_fg1_2', filename=N'D:\LABS2\sem4\SQL\3\Bykov3_fg1.ndf',
	size=4096Kb, maxsize=UNLIMITED, filegrowth=80%),
	filegroup FG2
	(name=N'Bykov3_fg2_1', filename=N'D:\LABS2\sem4\SQL\3\Bykov3_fg2.mdf',
	size=4096Kb, maxsize=UNLIMITED, filegrowth=90%),
	(name=N'Bykov3_fg2_2', filename=N'D:\LABS2\sem4\SQL\3\Bykov3_fg2.ndf',
	size=4096Kb, maxsize=UNLIMITED, filegrowth=100%)
	log on
	(name=N'BYKOV3_LOG', filename=N'D:\LABS2\sem4\SQL\3\Bykov3_log.ldf',
	size=1024Kb, maxsize=2048Gb, filegrowth=10%)
go