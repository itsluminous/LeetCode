// Accepted - using queue
public class Solution {
    public int[] deckRevealedIncreasing(int[] deck) {
        var n = deck.length;
        Arrays.sort(deck);

        // queue to store index where next card of deck should go
        Queue<Integer> queue = new LinkedList<>();   
        for(var i=0; i<n; i++)  queue.add(i);

        var ans = new int[n];
        for(var i=0; i<n; i++){
            var idx = queue.poll();
            ans[idx] = deck[i];
            queue.add(queue.poll());
        }

        return ans;
    }
}

// Accepted - using 2 pointers
class SolutionTwoPointers {
    public int[] deckRevealedIncreasing(int[] deck) {
        var n = deck.length;
        Arrays.sort(deck);
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