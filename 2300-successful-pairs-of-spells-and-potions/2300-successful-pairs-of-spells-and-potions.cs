public class Solution {
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        Array.Sort(potions);
        var n = spells.Length;
        var ans = new int[n];

        for(var i=0; i<n; i++){
            var target = success / (1.0d * spells[i]);
            var idx = BinarySearch(potions, target);
            ans[i] = (potions.Length - idx);
        }

        return ans;
    }

    private int BinarySearch(int[] potions, double target){
        int left = 0, right = potions.Length-1, ans = -1;
        while(left <= right){
            var mid = left + (right-left)/2;
            if(potions[mid] >= target) {
                right = mid-1;
                ans = mid;
            }
            else left = mid+1;
        }
        return ans == -1 ? potions.Length : ans;
    }
}