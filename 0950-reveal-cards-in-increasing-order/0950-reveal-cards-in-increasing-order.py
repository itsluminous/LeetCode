# Accepted - using queue
class Solution:
    def deckRevealedIncreasing(self, deck: List[int]) -> List[int]:
        n = len(deck)
        deck.sort()

        queue = deque()
        for i in range(n):
            queue.append(i)
        
        ans = [0] * n
        for i in range(n):
            idx = queue.popleft()
            ans[idx] = deck[i]
            if queue:
                queue.append(queue.popleft())
        
        return ans

# Accepted - using 2 pointers
class SolutionTwoPointers:
    def deckRevealedIncreasing(self, deck: List[int]) -> List[int]:
        n = len(deck)
        deck.sort()
        ans = [0] * n

        skip = False
        ans_idx = 0
        deck_idx = 0

        while deck_idx < n:
            if ans[ans_idx] == 0:
                if not skip:
                    ans[ans_idx] = deck[deck_idx]
                    deck_idx += 1
                skip = not skip
            ans_idx = (ans_idx + 1) % n
        
        return ans