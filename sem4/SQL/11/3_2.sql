-- �������� ������������� �������
DECLARE @CourseID INT
DECLARE DynamicCursor CURSOR DYNAMIC FOR
SELECT �������������
FROM �����

-- �������� �������
OPEN DynamicCursor

-- ���������� ������� ��������
FETCH NEXT FROM DynamicCursor INTO @CourseID
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT '���� ID: ' + CAST(@CourseID AS VARCHAR(10))
    -- ���������� ������ � ������� �������������
    UPDATE �������������
    SET ������� = '0987654321'
    WHERE ��� = 1
    -- ���������� ���������� ��������
    FETCH NEXT FROM DynamicCursor INTO @CourseID
END

-- �������� � �������� �������
CLOSE DynamicCursor
DEALLOCATE DynamicCursor