package zad4;

public class Polibiusz implements Algorithm {
    @Override
    public String Crypt(String word) {
        return polybiusCipher(word);
    }
    @Override
    public String Derypt(String word) {
        String decryptedWord = "";
        for (int i = 0; i < word.length(); i += 2) {
            int x = word.charAt(i) - '0';
            int y = word.charAt(i + 1) - '0';
            int distance = (x - 1) * 5 + y;
            int c = 'a' + distance - 1;
            if(c > 'i'){
                c++;
            }
            if(word.charAt(i) == ' '){
                decryptedWord += ' ';
            }else {
            decryptedWord += (char)c;
        }}
        return decryptedWord;
    }
    private String polybiusCipher(String s)
    {
        s = s.toLowerCase();
        String cryptedWord = "";
        int row, col;
        for (int i = 0;i < s.length(); i++)
        {
            if(s.charAt(i) == ' '){
                cryptedWord += "  ";
            }else{
            row = (int)Math.ceil((s.charAt(i) - 'a') / 5) + 1;
            col = ((s.charAt(i) - 'a') % 5) + 1;
            if (s.charAt(i) == 'k')
            {
                row = row - 1;
                col = 5 - col + 1;
            }
            else if (s.charAt(i) >= 'j')
            {
                if (col == 1)
                {
                    col = 6;
                    row = row - 1;
                }
                col = col - 1;
            }
            cryptedWord += row +""+ col;
            }
        }
        return cryptedWord;
    }
}
