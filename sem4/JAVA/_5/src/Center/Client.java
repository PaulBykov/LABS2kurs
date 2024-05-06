package Center;

public class Client implements Runnable {
    private final int id;
    private final CallCenter callCenter;

    public Client(int id, CallCenter callCenter) {
        this.id = id;
        this.callCenter = callCenter;
    }

    @Override
    public void run() {
        callCenter.call(id);
    }
}