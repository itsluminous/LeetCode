class Solution {
    public boolean checkIfExist(int[] arr) {
        var nums = new HashSet<Integer>();
        for(var num : arr){
            if(nums.contains(num * 2)) return true;
            if((num & 1) == 0 && nums.contains(num / 2)) return true;
            nums.add(num);
        }
        return false;
    }
}