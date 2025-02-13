class Solution:
    def floodFill(self, image: List[List[int]], sr: int, sc: int, color: int) -> List[List[int]]:
        if image[sr][sc] == color: return image

        m, n = len(image), len(image[0])
        orig = image[sr][sc]
        image[sr][sc] = color

        queue = deque()
        queue.append((sr, sc))

        dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)]
        while queue:
            x, y = queue.popleft()
            for dx, dy in dirs:
                nx, ny = x + dx, y + dy
                if nx == -1 or ny == -1 or nx == m or ny == n or image[nx][ny] != orig:
                    continue
                image[nx][ny] = color
                queue.append((nx, ny))
        
        return image

