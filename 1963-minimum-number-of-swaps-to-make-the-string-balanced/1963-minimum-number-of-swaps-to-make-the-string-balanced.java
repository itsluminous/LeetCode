// the trick is that no. of swaps needed will always be no. of mismatches / 2
// https://assets.leetcode.com/users/images/0731629f-ae07-4507-bfc4-a7b1bea289b6_1628395785.653253.png
class Solution {
    public int minSwaps(String s) {
        var mismatch = 0;
        for(var ch : s.toCharArray()){
            if(ch == '[')
                mismatch++;
            else if(mismatch > 0) 
                mismatch--;
        }
        return (mismatch + 1) / 2;
    }
}