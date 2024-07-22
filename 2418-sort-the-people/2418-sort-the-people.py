class Solution:
    def sortPeople(self, names: List[str], heights: List[int]) -> List[str]:
        n = len(names)
        dic = {}
        for i in range(n):
            dic[heights[i]] = names[i]

        heights.sort(reverse=True)
        for i in range(n):
            names[i] = dic[heights[i]]

        return names
        