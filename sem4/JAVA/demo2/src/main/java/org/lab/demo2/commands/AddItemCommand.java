package org.lab.demo2.commands;

import org.lab.demo2.services.ItemsService;

import javax.json.Json;
import javax.json.JsonObject;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

public class AddItemCommand implements Command {
    private ItemsService itemsService;

    public AddItemCommand(ItemsService itemsService) {
        this.itemsService = itemsService;
    }

    @Override
    public void execute(HttpServletRequest request, HttpServletResponse response) throws IOException {
        JsonObject data = Json.createReader(request.getInputStream()).readObject();
        String itemName = data.getString("itemName");

        if (itemName == null || itemName.isEmpty()) {
            response.sendError(HttpServletResponse.SC_BAD_REQUEST, "Item name must be provided");
            return;
        }

        itemsService.addItem(itemName);
        response.setContentType("text/plain");
        response.setCharacterEncoding("UTF-8");
        response.getWriter().write("Item added successfully");
    }
}