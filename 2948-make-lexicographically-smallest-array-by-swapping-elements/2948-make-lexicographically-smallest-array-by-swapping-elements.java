class Solution {
    public int[] lexicographicallySmallestArray(int[] nums, int limit) {
        var n = nums.length;

        // tuples of num and its index
        var numIdx = new ArrayList<int[]>();
        for(var i = 0; i < n; i++)
            numIdx.add(new int[]{nums[i], i});
        
        // sort numIdx asc based on num value
        numIdx.sort((a, b) -> a[0] - b[0]);

        // group numbers into different sets, based on their difference
        List<List<int[]>> sets = new ArrayList<>();
        sets.add(new ArrayList<>(Arrays.asList(numIdx.get(0))));
        for (var i = 1; i < n; i++) {
            if(numIdx.get(i)[0] - numIdx.get(i - 1)[0] > limit)
                sets.add(new ArrayList<>(Arrays.asList(numIdx.get(i))));   // separate set
            else
                sets.get(sets.size() - 1).add(numIdx.get(i));   // part of prev set
        }
        
        for(var sett : sets){
            // sort indexes of all elements in curr set
            List<Integer> indexes = new ArrayList<>();
            for(var num : sett) indexes.add(num[1]);
            Collections.sort(indexes);

            // now put smallest no. at smallest index, then next no. and so on
            for(var i = 0; i < indexes.size(); i++)
                nums[indexes.get(i)] = sett.get(i)[0];
        }
        
        return nums;
    }
}