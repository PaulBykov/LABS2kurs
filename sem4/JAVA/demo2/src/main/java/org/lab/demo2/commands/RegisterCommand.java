package org.lab.demo2.commands;

import org.lab.demo2.services.AuthService;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

public class RegisterCommand implements Command {
    private AuthService authService;

    public RegisterCommand(AuthService authService) {
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

        if (authService.existUser(login)) {
            response.sendError(HttpServletResponse.SC_CONFLICT, "User with this login already exists");
            return;
        }

        authService.registerUser(login, pass, "user");

        response.setContentType("text/plain");
        response.setCharacterEncoding("UTF-8");
        response.getWriter().write("Registration successful");
    }
}