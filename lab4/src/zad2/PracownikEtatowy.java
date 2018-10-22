package zad2;

public class PracownikEtatowy extends Pracownik {
    @Override
    protected double WynagrodzenieNetto() {
        return this.wynagrodzenieBrutto * 0.65;
    }
}
