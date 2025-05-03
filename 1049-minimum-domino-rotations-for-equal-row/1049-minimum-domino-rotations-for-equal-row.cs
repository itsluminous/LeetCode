public class Solution {
    public int MinDominoRotations(int[] tops, int[] bottoms) {
        var n = tops.Length;
        int[] topFreq = new int[7], botFreq = new int[7], sameFreq = new int[7];

        // count freq of each num in both rows respectively
        for(var i=0; i < n; i++){
            int t = tops[i], b = bottoms[i];
            topFreq[t]++;
            botFreq[b]++;
            if(t == b) sameFreq[t]++;
        }

        // now check which of 6 dice faces can be made
        for(var i=1; i<7; i++){
            if(topFreq[i] + botFreq[i] - sameFreq[i] == n)      // if this face has n occurence
                return n - Math.Max(topFreq[i], botFreq[i]);    // make it on row with max count of it  
        }

        return -1;
    }
}

// Accepted - try to make num1 & num2 in top row and bot row
public class SolutionSimulation {
    public int MinDominoRotations(int[] tops, int[] bottoms) {
        var FAIL = int.MaxValue;
        int top1 = tops[0], top1Rot = 0;
        int top2 = bottoms[0], top2Rot = 1;
        int bot1 = bottoms[0], bot1Rot = 0;
        int bot2 = tops[0], bot2Rot = 1;

        for(var i=1; i < tops.Length; i++){
            // make tops[0] in top row
            if(tops[i] != top1 && bottoms[i] != top1) top1Rot = FAIL;
            else if(top1Rot != FAIL && tops[i] != top1) top1Rot++;

            // make bottoms[0] in top row
            if(tops[i] != top2 && bottoms[i] != top2) top2Rot = FAIL;
            else if(top2Rot != FAIL && tops[i] != top2) top2Rot++;

            // make bottoms[0] in bottom row
            if(bottoms[i] != bot1 && tops[i] != bot1) bot1Rot = FAIL;
            else if(bot1Rot != FAIL && bottoms[i] != bot1) bot1Rot++;
            
            // make tops[0] in bottom row
            if(bottoms[i] != bot2 && tops[i] != bot2) bot2Rot = FAIL;
            else if(bot2Rot != FAIL && bottoms[i] != bot2) bot2Rot++;

            // if neither is possible, then early exit
            if(top1Rot == FAIL && top2Rot == FAIL && bot1Rot == FAIL && bot2Rot == FAIL)
                return -1;
        }

        // find smallest rotation
        var topRot = Math.Min(top1Rot, top2Rot);
        var botRot = Math.Min(bot1Rot, bot2Rot);
        return Math.Min(topRot, botRot);
    }
}