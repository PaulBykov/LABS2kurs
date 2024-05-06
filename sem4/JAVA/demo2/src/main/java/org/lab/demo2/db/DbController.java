package org.lab.demo2.db;

import org.lab.demo2.auth.User;
import org.lab.demo2.items.Item;

import java.sql.*;
import java.util.ArrayList;
import java.util.Date;
import java.util.logging.Logger;


public class DbController implements IConnection{
    private Connection _connection;
    Logger logger = Logger.getLogger(getClass().getName());

    public DbController(){}

    public void Connect(){
        try{
            Class.forName("com.mysql.cj.jdbc.Driver");
            this._connection = DriverManager.getConnection(DB_URL, DB_Username, DB_Password);
        }
        catch(SQLException e){
            logger.warning("Connection error (SQL): " + e.getMessage());
        }
        catch (Exception e){
            logger.warning("Connection error: ");
            e.printStackTrace();
        }

    }
    public boolean Disconnect(){
        try{
            this._connection.close();
            _connection = null;
        }
        catch (Exception e){
            return false;
        }

        return true;
    }

    public User getUser(String login, int passHash){
        try{
            PreparedStatement _state = _connection.prepareStatement(
                        "SELECT * FROM  users " +
                            "    WHERE login = ?" +
                            "    AND passHash = ?");

            _state.setString(1, login);
            _state.setInt(2, passHash);

            ResultSet response = _state.executeQuery();
            response.next();
            return new User(login, response.getString(4));
        }
        catch (Exception e){
            System.out.println("Error during getting user" + e.getMessage());
        }

        return null;
    }

    public void addUser(String login, int passHash, String role){
        try{
            PreparedStatement _state = _connection.prepareStatement("INSERT INTO users values (NULL, ?, ?, ?)");

            _state.setString(1, login);
            _state.setInt(2, passHash);
            _state.setString(3, role);

            _state.executeUpdate();
        } catch (Exception e){
            System.out.println("Error during adding user: " + e.getMessage());
        }
    }

    public Boolean existUser(String login){
        try{
            PreparedStatement _state = _connection.prepareStatement(
                    "SELECT COUNT(*) FROM  users " +
                            "    WHERE login = ?");

            _state.setString(1, login);

            ResultSet response = _state.executeQuery();
            response.next();
            return response.getInt(1) > 0;
        }
        catch (Exception e){
            System.out.println("Error during getting user" + e.getMessage());
        }

        return false;
    }


    public ArrayList<Item> GetAllItems(){
        ArrayList<Item> result = new ArrayList<>();

        try{
            PreparedStatement _state = _connection.prepareStatement(
                    "SELECT * FROM  items");

            ResultSet response = _state.executeQuery();

            while(response.next()){
                Item temp = new Item(
                        response.getInt(1),
                        response.getString(2),
                        response.getDate(3)
                );

                result.add(temp);
            }

        } catch (Exception e){
            e.printStackTrace();
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
