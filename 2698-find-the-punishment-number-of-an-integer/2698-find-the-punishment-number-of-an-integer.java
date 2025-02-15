class Solution {
    public int punishmentNumber(int n) {
        // first run findNumsMatchingCondition() to get all no. matching condition
        // then hardcode it so that all runs don't need to evaluate it 
        // var pun = findNumsMatchingCondition();

        var pun = new int[]{1, 9, 10, 36, 45, 55, 82, 91, 99, 100, 235, 297, 369, 370, 379, 414, 657, 675, 703, 756, 792, 909, 918, 945, 964, 990, 991, 999, 1000};

        var punishment = 0;
        for(var num : pun){
            if(num > n) break;
            punishment += num * num;
        }

        return punishment;
    }
    
    private List<Integer> findNumsMatchingCondition(){
        var match = new ArrayList<Integer>();
        for(var i=1; i<=1000; i++){
            if(canPartition(i*i, i))
                match.add(i);
        }
        return match;
    }

    private boolean canPartition(int num, int target){
        if(num == target) return true;
        if(num < target) return false;

        int curr = 0, mul = 1;
        while(num > 0){
            var lastDigit = num % 10;
            num /= 10;

            curr += mul * lastDigit;
            mul *= 10;
            if(canPartition(num, target - curr))
                return true;
        }
        
        return false;
    }
}