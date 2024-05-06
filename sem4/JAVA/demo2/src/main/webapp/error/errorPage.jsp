<%--
  Created by IntelliJ IDEA.
  User: rurumi
  Date: 25.04.2024
  Time: 18:59
  To change this template use File | Settings | File Templates.
--%>
<%@ page isErrorPage="true" %>
<%@ page language="java" contentType="text/html;"
         pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
    <title>Exception/Error Page</title>
</head>
<jsp:include page="./../header/header.jsp"/>
<body>
<p>Error has occurred</p>
<p>Вы должны быть авторизованны для доступа к этому ресурсу</p>
<jsp:include page="./../footer/footer.jsp"/>
</body>
</html>
