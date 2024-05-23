CREATE PROCEDURE DisziplinsAddX
    @a int,
    @b int,
    @c int,
	@d nvarchar(50),
	@e nvarchar(50),
	@n int --id 2--
AS
BEGIN
	BEGIN TRY
		set tran isolation level serializable
		begin tran
			INSERT INTO �����
				VALUES (@a, @b, @c, @d, @e)

			EXEC DisziplinsAdd @a = @n, @b=@b, @c = @c, @d=@d, @e=@e;
		commit tran


	END TRY
	begin catch
		rollback
		print '��������� �� ������: ' + cast(error_message() as varchar(8));
		print '������� �����������: ' + cast(error_severity() as varchar(6));
		print '���������: ' + cast(error_state() as varchar(8));
		print '����� ������: ' + cast(error_line() as varchar(8));
		if error_procedure() is not null
			print '��� ���������: ' + error_procedure();
		return -1;
	end catch;
END

EXEC DisziplinsAddX @a = 67, @b=1, @c = 1, @d='��', @e='��', @n=29;