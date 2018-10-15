import java.util.ArrayList;
import java.util.Dictionary;
import java.util.Enumeration;

public class DataFrame {

    private Dictionary<String, ArrayList<Object>> cols;

    public DataFrame(String[] strings, String[] strings1) {
        cols = new Dictionary<String, ArrayList<Object>>() {
            @Override
            public int size() {
                return 0;
            }

            @Override
            public boolean isEmpty() {
                return false;
            }

            @Override
            public Enumeration<String> keys() {
                return null;
            }

            @Override
            public Enumeration<ArrayList<Object>> elements() {
                return null;
            }

            @Override
            public ArrayList<Object> get(Object o) {
                return null;
            }

            @Override
            public ArrayList<Object> put(String s, ArrayList<Object> objects) {
                return null;
            }

            @Override
            public ArrayList<Object> remove(Object o) {
                return null;
            }
        };
        for (int i = 0; i < strings.length; i++) {
            cols.put(strings[i],new ArrayList<>());
        }
    }
    public int size(){
        int x = cols.size();
        return x;
    }
    public ArrayList<Object> get(String colname){
        return this.cols.get(colname);
    }
    public DataFrame get(String [] cols, boolean copy){

    }
}