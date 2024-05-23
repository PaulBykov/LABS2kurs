package org.lab.demo2.services;

import org.lab.demo2.model.Item;
import org.lab.demo2.repositories.DbController;
import org.lab.demo2.repositories.ItemRepository;

import java.util.ArrayList;

public class ItemsService {
    private ItemRepository db;

    public ItemsService() {
        db = new ItemRepository(new DbController());
    }

    public ArrayList<Item> getAllItems() {
        return db.getAllItems();
    }

    public void addItem(String itemName) {
        db.addNewItem(itemName);
    }

    public void deleteItem(int id) {
        db.deleteItem(id);
    }

    public void close() {
        db = null;
    }
}