package org.lab.demo2.items;

import org.lab.demo2.db.DbController;
import sun.rmi.runtime.Log;

import javax.json.Json;
import javax.json.JsonObject;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;



@WebServlet(name="Items", value="/Items")
public class Items extends HttpServlet {
    private DbController _db;

    @Override
    public void init(){
        _db = new DbController();
    }

    @Override
    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException{
        _db.Connect();
        ArrayList<Item> items = _db.GetAllItems();

        try {
            PrintWriter out = response.getWriter();

            out.println("<table>");

            out.println("<tr>");
            out.println("<td> id </td> <td> Название </td> <td> Дата находки </td>");
            out.println("</tr>");


            for(int i = 0; i < items.size(); i++){
                Item item = items.get(i);
                out.println("<tr>");

                out.println("<td>" + item.GetId() + "</td>");
                out.println("<td>" + item.GetName() + "</td>");
                out.println("<td>" + item.GetDate() + "</td>");

                out.println("</tr>");
            }


            out.println("</table>");
            out.close();
        } catch (Exception e){
            response.sendError(506, "Exception during GET request: " + e.getMessage());
        }

    }

    @Override
    public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException{
        JsonObject data = Json.createReader(request.getInputStream()).readObject();
        String requestType = data.getString("type");

        if(requestType == null){
            response.sendError(504, "Got unknown requestType");
        }

        switch (requestType){
            case "add":
                String itemName = data.getString("itemName");
                _db.addNewItem(itemName);
                break;
            case "delete":
                int id = Integer.parseInt(data.getString("itemId"));
                _db.deleteItem(id);
                break;
            default:
                response.sendError(504, "Got unknown requestType");
                System.err.println("Unknown request type!");
                break;
        }


    }



    @Override
    public void destroy(){
        _db = null;
    }
}
