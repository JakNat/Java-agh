package appl;

import excp.BadInputException;
import excp.NothingToSubstractFromException;
import excp.TooBigNumberException;

public class StringCalculator extends Calculator {

    private String result;
    private String finalReslut;
    public StringCalculator(String result) {
        this.result = result;
    }

    @Override
    void SaveToFile(String x, String filename) {

    }

    @Override
    String Add(String x) {
        finalReslut = result + x;
        return finalReslut;
    }

    @Override
    String Substract(String x) throws NothingToSubstractFromException, BadInputException {
        if(result.isEmpty()){
            throw new NothingToSubstractFromException();
        }
        if(!result.contains(x)){
            throw new BadInputException();
        }
        finalReslut = result;
        return finalReslut.replaceAll(x," ");

    }

    @Override
    String Multiply(int x) throws TooBigNumberException {
        if(x > 5){
            throw new TooBigNumberException();
        }
        finalReslut = "";
        for (int i = 0; i < x; i++) {
            finalReslut += result;
        }
        return  finalReslut;
    }
    public static void main(String[] args){
        StringCalculator stringCalculator = new StringCalculator("ala");

        String addString = stringCalculator.Add(" ma kota");
        System.out.println("Add: " + stringCalculator.Add(" ma kota"));
        try {
            String subString = stringCalculator.Substract("la");
            System.out.println("Substract: " + subString);

        }catch (NothingToSubstractFromException e){
            System.out.println("result is empty!!");

        } catch (BadInputException e) {
            System.out.println("nothing to remove");
            e.printStackTrace();
        }
        try{
            String multString = stringCalculator.Multiply(3);
            System.out.println("Multiply: " + multString);
        }
        catch (TooBigNumberException e) {
            System.out.println("value needs to be smaller than 5");
        }

    }
}
