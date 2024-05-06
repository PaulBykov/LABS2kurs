package org.lab.demo2.data;

import java.sql.*;


public class DbController implements IConnection{
    private Connection _connection;

    public DbController(){}

    public void Connect(){

        try{
            Class.forName("com.mysql.cj.jdbc.Driver");
            this._connection = DriverManager.getConnection(DB_URL, DB_Username, DB_Password);
        }
        catch(SQLException e){
            System.out.println("Connection error (SQL): " + e.getMessage());
        }
        catch (Exception e){
            System.out.println("Connection error: ");
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


    public static void main(String[] args) {
        DbController db = new DbController();
        db.Connect();
    }
}
