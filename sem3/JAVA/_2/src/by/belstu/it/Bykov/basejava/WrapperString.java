package by.belstu.it.Bykov.basejava;

import java.util.Objects;

interface IWrapping {
    public void replace (char oldchar, char newchar);
}

/**
 * Класс WrapperString реализует WrapeprString
 *
 *
 * */
public class WrapperString implements IWrapping {
    private String pstr = "";

    public WrapperString(String pstr) {
        this.pstr = pstr;
    }

    public String getPstr() {
        return pstr;
    }

    public void setPstr(String pstr) {
        this.pstr = pstr;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        WrapperString that = (WrapperString) o;
        return Objects.equals(pstr, that.pstr);
    }

    @Override
    public int hashCode() {
        return Objects.hash(pstr);
    }

    @Override
    public String toString() {
        return "WrapperString{" +
                "pstr='" + pstr + '\'' +
                '}';
    }

    public void replace (char oldchar, char newchar){
        pstr = pstr.replace(oldchar, newchar);
    }

}