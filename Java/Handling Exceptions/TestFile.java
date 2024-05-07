// Daniël De Jager 41669436 - CMPG212 Assignment 5

public class TestFile {
    public static void main(String[] args) {
        // Test correct MongoDB
        try {
            MongoDB db1 = new MongoDB("db1.com", "admin", "admin"); // Initialization must be in try catch block else program ends prematurely upon exception
            System.out.println(db1);
            db1.createConnection();
            db1.executeQuery("SELECT * FROM Table");
            db1.closeConnection();
        } catch (ConnectionException e) {
            System.out.println(e);
        } catch (ExecutionException e) {
            System.out.println(e);
        } catch (Exception e) {
            System.out.println(e);
        }

        // Test incorrect credentials MongoDB
        try {
            MongoDB db2 = new MongoDB("db2.com", "guest", "guest");
            System.out.println(db2);
            db2.createConnection();
            db2.executeQuery("SELECT * FROM Table");
            db2.closeConnection();
        } catch (ConnectionException e) {
            System.out.println(e);
        } catch (ExecutionException e) {
            System.out.println(e);
        } catch (Exception e) {
            System.out.println(e);
        }

        // Test correct MySQL
        try {
            MySQL db3 = new MySQL("db3.com", "admin", "admin");
            System.out.println(db3);
            db3.createConnection();
            db3.executeQuery("SELECT * FROM Table");
            db3.closeConnection();
        } catch (ConnectionException e) {
            System.out.println(e);
        } catch (ExecutionException e) {
            System.out.println(e);
        } catch (Exception e) {
            System.out.println(e);
        }

        // Test correct MongoDB
        try {
            SQLServer db4 = new SQLServer("db4.com", "admin", "admin");
            System.out.println(db4);
            db4.createConnection();
            db4.executeQuery("SELECT * FROM Table");
            db4.closeConnection();
        } catch (ConnectionException e) {
            System.out.println(e);
        } catch (ExecutionException e) {
            System.out.println(e);
        } catch (Exception e) {
            System.out.println(e);
        }
    }
}
