// Explaination - https://leetcode.com/problems/number-complement/discuss/158120/DETAILED-EXPLANATION-Java-XOR-Method-Easy-To-Understand
public class Solution {
    public int FindComplement(int num) {
        // step 1 : get a mask which has all bits set to 1 (starting from first 1 bit)
        // so mask for num 0000101001 will be 0000111111
        var mask = GetMask(num);
        
        // step 2 : xor the mask with num, so that only bits originally 0 will be set
        return num ^ mask;
    }
    
    private int GetMask(int num){
        // Copy the highest 1-bit onto all the lower bits
        var mask = num;     // Eg. num = 0000101001
        mask |= mask >> 1;  // 0000111001
        mask |= mask >> 2;  // 0000111101
        mask |= mask >> 4;  // 0000111111
        mask |= mask >> 8;  // 0000111111
        mask |= mask >> 16; // 0000111111
        
        return mask;
    }
}