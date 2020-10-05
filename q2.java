import java.util.*;

public class HelloWorld{

     public static void main(String []args) {
        Scanner sc = new Scanner(System.in);
        String userInput = sc.next();
        
        System.out.println(getNumberOfHouses(userInput));
        
        return;
     }
     
     // #2
     static public int getNumberOfHouses(String moves) {
        // base case
        if (moves.length() == 0) return 1;
        
        Set<String> visited = new HashSet<String>();
        int xPos = 0;
        int yPos = 0;
        
        visited.add(xPos+","+yPos);
        
        for (int i=0; i<moves.length(); i++) {
            //int[] test = new int[]{0,0};
            char move = moves.charAt(i);
            switch(move) {
              case '>':
                yPos++;
                break;
              case '<':
                yPos--;
                break;
              case '^':
                xPos++;
                break;
              case 'v':
                xPos--;
                break;
              default:
                break;
            }
            
            //System.out.println("");
            
            
            visited.add(xPos+","+yPos);
            
        }
        
        return visited.size();
     }
}

// 2565