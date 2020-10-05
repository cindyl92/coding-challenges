import java.util.*;

public class HelloWorld{

     public static void main(String []args) {
        Scanner sc = new Scanner(System.in);
        
        System.out.println(getSignal(sc, "a"));
        return;
     }
     
     static public int getSignal(Scanner sc, String keyValue) {
         Map<String, Integer> map  = new HashMap<String, Integer>();
        while (sc.hasNext()) {
            String curr = sc.next();
            System.out.println(curr);
            
            // NUM -> VAR
            if (Character.isDigit(curr.charAt(0))) {
                String arrow = sc.next();
                String variable = sc.next();
                map.put(variable, Integer.parseInt(curr));
            }
            
            else {
                // NOT
                // TODO: UNSIGNED 16 BITS
                if (curr.equals("NOT")) {
                    String keyVar = sc.next();
                    String arrow = sc.next();
                    String variable = sc.next();
                    
                    int result = map.get(keyVar).shortValue();
                    result = ~result;
                    System.out.println(result);
                    
                    map.put(variable, result);
                }
                // OTHER OPs
                else {
                    String operation = sc.next();
                    String keyVar2 = sc.next();
                    String arrow = sc.next();
                    String variable = sc.next();
                    
                    int result = 0;
                    
                    if (operation.equals("AND")) {
                        result = map.get(curr) & map.get(keyVar2);
                        //System.out.println(result);
                    }
                    if (operation.equals("OR")) {
                        result = map.get(curr) | map.get(keyVar2);
                        //System.out.println(result);
                    }
                    if (operation.equals("XOR")) {
                        result = map.get(curr) ^ map.get(keyVar2);
                        //System.out.println(result);
                    }
                    if (operation.equals("LSHIFT")) {
                        result = map.get(curr) << Integer.parseInt(keyVar2);
                        //System.out.println(result);
                    }
                    if (operation.equals("RSHIFT")) {
                        result = map.get(curr) << Integer.parseInt(keyVar2);
                        //System.out.println(result);
                    }
                    
                    map.put(variable, result);
                }
            }
        }
        
        for (String key : map.keySet()) {
          System.out.println(key + ": " + map.get(key));
        }
        
        return map.get(keyValue);
     }
}