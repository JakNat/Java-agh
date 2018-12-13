import java.sql.*;
import java.util.LinkedList;

public class DB{
    private LinkedList<Book> books = new LinkedList<>();
    private Connection conn = null;
    private Statement stmt = null;
    private ResultSet rs = null;
    public void connect(){
        for (int i = 0; i < 3; i++) {
            try {
                Class.forName("com.mysql.jdbc.Driver").newInstance();
                conn =
                        DriverManager.getConnection("jdbc:mysql://mysql.agh.edu.pl/natonek",
                                "natonek","UdMeQRyRSk15Kwpf");
                break;

            } catch (SQLException ex) {
                // handle any errors
                System.out.println("SQLException: " + ex.getMessage());
                System.out.println("SQLState: " + ex.getSQLState());
                System.out.println("VendorError: " + ex.getErrorCode());
            }catch(Exception e){e.printStackTrace();}
            if(i == 2){
                System.out.println("NO CONNECTION");
            }
        }

    }


    public void addBook(Book book) throws SQLException {
        stmt = conn.createStatement();
        String insert = "INSERT INTO books ";
        String values = "VALUES (\'"+ book.getIsbn() +"\',\'" + book.getTitle() +"\',\'" + book.getAuthor() + "\'," + book.getYear() + ")";
        String query = insert + values;
        stmt.executeUpdate(query);

    }

    public void GetAllBooks(){
        try {
            connect();
            stmt = conn.createStatement();

            // Wyciagamy wszystkie pola z kolumny name
            // znajdujące się w tabeli users
            rs = stmt.executeQuery("SELECT * FROM books");

            while(rs.next()){
                Book book = new Book();
                book.setIsbn(rs.getString(1));
                book.setAuthor(rs.getString(3));
                book.setTitle(rs.getString(2));
                book.setYear(Integer.parseInt(rs.getString(4)));
                books.add(book);
                String name = rs.getString(2);
                System.out.println("book: "+ book);
            }
        }catch (SQLException ex){
            // handle any errors

        }finally {
            // zwalniamy zasoby, które nie będą potrzebne
            if (rs != null) {
                try {
                    rs.close();
                } catch (SQLException sqlEx) { } // ignore
                rs = null;
            }

            if (stmt != null) {
                try {
                    stmt.close();
                } catch (SQLException sqlEx) { } // ignore

                stmt = null;
            }
        }
    }

    public void GetBooksByIsbn(String isbn){
        try {
            connect();
            stmt = conn.createStatement();
            String select = "SELECT * FROM books";
            String where = " WHERE isbn = " + isbn;
            String execution = select + where;
            rs = stmt.executeQuery(execution);

            while(rs.next()){
                Book book = new Book();
                book.setIsbn(rs.getString(1));
                book.setAuthor(rs.getString(3));
                book.setTitle(rs.getString(2));
                book.setYear(Integer.parseInt(rs.getString(4)));

                books.add(book);
                String name = rs.getString(2);
                System.out.println("book: "+ book);
            }
        }catch (SQLException ex){
            // handle any errors

        }finally {
            // zwalniamy zasoby, które nie będą potrzebne
            if (rs != null) {
                try {
                    rs.close();
                } catch (SQLException sqlEx) { } // ignore
                rs = null;
            }

            if (stmt != null) {
                try {
                    stmt.close();
                } catch (SQLException sqlEx) { } // ignore

                stmt = null;
            }
        }

    }

    public void GetBooksByAuthor(String author){
        try {
            connect();
            stmt = conn.createStatement();
            String select = "SELECT * FROM books";
            String where = " WHERE author = \"" + author + "\"";
            String execution = select + where;
            rs = stmt.executeQuery(execution);

            while(rs.next()){
                Book book = new Book();
                book.setIsbn(rs.getString(1));
                book.setAuthor(rs.getString(3));
                book.setTitle(rs.getString(2));
                book.setYear(Integer.parseInt(rs.getString(4)));

                books.add(book);
                String name = rs.getString(2);
                System.out.println("book: "+ book);
            }
        }catch (SQLException ex){
            // handle any errors

        }finally {
            // zwalniamy zasoby, które nie będą potrzebne
            if (rs != null) {
                try {
                    rs.close();
                } catch (SQLException sqlEx) { } // ignore
                rs = null;
            }

            if (stmt != null) {
                try {
                    stmt.close();
                } catch (SQLException sqlEx) { } // ignore

                stmt = null;
            }
        }

    }
}