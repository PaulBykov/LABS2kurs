-- �������� ��������� ������� ��� ������������
CREATE TABLE #�����
(
    �����_������ INT,
    ������� NVARCHAR(100)
)

-- ������� ������ �� ��������� �������
INSERT INTO #����� (�����_������, �������)
VALUES
    (1, '���������� 1'),
    (1, '���������� 2'),
    (2, '���������� 3'),
    (2, '���������� 4'),
    (3, '���������� 5')

-- ���������� ������
DECLARE @GlobalSubject NVARCHAR(100)
DECLARE GlobalSubjectCursor CURSOR GLOBAL FOR
	SELECT �������
	FROM #�����
OPEN GlobalSubjectCursor
FETCH NEXT FROM GlobalSubjectCursor INTO @GlobalSubject
PRINT '���������� ������:'
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT @GlobalSubject
    FETCH NEXT FROM GlobalSubjectCursor INTO @GlobalSubject
END
CLOSE GlobalSubjectCursor
DEALLOCATE GlobalSubjectCursor

-- ��������� ������
DECLARE @LocalSubject NVARCHAR(100)
DECLARE LocalSubjectCursor CURSOR LOCAL FOR
	SELECT �������
	FROM #�����
OPEN LocalSubjectCursor
FETCH NEXT FROM LocalSubjectCursor INTO @LocalSubject
PRINT '��������� ������:'
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT @LocalSubject
    FETCH NEXT FROM LocalSubjectCursor INTO @LocalSubject
END
CLOSE LocalSubjectCursor
DEALLOCATE LocalSubjectCursor

-- �������� ��������� �������
DROP TABLE #�����