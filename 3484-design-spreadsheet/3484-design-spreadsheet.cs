public class Spreadsheet {
    private Dictionary<string, int> sheet;

    public Spreadsheet(int rows) {
        sheet = new();
    }
    
    public void SetCell(string cell, int value) {
        sheet[cell] = value;
    }
    
    public void ResetCell(string cell) {
        sheet[cell] = 0;
    }
    
    public int GetValue(string formula) {
        var refs = formula.Substring(1).Split('+');
        return MapToValue(refs[0]) + MapToValue(refs[1]);
    }

    private int MapToValue(string s) {
        if(char.IsDigit(s[0])) return int.Parse(s);
        return sheet.TryGetValue(s, out int value) ? value : 0;
    }
}

/**
 * Your Spreadsheet object will be instantiated and called as such:
 * Spreadsheet obj = new Spreadsheet(rows);
 * obj.SetCell(cell,value);
 * obj.ResetCell(cell);
 * int param_3 = obj.GetValue(formula);
 */