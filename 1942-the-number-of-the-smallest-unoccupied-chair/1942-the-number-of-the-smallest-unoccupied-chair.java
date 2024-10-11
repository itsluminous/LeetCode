class Solution {
    public int smallestChair(int[][] times, int targetFriend) {
        var targetStart = times[targetFriend][0];
        Arrays.sort(times, (t1, t2) -> t1[0] - t2[0]);
        
        var leavingQueue = new PriorityQueue<int[]>((a,b) -> a[0] - b[0]);
        var avalableChairs = new TreeSet<Integer>();

        int nextChair = 0;
        for(var time : times){
            int start = time[0], end = time[1];
            while(!leavingQueue.isEmpty() && start >= leavingQueue.peek()[0])
                avalableChairs.add(leavingQueue.poll()[1]);
            
            var currChair = 0;
            if(!avalableChairs.isEmpty()){
                currChair = avalableChairs.first();
                avalableChairs.remove(currChair);
            }
            else {
                currChair = nextChair++;
            }

            if(start == targetStart) return currChair;
            leavingQueue.offer(new int[]{end, currChair});
        }

        return 0;
    }
}