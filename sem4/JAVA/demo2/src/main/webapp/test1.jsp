<%--
  Created by IntelliJ IDEA.
  User: rurumi
  Date: 10.05.2024
  Time: 18:19
  To change this template use File | Settings | File Templates.
--%>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>JSTL Formatting Example</title>
</head>
<body>
<h1>JSTL Formatting Example</h1>

<p>Current Date: <fmt:formatDate value="${now}" pattern="yyyy-MM-dd" /></p>

<p>Current Time: <fmt:formatDate value="${now}" pattern="HH:mm:ss" /></p>

<p>Number: <fmt:formatNumber value="${price}" pattern="#,##0.00" /></p>

<p>Currency: <fmt:formatNumber value="${price}" type="currency" currencyCode="USD" /></p>

<p>Percentage: <fmt:formatNumber value="${discount}" type="percent" /></p>

<p>Localized Message: <fmt:message key="welcome.message" /></p>

<p>Localized Message with Arguments:
    <fmt:message key="greeting.message">
        <fmt:param value="${name}" />
    </fmt:message></p>
</body>
</html>