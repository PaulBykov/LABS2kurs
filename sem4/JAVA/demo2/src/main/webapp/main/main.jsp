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
        <title>Main page</title>
    </head>

    <jsp:include page="./../header/header.jsp"/>

    <body id="main-body">
        <main>
            <a class="nav-link" href="http://localhost:8080/demo2-1.0-SNAPSHOT"> Go to home page </a>
            <div class="main-info">
                <h1 class="msg">Hello, ${cookie.get("login").value}</h1>
                <p class="role">Your role is: ${cookie.get("role").value} </p>

                <div class="items-container">

                </div>
            </div>

            <div class="actions-container">
                <form id="addItemForm">
                    <h1> Добавить предмет </h1>
                    <label for="itemName"> Название </label>
                    <input id="itemName" type="text" placeholder="шапка"/>
                    <button type="submit"> Отправить </button>
                </form>

                <form id="deleteItemForm">
                    <h1> Удалить предмет </h1>
                    <label for="itemID"> ID </label>
                    <input id="itemID" type="text" placeholder="2"/>
                    <button type="submit"> Отправить </button>
                </form>
            </div>
        </main>
    </body>

    <jsp:include page="./../footer/footer.jsp"/>

<style>
    <%@include file="main.css"%>
</style>

<script>
    <%@include file="main.js"%>
</script>

</html>
