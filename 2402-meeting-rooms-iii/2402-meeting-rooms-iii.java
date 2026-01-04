class Solution {
    public int mostBooked(int n, int[][] meetings) {
        var meetingCount = new int[n];
        // used rooms should be sorted by end time, and then by room number
        // the int[] here will have two elemebts : [endTime, roomIdx]
        var usedRooms = new PriorityQueue<int[]>((a, b) -> a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]);
        var unusedRooms = new PriorityQueue<Integer>();

        // all rooms will be unused initially
        for(var i=0; i<n; i++) unusedRooms.offer(i);
        // meetings that start first, should be picked first
        Arrays.sort(meetings, (m1, m2) -> m1[0] - m2[0]);

        for(var meeting : meetings){
            int start=meeting[0], end=meeting[1];

            while(!usedRooms.isEmpty() && usedRooms.peek()[0] <= start){
                var freedRoom = usedRooms.poll()[1];
                unusedRooms.offer(freedRoom);
            }

            // if meeting room is free then use it, else pick a room that will be free earliest
            if(!unusedRooms.isEmpty()){
                var freeRoom = unusedRooms.poll();
                var arr = new int[]{end, freeRoom};
                usedRooms.offer(arr);
                meetingCount[freeRoom]++;
            }
            else{
                var nextAvailableTime = usedRooms.peek()[0];
                var freeRoom = usedRooms.poll()[1];
                var arr = new int[]{nextAvailableTime + end - start, freeRoom};
                usedRooms.offer(arr);
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