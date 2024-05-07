// Daniël De Jager 41669436 - CMPG212 Assignment 5

public class ConnectionException extends Exception {
    ConnectionException() {
        this("The DB connection failed.---");
    }
    ConnectionException(String message) {
        super(message);
    }
}
