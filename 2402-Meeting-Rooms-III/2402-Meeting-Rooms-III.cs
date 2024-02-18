public class Solution {
    public int MostBooked(int n, int[][] meetings) {
        var meetingCount = new int[n];

        // all rooms will be unused initially
        var unusedRooms = new PriorityQueue<int,int>();
        for(var i=0; i<n; i++) unusedRooms.Enqueue(i, i);

        // used rooms should be sorted by end time, and then by room number
        // the long[] here will have two elemebts : [endTime, roomIdx]
        var usedRooms = new PriorityQueue<long[], long[]>(new RoomComparer());

        // meetings that start first, should be picked first
        Array.Sort(meetings, (m1, m2) => m1[0].CompareTo(m2[0]));

        foreach(var meeting in meetings){
            int start=meeting[0], end=meeting[1];

            // clear all rooms ending before start time
            while(usedRooms.Count > 0 && usedRooms.Peek()[0] <= start){
                var freedRoom = Convert.ToInt32(usedRooms.Dequeue()[1]);
                unusedRooms.Enqueue(freedRoom, freedRoom);
            }

            // if meeting room is free then use it, else pick a room that will be free earliest
            if(unusedRooms.Count > 0){
                var freeRoom = unusedRooms.Dequeue();
                var arr = new long[]{end, freeRoom};
                usedRooms.Enqueue(arr, arr);
                meetingCount[freeRoom]++;
            }
            else{
                var nextAvailableTime = usedRooms.Peek()[0];
                var freeRoom = Convert.ToInt32(usedRooms.Dequeue()[1]);
                var arr = new long[]{nextAvailableTime + end - start, freeRoom};
                usedRooms.Enqueue(arr, arr);
                meetingCount[freeRoom]++;
            }
        }

        // find out the room with max meetings
        int maxCount=0, maxCountRoom=0;
        for(var i=0; i<n; i++){
            if(meetingCount[i] > maxCount){
                maxCount = meetingCount[i];
                maxCountRoom = i;
            }
        }

        return maxCountRoom;
    }
}

public class RoomComparer : IComparer<long[]>
{
    public int Compare(long[] x, long[] y)
    {
        if (x[0] == y[0]) return x[1].CompareTo(y[1]);
        return x[0].CompareTo(y[0]);
    }
}