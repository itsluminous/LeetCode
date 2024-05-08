public class Solution {
    public string[] FindRelativeRanks(int[] score) {
        var toppers = new []{"Gold Medal", "Silver Medal", "Bronze Medal"};
        int n = score.Length, position = 1, maxScore = score.Max();

        // make an array of same size as max score, then place all players in that array based on score
        var scoreToIdx = new int[maxScore+1];
        for(var i=0; i<n; i++) scoreToIdx[score[i]] = i+1;

        // now traverse array from right to left and fill the rank array
        var rank = new string[n];
        for(var i=maxScore; i>=0; i--){
            if(scoreToIdx[i] == 0) continue;

            var idx = scoreToIdx[i]-1;
            if(position <= 3) rank[idx] = toppers[position-1];
            else rank[idx] = position.ToString();
            position++;
        }

        return rank;
    }
}

// Accepted - Using PriorityQueue - O(n.log n)
public class SolutionPQ {
    public string[] FindRelativeRanks(int[] score) {
        var toppers = new []{"Gold Medal", "Silver Medal", "Bronze Medal"};
        int n = score.Length, position = 1;
        
        // sort the players by rank
        var pq = new PriorityQueue<int, int>();
        for(var idx=0; idx<n; idx++) pq.Enqueue(idx, -score[idx]);

        // fill out rank array
        var rank = new string[n];
        for(var i=pq.Count; i>0; i--){
            var idx = pq.Dequeue();
            if(position <= 3) rank[idx] = toppers[position-1];
            else rank[idx] = position.ToString();
            position++;
        }

        return rank;
    }
}