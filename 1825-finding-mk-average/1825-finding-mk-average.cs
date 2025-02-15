public class MKAverage {
    int m, k;
    int runningSum, midSize;
    List<int> nums;
    CustomSortedList left, mid, right;

    public MKAverage(int m, int k) {
        this.m = m;
        this.k = k;

        // nums array to save stream
        nums = new List<int>();
        midSize = m - 2 * k;
        runningSum = 0;

        // 3 lists to track small and large numbers which will be removed, and remaining nums in mid
        // size of left = mid + right = m
        left = new CustomSortedList();
        mid = new CustomSortedList();
        right = new CustomSortedList();
    }
    
    public void AddElement(int num) {
        // remove first element which falls outside m-window
        if(nums.Count >= m){
            var idx = nums.Count - m;
            Remove(nums[idx]);
        }
            
        Add(num);
        nums.Add(num);
    }
    
    public int CalculateMKAverage() {
        if(nums.Count < m)
            return -1;
        return runningSum / midSize;
    }

    private void Remove(int num){
        if(num <= left.Max)
            left.Remove(num);
        else if(num <= mid.Max){
            mid.Remove(num);
            runningSum -= num;
        }
        else
            right.Remove(num);
        
        // rebalance such that left & mid always have required size
        // why? because we are going to call Add() after Remove()
        // which will get addded to left first, then move to mid, then right, based on where it fits
        // so all 3 will finally be right sized
        if(left.Count < k){
            var moved = Move(mid, left, true);
            runningSum -= moved;
        }

        if(mid.Count < midSize) {
            var moved = Move(right, mid, true);
            runningSum += moved;
        }
    }

    private int Move(CustomSortedList from, CustomSortedList to, bool min){
        var num = min ? from.Min : from.Max;
        from.Remove(num);
        to.Add(num);
        return num;
    }

    private void Add(int num){
        // add to left one, then rebalance
        left.Add(num);

        if(left.Count > k){
            var moved = Move(left, mid, false);
            runningSum += moved;
        }

        if(mid.Count > midSize){
            var moved = Move(mid, right, false);
            runningSum -= moved;
        }
    }
}

public class CustomSortedList {
    Dictionary<int, int> freq;
    SortedSet<int> uniq;
    public int Count;

    public CustomSortedList(){
        freq = new Dictionary<int, int>();
        uniq = new SortedSet<int>();
    }

    public void Add(int num){
        if(freq.ContainsKey(num))
            freq[num]++;
        else{
            freq[num] = 1;
            uniq.Add(num);
        }
        Count++;
    }

    public void Remove(int num){
        if(!freq.ContainsKey(num))
            return;
        
        if(freq[num] > 1)
            freq[num]--;
        else {
            freq.Remove(num);
            uniq.Remove(num);
        }
        Count--;
    }

    public int Max => uniq.Max;
    public int Min => uniq.Min;
}

/**
 * Your MKAverage object will be instantiated and called as such:
 * MKAverage obj = new MKAverage(m, k);
 * obj.AddElement(num);
 * int param_2 = obj.CalculateMKAverage();
 */