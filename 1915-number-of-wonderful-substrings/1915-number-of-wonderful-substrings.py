class Solution:
    def wonderfulSubstrings(self, word: str) -> int:
        # create array to keep track of how many times we have seen a given mask
        # 2^10 because we can have max 10 chars in a string, so if all chars are odd, then all bits are 1
        freq = [0] * 1024
        freq[0] = 1  # 0 will be string with no chars at all
        
        result = 0  # 0 wonderful substrings at start
        mask = 0    # no odd characters at starting
        for ch in word:
            mask ^= self.maskOf(ch)  # flip the bit corresponding to current char. If it was odd, it becomes even and so on
            
            # if we have seen this mask in past, then chars between that posn and current are all even
            # so it is a valid wonderful substring, hence we increase result
            # freq[mask] will be 0 if we have not seen this mask earlier
            result += freq[mask]
            
            # even count is taken care of. now we need to consider case where one char is odd
            # so for each char in current mask, we will flip it one by one, and check if we have seen the mask earlier
            # if we have seen it, then it means that the char we flipped will be odd, and others even
            for curr in range(ord('a'), ord('j')+1):
                maskToCheck = mask ^ self.maskOf(chr(curr))
                result += freq[maskToCheck]
            
            # now we have to update freq to say that we have seen the current mask
            freq[mask] += 1
        
        return result

    def maskOf(self, ch: str) -> int:
        # we start with a mask of 10 bits 0000000001
        # the we shift "1" as many times as the char position
        # so for 'a' we shift 0 times, for b shift once, and so on...
        # final mask of "d" should be "0000001000"
        val = ord(ch) - ord('a')
        return 1 << val
