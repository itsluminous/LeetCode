// by sorting
public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if (hand.Length % groupSize != 0) return false;

        // count freq of each number
        Array.Sort(hand);
        var freq = new Dictionary<int, int>();
        foreach (var num in hand) {
            if (freq.ContainsKey(num)) freq[num]++;
            else freq[num] = 1;
        }
        
        // try to make groups of groupSize
        foreach (var num in hand) {
            if (freq[num] == 0) continue;

            for(var nmbr = num; nmbr < num+groupSize; nmbr++){
                if(!freq.ContainsKey(nmbr) || freq[nmbr] == 0) return false;
                freq[nmbr]--;
            }
        }
        return true;
    }
}

// Accepted - using dictionary
public class SolutionDict {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        var len = hand.Length;
        if(len % groupSize != 0) return false;

        // count freq of each number, sorted by groupSizeey asc
        var freq = new SortedDictionary<int, int>();
        foreach(var num in hand)
            if(!freq.TryAdd(num, 1))
                freq[num]++;

        // try to make groups of groupSize
        while(freq.Count > 0){
            var smallest = freq.First().Key;
            for(var nmbr = smallest; nmbr < smallest+groupSize; nmbr++){
                if(!freq.ContainsKey(nmbr)) return false;
                
                var val = freq[nmbr];
                if(val == 1) freq.Remove(nmbr);
                else freq[nmbr] = val - 1;
            }
        }
        
        return true;
    }
}