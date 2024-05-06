import DataBase.DBController;

public class Main {
    public static void main(String[] args) {
        try {
            //Class.forName(DBController.DB_Driver);
            DBController db = new DBController();

            //1
            DBController.PrintQuery(db.MakeQuery(DBController.getQuery1()));

            //2
            DBController.PrintQuery(db.MakeQuery(DBController.getQuery2()));

            //3
            DBController.PrintQuery(db.MakeQuery(DBController.getQuery3("Реферат")));

            //4
            DBController.PrintQuery(db.MakeQuery(DBController.getQuery4("Реферат")));
`
            //5
            //db.MakeUpdate(DBController.getQuery5(4, "Привет"));

            //transact
            //db.prepareTSQL();
        }
        catch (Exception e){
            e.printStackTrace();
            System.out.println(e.getMessage());
        }

    }
}