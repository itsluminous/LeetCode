# O(n) approach using Hashmap/Dictionary

# 1. Keep a variable called runningSum
# 2. Keep a Hashmap called seen which will store index of first time a runningSum was seen
# 3. set runningSum[0] = -1. meaning, that without picking any element, running sum is 0.
# 4. Start traversing the array
# 5. Everytime you encounter a 0, subtract 1, and when you encounter 1, then add 1 to the runningSum
# 6. If the current runningSum exists in dictionary, then it means that all zeroes and ones between current index and the first time we saw this runningSum are equal. Update max length if (currIdx - seen.get(runningSum) > max length)
# 7. If the current runningSum does not exists in dictionary, then add it with current index as value
# 8. At the end of loop, you will have answer

class Solution:
    def findMaxLength(self, nums: List[int]) -> int:
        n = len(nums)
        running_sum = 0
        max_len = 0
        seen = {0: -1}

        for i in range(n):
            running_sum += -1 if nums[i] == 0 else 1

            if running_sum in seen:
                last_seen = seen[running_sum]
                max_len = max(max_len, i - last_seen)
            else:
                seen[running_sum] = i

        return max_len