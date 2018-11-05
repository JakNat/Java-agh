import org.junit.Test;
import org.junit.Assert;

public class ATest {
    @Test
    public void met1(){
        A a = new A();

        String respone = a.met(1);

        Assert.assertEquals("pierwszy", respone);
    }

    @Test
    public void met2(){
        A a = new A();

        String respone = a.met(2);

        Assert.assertEquals("drugi", respone);
    }

    @Test
    public void metAnother(){
        A a = new A();

        String respone = a.met(23);

        Assert.assertEquals("inny", respone);
    }


}