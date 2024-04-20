// this is graph cycle decomposition problem
// basically find out how many distinct graphs we have 
// for each graph, swaps needed = no. of nodes -1
// one approach could be union find to find disjoint sets
// below we are using mathematical approach - where you keep swapping till everyone is right
// refer : https://leetcode.com/problems/couples-holding-hands/solutions/113362/java-c-o-n-solution-using-cyclic-swapping/
public class Solution {
    public int MinSwapsCouples(int[] row) {
        var n = row.Length;
        
        // figure out where each person is currently
        var pos = new int[n];
        for(var i=0; i<n; i++)
            pos[row[i]] = i;

        // now keep swapping till all are at right place
        var ans = 0;
        for(var curPos=0; curPos<n; curPos++){
            for(var expectedPos = ExpectedPos(row, pos, curPos); curPos != expectedPos; expectedPos = ExpectedPos(row, pos, curPos)){
                // send this person next to their partner
                (row[curPos], row[expectedPos]) = (row[expectedPos], row[curPos]);
                
                // update the new position in pos array   
                (pos[row[curPos]], pos[row[expectedPos]]) = (pos[row[expectedPos]], pos[row[curPos]]);

                ans++;
            }
        }

        return ans;
    }

    private int ExpectedPos(int[] row, int[] pos, int idx){
        // XOR with 1 to get partner, so that only last bit is flipped
        // this way, for person at even index, we get just next odd index
        // for odd index, we get just previous even index
        var partnerOfPersonAtCurrIndex = row[idx]^1; 
        var posOfThePartner = pos[partnerOfPersonAtCurrIndex];
        var posOfPartnerOfThisPerson = posOfThePartner^1;

        return posOfPartnerOfThisPerson;
    }
}