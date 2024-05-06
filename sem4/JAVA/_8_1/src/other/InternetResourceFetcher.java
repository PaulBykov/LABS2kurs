package other;


import java.io.*;
import java.net.*;

public class InternetResourceFetcher {
    public static void main(String[] args) {
        String urlAddress = "https://github.com/Oleg-N-Cher/MakeZX/blob/master/Docu/TAP%20file%20format.txt";

        try {
            URL url = new URL(urlAddress);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setRequestMethod("GET");

            int responseCode = connection.getResponseCode();
            if (responseCode == HttpURLConnection.HTTP_OK) {
                BufferedReader in = new BufferedReader(new InputStreamReader(connection.getInputStream()));
                String inputLine;
                StringBuilder content = new StringBuilder();
                while ((inputLine = in.readLine()) != null) {
                    content.append(inputLine);
                }
                in.close();

                System.out.println("Содержимое ресурса:");
                System.out.println(content.toString());
            } else {
                System.out.println("Не удалось получить доступ к ресурсу. Код ответа: " + responseCode);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
