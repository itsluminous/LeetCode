class Solution {
    public:
    int findComplement(int num) {
        // step 1 : get a mask which has all bits set to 1 (starting from first 1 bit)
        // so mask for num 0000101001 will be 0000111111
        auto mask = getMask(num);

        // step 2 : xor the mask with num, so that only bits originally 0 will be set
        return num ^ mask;
    }

    private:
    int getMask(int num){
        auto mask = num;
        // Copy the highest 1-bit onto all the lower bits
        while(num != 0){
            num >>= 1;
            mask |= num;
        }
        return mask;
    }

    private:
    int getMaskAlt(int num){
        // Copy the highest 1-bit onto all the lower bits
        auto mask = num;     // Eg. num = 0000101001
        mask |= mask >> 1;  // 0000111001
        mask |= mask >> 2;  // 0000111101
        mask |= mask >> 4;  // 0000111111
        mask |= mask >> 8;  // 0000111111
        mask |= mask >> 16; // 0000111111
        
        return mask;
    }
};