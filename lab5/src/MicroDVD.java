/**
 * Created by student on 2018-10-23.
 */
import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.util.List;

public class MicroDVD {
    private int framerate;

    public MicroDVD(int framerate) {
        this.framerate = framerate;
    }

    public void delay(String in, String out, int delay, int fps) throws IOException {

        int diference = (delay * fps) / 1000;
        if (fps < 0 && delay < 0){
            throw new IllegalArgumentException();
        }
        File file = new File(in);
        List<String> lines = Files.readAllLines(file.toPath());

        for (String line: lines){
            line.replaceAll("\\{([0-9]+)\\}", "{$1}");
        }

    }
}
