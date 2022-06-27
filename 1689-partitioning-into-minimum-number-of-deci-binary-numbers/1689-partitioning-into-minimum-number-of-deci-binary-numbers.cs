// logic -
// to make a number 9, I need to add "1" 9 times, so I need 9 count total.
// to make a number 8, I need to add "1" 8 times, so I need 8 count total.
// to make a number 89, I need to add "1" at ones place 9 times and "1" at tens place 8 times
// so something like 11 + 11 + 11 + 11 + 11 + 11 + 11 + 11 + 1  (last number has only one "1")
// so with only 9 deci-binary numbers count, I can make 89
// similarly, for number 789, I need max 9 count because for 7 & 8 those 9 counts will have required "1" in right place
// hence, basically we just need to find biggest number in string and that is answer

public class Solution {
    public int MinPartitions(string n) {
        var max = 0;
        foreach(var ch in n){
            max = Math.Max(max, ch-'0');
            if(max == 9) return max;     // we will never find a number greater than 9
        }
        
        return max;
    }
}