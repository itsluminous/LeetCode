class FindSumPairs:

    def __init__(self, nums1: List[int], nums2: List[int]):
        nums1.sort()
        self.freq1 = dict() # maintains insertion order in python
        for num in nums1:
            self.freq1[num] = self.freq1.get(num, 0) + 1

        self.nums2 = nums2
        self.freq2 = defaultdict(int)
        for num in nums2:
            self.freq2[num] += 1

    def add(self, index: int, val: int) -> None:
        num = self.nums2[index]
        if self.freq2[num] == 1:
            del self.freq2[num]
        else:
            self.freq2[num] -= 1

        num += val
        self.nums2[index] = num
        self.freq2[num] += 1

    def count(self, tot: int) -> int:
        ans = 0
        for num in self.freq1:
            if num >= tot: break    # can't find match beyond this
            if tot - num in self.freq2:
                ans += self.freq1[num] * self.freq2[tot - num]
        return ans


# Your FindSumPairs object will be instantiated and called as such:
# obj = FindSumPairs(nums1, nums2)
# obj.add(index,val)
# param_2 = obj.count(tot)