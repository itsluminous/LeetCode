public class FreqStack {
    
    Dictionary<int,int> numToFreq;
    Dictionary<int,Stack<int>> freqToNum;
    int maxFreq;

    public FreqStack() {
        numToFreq = new Dictionary<int,int>();
        freqToNum = new Dictionary<int,Stack<int>>();
        maxFreq = 0;
    }
    
    public void Push(int val) {
        // increment freq of this number
        if(!numToFreq.ContainsKey(val)) numToFreq[val] = 0;
        numToFreq[val]++;
        var freq = numToFreq[val];
        
        // recalculate max freq at this point
        maxFreq = Math.Max(maxFreq, freq);
        
        // add current num to stack of numbers matching this freq
        if(!freqToNum.ContainsKey(freq)) freqToNum[freq] = new Stack<int>();
        freqToNum[freq].Push(val);
    }
    
    public int Pop() {
        // get most recent number with max freq
        var num = freqToNum[maxFreq].Pop();
        if(freqToNum[maxFreq].Count == 0) maxFreq--;
        
        // reduce the freq of that number
        numToFreq[num]--;
        return num;
    }
}

/**
 * Your FreqStack object will be instantiated and called as such:
 * FreqStack obj = new FreqStack();
 * obj.Push(val);
 * int param_2 = obj.Pop();
 */