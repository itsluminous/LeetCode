# idea in both approach is that if there are n rabbits who answer same number
# then, we can make (n / num+1) groups + (n % num+1) groups with remaining rabbits
# and in each group we will have num+1 rabbits, so count would be group * num+1

# O(n)
class Solution:
    def numRabbits(self, answers: List[int]) -> int:
        freq = defaultdict(int)
        for ans in answers:
            freq[ans] += 1

        rabbits = 0
        for curr in freq:
            currCount = freq[curr]
            groups = (currCount + curr) // (curr + 1)  # equivalent of Math.ceil
            rabbits += groups * (curr + 1)

        return rabbits


# Accepted : O(n log(n))
class SolutionSort:
    def numRabbits(self, answers: List[int]) -> int:
        answers.sort()
        rabbits = 0
        
        i = 0
        while i < len(answers):
            curr = answers[i]
            currCount = 1
            i += 1
            while i < len(answers) and answers[i] == curr:
                i += 1
                currCount += 1

            groups = (currCount + curr) // (curr + 1)  # equivalent of Math.ceil
            rabbits += groups * (curr + 1)

        return rabbits