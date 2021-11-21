public class RangeFreqQuery {
    Dictionary<int,List<int>> dict;
    
    public RangeFreqQuery(int[] arr) {
        dict = new Dictionary<int,List<int>>();
        for(int i=0; i<arr.Length; i++){
            if(dict.ContainsKey(arr[i]))
                dict[arr[i]].Add(i);
            else
                dict[arr[i]] = new List<int>(){i};
        }
    }
    
    public int Query(int left, int right, int value) {
        if(!dict.ContainsKey(value)) return 0;
        
        var lst = dict[value];
        var l = lst.BinarySearch(left);
        var r = lst.BinarySearch(right);
        // suppose you are searching 4 in the list 1,2,3,5. BinarySearch will return -4 
        // to find element >= 4, (-4+1)*-1 which is equal to index 3, i.e. value 5
        // to find element <= 4, (-4+2)*-1 which is equal to index 2, i.e. value 3
        if(l<0) l=(l+1)*(-1);
        if(r<0) r=(r+2)*(-1);
        return r-l+1;
    }
}

// TLE - O(n)
public class RangeFreqQuery1 {
    int[] ar;
    public RangeFreqQuery1(int[] arr) {
        ar = arr;
    }
    
    public int Query(int left, int right, int value) {
        var freq = 0;
        for(int i=left; i<=right; i++){
            if(ar[i] == value) freq++;
        }
        return freq;
    }
}

/**
 * Your RangeFreqQuery object will be instantiated and called as such:
 * RangeFreqQuery obj = new RangeFreqQuery(arr);
 * int param_1 = obj.Query(left,right,value);
 */