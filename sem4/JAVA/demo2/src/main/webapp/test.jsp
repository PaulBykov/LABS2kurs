<%--
  Created by IntelliJ IDEA.
  User: rurumi
  Date: 10.05.2024
  Time: 17:45
  To change this template use File | Settings | File Templates.
--%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>JSTL Core Example</title>
</head>
<body>
<h1>JSTL Core Example</h1>

<c:set var="name" value="John Doe" />

<c:if test="${not empty name}">
    <p>Welcome, <c:out value="${name}" />!</p>
</c:if>

<c:choose>
    <c:when test="${name == 'John Doe'}">
        <p>This is John Doe.</p>
    </c:when>
    <c:otherwise>
        <p>This is not John Doe.</p>
    </c:otherwise>
</c:choose>

<c:forEach var="i" begin="1" end="5">
    <p>Loop iteration: <c:out value="${i}" /></p>
</c:forEach>

<c:catch var="exception">
    <%-- Some code that may throw an exception --%>
</c:catch>

<c:if test="${exception != null}">
    <p>An exception occurred: <c:out value="${exception.message}" /></p>
</c:if>
</body>
</html>
