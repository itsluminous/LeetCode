class Solution {
    public int numOfUnplacedFruits(int[] fruits, int[] baskets) {
        int n = baskets.length, match = 0;
        for(var fruit : fruits)
            for(var i=0; i<n; i++)
                if(fruit <= baskets[i]){
                    baskets[i] = 0;
                    match++;
                    break;
                }

        return fruits.length - match;
    }
}