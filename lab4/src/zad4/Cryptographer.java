package zad4;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.LinkedList;
import java.util.List;

public class Cryptographer {
    public static void Cryptfile(File file, File CryptedFile, Algorithm algo) throws IOException {
        LinkedList<String> cryptedText = new LinkedList<>();
        try (BufferedReader br = new BufferedReader(new FileReader(file))) {
            String line;
            while ((line = br.readLine()) != null) {
                cryptedText.add(algo.Crypt(line));
            }
            Files.write(CryptedFile.toPath(), cryptedText, Charset.forName("UTF-8"));
        }
    }
    public static void Decryptfile(File file,File decryptedFile, Algorithm algo) throws IOException {
        LinkedList<String> cryptedText = new LinkedList<>();
        try (BufferedReader br = new BufferedReader(new FileReader(file))) {
            String line;
            while ((line = br.readLine()) != null) {
                cryptedText.add(algo.Derypt(line));
            }
            Files.write(decryptedFile.toPath(), cryptedText, Charset.forName("UTF-8"));
        }
    }
}
