package other.UDP;


import java.io.*;
import java.net.*;

public class Receiver {
    private static final int SERVER_PORT = 12345;

    public static void main(String[] args) {
        try {
            DatagramSocket socket = new DatagramSocket(SERVER_PORT);

            byte[] receiveData = new byte[1024];

            // Создаем дейтаграмму для приема данных
            DatagramPacket receivePacket = new DatagramPacket(receiveData, receiveData.length);

            // Получаем данные
            socket.receive(receivePacket);

            // Преобразуем данные в строку
            String receivedMessage = new String(receivePacket.getData(), 0, receivePacket.getLength());

            System.out.println("Получено сообщение: " + receivedMessage);

            // Закрываем сокет
            socket.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
