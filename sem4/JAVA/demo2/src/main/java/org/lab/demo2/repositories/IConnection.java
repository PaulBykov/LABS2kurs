package org.lab.demo2.repositories;

import java.sql.Connection;

public interface IConnection {
    public final static String DB_URL = "jdbc:mysql://localhost:3306/java?autoReconnect=true&useSSL=false";
    public final static String DB_Username = "admin";
    public final static String DB_Password = "admin";

    public Connection connect();

    public boolean disconnect();
}
