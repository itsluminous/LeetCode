public class Solution {
    public int LongestConsecutive(int[] nums) {
        var set = new HashSet<int>();
        foreach(var num in nums)
            set.Add(num);
        
        int max = 0, curr = 0, currNum;
        foreach(var num in set){
            if(set.Contains(num-1)) continue;
            currNum = num;
            curr = 1;
            
            while(set.Contains(currNum+1)){
                currNum++;
                curr++;
            }
            
            max = Math.Max(max, curr);
        }
        
        return max;
    }
}