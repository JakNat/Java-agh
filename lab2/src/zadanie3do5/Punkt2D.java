package zadanie3do5;

/**
 * Created by student on 2018-10-09.
 */
public class Punkt2D {
    protected double x;
    protected double y;

    public Punkt2D(double x, double y) {
        this.x = x;
        this.y = y;
    }

    public double getX() {
        return x;
    }

    public void setX(double x) {
        this.x = x;
    }

    public double getY() {
        return y;
    }

    public void setY(double y) {
        this.y = y;
    }
    protected  double distance(Punkt2D punkt2D){
        double a = punkt2D.getX();
        double b = punkt2D.getY();
        double cPow = a * a + b * b;
        return Math.sqrt(cPow);
    }
}
