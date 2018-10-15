import java.io.Console;

import static java.lang.StrictMath.sqrt;

public class LiczbyPierwsze {
    private int size;

    public LiczbyPierwsze(int size) {
        this.size = size;
    }
    public void WypiszLiczbyPierwsze(){
        boolean a = true;
        for (int i = 2; i < this.size; i++) {
            a = true;
            int sqrtOfI = (int)sqrt(i);
            for (int j = 2; j <= sqrtOfI; j++) {
                if(i % j == 0){
                    a = false;
                    break;
                }
            }
            if(a){
                System.out.println(i);
            }
        }
    }
}
