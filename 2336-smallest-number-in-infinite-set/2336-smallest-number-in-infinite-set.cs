public class SmallestInfiniteSet {
    bool[] set;
    PriorityQueue<int, int> pq;

    public SmallestInfiniteSet() {
        set = Enumerable.Repeat(true, 1001).ToArray();
        pq = new PriorityQueue<int, int>();
        for(var i=1; i<=1000; i++) pq.Enqueue(i, i);
    }
    
    public int PopSmallest() {
        var smallest = pq.Dequeue();
        set[smallest] = false;
        return smallest;
    }
    
    public void AddBack(int num) {
        if(set[num]) return;
        set[num] = true;
        pq.Enqueue(num, num);
    }
}

/**
 * Your SmallestInfiniteSet object will be instantiated and called as such:
 * SmallestInfiniteSet obj = new SmallestInfiniteSet();
 * int param_1 = obj.PopSmallest();
 * obj.AddBack(num);
 */