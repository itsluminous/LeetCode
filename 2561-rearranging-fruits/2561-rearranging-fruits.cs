public class Solution {
    public long MinCost(int[] basket1, int[] basket2) {
        var freq = new Dictionary<int, int>();
        var minVal = int.MaxValue;

        // increase freq count for basket1
        foreach(var b in basket1){
            if(!freq.ContainsKey(b)) freq[b] = 0;
            freq[b]++;
            minVal = Math.Min(minVal, b);
        }
        // decrease freq count for basket2
        foreach(var b in basket2){
            if(!freq.ContainsKey(b)) freq[b] = 0;
            freq[b]--;
            minVal = Math.Min(minVal, b);
        }

        // find out elements that need swapping
        var swp = new List<int>();
        foreach(var k in freq.Keys){
            var count = freq[k];
            if((count & 1) == 1) return -1; // impossible to match odd count

            // the elements left in freq map need to be swapped
            count = Math.Abs(count);
            for(var i=0; i < count/2; i++)
                swp.Add(k);
        }

        // we ideally will swap all big elements with all small elements
        // but sometimes it is cheaper to swap minVal to and fro in both arrays with element1 and element2
        swp.Sort();
        long ans = 0;
        for(var i=0; i<swp.Count/2; i++)
            ans += Math.Min(swp[i], minVal * 2);
        
        return ans;
    }
}