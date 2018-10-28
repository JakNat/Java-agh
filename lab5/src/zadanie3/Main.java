package zadanie3;

public class Main {

    public static void main(String[] args) throws Exception {
        MicroDVD microDVD = new MicroDVD(100);
        try {
            microDVD.delay("gravity.txt","gravity_out.txt",100,30);
        }catch (NumberFormatException e){
            System.out.println(e.getMessage());
        }catch (ArithmeticException e){
            System.out.println(e.getMessage());
        }catch (IllegalArgumentException e){
            System.out.println(e.getMessage());
        }catch (Exception e){
            System.out.println(e.getMessage());
        }
    }
}
