--1--
DECLARE @z float,
		@x float = 3.9,
		@t float = 2.3;

IF(@t > @x) SET @z = sin(@t) * sin(@t);
ELSE IF(@t < @x) SET @z = 4 * (@t + @x);
ELSE SET @z = 1 - exp(@x-2);

PRINT('z = ' + cast(@z as varchar(10)));


--2--
DECLARE @FullName NVARCHAR(100) = 'Быков Павел Алексеевич';

DECLARE @LastName NVARCHAR(50) = PARSENAME(REPLACE(@FullName, ' ', '.'), 3),
		@FirstName NVARCHAR(50) = PARSENAME(REPLACE(@FullName, ' ', '.'), 2),
		@MiddleName NVARCHAR(50) = PARSENAME(REPLACE(@FullName, ' ', '.'), 1);

DECLARE @ShortName NVARCHAR(50);
SET @ShortName = @LastName + ' ' + LEFT(@FirstName, 1) + '. ' + LEFT(@MiddleName, 1) + '.';

PRINT 'Сокращенное имя: ' + @ShortName;


--3--
DECLARE @BirthDate DATE = '2000-04-15',
		@CurrentDate DATE = GETDATE(),
		@Age INT

DECLARE @BirthMonth INT = MONTH(@BirthDate);
DECLARE @CurrentMonth INT = MONTH(@CurrentDate);


IF @BirthMonth = @CurrentMonth
BEGIN
    SET @Age = DATEDIFF(YEAR, @BirthDate, @CurrentDate);
END
ELSE
BEGIN
    SET @Age = NULL;
END

PRINT 'Дата рождения: ' + CONVERT(VARCHAR(10), @BirthDate, 120);
PRINT 'Текущая дата: ' + CONVERT(VARCHAR(10), @CurrentDate, 120);
PRINT 'Возраст: ' + CAST(@Age AS VARCHAR(10));


--4--
DECLARE @Date DATE = '2024-04-08';
DECLARE	@DayOfWeek nvarchar(50) = DATENAME(WEEKDAY, @Date),
		@DayName NVARCHAR(50);

PRINT 'День недели: ' + @DayOfWeek;

