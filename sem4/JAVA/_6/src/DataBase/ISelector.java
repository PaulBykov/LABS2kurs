package DataBase;

import java.sql.ResultSet;

public interface ISelector {
    public ResultSet MakeQuery(String query);
}
