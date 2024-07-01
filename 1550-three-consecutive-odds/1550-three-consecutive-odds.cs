public class Solution {
    public bool ThreeConsecutiveOdds(int[] arr) {
        var odd = 0;
        foreach(var num in arr){
            if((num & 1) == 1) odd++;
            else odd = 0;

            if(odd == 3) return true;
        }

        return false;
    }
}