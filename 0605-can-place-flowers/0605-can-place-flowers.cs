public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        var len = flowerbed.Length;
        for(var i=0; i<len && n>0; i++){
            if(flowerbed[i] == 1) i++;
            else if(i == len-1 || flowerbed[i+1] == 0){
                n--;
                i++;
            }
        }
        return n == 0;
    }
}