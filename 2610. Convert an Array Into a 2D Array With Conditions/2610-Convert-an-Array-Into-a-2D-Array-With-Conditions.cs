public class Solution {
    public IList<IList<int>> FindMatrix(int[] nums) {
        var dict = new Dictionary<int, int>();
        foreach(var num in nums){
            if(dict.ContainsKey(num))
                dict[num]++;
            else
                dict[num] = 1;
        }
        
        var numsLen = nums.Length;
        var counter = 0;
        var result = new List<IList<int>>();
        while(counter < numsLen){
            var lst = new List<int>();
            var keysLen = dict.Keys.Count;
            counter += keysLen;
            var keys = dict.Keys;
            foreach(var k in keys){
                lst.Add(k);
                dict[k] -= 1;
                if(dict[k] == 0)
                    dict.Remove(k);
            }
            result.Add(lst);
        }

        return result;
    }
}