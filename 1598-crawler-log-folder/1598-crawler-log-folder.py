class Solution:
    def minOperations(self, logs: List[str]) -> int:
        depth = 0
        for cmd in logs:
            if cmd == "../" and depth > 0:
                depth -= 1
            elif cmd[0] != ".":
                depth += 1
        return depth