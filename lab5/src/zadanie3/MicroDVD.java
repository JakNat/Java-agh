package zadanie3; /**
 * Created by student on 2018-10-23.
 */

import java.io.IOException;
import java.nio.charset.Charset;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.LinkedList;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class MicroDVD {
    private int framerate;
    final static Charset ENCODING = StandardCharsets.UTF_8;

    public MicroDVD(int framerate) {
        this.framerate = framerate;
    }

    public void delay(String in, String out, int delay, int fps) throws Exception {
        int diference = (delay * fps) / 1000;
        if (fps < 0 && delay < 0){
            throw new IllegalArgumentException("zły format");
        }
        List<String> lines = readSmallTextFile(in);
        List<String> linesOut = new LinkedList<>();
        /**
         * regex patern - znajduje pare klamer {x}{y}
         */
        String pattern = "\\{(.+)\\}\\{(.+)\\}";
        Pattern r = Pattern.compile(pattern);
         for(String line:lines) {
             /**
              * matcher znajduje dopasowanie w kazdej lini.
              * dla {23}{111} m.group(1) = 23, m.group(2) = 111
              */
            Matcher m = r.matcher(line);
            if (m.find( )) {
                if(!isNumeric(m.group(1)) || !isNumeric(m.group(2))){
                    throw new NumberFormatException("zły format: {" + m.group(1) + "}{" + m.group(2) + "}" );
                }
                int start = Integer.parseInt(m.group(1));
                int end = Integer.parseInt(m.group(2));
                /**
                 *  wyjątek gdy w pliku pojawi się niepoprana sekwencja znaków
                 */
                if(end <= start){
                    throw new ArithmeticException(end + " <= " + start);
                }
                start += diference;
                end += diference;

                String replace = "{" + start + "}{" + end + "}";
                String newLine = line.replaceAll("\\{([0-9]+)\\}\\{([0-9]+)\\}", replace);
                linesOut.add(newLine);
            }else {
                throw new Exception("No Match!");
            }
        }
        writeSmallTextFile(linesOut,out);
    }

    /**
     *Metoda sprawdza czy dany string mozna skonwertować na typ numeryczny
     * @param strNum string do sprawdzenia
     */
    public static boolean isNumeric(String strNum) {
        try {
            double d = Double.parseDouble(strNum);
        } catch (NumberFormatException | NullPointerException nfe) {
            return false;
        }
        return true;
    }

    /**
     * Metoda zapisuje zdania do pliku
     * @param lines linie do wpisania
     * @param fileName nazwa folderu
     * @throws IOException bład przy wpisaniu do pliku
     */
    void writeSmallTextFile(List<String> lines, String fileName) throws IOException {
        Path path = Paths.get(fileName);
        Files.write(path, lines, ENCODING);
    }
    /**
     * @param fileName nazwa folderu do odczytu
     * @return zwraca wszystkie linie z pliku
     * @throws IOException bład przy odczytywaniu
     */
    List<String> readSmallTextFile(String fileName) throws IOException {
        Path path = Paths.get(fileName);
        return Files.readAllLines(path, ENCODING);
    }
}
