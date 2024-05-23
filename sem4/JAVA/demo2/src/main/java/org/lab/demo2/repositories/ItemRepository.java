package org.lab.demo2.repositories;

import org.lab.demo2.model.Item;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.Date;
import java.util.logging.Logger;

public class ItemRepository {
    private DbController dbController;
    private Connection _connection;
    Logger logger = Logger.getLogger(getClass().getName());


    public ItemRepository(DbController dbController) {
        this.dbController = dbController;
        this._connection = dbController.connect();
    }

    public ArrayList<Item> getAllItems() {
        ArrayList<Item> result = new ArrayList<>();
        Connection connection = dbController.connect();

        try {
            PreparedStatement statement = connection.prepareStatement("SELECT * FROM items");
            ResultSet response = statement.executeQuery();

            while (response.next()) {
                Item temp = new Item(
                        response.getInt(1),
                        response.getString(2),
                        response.getDate(3)
                );
                result.add(temp);
            }
        }
        catch (Exception e) {
            logger.warning(e.getMessage());
        }

        return result;
    }

    public void addNewItem(String itemName){
        Date date = new Date();

        try{
            PreparedStatement statement = _connection.prepareStatement(
                    "INSERT INTO items VALUES (NULL, ?, ?)");

            statement.setString(1, itemName);
            statement.setDate(2, new java.sql.Date(date.getTime()));

            statement.executeUpdate();
        }
        catch (Exception e){
            logger.warning(e.getMessage());
            e.printStackTrace();
        }
    }

    public void deleteItem(int itemId){
        try{
            PreparedStatement statement = _connection.prepareStatement(
                    "DELETE FROM items WHERE items.id = ?");

            statement.setInt(1, itemId);
            statement.executeUpdate();
        }
        catch (Exception e){
            System.err.println("Deleting error: " + e.getMessage() + "\n itemId" + itemId);
            e.printStackTrace();
        }
    }
}

