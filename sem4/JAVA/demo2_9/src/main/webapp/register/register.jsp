<%--
  Created by IntelliJ IDEA.
  User: rurumi
  Date: 19.04.2024
  Time: 17:37
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
    <head>
        <title>Register</title>
    </head>

    <body>
        <a class="nav-link" href="http://localhost:8080/demo2-1.0-SNAPSHOT"> Go to home page </a>

        <h1 class="head-msg"> Register </h1>

        <div id="login-status"></div>

        <form id="login-form">
            <div class="login-container">
                <label for="login-input">
                    login
                </label>
                <input type="text" id="login-input" maxlength="15" required/>
            </div>

            <div class="pass-container">
                <label for="pass-input">
                    password
                </label>
                <input type="password" id="pass-input" maxlength="15" required/>
            </div>

            <div class="btn-container">
                <button type="submit" autofocus>
                    enter
                </button>
            </div>
        </form>
    </body>

    <script type="text/javascript">
        <%@include file="register.js"%>
    </script>

    <style>
        <%@include file="../login/login.css"%>
    </style>
</html>
