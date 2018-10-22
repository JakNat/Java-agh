package zad2;

public class Student extends Pracownik {
    @Override
    protected double WynagrodzenieNetto() {
        return this.wynagrodzenieBrutto * 0.8;
    }
}
