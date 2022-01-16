// Idea is to calculate backwards
public class Solution {
    public int MinMoves(int target, int maxDoubles) {
        if(target == 1) return 0;
        
        var moves = 0;
        // use all the Double operations possible
        for(var i=0; i<maxDoubles; i++){
            // if it is an odd number, then we need one increment operation also
            if(target%2 != 0){
                target--;
                moves++;
            }
            // now we do a double operation
            moves++;
            target = target/2;
            // break if we reach starting point
            if(target == 1) break;
        }
        
        // now all Doubles are exhausted, so we use Increment operations for remaining
        moves += target-1;
        return moves;
    }
}