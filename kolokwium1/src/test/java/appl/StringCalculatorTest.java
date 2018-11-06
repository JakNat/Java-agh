package appl;

import com.sun.org.apache.xpath.internal.operations.Equals;
import excp.TooBigNumberException;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.*;

public class StringCalculatorTest {
    private StringCalculator stringCalculator;
    @Before
    public void setStringCalculator(){
        stringCalculator = new StringCalculator("Beata");
    }

    @Test
    public void add() {
        String result = stringCalculator.Add(" nie lubi javascript");


        assertEquals("Beata nie lubi javascript", result);
    }

    @Test
    public void multiply() {
        try {
            String result = stringCalculator.Multiply(3);
            assertEquals("BeataBeataBeata", result);
        } catch (TooBigNumberException e) {
            fail();
        }
    }

    @Test
    public void multiplyBy6ThrowTooBigNumberException() {
        try {
            String result = stringCalculator.Multiply(6);
            fail("Should throw TooBigNumberException");
        } catch (TooBigNumberException e) {
            
        }
    }

}