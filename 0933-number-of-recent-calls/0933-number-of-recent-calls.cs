public class RecentCounter {
    Queue<int> queue;

    public RecentCounter() {
        queue = new Queue<int>();        
    }
    
    public int Ping(int t) {
        queue.Enqueue(t);
        while(t - queue.Peek() > 3000) queue.Dequeue();
        return queue.Count;
    }
}

/**
 * Your RecentCounter object will be instantiated and called as such:
 * RecentCounter obj = new RecentCounter();
 * int param_1 = obj.Ping(t);
 */