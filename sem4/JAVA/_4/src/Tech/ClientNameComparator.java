package Tech;

import Bank.users.Client;


import java.util.Comparator;
import java.util.Objects;

public class ClientNameComparator implements Comparator<Client> {
    @Override
    public int compare(Client person1, Client person2) {
        return String.CASE_INSENSITIVE_ORDER.compare(person1.getName(), person2.getName());
    }
}
