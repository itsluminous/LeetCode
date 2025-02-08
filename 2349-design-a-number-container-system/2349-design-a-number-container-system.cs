public class NumberContainers {
    Dictionary<int, SortedSet<int>> numIdx; // sorted list of indexes for each num
    Dictionary<int, int> idxNum;            // which no. is present at given idx

    public NumberContainers() {
        numIdx = new();
        idxNum = new();
    }
    
    public void Change(int index, int number) {
        // do nothing if same no. already exists at this idx 
        if(idxNum.ContainsKey(index) && idxNum[index] == number) return;

        // remove curr index from prev num list
        if(idxNum.ContainsKey(index)){
            var prevNum = idxNum[index];
            numIdx[prevNum].Remove(index);    
        }
        
        // initialize numIdx value if we are seeing this no. for first time
        if(!numIdx.ContainsKey(number))
            numIdx[number] = new();
        
        // add curr index to number's index list, and vice versa
        numIdx[number].Add(index);
        idxNum[index] = number;
    }
    
    public int Find(int number) {
        if(!numIdx.ContainsKey(number) || numIdx[number].Count == 0)
            return -1;
        
        return numIdx[number].Min;
    }
}

/**
 * Your NumberContainers object will be instantiated and called as such:
 * NumberContainers obj = new NumberContainers();
 * obj.Change(index,number);
 * int param_2 = obj.Find(number);
 */