package zad2;

public abstract class Pracownik {
    PESEL pesel;
    double wynagrodzenieBrutto;
    protected abstract double WynagrodzenieNetto();

    public double getWynagrodzenieBrutto() {
        return wynagrodzenieBrutto;
    }

    public void setWynagrodzenieBrutto(double wynagrodzenieBrutto) {
        this.wynagrodzenieBrutto = wynagrodzenieBrutto;
    }
}
