class Solution {
    public boolean threeConsecutiveOdds(int[] arr) {
        var odd = 0;
        for(var num : arr){
            if((num & 1) == 1) odd++;
            else odd = 0;

            if(odd == 3) return true;
        }

        return false;
    }
}