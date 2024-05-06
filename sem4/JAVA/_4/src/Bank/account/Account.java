package Bank.account;

import java.util.ArrayList;
import java.util.List;

public class Account {
    private int accId;
    private double balance;
    private List<Card> cards;

    public Account(int accId, double balance) {
        this.accId = accId;
        this.balance = balance;
        this.cards = new ArrayList<>();
    }

    public int getAccId() {
        return accId;
    }

    public void setAccId(int accId) {
        this.accId = accId;
    }

    public double getBalance() {
        return balance;
    }

    public void setBalance(double balance) {
        this.balance = balance;
    }

    public List<Card> getCards() {
        return cards;
    }

    public void addCard(Card card) {
        cards.add(card);
    }

    public void removeCard(Card card) {
        cards.remove(card);
    }
}