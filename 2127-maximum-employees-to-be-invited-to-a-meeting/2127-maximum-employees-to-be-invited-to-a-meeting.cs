public class Solution {
    public int MaximumInvitations(int[] favorite) {
        var n = favorite.Length;
        
        // count how many fans each person has
        var fans = new int[n];
        foreach(var person in favorite) fans[person]++;

        // topological sort the dependency graph
        // we start with people who have no fans, as they will be at the edges
        var queue = new Queue<int>();
        for(var person=0; person<n; person++)
            if(fans[person] == 0)
                queue.Enqueue(person);
        
        // find out longest path leading to each person
        var depth = new int[n]; 
        for(var i=0; i<n; i++) depth[i] = 1;

        while(queue.Count > 0){
            var person = queue.Dequeue();
            var fav = favorite[person];
            depth[fav] = Math.Max(depth[fav], 1 + depth[person]);
            if(--fans[fav] == 0) queue.Enqueue(fav);
        }

        // there can be 2 cases for max invitation
        // 1. there is a very big cycle where first person is a favourite of last person
        // 2. there is a cycle of 2 nodes (who like each other), and they each have a tail of fans
        int longestCycle = 0, twoCycleChain = 0;

        // detect cycle
        for(var person=0; person<n; person++) {
            if(fans[person] == 0) continue; // what a miserable life! (or we already visited this one)

            int cycleLength = 0, curr = person;
            while(fans[curr] != 0){
                fans[curr] = 0; // mark as visited
                curr = favorite[curr];
                cycleLength++;
            }

            if(cycleLength == 2)    // case 2 (two people like each other)
                twoCycleChain += depth[person] + depth[favorite[person]];
            else                    // case 1 (a complete cycle of people)
                longestCycle = Math.Max(longestCycle, cycleLength);
        }

        return Math.Max(longestCycle, twoCycleChain);
    }
}