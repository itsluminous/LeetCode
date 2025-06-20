class Solution:
    def maxDistance(self, s: str, k: int) -> int:
        max_dist = 0
        direction_map = {
            'N': (0, 1),
            'S': (0, -1),
            'E': (1, 0),
            'W': (-1, 0)
        }

        x = y = 0  # track cumulative x and y movement
        for i, dir in enumerate(s):
            dx, dy = direction_map[dir]
            x += dx
            y += dy

            # calculate manhattan distance without changing anything
            curr_dist = abs(x) + abs(y)

            # if i <= k then all dirs can be pointed to one diagonal, so max_dist = i+1
            # if i > k, then we can change k directions only.
            # Each change will have double impact, because it removes one wrong dir and adds one right dir
            curr_dist = min(i + 1, curr_dist + 2 * k)
            max_dist = max(max_dist, curr_dist)

        return max_dist