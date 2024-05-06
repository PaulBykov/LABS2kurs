DECLARE @i int = 1,
		@c char = 'a',
		@vc varchar,
		@curr datetime,
		@tm time,
		@a int,
		@b tinyint,
		@d numeric(12,5)
SET @a = 18; 
SET @b = 30;
		
SELECT @i i, @c c, @vc vc, @curr curr, @tm tm, @a a, @b b, @d d;
PRINT @a;
PRINT @b;
