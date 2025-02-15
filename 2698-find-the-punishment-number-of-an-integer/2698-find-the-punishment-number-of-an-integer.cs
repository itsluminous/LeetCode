public class Solution {
    public int PunishmentNumber(int n) {
        // first run FindNumsMatchingCondition() to get all no. matching condition
        // then hardcode it so that all runs don't need to evaluate it 
        // var pun = FindNumsMatchingCondition();

        int[] pun = [1, 9, 10, 36, 45, 55, 82, 91, 99, 100, 235, 297, 369, 370, 379, 414, 657, 675, 703, 756, 792, 909, 918, 945, 964, 990, 991, 999, 1000];

        var punishment = 0;
        foreach(var num in pun){
            if(num > n) break;
            punishment += num * num;
        }

        return punishment;
    }
    
    private List<int> FindNumsMatchingCondition(){
        var match = new List<int>();
        for(var i=1; i<=1000; i++){
            if(CanPartition(i*i, i))
                match.Add(i);
        }
        return match;
    }

    private bool CanPartition(int num, int target){
        if(num == target) return true;
        if(num < target) return false;

        int curr = 0, mul = 1;
        while(num > 0){
            var lastDigit = num % 10;
            num /= 10;

            curr += mul * lastDigit;
            mul *= 10;
            if(CanPartition(num, target - curr))
                return true;
        }
        
        return false;
    }
}