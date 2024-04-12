class Solution:
    def reverse(self, x: int) -> int:
        ans = 0
        min_val, max_val = -2**31, 2**31 - 1

        while x != 0:
            # modulo operator % does not behave like java/C# in python for negative numbers
            digit = x % 10 if x >= 0 else (abs(x) % 10)*-1
            x = x // 10 if x >=0 else math.ceil(x / 10)
            ans = ans * 10 + digit

            if ans > max_val or ans < min_val: return 0

        return ans