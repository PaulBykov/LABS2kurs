package org.lab.demo2.commands;

import org.lab.demo2.model.User;
import org.lab.demo2.services.AuthService;

import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

public class LoginCommand implements Command {
    private AuthService authService;

    public LoginCommand(AuthService authService) {
        this.authService = authService;
    }

    @Override
    public void execute(HttpServletRequest request, HttpServletResponse response) throws IOException {
        String login = request.getParameter("login");
        String pass = request.getParameter("pass");

        if (login == null || pass == null) {
            response.sendError(HttpServletResponse.SC_BAD_REQUEST, "Login and password must be provided");
            return;
        }

        User user = authService.tryAuth(login, pass);

        if (user == null) {
            response.sendError(HttpServletResponse.SC_UNAUTHORIZED, "Invalid login or password");
            return;
        }

        response.setContentType("text/plain");
        response.setCharacterEncoding("UTF-8");
        response.addCookie(new Cookie("role", user.GetRole()));
        response.addCookie(new Cookie("login", login));
        response.getWriter().write("Login successful");
    }
}