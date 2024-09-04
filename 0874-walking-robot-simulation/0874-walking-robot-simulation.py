class Solution:
    def robotSim(self, commands: List[int], obstacles: List[List[int]]) -> int:
        obs = set()
        for ob in obstacles:
            obs.add(f"{ob[0]}:{ob[1]}")

        dirs = [[0, 1], [1, 0], [0, -1], [-1, 0]]
        maxDist = dirIdx = x = y = 0
        for cmd in commands:
            if cmd == -1:
                dirIdx = (dirIdx + 1) % 4
            elif cmd == -2:
                dirIdx -= 1
                if dirIdx == -1: dirIdx = 3
            else:
                for _ in range(cmd):
                    newX = x + dirs[dirIdx][0]
                    newY = y + dirs[dirIdx][1]
                    if f"{newX}:{newY}" in obs: break
                    x, y = newX, newY
                currDist = x*x + y*y
                maxDist = max(maxDist, currDist)

        return maxDist