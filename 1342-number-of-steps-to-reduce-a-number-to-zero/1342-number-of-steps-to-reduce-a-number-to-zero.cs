// Bit manipulation
// In binary, for 0, result += 1 because we are doing divide;
// for 1, result += 2 because we first do "-1" then do a divide;
public class Solution {
    public int NumberOfSteps(int num) {
        if(num == 0) return 0;
        
        var steps = 0;
        do{
            if((num&1) == 1) steps+= 2;     // if odd, then two steps
            else steps++;                   // if even, then one step
            num = num>>1;
        }while(num != 0);
        
        return steps-1; // leftmost 1 we only need to -1 and we no need to divide by 2, so reducing 1 step
    }
}

// Accepted
public class Solution1 {
    public int NumberOfSteps(int num) {
        var steps = 0;
        while(num != 0){
            if(num % 2 == 0) num /= 2;
            else num--;
            steps++;
        }
        return steps;
    }
}