import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

/**
 * Created by student on 2018-10-02.
 */
public class JIn {
    public static String getString() {
        String text = null;
        try{
            InputStreamReader rd = new InputStreamReader(System.in);
            BufferedReader bfr = new BufferedReader(rd);

            text = bfr.readLine();
        }catch(IOException e){e.printStackTrace();}
        return text;
    }
}