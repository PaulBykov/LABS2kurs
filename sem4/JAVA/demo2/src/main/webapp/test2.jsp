<%--
  Created by IntelliJ IDEA.
  User: rurumi
  Date: 10.05.2024
  Time: 18:37
  To change this template use File | Settings | File Templates.
--%>
<%@ taglib prefix="sql" uri="http://java.sun.com/jsp/jstl/sql"  %>
<%@ taglib prefix="c"   uri="http://java.sun.com/jsp/jstl/core" %>

<sql:setDataSource
        var="dataSource"
        driver="com.mysql.cj.jdbc.Driver"
        url="jdbc:mysql://localhost:3306/java?autoReconnect=true&useSSL=false"
        user="admin"
        password="admin" />

<sql:query dataSource="${dataSource}" var="result">
    SELECT * FROM  users;
</sql:query>

<!DOCTYPE html>
<html>
<head>
    <title>SQL Example</title>
</head>
<body>
<h1>SQL Example</h1>

<table>
    <tr>
        <th>ID</th>
        <th>Name</th>
    </tr>
    <c:forEach var="row" items="${result.rows}">
        <tr>
            <td>${row.id}</td>
            <td>${row.login}</td>
        </tr>
    </c:forEach>
</table>
</body>
</html>