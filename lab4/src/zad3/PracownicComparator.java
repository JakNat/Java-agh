package zad3;

import zad2.Pracownik;

import java.util.Comparator;
// użyty w klasie Kadry (metoda sortujPracownikow())
public class PracownicComparator implements Comparator<Pracownik> {

    @Override
    public int compare(Pracownik pracownik, Pracownik t1) {
        if(pracownik.getWynagrodzenieBrutto() > t1.getWynagrodzenieBrutto()){
            return 1;
        }else if(pracownik.getWynagrodzenieBrutto() == t1.getWynagrodzenieBrutto()){
            return 0;
        }
        return -1;
    }
}
