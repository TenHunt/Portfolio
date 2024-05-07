// Daniël De Jager 41669436 - CMPG212 Assignment 5

public class ExecutionException extends Exception {
    ExecutionException() {
        this("The DB query could not be executed. Please check your credentials.---");
    }
    ExecutionException(String message) {
        super(message);
    }
}
