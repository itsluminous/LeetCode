public class Solution {
    int maxScore = -1, maxMask = 0;
    HashSet<string>[] seen;

    public int[] MaximumBobPoints(int numArrows, int[] aliceArrows) {
        var n = aliceArrows.Length;
        seen = new HashSet<string>[n];      // 3d array of currIdx,numOfArrowsLeft,currScore
        for(var i=0; i<n; i++) seen[i] = new();

        maximumBobPoints(numArrows, aliceArrows, 0, 0, n-1);
        var ans = new int[n];
        
        // fill up ans based on maxMask
        for(var i=n-1; i>0; i--){
            var mask = (1 << i);
            if((mask & maxMask) != mask) continue;
            ans[i] = aliceArrows[i] + 1;
            numArrows -= (aliceArrows[i] + 1);
        }
        ans[0] = numArrows;
        return ans;
    }

    private void maximumBobPoints(int numArrows, int[] aliceArrows, int currMask, int currScore, int idx) {
        if(idx == -1) return;
        if(seen[idx].Contains($"{numArrows}-{currScore}")) return;
        seen[idx].Add($"{numArrows}-{currScore}");

        if(idx == 0){
            if(aliceArrows[idx] < numArrows) currMask |= (1 << idx);
            // Console.WriteLine($"{idx} : {currScore} with {Convert.ToString(currMask, 2)}");
            if(currScore > maxScore)
                (maxScore, maxMask) = (currScore, currMask);
            return;
        }

        maximumBobPoints(numArrows, aliceArrows, currMask, currScore, idx-1);  // not win current index
        if(aliceArrows[idx] < numArrows){
            currMask |= (1 << idx);
            maximumBobPoints(numArrows - aliceArrows[idx] -1, aliceArrows, currMask, currScore + idx, idx-1);  // win current index
        }
    }
}