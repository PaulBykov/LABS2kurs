package org.lab.demo2.repositories;

import org.lab.demo2.model.User;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.logging.Logger;

public class UserRepository {

    private DbController dbController;
    Logger logger = Logger.getLogger(getClass().getName());

    public UserRepository(DbController dbController) {
        this.dbController = dbController;
    }

    public User getUser(String login, int passHash) {
        Connection connection = dbController.connect();

        try {
            PreparedStatement statement = connection.prepareStatement(
                    "SELECT * FROM users WHERE login = ? AND passHash = ?");
            statement.setString(1, login);
            statement.setInt(2, passHash);

            ResultSet response = statement.executeQuery();
            response.next();
            return new User(login, response.getString(4));
        } catch (Exception e) {
            logger.warning("Error during getting user: " + e.getMessage());
        }
        return null;
    }

    public void addUser(String login, int passHash, String role) {
        Connection connection = dbController.connect();

        try {
            PreparedStatement statement = connection.prepareStatement("INSERT INTO users VALUES (NULL, ?, ?, ?)");
            statement.setString(1, login);
            statement.setInt(2, passHash);
            statement.setString(3, role);
            statement.executeUpdate();
        } catch (Exception e) {
            logger.warning("Error during adding user: " + e.getMessage());
        }
    }

    public boolean existUser(String login) {
        Connection connection = dbController.connect();

        try {
            PreparedStatement statement = connection.prepareStatement(
                    "SELECT COUNT(*) FROM users WHERE login = ?");
            statement.setString(1, login);

            ResultSet response = statement.executeQuery();
            response.next();
            return response.getInt(1) > 0;
        } catch (Exception e) {
            logger.warning("Error during checking user existence: " + e.getMessage());
        }
        return false;
    }

}