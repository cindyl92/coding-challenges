import java.util.*;

public class HelloWorld{

     public static void main(String []args) {
        Scanner sc = new Scanner(System.in);
        String userInput = sc.next();
        
        System.out.println(getFloorLevel(userInput));
        System.out.println(getFloorLevel2(userInput));
        
        return;
     }
     
     // #1
     static public int getFloorLevel(String upDowns) {
	    // base case
        if (upDowns.length() == 0) return 0;
        
        int level = 0;
        
        for (int i=0; i<upDowns.length(); i++) {
            if (upDowns.charAt(i) == '(') level++;
            else if (upDowns.charAt(i) == ')') level--;
        }
        
        return level;
     }
     
     // #1  ANOTHER SOLUTION
     static public int getFloorLevel2(String upDowns) {
        int upCount = upDowns.replaceAll("\\)", "").length();
        
        return upCount - (upDowns.length() - upCount);
     }
}


// 138