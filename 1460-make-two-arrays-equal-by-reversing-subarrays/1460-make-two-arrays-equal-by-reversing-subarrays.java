class Solution {
    public boolean canBeEqual(int[] target, int[] arr) {
        var freq = new int[1001];
        for(var num : arr) freq[num]++;

        for(var num : target){
            freq[num]--;
            if(freq[num] == -1) return false;
        }
        return true;
    }
}