package org.lab.demo2.controllers;

import org.lab.demo2.commands.*;
import org.lab.demo2.services.AuthService;
import org.lab.demo2.services.ItemsService;

import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.logging.Logger;


@WebServlet(name="MainControllerServlet", value="/controller")
public class MainController extends HttpServlet {
    private AuthService authService;
    private ItemsService itemsService;
    private Logger logger = Logger.getLogger(getClass().getName());


    public MainController() {
        authService = new AuthService();
        itemsService = new ItemsService();
    }


    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException {
        request.setCharacterEncoding("UTF-8");
        String command = request.getParameter("command");

        if (command == null) {
            response.sendError(HttpServletResponse.SC_BAD_REQUEST, "No command provided");
            return;
        }

        switch (command) {
            case "login":
                new LoginCommand(authService).execute(request, response);
                break;
            case "register":
                new RegisterCommand(authService).execute(request, response);
                break;
            case "addItem":
                new AddItemCommand(itemsService).execute(request, response);
                break;
            case "deleteItem":
                new DeleteItemCommand(itemsService).execute(request, response);
                break;
            default:
                response.sendError(HttpServletResponse.SC_BAD_REQUEST, "Unknown command: " + command);
                break;
        }
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        request.setCharacterEncoding("UTF-8");
        String command = request.getParameter("command");

        if (command == null) {
            response.sendError(HttpServletResponse.SC_BAD_REQUEST, "No command provided");
            return;
        }

        switch (command) {
            case "getAllItems":
                new GetAllItemsCommand(itemsService).execute(request, response);
                break;
            default:
                response.sendError(HttpServletResponse.SC_BAD_REQUEST, "Unknown command: " + command);
                break;
        }
    }
}