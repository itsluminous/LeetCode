class Solution:
    def asteroidCollision(self, asteroids: List[int]) -> List[int]:
        stack = []
        for a in asteroids:
            explode = False
            while a < 0 and stack and not explode:
                if stack[-1] < 0: break
                if stack[-1] > abs(a):
                    explode = True
                    break
                top = stack.pop()
                if top == abs(a): explode = True
            if not explode: stack.append(a)
        return stack