package org.lab.demo2.services;

import org.lab.demo2.model.User;
import org.lab.demo2.repositories.DbController;
import org.lab.demo2.repositories.UserRepository;

public class AuthService {
    private UserRepository userRepository;

    public AuthService() {
        userRepository = new UserRepository(new DbController());
    }

    public User tryAuth(String login, String password) {
        int passHash = hashFunction(password);
        return userRepository.getUser(login, passHash);
    }

    public boolean existUser(String login) {
        return userRepository.existUser(login);
    }

    public void registerUser(String login, String password, String role) {
        int passHash = hashFunction(password);
        userRepository.addUser(login, passHash, role);
    }

    private int hashFunction(String str) {
        return str.hashCode();
    }
}