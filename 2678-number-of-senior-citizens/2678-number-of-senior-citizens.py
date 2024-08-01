class Solution:
    def countSeniors(self, details: List[str]) -> int:
        count = 0
        for detail in details:
            age = detail[11:13]
            if int(age) > 60: count += 1

        return count