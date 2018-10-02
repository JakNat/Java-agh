import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

/**
 * Klasa wyświetlajaca powitaniena konsoli.
 * @author Szymon
 */
public class WitajSwiecie {
    /**
     *
     * @param argv lista argumentów przekazywana do programu
     */
    public static void main(String [] argv) throws IOException {
        String login = "login";
        String password = "passw0rd";

        InputStreamReader rd = new InputStreamReader(System.in);
        BufferedReader bfr = new BufferedReader(rd);

        System.out.print("Wpisz login: ");
        String log = bfr.readLine();
        System.out.print("Wpisz hasło: ");
        String pass = bfr.readLine();
        if(log.equals(login) && pass.equals(password)){
            System.out.println("Zalogowany ");
        }else {
            System.out.println("Złe dane ");
        }
    }
}