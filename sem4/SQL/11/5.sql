declare cur cursor local dynamic for 
	select �������������, ���_�������, �����_������ from ����� p FOR UPDATE
declare @id varchar(10), @sub varchar(15), @nt int


open cur
fetch cur into @id, @sub, @nt
print @id + ' sub � ' + rtrim(cast(@sub as varchar)) + ' (nt ' + cast(@nt as varchar) + ')'
delete ����� where CURRENT OF cur

fetch cur into @id, @sub, @nt
update ����� set ���_������� = '������' where CURRENT OF cur
print ''
print @id + ' sub �  ' + rtrim(cast(@sub as varchar)) + ' (nt ' + cast(@nt as varchar) + ')'

close cur

SELECT * From �����