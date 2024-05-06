package client;

import java.io.*;
import java.net.*;


public class GuessNumberClient {
    private static final String SERVER_ADDRESS = "localhost";
    private static final int PORT = 8888;

    public static void main(String[] args) {
        Socket socket = null;

        try {
            socket = new Socket(SERVER_ADDRESS, PORT);

            BufferedReader in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            PrintWriter out = new PrintWriter(socket.getOutputStream(), true);
            BufferedReader serverInput = new BufferedReader(new InputStreamReader(socket.getInputStream()));

            // Создаем отдельный поток для чтения ввода от пользователя
            Thread userInputThread = new Thread(() -> {
                try {
                    BufferedReader userInput = new BufferedReader(new InputStreamReader(System.in));
                    String userInputStr;
                    while ((userInputStr = userInput.readLine()) != null) {
                        out.println(userInputStr);
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }
            });
            userInputThread.start();

            String response;
            while ((response = serverInput.readLine()) != null) {
                System.out.println(response);
                if (response.contains("угадал")) {
                    break;
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                if (socket != null) {
                    socket.close();
                }
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}