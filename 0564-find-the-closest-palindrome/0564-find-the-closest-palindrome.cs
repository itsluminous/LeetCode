public class Solution {
    public string NearestPalindromic(string n) {
        var len = n.Length;
        if(len == 1)
            return (int.Parse(n) - 1).ToString();
        
        var mid = (len + 1) / 2;
        var firstHalf = long.Parse(n.Substring(0, mid));
        var input = long.Parse(n);

        var nearestPalindromes = new List<long>();
        nearestPalindromes.Add(HalfToPalindrome(firstHalf, len % 2 == 0));      // mirror first half
        nearestPalindromes.Add(HalfToPalindrome(firstHalf + 1, len % 2 == 0));  // mirror first half + 1
        nearestPalindromes.Add(HalfToPalindrome(firstHalf - 1, len % 2 == 0));  // mirror first half - 1
        nearestPalindromes.Add((long)Math.Pow(10, len - 1) - 1);                // eg. 99999
        nearestPalindromes.Add((long)Math.Pow(10, len) + 1);                    // eg. 100001

        long diff = long.MaxValue, ans = 0;
        foreach(var num in nearestPalindromes){
            if(num == input) continue;  // can't have same number as input
            var currDiff = Math.Abs(num - input);
            if(currDiff < diff){        // pick the palindrome with smallest diff from original
                diff = currDiff;
                ans = num;
            }
            else if(currDiff == diff)
                ans = Math.Min(ans, num);   // pick the smallest palindrome
        }

        return ans.ToString();
    }

    private long HalfToPalindrome(long left, bool even){
        long res = left;
        if(!even) left /= 10;
        while(left > 0){
            res = res * 10 + (left % 10);
            left /= 10;
        }
        return res;
    }
}