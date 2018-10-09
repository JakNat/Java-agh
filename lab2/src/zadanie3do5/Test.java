package zadanie3do5;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedList;

/**
 * Created by student on 2018-10-09.
 */
public class Test {

    public static void main(String[] args) throws IOException {
        InputStreamReader rd = new InputStreamReader(System.in);
        BufferedReader bfr = new BufferedReader(rd);
         LinkedList<Punkt3D> punkty = new LinkedList<Punkt3D>();
        punkty.add(new Punkt3D(1,2,3));
        punkty.add(new Punkt3D(3,4,5));
        punkty.add(new Punkt3D(10,10,10));
        punkty.add(new Punkt3D(1,1,1));
        punkty.add(new Punkt3D(5,5,5));
        while (true) {
            System.out.println("\n1. Wczytaj punkt 3D\n" +
                    "2. Wyświetl wszystkie punkty\n" +
                    "3. Oblicz odległość\n" +
                    "4. Zakończ\n" +
                    "?");
            try {
                int answer = Integer.parseInt(bfr.readLine());
                if(answer == 1){
                    try {
                        Punkt3D punkt = ReadPoint();
                        if(punkt == null){
                            continue;
                        }
                        punkty.add(punkt);
                    }catch (Exception e){
                        System.out.println("podana wielkość w złym formacie");
                    }
                }else if(answer == 2){
                    for (Punkt3D punkt:punkty) {
                        double x = punkt.getX();
                        double y = punkt.getY();
                        double z = punkt.getZ();
                        double odlegloscc = punkt.distance(punkt);
                        System.out.println("\nPunkt(" + x + ", " + y + ", "+ z + ")" +
                                "\nodległość od prostej = " + odlegloscc );
                    }
                }else if(answer == 3){
                    try {
                        Punkt3D punkt = ReadPoint();
                        if(punkt == null){
                            continue;
                        }
                        System.out.println("Odległosc wynosi: " + punkt.distance(punkt));
                    }catch (Exception e){
                        System.out.println("podana wielkość w złym formacie");
                    }
                }else if(answer == 4){
                    break;
                }else{
                    System.out.println("Zła odpowiedź");
                }
            }catch (Exception e){
                System.out.println("Zła odpowiedź");
            }
        }
    }
    public static Punkt3D ReadPoint(){
        InputStreamReader rd = new InputStreamReader(System.in);
        BufferedReader bfr = new BufferedReader(rd);
        try {
            System.out.println("Wartość x");
            int x = Integer.parseInt(bfr.readLine());
            System.out.println("Wartość y");
            int y = Integer.parseInt(bfr.readLine());
            System.out.println("Wartość z");
            int z = Integer.parseInt(bfr.readLine());
            return new Punkt3D(x,y,z);
        }catch (Exception e){
            System.out.println("podana wielkość w złym formacie");
            return null;
        }
    }
}
