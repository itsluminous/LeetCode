class Solution {
    public int maximumInvitations(int[] favorite) {
        var n = favorite.length;
        
        // count how many fans each person has
        var fans = new int[n];
        for(var person : favorite) fans[person]++;

        // topological sort the dependency graph
        // we start with people who have no fans, as they will be at the edges
        Queue<Integer> queue = new LinkedList<>();
        for(var person=0; person<n; person++)
            if(fans[person] == 0)
                queue.offer(person);
        
        // find out longest path leading to each person
        var depth = new int[n]; 
        Arrays.fill(depth, 1);

        while(!queue.isEmpty()){
            var person = queue.poll();
            var fav = favorite[person];
            depth[fav] = Math.max(depth[fav], 1 + depth[person]);
            if(--fans[fav] == 0) queue.offer(fav);
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
                longestCycle = Math.max(longestCycle, cycleLength);
        }

        return Math.max(longestCycle, twoCycleChain);
    }
}