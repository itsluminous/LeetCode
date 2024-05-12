class Solution:
    def maximumEnergy(self, energy: List[int], k: int) -> int:
        maxEnergy, n = -1111, len(energy)
        for p in range(n-1, n-k-1, -1):
            curr = 0
            for i in range(p, -1, -k):
                curr += energy[i]
                maxEnergy = max(maxEnergy, curr)
        return maxEnergy