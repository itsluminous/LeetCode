// using in-built LinkedList
public class LRUCache {

    public class Cache
    {
        public int CacheKey;
        public int CacheVal;
        public Cache(int key, int val)
        {
            CacheKey = key;
            CacheVal = val;
        }
    }
    
    public int Capacity = 0;
    public LinkedList<Cache> lruList = new LinkedList<Cache>();
    public Dictionary<int, LinkedListNode<Cache>> dic = new Dictionary<int, LinkedListNode<Cache>>();
        
    public LRUCache(int capacity) {
        this.Capacity = capacity;
    }
    
    public int Get(int key) {
        if(!dic.ContainsKey(key))
            return -1;
        
        return update(key);
    }
    
    public void Put(int key, int value) {
        if(dic.ContainsKey(key))
        {
            dic[key].Value.CacheVal = value;
            update(key);
        }
        else
        {   
            // add a new cache to the dic and lru
            Cache cache = new Cache(key, value);
            dic.Add(key, new LinkedListNode<Cache>(cache));
            lruList.AddFirst(dic[key]);
            
            if(dic.Count > Capacity)
            {
                LinkedListNode<Cache> lastCache = lruList.Last;
                dic.Remove(lastCache.Value.CacheKey);
                lruList.Remove(lastCache);
            }  
        } 
    }
    
    private int update(int key){
        var cache = dic[key];
        lruList.Remove(cache);
        lruList.AddFirst(cache);
        
        return cache.Value.CacheVal;
    }
}

// Accepted - without using inbuilt LinkedList
public class LRUCacheCustom {
    Dictionary<int, Node> cache;
    Node first, last;
    int size;

    public LRUCacheCustom(int capacity) {
        size = capacity;
        cache = new Dictionary<int, Node>();
        first = null;
        last = null;
    }
    
    public int Get(int key) {
        if(!cache.ContainsKey(key)) return -1;
        MarkAsMostRecent(key);
        // PrintCache($"Get {key}");
        return cache[key].val;
    }
    
    public void Put(int key, int value) {
        // upsert the current key in cache
        if(cache.ContainsKey(key)) cache[key].val = value;
        else cache[key] = new Node(key, value);

        MarkAsMostRecent(key);
        EvictLRU();
        // PrintCache($"Put {key}");
    }

    private bool EvictLRU(){
        if(cache.Count <= size) return false;

        cache.Remove(first.key);
        if(first.right != null) first.right.left = null;
        first = first.right;
        return true;
    }

    private void MarkAsMostRecent(int key){
        var node = cache[key];
        if(last == node) return;    // already most recent

        if(first == node) first = first.right;

        // remove node from its position
        if(node.left != null) node.left.right = node.right;
        if(node.right != null) node.right.left = node.left;

        // add node to end (most recently used)
        if(last != null) last.right = node;
        node.left = last;
        node.right = null;
        
        // update last and first node pointers
        last = node;
        if(first == null) first = node;
    }

    private void PrintCache(string operation){
        var curr = first;
        Console.Write($"{operation} : ");
        while(curr != null){
            Console.Write($"{curr.key}-{curr.val}, ");
            curr = curr.right;
        }
        Console.WriteLine();
    }
}

public class Node{
    public int key;
    public int val;
    public Node left;
    public Node right;

    public Node(){}
    public Node(int k, int v){
        this.key = k;
        this.val = v;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */