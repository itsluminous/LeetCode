class Solution {
    public int[] relativeSortArray(int[] arr1, int[] arr2) {
        var freq = new int[1001];

        // find freq of each number in arr1
        for(var num : arr1)
            freq[num]++;
        
        // put all matching nums from arr2 in final ans
        var pos = 0;
        for(var num : arr2){
            var count = freq[num];
            freq[num] = 0;
            for(var i=0; i<count; i++)
                arr1[pos++] = num;
        }

        // sort remaining nums and put in ans
        for(var num=0; num<1001; num++){
            var count = freq[num];
            for(var i=0; i<count; i++)
                arr1[pos++] = num;
        }

        return arr1;
    }
}