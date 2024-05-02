public class Solution {
    public boolean canVisitAllRooms(List<List<Integer>> rooms) {
        var roomCount = rooms.size();
        var visited = new HashSet<Integer>();
        
        Queue<Integer> queue = new LinkedList<>();
        queue.add(0);   // room-0 is open initially

        // start bfs
        while(queue.size() > 0){
            for(var i=queue.size(); i>0; i--){
                var currRoom = queue.poll();
                if(visited.contains(currRoom)) continue;
                
                visited.add(currRoom);
                for(var r : rooms.get(currRoom)) queue.add(r);
            }
        }

        return roomCount == visited.size();
    }
}