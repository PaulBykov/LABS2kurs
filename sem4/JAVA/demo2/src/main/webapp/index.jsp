<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
    <head>
        <title>JSP - Hello World</title>
    </head>

    <jsp:include page="./header/header.jsp"/>

    <body>

        <main>
            <h1><%= "Home page" %></h1>
            <br/>
            <nav class="nav">
                <a href="main/main.jsp">        Main</a>
                <a href="login/login.jsp">      Login</a>
                <a href="register/register.jsp">Register</a>
            </nav>
        </main>

    </body>

    <jsp:include page="./footer/footer.jsp"/>
<style>

    .nav{
        display: flex;
        flex-direction: column;
        gap: 20px;

        & > a{
            color: darkblue;
            text-decoration: none;

            font-size: 32px;
            font-weight: lighter;
            width: auto;
        }
    }

</style>

</html>