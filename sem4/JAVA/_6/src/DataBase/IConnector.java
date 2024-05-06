package DataBase;

import java.sql.Connection;

public interface IConnector {
    public final static String DB_URL = "jdbc:mysql://localhost:3306/java";
    public final static String DB_Username = "admin";
    public final static String DB_Password = "admin";

    public static final String DB_Driver = "com.mysql.cj.jdbc.Driver";

    public static Connection Connect(){
        Connection con = null;
        return con;
    }

    public boolean CloseConnection();


}
