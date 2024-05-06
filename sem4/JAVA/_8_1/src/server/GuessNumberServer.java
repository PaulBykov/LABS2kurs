package server;

import java.io.*;
import java.net.*;

public class GuessNumberServer {
    private static final int PORT = 8888;

    public static void main(String[] args) {
        ServerSocket serverSocket = null;
        Socket clientSocket = null;

        try {
            serverSocket = new ServerSocket(PORT);
            System.out.println("Сервер запущен. Ожидание подключения...");

            clientSocket = serverSocket.accept();
            System.out.println("Подключение установлено.");

            // Генерируем случайное число от 1 до 100
            int number = (int) (Math.random() * 100) + 1;
            System.out.println("Загаданое число: " + number);

            BufferedReader in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
            PrintWriter out = new PrintWriter(clientSocket.getOutputStream(), true);

            out.println("Добро пожаловать в игру \"Угадай число\"!");
            out.println("Я загадал число от 1 до 100. Попробуйте угадать.");

            String guess;
            int attempts = 0;

            while ((guess = in.readLine()) != null) {
                try {
                    int guessNumber = Integer.parseInt(guess);
                    attempts++;

                    if (guessNumber < number) {
                        out.println("Мое число больше.");
                    } else if (guessNumber > number) {
                        out.println("Мое число меньше.");
                    } else {
                        out.println("Поздравляю! Вы угадали число " + number + " с " + attempts + " попыток.");
                        break;
                    }
                } catch (NumberFormatException e) {
                    out.println("Пожалуйста, введите число.");
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                if (clientSocket != null) {
                    clientSocket.close();
                }
                if (serverSocket != null) {
                    serverSocket.close();
                }
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}
