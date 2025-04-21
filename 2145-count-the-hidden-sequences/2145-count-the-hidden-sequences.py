class Solution:
    def numberOfArrays(self, differences: List[int], lower: int, upper: int) -> int:
        n = len(differences)
        allowedGap = upper - lower
        
        num = smallest = largest = 0
        for diff in differences:
            num += diff
            smallest = min(smallest, num)
            largest = max(largest, num)
            if largest - smallest > allowedGap: return 0

        return 1 + allowedGap - (largest - smallest)