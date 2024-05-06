<%--
  Created by IntelliJ IDEA.
  User: rurumi
  Date: 19.04.2024
  Time: 13:21
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
    <head>
        <title>Title</title>
    </head>
    <body id="main-body">
    <a class="nav-link" href="http://localhost:8080/demo2-1.0-SNAPSHOT"> Go to home page </a>
    <div class="main-info">
            <h1 class="msg">Hello, ${cookie.get("login").value}</h1>
            <p class="role">Your role is: ${cookie.get("role").value} </p>

            <div class="time">
                <p id="time-status"> ${cookie.get("date").value} </p>
                <button id="update-time"> update </button>
            </div>
        </div>

        <div class="request-info">
        </div>
    </body>

<style>
    <%@include file="main.css"%>
</style>

<script>
    <%@include file="main.js"%>
</script>

</html>
