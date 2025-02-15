class MKAverage {
    int m, k;
    int runningSum, midSize;
    List<Integer> nums;
    CustomSortedList left, mid, right;

    public MKAverage(int m, int k) {
        this.m = m;
        this.k = k;

        // nums array to save stream
        nums = new ArrayList<>();
        midSize = m - 2 * k;
        runningSum = 0;

        // 3 lists to track small and large numbers which will be removed, and remaining nums in mid
        // size of left = mid + right = m
        left = new CustomSortedList();
        mid = new CustomSortedList();
        right = new CustomSortedList();
    }
    
    public void addElement(int num) {
        // remove first element which falls outside m-window
        if(nums.size() >= m){
            var idx = nums.size() - m;
            remove(nums.get(idx));
        }
            
        add(num);
        nums.add(num);
    }
    
    public int calculateMKAverage() {
        if(nums.size() < m)
            return -1;
        return runningSum / midSize;
    }

    private void remove(int num){
        if(num <= left.getMax())
            left.remove(num);
        else if(num <= mid.getMax()){
            mid.remove(num);
            runningSum -= num;
        }
        else
            right.remove(num);
        
        // rebalance such that left & mid always have required size
        // why? because we are going to call add() after remove()
        // which will get addded to left first, then move to mid, then right, based on where it fits
        // so all 3 will finally be right sized
        if(left.size() < k){
            var moved = move(mid, left, true);
            runningSum -= moved;
        }

        if(mid.size() < midSize) {
            var moved = move(right, mid, true);
            runningSum += moved;
        }
    }

    private int move(CustomSortedList from, CustomSortedList to, boolean min){
        var num = min ? from.getMin() : from.getMax();
        from.remove(num);
        to.add(num);
        return num;
    }

    private void add(int num){
        // add to left one, then rebalance
        left.add(num);

        if(left.size() > k){
            var moved = move(left, mid, false);
            runningSum += moved;
        }

        if(mid.size() > midSize){
            var moved = move(mid, right, false);
            runningSum -= moved;
        }
    }
}

public class CustomSortedList {
    private Map<Integer, Integer> freq;
    private SortedSet<Integer> uniq;
    private int count;

    public CustomSortedList() {
        freq = new HashMap<>();
        uniq = new TreeSet<>();
        count = 0;
    }

    public void add(int num){
        freq.put(num, freq.getOrDefault(num, 0) + 1);
        uniq.add(num);
        count++;
    }

    public void remove(int num){
        if(!freq.containsKey(num))
            return;
        
        if(freq.get(num) > 1)
            freq.put(num, freq.get(num) - 1);
        else {
            freq.remove(num);
            uniq.remove(num);
        }
        count--;
    }

    public int getMax() {
        return uniq.last();
    }

    public int getMin() {
        return uniq.first();
    }

    public int size() {
        return count;
    }
}

/**
 * Your MKAverage object will be instantiated and called as such:
 * MKAverage obj = new MKAverage(m, k);
 * obj.addElement(num);
 * int param_2 = obj.calculateMKAverage();
 */