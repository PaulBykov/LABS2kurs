package DataBase;

import java.sql.*;


public class DBController implements IConnector , ISelector, IUpdater{
    private Connection _connection;
    public DBController(){
        _connection = Connect();
    }

    public void prepareTSQL(){
        try{
            System.out.println("TRANSACT TEST!!!");

            this._connection.setAutoCommit(false);
            Savepoint save = _connection.setSavepoint();

            //мутирующий запрос
            this.MakeUpdate(getQuery5(3, "test"));

            //откат
            _connection.rollback(save);

        } catch (Exception e){
            System.out.println("Transact err: " + e.getMessage());
        }
        finally {
            System.out.println("Transact end!");
        }

    }
    public static Connection Connect(){
        Connection con = null;

        try{
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
    public boolean CloseConnection(){
        try{
            this._connection.close();
            _connection = null;
        }
        catch (Exception e){
            return false;
        }

        return true;
    }


    public static void PrintQuery(ResultSet response)   {
        if(response == null)
            return;

        try{
            int columnCount = response.getMetaData().getColumnCount();

            // Выводим заголовки столбцов
            for(int i = 1; i <= columnCount; i++) {
                System.out.printf("%-35s",response.getMetaData().getColumnName(i) + "\t\t");
            }
            System.out.println("\n");

            // данные
            while(response.next()) {
                int i = 1;
                while(i < columnCount+1){
                    String value = response.getString(i);
                    System.out.printf("%-40s",value);
                    i++;
                }
                System.out.println();
            }
        }
        catch (Exception e){
            System.out.println("Exception while printing the query");
        }
        finally {
            System.out.println("\n\n" + "-".repeat(200));
        }

    }

    public static String getQuery1(){
        return  "SELECT people.* FROM people\n" +
                "    inner join mails on people.Id = mails.Sender_id\n" +
                "        ORDER BY length(mails.text) desc\n" +
                "LIMIT 1\n";
    }
    public static String getQuery2(){
        return "SELECT people.*,\n" +
                "    (SELECT count(*) FROM mails WHERE people.Id = mails.Sender_id) as Отправлено,\n" +
                "    (SELECT count(*) FROM mails WHERE people.Id = mails.Recipient_id) as Получено\n" +
                "FROM people";
    }
    public static String getQuery3(String theme){
        return String.format("SELECT people.* FROM people\n" +
                "    inner join mails on people.Id = mails.Recipient_id\n" +
                "        where theme = '%s' \n" +
                "        GROUP BY people.Id\n" +
                "        ORDER BY people.Id", theme);
    }
    public static String getQuery4(String theme){
        return String.format("SELECT people.* FROM people\n" +
                "    LEFT JOIN mails ON\n" +
                "        people.Id = mails.Recipient_id\n" +
                "        AND mails.theme = '%s'\n" +
                "    WHERE mails.Recipient_id IS NULL\n" +
                "    ORDER BY people.Id;\n", theme);
    }
    public static String getQuery5(int senderId, String theme){
        return String.format(
                "INSERT INTO mails (Sender_id, Recipient_id, theme, text, date)\n" +
                "SELECT %d, id, '%s', '', current_date() FROM people\n", senderId, theme
        );
    }


    public ResultSet MakeQuery(String query){
        if(_connection == null){return null;}

        try{
            Statement statement = _connection.createStatement();
            statement.setFetchSize(100);

            return statement.executeQuery(query);
        } catch (Exception e){
            System.out.println("Query error: " + e.getMessage());
        }

        return null;
    }
    public void MakeUpdate(String query){
        if(_connection == null){return;}

        try{
            PreparedStatement statement = _connection.prepareStatement(query);
            statement.setFetchSize(100);

            statement.executeUpdate(query);
        } catch (Exception e){
            System.out.println("Query error: " + e.getMessage());
        }

    }
}
