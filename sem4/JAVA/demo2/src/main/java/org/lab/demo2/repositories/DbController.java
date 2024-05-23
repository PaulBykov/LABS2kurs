package org.lab.demo2.repositories;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.logging.Logger;

public class DbController implements IConnection {

    private Connection connection;
    Logger logger = Logger.getLogger(getClass().getName());

    public DbController() {}

    public Connection connect() {
        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
            this.connection = DriverManager.getConnection(DB_URL, DB_Username, DB_Password);

            return this.connection;
        } catch (SQLException e) {
            logger.warning("Connection error (SQL): " + e.getMessage());
        } catch (Exception e) {
            logger.warning("Connection error: ");
            e.printStackTrace();
        }

        return null;
    }


    public boolean disconnect() {
        try {
            this.connection.close();
            this.connection = null;
        } catch (Exception e) {
            return false;
        }
        return true;
    }
}