package org.lab.demo2.db;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public interface IConnection {
    public final static String DB_URL = "jdbc:mysql://localhost:3306/java?autoReconnect=true&useSSL=false";
    public final static String DB_Username = "admin";
    public final static String DB_Password = "admin";

    public static Connection Connect(){
        Connection con = null;

        try{
            //Class.forName("com.mysql.cj.jdbc.Driver");
            con = DriverManager.getConnection(DB_URL, DB_Username, DB_Password);
        }
        catch(SQLException e){
            System.out.println("Connection error (SQL): " + e.getMessage());
        }
        catch (Exception e){
            System.out.println("Connection error: " + e.getMessage());
        }

        return con;
    }

    public boolean Disconnect();
}
