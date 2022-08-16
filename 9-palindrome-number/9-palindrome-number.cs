public class Solution {
    public bool IsPalindrome(int x) {
        // negative nums & nums ending with 0 can never be palindrome
        if(x < 0 || (x % 10 == 0 && x!= 0)) return false;    
        
        var rev = 0;    // reverse only half the number and then compare the two halves
        while(x > rev){
            rev = rev * 10 + x % 10;
            x /= 10;
        }
        
        return x == rev || x == rev/10;
    }
}

// Accepted : by using string conversion
public class Solution1 {
    public bool IsPalindrome(int x) {
        // negative nums & nums ending with 0 can never be palindrome
        if(x < 0 || (x % 10 == 0 && x!= 0)) return false;    
        
        var str = x.ToString();
        var n = str.Length;
        for(var i=0; i<n/2; i++)
            if(str[i] != str[n-i-1]) return false;
        return true;
    }
}