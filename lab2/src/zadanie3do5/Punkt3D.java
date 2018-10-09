package zadanie3do5;

/**
 * Created by student on 2018-10-09.
 */
public class Punkt3D extends  Punkt2D {
    protected double z;
    public Punkt3D(double x, double y, double z) {
        super(x, y);
        this.z = z;
    }

    public double getZ() {
        return z;
    }

    public void setZ(double z) {
        this.z = z;
    }

    @Override
    protected double distance(Punkt2D punkt2D) {
        double d = punkt2D.getY();
        double c = super.distance(punkt2D);
        double ePow = d * d + c * c;
        return Math.sqrt(ePow);
    }
}
