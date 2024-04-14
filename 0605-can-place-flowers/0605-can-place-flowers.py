class Solution:
    def canPlaceFlowers(self, flowerbed: List[int], n: int) -> bool:
        ln = len(flowerbed)
        i = 0
        while i<ln and n>0:
            if flowerbed[i] == 1: i+=1
            elif i == ln-1 or flowerbed[i+1] == 0:
                n,i = n-1, i+1
            i += 1
        return n == 0