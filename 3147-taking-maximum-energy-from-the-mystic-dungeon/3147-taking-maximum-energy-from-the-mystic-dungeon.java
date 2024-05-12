class Solution {
    public int maximumEnergy(int[] energy, int k) {
        var maxEnergy = -1111;
        var n = energy.length;
        for(var p=n-1; p>=(n-k); p--){
            var curr = 0;
            for(var i=p; i>=0; i-=k){
                curr += energy[i];
                maxEnergy = Math.max(maxEnergy, curr);
            }
        }
        return maxEnergy;
    }
}