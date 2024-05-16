<%--
  Created by IntelliJ IDEA.
  User: rurumi
  Date: 16.05.2024
  Time: 21:27
  To change this template use File | Settings | File Templates.
--%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/functions" prefix="fn" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>JSP Example with JSTL Functions</title>
</head>
<body>
    <%-- Пример строки для обработки --%>
    <c:set var="originalString" value="Hello, JSTL Functions!" />

    <h2>Original String:</h2>
    <p>${originalString}</p>

    <%-- Использование JSTL функции для проверки содержания подстроки --%>
    <h2>Checking if the original string contains "JSTL":</h2>
    <p>${fn:contains(originalString, 'JSTL')}</p>

    <%-- Использование JSTL функции для извлечения подстроки --%>
    <h2>Substring (from index 7 to 11):</h2>
    <p>${fn:substring(originalString, 7, 11)}</p>

    <%-- Использование JSTL функции для преобразования строки в верхний регистр --%>
    <h2>String in Uppercase:</h2>
    <p>${fn:toUpperCase(originalString)}</p>
</body>
</html>
