import org.junit.Assert;
import org.junit.Test;
import org.junit.Rule;
import static org.junit.Assert.fail;



public class MammothTest {


    @Test
    public void eatMeat() {
        Mammoth mammoth = new Mammoth();

        Food meat = new Meat();


    }

    @Test public void throwsMyExceptionWhenAIsCreatedWithNull() {
        Mammoth mammoth = new Mammoth();

        Food meat = new Meat();
        Meat meat1 = new Meat();

        try {
            mammoth.eat(meat1);
            fail("Expected InadequateFoodException to be thrown");
        } catch( InadequateFoodException ex ) {
            Assert.assertEquals("I don't like meat", ex.getMessage());

        }
    }
}