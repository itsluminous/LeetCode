class Solution {
    public int minimumIndex(List<Integer> nums) {
        var n = nums.size();
        if(n < 2) return -1;

        // find the dominant number
        int domNum = nums.get(0), domCount = 0;
        for(var num : nums){
            if(num == domNum) domCount++;
            else if(domCount > 1) domCount--;
            else domNum = num;
        }

        // find dominant number's count
        domCount = 0;
        for(var num : nums)
            if(num == domNum) domCount++;

        // find the first split position
        var leftDomCount = 0;
        for(var i=0; i<n; i++){
            if(nums.get(i) == domNum)
                leftDomCount++;
            
            var leftDom = leftDomCount > (i + 1) / 2;
            var rightDom = (domCount - leftDomCount) > (n - i - 1) / 2;
            if(leftDom && rightDom) return i;
        }

        return -1;
    }
}