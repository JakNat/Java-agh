package zad4;

public class ROOT11 implements Algorithm {
    private int type;
    private int distance;

    public ROOT11(int distance) {
        this.distance = distance;
    }

    @Override
    public String Crypt(String word) {
        String cryptedWord = "";

        for (int i = 0; i < word.length(); i++) {
            cryptedWord += Root11(word.charAt(i));
        }
        return cryptedWord;
    }

    @Override
    public String Derypt(String word) {
        String decryptedWord = "";

        for (int i = 0; i < word.length(); i++) {
            decryptedWord += Deroot11(word.charAt(i));
        }
        return decryptedWord;
    }


    char Root11 (int c ) {
        if ( (c >= 'A') && (c <= 'Z') ){
            if(c + distance > 'Z'){
                c = 'A' + distance - ('Z' - c);
            }else{
                c += distance;
            }
        }
        if ( (c >= 'a') && (c <= 'z') ){
            if(c + 11 > 'z')
            {
                c = 'a' + distance - ('z' - c);
            }
            else{
                c += distance;
            }
        }
        int x = 'a';
        int b = 'z';
        return (char)c;
    }
    char Deroot11 (int c ) {
        if ( (c >= 'A') && (c <= 'Z') ){
            if(c - 11 < 'A' || c == 'Z'){
                c = 'Z' - (distance - (c - 'A'));
            }else{
                c -= distance;
            }
        }
        if ( (c >= 'a') && (c <= 'z') ){
            if(c - 11 < 'a' || c == 'z'){
                c = 'z' - (distance - (c - 'a'));
            }else{
                c -= distance;
            }
        }
        return (char)c;
    }
}
