public class Solution {
    public int MaxEvents(int[][] events) {
        var lastDay = 0;
        foreach(var evt in events)
            lastDay = Math.Max(lastDay, evt[1]);
        
        Array.Sort(events, (e1, e2) => e1[0] - e2[0]);
        var pq = new PriorityQueue<int, int>();
        var ans = 0;

        // emulate each passing day
        for(int day=1, idx = 0; day <= lastDay; day++){
            // if event start day <= curr day, then it is eligible
            while(idx < events.Length && events[idx][0] <= day){
                pq.Enqueue(events[idx][1], events[idx][1]);
                idx++;
            }

            // if event end time < curr day, then it is not eligible
            while(pq.Count > 0 && pq.Peek() < day)
                pq.Dequeue();
            
            // if there is somethig left in queue, then it is eligible
            // we pick the day with smallest end time
            if(pq.Count > 0){
                pq.Dequeue();
                ans++;
            }
        }

        return ans;
    }
}