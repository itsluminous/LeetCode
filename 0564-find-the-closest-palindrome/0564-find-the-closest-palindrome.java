class Solution {
    public String nearestPalindromic(String n) {
        var len = n.length();
        if(len == 1)
            return Integer.toString((Integer.parseInt(n) - 1));
        
        var mid = (len + 1) / 2;
        var firstHalf = Long.parseLong(n.substring(0, mid));
        var input = Long.parseLong(n);

        var nearestPalindromes = new ArrayList<Long>();
        nearestPalindromes.add(halfToPalindrome(firstHalf, len % 2 == 0));      // mirror first half
        nearestPalindromes.add(halfToPalindrome(firstHalf + 1, len % 2 == 0));  // mirror first half + 1
        nearestPalindromes.add(halfToPalindrome(firstHalf - 1, len % 2 == 0));  // mirror first half - 1
        nearestPalindromes.add((long)Math.pow(10, len - 1) - 1);                // eg. 99999
        nearestPalindromes.add((long)Math.pow(10, len) + 1);                    // eg. 100001

        long diff = Long.MAX_VALUE, ans = 0;
        for(var num : nearestPalindromes){
            if(num == input) continue;  // can't have same number as input
            var currDiff = Math.abs(num - input);
            if(currDiff < diff){        // pick the palindrome with smallest diff from original
                diff = currDiff;
                ans = num;
            }
            else if(currDiff == diff)
                ans = Math.min(ans, num);   // pick the smallest palindrome
        }

        return String.valueOf(ans);
    }

    private long halfToPalindrome(long left, boolean even){
        long res = left;
        if(!even) left /= 10;
        while(left > 0){
            res = res * 10 + (left % 10);
            left /= 10;
        }
        return res;
    }
}