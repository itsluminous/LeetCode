class NumberContainers {
    HashMap<Integer, SortedSet<Integer>> numIdx;    // sorted list of indexes for each num
    HashMap<Integer, Integer> idxNum;               // which no. is present at given idx

    public NumberContainers() {
        numIdx = new HashMap<>();
        idxNum = new HashMap<>();
    }
    
    public void change(int index, int number) {
        // do nothing if same no. already exists at this idx 
        if(idxNum.containsKey(index) && idxNum.get(index) == number) return;

        // remove curr index from prev num list
        if(idxNum.containsKey(index)){
            var prevNum = idxNum.get(index);
            numIdx.get(prevNum).remove(index);    
        }
        
        // initialize numIdx value if we are seeing this no. for first time
        numIdx.putIfAbsent(number, new TreeSet<>());
        
        // add curr index to number's index list, and vice versa
        numIdx.get(number).add(index);
        idxNum.put(index, number);
    }
    
    public int find(int number) {
        if(!numIdx.containsKey(number) || numIdx.get(number).size() == 0)
            return -1;
        
        return (int)numIdx.get(number).first();
    }
}

/**
 * Your NumberContainers object will be instantiated and called as such:
 * NumberContainers obj = new NumberContainers();
 * obj.change(index,number);
 * int param_2 = obj.find(number);
 */