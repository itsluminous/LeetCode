class Solution {
    public int maxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes) {
        int n = candies.length, maxCandies = 0;
        boolean[] boxFound = new boolean[n], keyFound = new boolean[n];

        Queue<Integer> queue = new LinkedList<>();
        for(var box : initialBoxes){
            boxFound[box] = true;
            if(status[box] == 1) queue.offer(box);
        }

        while(!queue.isEmpty()){
            var box = queue.poll();
            if(status[box] == -1) continue; // already explored

            // capture candies
            maxCandies += candies[box];
            status[box] = -1;   // mark visited

            // explore new boxes found
            for(var cBox : containedBoxes[box]){
                boxFound[cBox] = true;
                if(status[cBox] == 1 || (status[cBox] == 0 && keyFound[cBox])) queue.offer(cBox);
            }

            // explore new keys found
            for(var kBox : keys[box]){
                keyFound[kBox] = true;
                if(status[kBox] != -1 && boxFound[kBox]) queue.offer(kBox);
            }
        }

        return maxCandies;
    }
}