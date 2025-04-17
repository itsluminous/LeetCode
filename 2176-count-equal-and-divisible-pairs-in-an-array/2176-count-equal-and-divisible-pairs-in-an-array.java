// Brute Force
class Solution {
    public int countPairs(int[] nums, int k) {
        var count = 0;
        for(var i=0; i < nums.length; i++)
            for(var j=i+1; j < nums.length; j++)
                if(nums[i] == nums[j] && i*j % k == 0)
                    count++;

        return count;
    }
}

// Accepted - first group same numbers together, then check divisibility
class SolutionMap {
    public int countPairs(int[] nums, int k) {
        List<Integer>[] sameIdx = new ArrayList[101];
        for(var i=0; i<101; i++) sameIdx[i] = new ArrayList<>();

        for(var i=0; i<nums.length; i++)
            sameIdx[nums[i]].add(i);

        var count = 0;
        for(var indexes : sameIdx){
            if(indexes.size() < 2) continue;
            for(var i=0; i<indexes.size(); i++)
                for(var j=i+1; j<indexes.size(); j++)
                    if((indexes.get(i) * indexes.get(j)) % k == 0)
                        count++;
        }

        return count;
    }
}