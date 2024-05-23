-- �������� ������� � ��������� SCROLL
DECLARE @CourseID INT
DECLARE ScrollCursor CURSOR SCROLL FOR
SELECT �������������
FROM �����

-- �������� �������
OPEN ScrollCursor

-- ���������� ������� �������� (FIRST)
FETCH FIRST FROM ScrollCursor INTO @CourseID
PRINT '������ ���� ID: ' + CAST(@CourseID AS VARCHAR(10))

-- ���������� ���������� �������� (NEXT)
FETCH NEXT FROM ScrollCursor INTO @CourseID
PRINT '��������� ���� ID: ' + CAST(@CourseID AS VARCHAR(10))

-- ���������� ����������� �������� (PRIOR)
FETCH PRIOR FROM ScrollCursor INTO @CourseID
PRINT '���������� ���� ID: ' + CAST(@CourseID AS VARCHAR(10))

-- ���������� ���������� �������� (LAST)
FETCH LAST FROM ScrollCursor INTO @CourseID
PRINT '��������� ���� ID: ' + CAST(@CourseID AS VARCHAR(10))

-- ���������� �������� �� ���������� ������� (ABSOLUTE 2)
FETCH ABSOLUTE 2 FROM ScrollCursor INTO @CourseID
PRINT '���� ID �� ������� 2: ' + CAST(@CourseID AS VARCHAR(10))

-- ���������� �������� �� ������������� ������� (RELATIVE -1)
FETCH RELATIVE -1 FROM ScrollCursor INTO @CourseID
PRINT '���� ID �� ���� ������� ����� �� �������: ' + CAST(@CourseID AS VARCHAR(10))

-- �������� � �������� �������
CLOSE ScrollCursor
DEALLOCATE ScrollCursor