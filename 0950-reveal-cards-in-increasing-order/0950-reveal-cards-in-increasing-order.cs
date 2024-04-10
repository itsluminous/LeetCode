// Accepted - using 2 pointers
public class Solution {
    public int[] DeckRevealedIncreasing(int[] deck) {
        var n = deck.Length;
        Array.Sort(deck);
        var ans = new int[n];

        var skip = false;
        int ansIdx = 0, deckIdx = 0;
        while(deckIdx < n){
            // only update value if this idx is not already processed
            if(ans[ansIdx] == 0){
                if(!skip){
                    ans[ansIdx] = deck[deckIdx];
                    deckIdx++;
                }
                skip = !skip;
            }
            // find the next ansIdx
            ansIdx = (ansIdx + 1) % n;
        }

        return ans;
    }
}