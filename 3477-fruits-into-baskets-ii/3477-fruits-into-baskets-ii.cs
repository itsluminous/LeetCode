public class Solution {
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets) {
        int n = baskets.Length, match = 0;
        foreach(var fruit in fruits)
            for(var i=0; i<n; i++)
                if(fruit <= baskets[i]){
                    baskets[i] = 0;
                    match++;
                    break;
                }

        return fruits.Length - match;
    }
}