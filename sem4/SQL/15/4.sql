create trigger TR_TEACHER_ALL  on Преподаватели after INSERT, DELETE, UPDATE  
as 
	declare @a1 nvarchar(20), @a2 nvarchar(20), @a3 nvarchar(20), @in varchar(300);

	declare @ins int = (select count(*) from inserted),
			@del int = (select count(*) from deleted);
	
	if  @ins > 0 and  @del = 0  
		begin 
			 set @a1 = (select [Фамилия] from INSERTED);  
			 set @a2 = (select [Имя] from INSERTED);
			 set @a3 = (select [Телефон] from INSERTED);
			 set @in = @a1+' '+cast(@a2 as varchar(20))+' '+cast(@a3 as varchar(20));
			 insert into AUTDIT(STMT, TRNAME, CC)  values('INS', 'TR_TEACHER_ALL', @in);
		end; 
	else		  	 
	if @ins = 0 and  @del > 0  
		begin 
			set @a1 = (select [Фамилия] from deleted);
			set @a2 = (select [Имя] from deleted);
			set @a3 = (select [Телефон] from deleted);
			set @in = @a1+' '+cast(@a2 as varchar(20))+' '+cast(@a3 as varchar(20));
			insert into AUTDIT(STMT, TRNAME, CC)  values('DEL', 'TR_TEACHER_ALL', @in);
		end; 
	else	  
	if @ins > 0 and  @del > 0  
		begin 
			set @a1 = (select [Фамилия] from inserted);
			set @a2 = (select [Имя] from inserted);
			set @a3 = (select [Телефон] from inserted);
			set @in = @a1+' '+cast(@a2 as varchar(20))+' '+cast(@a3 as varchar(20));
			set @a1 = (select [Фамилия] from deleted);
			set @a2 = (select [Имя] from deleted);
			set @a3 = (select [Телефон] from deleted);
			set @in = @a1+' '+cast(@a2 as varchar(20))+' '+cast(@a3 as varchar(20))+' '+@in;
			insert into AUTDIT(STMT, TRNAME, CC)  values('UPD', 'TR_TEACHER_ALL', @in); 
		end;  



