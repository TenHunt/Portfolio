// Daniël De Jager 41669436 - CMPG212 Assignment 5

public abstract class Database implements DatabaseIO {
    String url;
    String username;
    String password;

    public String getUrl() {
        return this.url;
    }
    public String getUsername() {
        return this.username;
    }
    public String getPassword() {
        return this.password;
    }

    public void setUrl(String url) {
        this.url = url;
    }
    public void setUsername(String username) {
        this.username = username;
    }
    public void setPassword(String password) {
        this.password = password;
    }

    public void executeQuery(String query) throws ExecutionException {
        if(this.getUsername() == "admin" && this.getPassword() == "admin") {
            System.out.println("Connection to DB at URL " + this.getUrl() + " successful. The following query was executed: " + query);
        }
        else {
            throw new ExecutionException();
        }
    }

    public String toString() {
        return "-The database URL is set to " + this.getUrl() + " with the username " + this.getUsername() + " and password " + this.getPassword() + "-";
    }
}
