import java.sql.SQLException;
import java.util.Scanner;

public class main {
    public static void main(String [] args) throws SQLException {
        Scanner reader = new Scanner(System.in);

        DB db = new DB();
        db.connect();

        while (true){
            System.out.println("\nWpisz:" +
                    "\n1 => wyszukaj wszystkie"+
                    "\n2 => wyszukaj po isbn"+
                    "\n3 => wyszukaj po auhorze"+
                    "\n4 => dodaj ksiazke" +
                    "\n5 => Zakończ");

            int response = reader.nextInt();
            if(response == 1){
                db.GetAllBooks();
            }else if(response == 2){
                System.out.print("Wpisz kod:");
                String isbn = reader.next();
                db.GetBooksByIsbn(isbn);
            }else if(response == 3){
                System.out.print("Wpisz nazwe autora:");
                String author = reader.next();
                db.GetBooksByAuthor(author);
            }else if(response == 4){
                Book book = new Book();
                System.out.print("Wpisz kod isb:");
                book.setIsbn(reader.next());
                System.out.print("Wpisz nazwe autora:");
                book.setAuthor(reader.next());
                System.out.print("Wpisz nazwe książki:");
                book.setTitle(reader.next());
                System.out.print("Wpisz rok wydania:");
                book.setYear(reader.nextInt());
                db.addBook(book);
            }else if(response == 5){
                break;
            }

        }

    }
}
