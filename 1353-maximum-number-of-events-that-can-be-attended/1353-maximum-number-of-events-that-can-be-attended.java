class Solution {
    public int maxEvents(int[][] events) {
        var lastDay = 0;
        for(var evt : events)
            lastDay = Math.max(lastDay, evt[1]);
        
        Arrays.sort(events, (e1, e2) -> e1[0] - e2[0]);
        var pq = new PriorityQueue<Integer>();
        var ans = 0;

        // emulate each passing day
        for(int day=1, idx = 0; day <= lastDay; day++){
            // if event start day <= curr day, then it is eligible
            while(idx < events.length && events[idx][0] <= day){
                pq.offer(events[idx][1]);
                idx++;
            }

            // if event end time < curr day, then it is not eligible
            while(!pq.isEmpty() && pq.peek() < day)
                pq.poll();
            
            // if there is somethig left in queue, then it is eligible
            // we pick the day with smallest end time
            if(!pq.isEmpty()){
                pq.poll();
                ans++;
            }
        }

        return ans;
    }
}