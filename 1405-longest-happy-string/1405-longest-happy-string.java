class Solution {
    public String longestDiverseString(int a, int b, int c) {
        var maxHeap = new PriorityQueue<int[]>((i1, i2) -> i2[1] - i1[1]);  // [char, count]
        if(a != 0) maxHeap.offer(new int[]{0, a});
        if(b != 0) maxHeap.offer(new int[]{1, b});
        if(c != 0) maxHeap.offer(new int[]{2, c});

        var happy = new StringBuilder();
        int prev1 = 0, prev2 = 0;   // last two characters
        while(!maxHeap.isEmpty()){
            var first = maxHeap.poll();
            // check if we are going to repeat same char 3rd time
            if(happy.length() >= 2 && prev1 == first[0] && prev2 == first[0]){
                // if heap is empty, we already have final answer
                if(maxHeap.isEmpty()) return happy.toString();
                var second = maxHeap.poll();
                happy.append((char)('a' + second[0]));
                second[1]--;    // reduce remaining count
                if(second[1] > 0) maxHeap.offer(new int[]{second[0], second[1]});
                maxHeap.offer(new int[]{first[0], first[1]});
                prev1 = prev2;
                prev2 = second[0];
            }
            // if curr character fits nicely
            else {
                happy.append((char)('a' + first[0]));
                first[1]--;    // reduce remaining count
                if(first[1] > 0) maxHeap.offer(new int[]{first[0], first[1]});
                prev1 = prev2;
                prev2 = first[0];
            }
        }

        return happy.toString();
    }
}