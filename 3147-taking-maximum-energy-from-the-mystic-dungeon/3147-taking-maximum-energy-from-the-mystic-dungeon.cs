public class Solution {
    public int MaximumEnergy(int[] energy, int k) {
        var maxEnergy = -1111;
        var n = energy.Length;
        for(var p=n-1; p>=(n-k); p--){
            var curr = 0;
            for(var i=p; i>=0; i-=k){
                curr += energy[i];
                maxEnergy = Math.Max(maxEnergy, curr);
            }
        }
        
        return maxEnergy;
    }
}