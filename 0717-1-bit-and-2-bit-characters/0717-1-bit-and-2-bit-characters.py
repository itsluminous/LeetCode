class Solution:
    def isOneBitCharacter(self, bits: List[int]) -> bool:
        i = 0
        while i < len(bits) - 1:
            # if digit starts with 1, we need 2 characters 
            i += 1 + bits[i]  
        
        return i == len(bits) - 1