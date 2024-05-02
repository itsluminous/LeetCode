public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        var roomCount = rooms.Count;
        var visited = new HashSet<int>();
        
        var queue = new Queue<int>();
        queue.Enqueue(0);   // room-0 is open initially

        // start bfs
        while(queue.Count > 0){
            for(var i=queue.Count; i>0; i--){
                var currRoom = queue.Dequeue();
                if(visited.Contains(currRoom)) continue;
                
                visited.Add(currRoom);
                foreach(var r in rooms[currRoom]) queue.Enqueue(r);
            }
        }

        return roomCount == visited.Count;
    }
}