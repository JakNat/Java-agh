package zad4;

import java.io.File;
import java.io.IOException;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) throws IOException {
        // write your code here

        List<String> lines = Arrays.asList("THHHhe first line", "the second line");
        Path file = Paths.get("text.txt");
        Files.write(file, lines, Charset.forName("UTF-8"));
        File fil3e = new File(file.toString());

        Path file2 = Paths.get("Crypted-root-text.txt");

        Cryptographer cryptographer = new Cryptographer();


        cryptographer.Cryptfile(fil3e,new File("Crypted--text.txt"), root11);
        cryptographer.Decryptfile(new File("crypted-root-text.txt"),new File("decrypted-root-text.txt") ,root11);


    }
}