public class Solution {
    public int MinCostToMoveChips(int[] position) {
        int coinsAtOdd = 0, coinsAtEven = 0;
        for(var i=0; i<position.Length; i++){
            if(position[i]%2 == 0)
                coinsAtEven++;
            else
                coinsAtOdd++;
        }
        
        return Math.Min(coinsAtOdd, coinsAtEven);
    }
}