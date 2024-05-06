package Bank.users;

import Bank.account.Account;
import Bank.account.Card;

import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import com.google.gson.Gson;

public class Client extends User {
    private int clientId;
    private String name;
    private List<Account> accounts;

    public Client(int clientId, String name) {
        this.clientId = clientId;
        this.name = name;
        this.accounts = new ArrayList<>();
    }

    public void printAllCards(){
        System.out.println("id\tnumber\t\t\t\ttype\tbalance\tstatus");
        for(Account account: this.accounts){
            for(Card card: account.getCards()){
                System.out.println(card.getCardId() + "\t"
                        + card.getNumber() + "\t"
                        + card.getType() + "\t"
                        + account.getBalance() + "\t"
                        + card.isOnline());
            }
        }
    }
    public List<Card> getAllCards(){
        List<Card> cards = new ArrayList<>();

        for(Account acc: this.accounts){
            for(Card card: acc.getCards()){
                cards.add(card);
            }
        }

        return cards;
    }
    public Card getCardById(int id){
        var cards = getAllCards();

        for(Card card: cards){
            if(card.getCardId() == id){
                return card;
            }
        }

        return null;
    }

    public Account getAccountByCard(Card card){
        for(Account acc: accounts){
            for(Card crd: acc.getCards()){
                if(crd == card){
                    return acc;
                }
            }
        }

        return null;
    }

    public int getClientId() {
        return clientId;
    }
    public String getName() {
        return name;
    }

    public List<Account> getAccounts() {
        return accounts;
    }

    public void addAccount(Account account) {
        accounts.add(account);
    }

    public void removeAccount(Account account) {
        accounts.remove(account);
    }

    public double checkBalance() {
        double totalBalance = 0;
        for (Account account : accounts) {
            totalBalance += account.getBalance();
        }
        return totalBalance;
    }

    public void Serialize(String filePath) {
        try (FileWriter writer = new FileWriter(filePath)) {
            Gson gson = new Gson();
            gson.toJson(this, writer);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static Client Deserialize(String filePath) {
        try (FileReader reader = new FileReader(filePath)) {
            Gson gson = new Gson();
            return gson.fromJson(reader, Client.class);
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        }
    }

    public void blockCard(Card card) {
        // логика блокировки карты
    }

    public void makePayment(double amount, Card card) {
        // логика выполнения платежа
    }

    public void topUp(double amount, Account account) {
        // логика пополнения счета
    }

    @Override
    public String toString() {
        return this.getName() + " №" + this.getClientId();
    }
}
