// Cantor's Diagonal Argument
// basically, we have to form a new string of length n, and no. of items in array are also n
// so if say, i-th posn in string ensures that this string is different from i-th word
// then the final string is guaranteed to be different from all strings
public class Solution {
    public string FindDifferentBinaryString(string[] nums) {
        var ans = new StringBuilder();

        // for i-th string, assign opposite value of i-th char in that string
        // technically the char can be any random posn, not necessarily matching i
        // but we want to ensure that one posn corresponds to only one string
        // so it is easy to keep char posn same as string posn
        for(var i=0; i<nums.Length; i++){
            var ch = nums[i][i];
            ans.Append(ch == '0' ? '1' : '0');
        }

        return ans.ToString();
    }
}