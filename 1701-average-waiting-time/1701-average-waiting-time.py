class Solution:
    def averageWaitingTime(self, customers: List[List[int]]) -> float:
        n = len(customers)
        wait = time = 0
        
        for cust in customers:
            if time <= cust[0]:
                time = cust[0] + cust[1]
            else:
                time += cust[1]
            wait += (time - cust[0])

        return wait/n