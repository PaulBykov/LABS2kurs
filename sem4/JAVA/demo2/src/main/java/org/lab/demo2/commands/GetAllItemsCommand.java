package org.lab.demo2.commands;

import org.lab.demo2.model.Item;
import org.lab.demo2.services.ItemsService;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;

public class GetAllItemsCommand implements Command {
    private ItemsService itemsService;

    public GetAllItemsCommand(ItemsService itemsService) {
        this.itemsService = itemsService;
    }

    @Override
    public void execute(HttpServletRequest request, HttpServletResponse response) throws IOException {
        ArrayList<Item> items = itemsService.getAllItems();

        response.setContentType("text/html");
        response.setCharacterEncoding("UTF-8");

        try {
            PrintWriter out = response.getWriter();

            out.println("<table border='1'>");

            out.println("<tr>");
            out.println("<th>Id</th><th>Название</th><th>Дата находки</th>");
            out.println("</tr>");

            for (Item item : items) {
                out.println("<tr>");
                out.println("<td>" + item.getId() + "</td>");
                out.println("<td>" + item.getName() + "</td>");
                out.println("<td>" + item.getDate() + "</td>");
                out.println("</tr>");
            }

            out.println("</table>");
            out.close();
        } catch (Exception e) {
            response.sendError(HttpServletResponse.SC_INTERNAL_SERVER_ERROR, "Exception during GET request: " + e.getMessage());
        }
    }
}