public class Solution {
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