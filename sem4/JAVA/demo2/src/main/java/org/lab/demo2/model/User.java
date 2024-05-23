package org.lab.demo2.model;

public class User {
    private String _login;
    private String _role;

    public User(String login, String role){
        this._login = login;
        this._role = role;
    }

    public String GetRole(){
        return _role;
    }
}
