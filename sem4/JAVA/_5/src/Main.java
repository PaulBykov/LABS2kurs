import Center.*;
import Tender.*;

import java.io.Console;
import java.util.concurrent.*;


public class Main {
    private static void task1() {
        try {
            int n = 2;
            int m = 5;
            CallCenter callCenter = new CallCenter(n);
            ExecutorService executorService = Executors.newFixedThreadPool(m);
            for (int i = 0; i < m; i++) {
                executorService.submit(new Client(i, callCenter));
            }
            executorService.shutdown();
        } catch (Exception e){
            System.out.println(e.getMessage());
        }
    }

    private static void task2(){
        try {
            int n = 5; // количество участников тендера
            Tender tender = new Tender(n);

            ExecutorService executorService = Executors.newFixedThreadPool(n);
            for (int i = 0; i < n; i++) {
                executorService.submit(new Bidder("Участник " + i, tender));
            }
            executorService.shutdown();
            
            String winner = tender.determineWinner();
            System.out.println("Победитель тендера: " + winner);
        } catch (Exception e){
            System.out.println(e.getMessage());
        }
    }

    public static void main(String[] args) {
        task2();
    }
}