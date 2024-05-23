package org.lab.demo2.model;

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

    public int getId(){
        return this._id;
    }

    public String getName() {
        return _name;
    }

    public Date getDate() {
        return _date;
    }
}