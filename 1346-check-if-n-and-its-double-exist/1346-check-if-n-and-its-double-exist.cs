public class Solution {
    public bool CheckIfExist(int[] arr) {
        var nums = new HashSet<int>();
        foreach(var num in arr){
            if(nums.Contains(num * 2)) return true;
            if((num & 1) == 0 && nums.Contains(num / 2)) return true;
            nums.Add(num);
        }
        return false;
    }
}