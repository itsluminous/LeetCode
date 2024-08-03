public class Solution {
    public bool CanBeEqual(int[] target, int[] arr) {
        var freq = new int[1001];
        foreach(var num in arr) freq[num]++;

        foreach(var num in target){
            freq[num]--;
            if(freq[num] == -1) return false;
        }
        return true;
    }
}