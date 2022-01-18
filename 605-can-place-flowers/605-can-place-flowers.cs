public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        int f = flowerbed.Length, planted = 0;
        for(var i=0; i<f; i++){
            if(flowerbed[i] == 1) continue;
            var prev = i == 0 ? 0 : flowerbed[i-1];
            var next = i == f-1 ? 0 : flowerbed[i+1];
            if(prev == 0 && next == 0){
                planted++;
                flowerbed[i] = 1;
            }
            if(planted >= n) return true;
        }
        
        return planted >= n;
    }
}