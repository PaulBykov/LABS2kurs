package org.lab.demo2.items;

import java.util.Date;

public class Item {
    private int _id;
    private String _name;

    private Date _date;

    public Item(int id, String name, Date date){
        this._id = id;
        this._name = name;
        this._date = date;
    }

    public int GetId(){
        return this._id;
    }

    public String GetName() {
        return _name;
    }

    public Date GetDate() {
        return _date;
    }
}