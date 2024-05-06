package org.lab.demo2.auth;


import org.lab.demo2.db.DbController;

import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;


@WebServlet(name="Auth", value="/Auth")
public class Auth extends HttpServlet {
    private DbController _db;

    public Auth(){
        _db = new DbController();

    }

    public User tryAuth(String login, String password){
        int passHash = hashFunction(password);
        User user = _db.getUser(login, passHash);

        return user;
    }

    public Boolean existUser(String login){
        return _db.existUser(login);
    }

    public void registerUser(String login, String password, String role){
        int passHash = hashFunction(password);
        _db.addUser(login, passHash, role);
    }

    private int hashFunction(String str){
        return str.hashCode();
    }

    @Override
    public void init(){
        _db.Connect();
    }


    @Override
    public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException {
        request.setCharacterEncoding("UTF-8");
        String login = request.getParameter("login");
        String pass = request.getParameter("pass");
        Boolean isRegister = request.getParameter("register").equals("true");

        if(pass == null || login == null){
            response.sendError(504, "No pass or login taken: " + login + "\n, pass: " + pass);
            return;
        }

        User user = null;
        if(isRegister){
            if(existUser(login)){
                response.sendError(504, "User with this login already exist!");
                return;
            }

            this.registerUser(login, pass, "user");
        }

        user = this.tryAuth(login, pass);


        if (user == null) {
            response.sendError(504, "No such user found!");
            return;
        }

        response.setContentType("text/plain");
        response.setCharacterEncoding("UTF-8");

        response.addCookie(new Cookie("role", user.GetRole()));
        response.addCookie(new Cookie("login", login));
        response.getWriter().write("success");
    }
}
