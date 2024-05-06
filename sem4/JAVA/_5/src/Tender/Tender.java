package Tender;
import java.util.Map;
import java.util.concurrent.*;

public class Tender {
    private final ConcurrentMap<String, Double> bids = new ConcurrentHashMap<>();
    private final CountDownLatch latch;

    public Tender(int numBids) {
        latch = new CountDownLatch(numBids);
    }

    public void makeBid(String name, double price) {
        bids.put(name, price);
        latch.countDown();
    }

    public String determineWinner() throws InterruptedException {
        latch.await();
        return bids.entrySet().stream()
                .min(Map.Entry.comparingByValue())
                .map(Map.Entry::getKey)
                .orElse(null);
    }
}
