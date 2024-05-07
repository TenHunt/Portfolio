// Daniël De Jager 41669436 - CMPG212 Assignment 5

public interface DatabaseIO {
    public void createConnection() throws ConnectionException;
    public void executeQuery(String query) throws ExecutionException;
    public void closeConnection() throws ConnectionException;
}
