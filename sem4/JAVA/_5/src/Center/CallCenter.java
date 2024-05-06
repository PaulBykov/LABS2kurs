package Center;

import java.util.concurrent.*;

public class CallCenter {
    private final Semaphore operators;

    public CallCenter(int n) {
        operators = new Semaphore(n);
    }

    public void call(int clientId) {
        try {
            System.out.println("Клиент " + clientId + " звонит");
            operators.acquire();
            System.out.println("Клиент " + clientId + " обслуживается");
            Thread.sleep((long) (Math.random() * 1000));
            System.out.println("Клиент " + clientId + " завершил разговор");
            operators.release();
        } catch (InterruptedException e) {
            System.out.println("Клиент " + clientId + " положил трубку");
        }
    }
}
