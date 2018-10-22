package zad2;

import zad3.PracownicComparator;

import java.util.Collection;
import java.util.Collections;
import java.util.Comparator;
import java.util.LinkedList;

public class Kadry{
    LinkedList<Pracownik> pracownicy;

    public Kadry(LinkedList<Pracownik> pracownicy) {
        this.pracownicy = pracownicy;
    }

    public void DodajPracownika(Pracownik pracownik){
        pracownicy.add(pracownik);
    }
    public void UsunPracownika(PESEL pesel){
        pracownicy.removeIf(pracownik -> pesel.getPesel() == pesel.getPesel());
    }
    public void ZdajdzPracownika(PESEL pesel){
        for (Pracownik pracownik:pracownicy
             ) {
            if(pracownik.pesel.getPesel() == pesel.getPesel()){
                System.out.println("Znaleziono");
                return;
            }
        }
        System.out.println("Nie Znaleziono");
    }
    public void ZmienWynagrodzeniePracownika(PESEL pesel, double wynagrodzenie){
        for (Pracownik pracownik:pracownicy
        ) {
            if(pracownik.pesel.getPesel() == pesel.getPesel()){
                pracownik.setWynagrodzenieBrutto(wynagrodzenie);
                System.out.println("Zmieniono wynagrodzenie pracownika");
                return;
            }
        }
        System.out.println("Nie Znaleziono pracownika");
    }
    public double PobierzWynagrodzenieBruttoPracownika(PESEL pesel, double wynagrodzenie){
        for (Pracownik pracownik:pracownicy
        ) {
            if(pracownik.pesel.getPesel() == pesel.getPesel()){
                pracownik.setWynagrodzenieBrutto(wynagrodzenie);
                return pracownik.getWynagrodzenieBrutto();
            }
        }
        System.out.println("Nie Znaleziono pracownika");
        return 0;
    }
    public double PobierzWynagrodzenieNettoPracownika(PESEL pesel, double wynagrodzenie){
        for (Pracownik pracownik:pracownicy
        ) {
            if(pracownik.pesel.getPesel() == pesel.getPesel()){
                pracownik.setWynagrodzenieBrutto(wynagrodzenie);
                return pracownik.WynagrodzenieNetto();
            }
        }
        System.out.println("Nie Znaleziono pracownika");
        return 0;
    }

// zadanie 3
    public void SortujPracownikow(){
        Collections.sort(pracownicy, new PracownicComparator());
    }


}
