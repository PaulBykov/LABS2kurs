-- �������� ������������ �������
DECLARE @CourseID INT
DECLARE StaticCursor CURSOR STATIC FOR
SELECT �������������
FROM �����

-- �������� �������
OPEN StaticCursor

-- ���������� ������� ��������
FETCH NEXT FROM StaticCursor INTO @CourseID
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT '���� ID: ' + CAST(@CourseID AS VARCHAR(10))
    -- ���������� ���������� ��������
    FETCH NEXT FROM StaticCursor INTO @CourseID
END

-- �������� � �������� �������
CLOSE StaticCursor
DEALLOCATE StaticCursor

-- ���������� ������ � ������� �������������
UPDATE �������������
SET ������� = '1234567890'
WHERE ��� = 1