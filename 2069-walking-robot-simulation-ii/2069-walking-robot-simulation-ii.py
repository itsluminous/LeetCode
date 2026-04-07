class Robot:

    def __init__(self, width: int, height: int):
        self.moved = False
        self.idx = 0
        self.pos = []
        self.dir = []
        self.toDir = {0: "East", 1: "North", 2: "West", 3: "South"}

        self.pos += [(i, 0) for i in range(width)]
        self.dir += [0] * width

        self.pos += [(width - 1, i) for i in range(1, height)]
        self.dir += [1] * (height - 1)

        self.pos += [(i, height - 1) for i in range(width - 2, -1, -1)]
        self.dir += [2] * (width - 1)

        self.pos += [(0, i) for i in range(height - 2, 0, -1)]
        self.dir += [3] * (height - 2)

        self.dir[0] = 3

    def step(self, num: int) -> None:
        self.moved = True
        self.idx = (self.idx + num) % len(self.pos)

    def getPos(self) -> List[int]:
        return self.pos[self.idx]

    def getDir(self) -> str:
        if not self.moved: return self.toDir[0] # east
        return self.toDir[self.dir[self.idx]]


# Your Robot object will be instantiated and called as such:
# obj = Robot(width, height)
# obj.step(num)
# param_2 = obj.getPos()
# param_3 = obj.getDir()