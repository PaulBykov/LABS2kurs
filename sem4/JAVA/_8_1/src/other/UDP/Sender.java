package other.UDP;

import java.io.*;
import java.net.*;

public class Sender {
    private static final String SERVER_HOST = "localhost";
    private static final int SERVER_PORT = 12345;

    public static void main(String[] args) {
        try {
            DatagramSocket socket = new DatagramSocket();

            // Считываем сообщение с консоли
            BufferedReader userInput = new BufferedReader(new InputStreamReader(System.in));
            System.out.print("Введите сообщение: ");
            String message = userInput.readLine();

            // Преобразуем сообщение в байтовый массив
            byte[] sendData = message.getBytes();

            // Создаем дейтаграмму с данными для отправки
            DatagramPacket sendPacket = new DatagramPacket(sendData, sendData.length, InetAddress.getByName(SERVER_HOST), SERVER_PORT);

            // Отправляем дейтаграмму
            socket.send(sendPacket);

            System.out.println("Сообщение успешно отправлено.");

            // Закрываем сокет
            socket.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}


