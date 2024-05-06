package Tender;

public class Bidder implements Runnable {
    private final String name;
    private final Tender tender;

    public Bidder(String name, Tender tender) {
        this.name = name;
        this.tender = tender;
    }

    @Override
    public void run() {
        double price = Math.random() * 100;
        tender.makeBid(name, price);
        System.out.println(name + " сделал ставку: " + price);
    }
}
