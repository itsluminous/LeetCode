// 3^19 is last number less than 2^31, so we don't have to check beyond that
// 3^19 = 3^x * 3^(19-x)
// if n is power of 3, then 3^19 = k * n
// since 3 is prime, k and n both should be power of 3, so they should be 3^x & 3^(19-x)
public class Solution {
    public bool IsPowerOfThree(int n) {
        if(n < 0) return false;
        return (Math.Pow(3, 19) % n) == 0;
    }
}

// Accepted - O(20)
public class Solution1 {
    public bool IsPowerOfThree(int n) {
        if(n < 0) return false;
        while (n % 3 == 0)  n /= 3;
        return n == 1;
    }
}

// Accepted - O(20)
public class Solution2 {
    public bool IsPowerOfThree(int n) {
        if(n < 0) return false;
        for(var p=0; p<20; p++){
            var num = Math.Pow(3, p);
            if(num > n) break;
            if(num == n) return true;
        }
        return false;
    }
}