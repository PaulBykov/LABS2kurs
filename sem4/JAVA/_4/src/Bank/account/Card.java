package Bank.account;

public class Card {
    private enum types {debet, credit};
    private final int cardId;
    private boolean isOnline = true;
    private String type;
    private String number;


    public Card(int cardId, String type, String number) {
        this.cardId = cardId;
        this.type = type;
        this.number = number;
    }

    public int getCardId() {
        return cardId;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public String getNumber() {
        return number;
    }

    public void setNumber(String number) {
        this.number = number;
    }

    public boolean isOnline() {
        return isOnline;
    }



    public void setOnline(boolean online) {
        isOnline = online;
    }
}
