public class FindSumPairs {
    int[] nums2;
    SortedDictionary<int, int> freq1;
    Dictionary<int, int> freq2;

    public FindSumPairs(int[] nums1, int[] nums2) {
        freq1 = new();
        foreach(var num in nums1)
            if(freq1.ContainsKey(num)) freq1[num]++;
            else freq1[num] = 1;
        
        this.nums2 = nums2;
        freq2 = new();
        foreach(var num in nums2)
            if(freq2.ContainsKey(num)) freq2[num]++;
            else freq2[num] = 1;
    }
    
    public void Add(int index, int val) {
        var num = nums2[index];
        if(freq2[num] == 1) freq2.Remove(num);
        else freq2[num]--;

        num += val;
        nums2[index] += val;
        if(freq2.ContainsKey(num)) freq2[num]++;
        else freq2[num] = 1;
    }
    
    public int Count(int tot) {
        var ans = 0;
        foreach(var num in freq1.Keys){
            if(num >= tot) break;   // can't find match beyond this
            if(!freq2.ContainsKey(tot - num)) continue;
            ans += freq1[num] * freq2[tot - num];
        }
        return ans;
    }
}

/**
 * Your FindSumPairs object will be instantiated and called as such:
 * FindSumPairs obj = new FindSumPairs(nums1, nums2);
 * obj.Add(index,val);
 * int param_2 = obj.Count(tot);
 */