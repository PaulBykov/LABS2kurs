package org.lab.demo2.commands;

import org.lab.demo2.services.ItemsService;

import javax.json.Json;
import javax.json.JsonObject;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

public class DeleteItemCommand implements Command {
    private ItemsService itemsService;

    public DeleteItemCommand(ItemsService itemsService) {
        this.itemsService = itemsService;
    }

    @Override
    public void execute(HttpServletRequest request, HttpServletResponse response) throws IOException {
        JsonObject data = Json.createReader(request.getInputStream()).readObject();
        int id = data.getInt("id");

        if (id <= 0) {
            response.sendError(HttpServletResponse.SC_BAD_REQUEST, "Item ID must be provided");
            return;
        }

        itemsService.deleteItem(id);

        response.setContentType("text/plain");
        response.setCharacterEncoding("UTF-8");
        response.getWriter().write("Item deleted successfully");
    }
}