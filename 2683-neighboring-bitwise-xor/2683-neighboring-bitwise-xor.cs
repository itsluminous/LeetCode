// if original was [a,b,c,d,e] then derived is [a ^ b, b ^ c, c ^ d, d ^ e, e ^ a]
// xor of all derived should be 0 : a ^ b ^ b ^ c ^ c ^ d ^ d ^ e ^ e ^ a = 0
// hence, if xor = 0, then we can form original array
public class Solution {
    public bool DoesValidArrayExist(int[] derived) {
        var xor = 0;
        foreach(var num in derived)
            xor ^= num;
        
        return xor == 0;
    }
}

// The XOR of two binary digits is equal to their sum modulo 2
public class SolutionSum {
    public bool DoesValidArrayExist(int[] derived) {
        var sum = derived.Sum();
        return sum % 2 == 0;
    }
}