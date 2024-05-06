package Bank.main;

import Tech.ClientNameComparator;
import Tech.XMLValidator;
import Tech.StaxStreamProcessor;

import Bank.account.Account;
import Bank.account.Card;
import Bank.users.Client;

import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.*;
import java.util.logging.Logger;
import java.util.stream.Collectors;

import org.apache.log4j.*;
import org.apache.log4j.xml.DOMConfigurator;

import javax.xml.stream.XMLStreamReader;


public class Main {
    static {
        new DOMConfigurator().doConfigure("log/log4j.xml",
                LogManager.getLoggerRepository());
    }
    private static final Logger LOGGER = Logger.getLogger(Main.class.getName());

    private static void StreamAPITest(){
        List<Integer> numbers = Arrays.asList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

        // Используем Stream API для фильтрации и вывода четных чисел
        List<Integer> evenNumbers = numbers.stream()
                .filter(num -> num % 2 == 0)
                .collect(Collectors.toList());

        // Выводим четные числа
        System.out.println("Even numbers: " + evenNumbers);
    }

    public static void main(String[] args) {
        LOGGER.info("Программа запущена");

        Scanner console =  new Scanner(System.in);
        List<Client> DB_Clients = new ArrayList<>();

        XMLValidator.start();
        try (StaxStreamProcessor processor = new StaxStreamProcessor(Files.newInputStream(Paths.get("files/data.xml")))) {
            XMLStreamReader reader = processor.getReader();
            processor.parseClient(reader);
        }
        catch (Exception e){
            System.out.println(e.getMessage());
        }



        Card firstCard = new Card(1, "debet", "4250 0511 2130 4212");
        Account firstAcc = new Account(1, 1000);
        firstAcc.addCard(firstCard);
        firstAcc.addCard(new Card(3, "credit", "1111 1111 1111 1111"));
        Client firstClient = new Client(1, "Paul");
        firstClient.addAccount(firstAcc);
        DB_Clients.add(firstClient);

        Card secondCard = new Card(2, "credit", "2222 2222 2222 2222");
        Account secondAcc = new Account(2, 2500);
        secondAcc.addCard(secondCard);
        Client secondClient = new Client(2, "Alex");
        secondClient.addAccount(secondAcc);
        DB_Clients.add(secondClient);


        firstClient.Serialize("client.json");
        Client newClient = Client.Deserialize("client.json");
        System.out.println("firstClient: " + firstClient.toString());
        System.out.println("secondClient: " + newClient.toString());


        Collections.sort(DB_Clients, new ClientNameComparator());
        StreamAPITest();

        System.out.println("1) Login as User");
        System.out.println("2) Login as Admin");

        byte choice = console.nextByte();

        while(true){
            LOGGER.info("NEW LOOP");
            switch (choice){
                case 1: {
                    LOGGER.info("CASE USER");
                    Client self = firstClient;
                    System.out.println("1) Check balance");
                    System.out.println("2) Block card");
                    System.out.println("3) Make payment");
                    System.out.println("4) Add balance");

                    byte choice1 = console.nextByte();

                    switch (choice1) {
                        case 1: {
                            System.out.println("Total balance: " + self.checkBalance());
                            break;
                        }
                        case 2: {
                            self.printAllCards();
                            byte cardId = console.nextByte();

                            try {
                                boolean resultStatus = false;
                                for (Card card : self.getAllCards()) {
                                    if (card.getCardId() == cardId) {
                                        card.setOnline(false);
                                        System.out.println("Success!");
                                        resultStatus = true;
                                        break;
                                    }
                                }

                                if (!resultStatus) {
                                    throw new Exception("You don't own a card with this ID");
                                }

                            } catch (Exception err) {
                                LOGGER.severe("Произошла ошибка: " + err.getMessage());
                                System.out.println(err.getMessage());
                            }
                            ;

                            break;
                        }
                        case 3: {
                            self.printAllCards();
                            byte selectedCardId = console.nextByte();
                            Card selfCard = self.getCardById(selectedCardId);

                            System.out.print("Enter amount: ");
                            int sum = console.nextInt();

                            System.out.println("Enter target card number: ");
                            String targetCardNumber = console.nextLine();

                            try {
                                if (self.getAccountByCard(selfCard).getBalance() < sum) {
                                    throw new Exception("Your balance too low");
                                }

                                self.getAccountByCard(selfCard).setBalance(self.getAccountByCard(selfCard).getBalance() - sum);
                                System.out.println("Success!");
                            } catch (Exception err) {
                                LOGGER.severe("Произошла ошибка: " + err.getMessage());
                                System.out.println(err.getMessage());
                            }

                            break;
                        }
                        case 4: {
                            self.printAllCards();
                            byte selectedCardId = console.nextByte();

                            System.out.println("How much money do you want?");
                            double sum = console.nextDouble();

                            self.getAccountByCard(self.getCardById(selectedCardId))
                                    .setBalance(self.getAccountByCard(self.getCardById(selectedCardId)).getBalance() + sum);

                            System.out.println("Okey!");
                        }

                        default:
                            break;
                    }

                    break;
                }
                case 2: {
                    LOGGER.info("CASE ADMIn");
                    System.out.println("1) Search card");
                    System.out.println("2) Block card");

                    byte choice2 = console.nextByte();
                    switch (choice2){
                        case 1:{
                            System.out.println("Enter card number: ");
                            String target_number = console.nextLine();

                            for(Client client: DB_Clients){
                                var cards = client.getAllCards();

                                for(Card card: cards){
                                    if(card.getNumber() == target_number){
                                        System.out.println(card.getCardId() + "\t"
                                                + card.getNumber() + "\t"
                                                + card.getType() + "\t"
                                                + card.isOnline());
                                    }
                                }
                            }

                            break;
                        }
                        case 2: {
                            System.out.println("Enter card id: ");
                            for(Client client: DB_Clients){
                                client.printAllCards();
                            }

                            byte targetId = console.nextByte();
                            for(Client client: DB_Clients){
                                for(Card card: client.getAllCards()){
                                    if(card.getCardId() == targetId){
                                        card.setOnline(false);
                                    }
                                }
                            }

                            break;
                        }
                        default:break;
                    }

                    break;
                }
                default: break;
            }
        }
    }
}