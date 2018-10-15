public class Main {

    public static void main(String[] args) {
        // Prints "Hello, World" to the terminal window.
        System.out.println("Hello, World");
        LiczbyPierwsze liczbyPierwsze = new LiczbyPierwsze(1000);
        liczbyPierwsze.WypiszLiczbyPierwsze();
        DataFrame df = new  DataFrame(new String[]{"kol1","kol2","kol3"},
                new String[]{"int","double","MyCustomType"});
    }

}