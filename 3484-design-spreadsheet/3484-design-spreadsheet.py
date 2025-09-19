class Spreadsheet:

    def __init__(self, rows: int):
        self.sheet = {}

    def setCell(self, cell: str, value: int) -> None:
        self.sheet[cell] = value

    def resetCell(self, cell: str) -> None:
        self.sheet[cell] = 0

    def getValue(self, formula: str) -> int:
        refs = formula[1:].split('+')
        return self.mapToValue(refs[0]) + self.mapToValue(refs[1])
    
    def mapToValue(self, s: str) -> int:
        if s[0].isdigit(): return int(s)
        return self.sheet.get(s, 0)


# Your Spreadsheet object will be instantiated and called as such:
# obj = Spreadsheet(rows)
# obj.setCell(cell,value)
# obj.resetCell(cell)
# param_3 = obj.getValue(formula)