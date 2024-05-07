// Daniël De Jager 41669436 - CMPG212 Assignment 5

public class MySQL extends Database {
    MySQL(String url, String username, String password) {
        super.setUrl(url);
        super.setUsername(username);
        super.setPassword(password);
    }

    double randNum = Math.random();
    public void createConnection() throws ConnectionException {
        if(randNum < 0.2) {
            throw new ConnectionException();
        }
        else {
            System.out.println("---Connection created for MySQL DB at URL " + this.getUrl()+ ". Awaiting Instruction.");
        }
    }
    public void closeConnection() throws ConnectionException {
        if(randNum < 0.2) {
            throw new ConnectionException();
        }
        else {
            System.out.println("Instruction for MySQL DB at URL " + this.getUrl() + " succeeded. Connection closed.---");
        }
    }
}
