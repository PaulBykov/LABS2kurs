

CREATE TRIGGER TRIGGER_TRAN
			on ������������� after INSERT
			as
begin
	print ('!!!   TRIGGER_TRAN ���������')
	rollback;
end


begin tran
	INSERT ������������� values(999, '����', '������ ����������', '11111111111')

	if @@TRANCOUNT > 0
		print('ROLLBACK �� ���������');
	else
		print('����')
