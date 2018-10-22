package zad4;

public class square extends Shape {

    public square(String name) {
        super(name);
    }

    @Override
    public void draw() {
        System.out.println(name);

    }
}
