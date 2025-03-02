class Solution:
    def largestInteger(self, nums: List[int], k: int) -> int:
        MAX = 50
        freq = [0] * (MAX+1)
        
        for l in range(0, len(nums) - k + 1):
            uniq = set()
            for r in range(l, l+k):
                uniq.add(nums[r])
            
            for num in uniq:
                freq[num] += 1
                
        for i in range(MAX, -1, -1):
            if freq[i] == 1:
                return i
        
        return -1