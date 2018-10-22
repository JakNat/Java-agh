package zad4;

public abstract class Shape{
    public String name;

    public Shape(String name) {
        this.name = name;
    }

    /**
     * Metoda rysujaca w konsoli dany kształt
     */
    public abstract void draw();
}