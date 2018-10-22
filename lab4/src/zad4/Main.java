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

        ROOT11 root11 = new ROOT11(11);
        String abc = "abcdefghijklmnopq xyztwm";
        String x = root11.Crypt(abc);
        String v = root11.Derypt(x);

        Polibiusz poll = new Polibiusz();
        String xxx = poll.Crypt("geeksforgeeks");
        String xxxd = poll.Derypt(xxx);
        List<String> lines = Arrays.asList("THHHhe first line", "the second line");
        Path file = Paths.get("text.txt");
        Path file2 = Paths.get("Crypted-root-text.txt");
        Files.write(file, lines, Charset.forName("UTF-8"));

        Cryptographer cryptographer = new Cryptographer();
        File fil3e = new File(file.toString());

        cryptographer.Cryptfile(fil3e,new File("Crypted--text.txt"), root11);
        cryptographer.Decryptfile(new File("crypted-root-text.txt"),new File("decrypted-root-text.txt") ,root11);


    }
}