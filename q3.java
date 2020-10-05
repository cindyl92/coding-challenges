import java.util.*;

public class HelloWorld{

     public static void main(String []args) {
        Scanner sc = new Scanner(System.in);
        
        System.out.println(getNumOfGoodWords(sc));
        return;
     }
     
     // #3
     static public int getNumOfGoodWords(Scanner sc) {
        int goodStrings = 0;
        while (sc.hasNext()) {
            String userInput = sc.next();
            boolean noConseq = true;
            boolean isDouble = false;
            int vowelCount = 0;
            
            if (userInput.length() <= 1) {
                break;
            }
            
            int prev = -1;
            
            for (int i=0; i<userInput.length(); i++) {
                int curr = userInput.charAt(i);
                
                // check if one set of two identical characters
                if (prev == curr) { 
                    isDouble = true;
                }
                
                // check if containing consecutive characters
                else if (prev == curr-1) {
                    noConseq = false;
                    break;
                }
                
                // count vowels
                if ("AEIOUaeiou".indexOf(curr) != -1) {
                    vowelCount++;
                }
                
                prev = curr;
            }  
            //System.out.println(noConseq);
            //System.out.println(isDouble);
            //System.out.println(vowelCount);
            
            
            if (noConseq && isDouble && vowelCount >= 3) {
                goodStrings++;
            }
        }
        return goodStrings;
     }
}


// 164