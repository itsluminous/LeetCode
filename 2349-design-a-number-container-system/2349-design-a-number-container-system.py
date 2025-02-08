class NumberContainers:

    def __init__(self):
        self.numIdx = collections.defaultdict(SortedSet)    # sorted list of indexes for each num
        self.idxNum = {}                                    # which no. is present at given idx

    def change(self, index: int, number: int) -> None:
        # do nothing if same no. already exists at this idx 
        if index in self.idxNum and self.idxNum[index] == number: return

        # remove curr index from prev num list
        if index in self.idxNum:
            prevNum = self.idxNum[index]
            self.numIdx[prevNum].remove(index)   
        
        # add curr index to number's index list, and vice versa
        self.numIdx[number].add(index)
        self.idxNum[index] = number

    def find(self, number: int) -> int:
        if number not in self.numIdx or len(self.numIdx[number]) == 0:
            return -1
        
        return self.numIdx[number][0]



# Your NumberContainers object will be instantiated and called as such:
# obj = NumberContainers()
# obj.change(index,number)
# param_2 = obj.find(number)