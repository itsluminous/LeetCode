class Spreadsheet {
    Map<String, Integer> sheet;

    public Spreadsheet(int rows) {
        sheet = new HashMap<>();
    }
    
    public void setCell(String cell, int value) {
        sheet.put(cell, value);
    }
    
    public void resetCell(String cell) {
        sheet.put(cell, 0);
    }
    
    public int getValue(String formula) {
        var refs = formula.substring(1).split("\\+");
        return mapToValue(refs[0]) + mapToValue(refs[1]);
    }

    private int mapToValue(String s) {
        if(Character.isDigit(s.charAt(0))) return Integer.parseInt(s);
        return sheet.getOrDefault(s, 0);
    }
}

/**
 * Your Spreadsheet object will be instantiated and called as such:
 * Spreadsheet obj = new Spreadsheet(rows);
 * obj.setCell(cell,value);
 * obj.resetCell(cell);
 * int param_3 = obj.getValue(formula);
 */