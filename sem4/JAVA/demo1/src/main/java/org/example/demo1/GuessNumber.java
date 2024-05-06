package org.example.demo1;

import java.io.*;
import java.util.Random;
import javax.servlet.http.*;
import javax.servlet.annotation.*;

@WebServlet(name = "GuessNumber", value = "/GuessNumber")
public class GuessNumber extends HttpServlet {
    private static final long serialVersionUID = 1L;
    private static int secretNumber;

    public static void overrideSecretNumber(int newNumber){
        secretNumber = newNumber;
    }

    public static int getSecretNumber(){
        return secretNumber;
    }

    @Override
    public void init() {
        // Генерация случайного числа от 1 до 100 при запуске сервера
        Random random = new Random();
        secretNumber = random.nextInt(100) + 1;
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException {
        int guess = Integer.parseInt(request.getParameter("guess"));
        String result;

        if (guess == secretNumber) {
            result = "Поздравляем! Вы угадали число.";
        } else if (guess < secretNumber) {
            result = "Загаданное число больше.";
        } else {
            result = "Загаданное число меньше.";
        }

        response.setContentType("text/plain");
        response.setCharacterEncoding("UTF-8");
        response.getWriter().write(result);
    }
}