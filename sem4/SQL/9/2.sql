DECLARE @avg float(4) = (select avg(����������_���������) from ������)
DECLARE @sum float(4) = (select sum(����������_���������) from ������)

DECLARE @r1 int,
		@r2 int,
		@r3 float;

IF @sum > 100
begin
	SELECT @r1 = (SELECT CAST(COUNT(*) as numeric(8, 3)) FROM ������),
		   @r2 = (SELECT CAST(COUNT(*) as numeric(8, 3)) FROM ������ WHERE ����������_��������� < @avg);
	
	SET @r3 = (@r2 / CAST(@r1 as float)) * 100;

	PRINT '����� ���-�� �����: ' + cast(@r1 as varchar(10));
	PRINT '���-�� ����� �������� ������ avg: ' + cast(@r2 as varchar(10));
	PRINT '������� ����� �������� ������ avg: ' + cast(@r3 as varchar(10)) + '%';
end
else print('<=100');
