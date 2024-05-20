class Solution {
    public String intToRoman(int num) {
        var map = GetNumberToRomanMap();

        var sb = new StringBuilder();
        for(var pair : map.entrySet()){
            while(num >= pair.getKey()){
                sb.append(pair.getValue());
                num -= pair.getKey();
            }
        }

        return sb.toString();
    }

    private Map<Integer, String> GetNumberToRomanMap(){
        var map = new LinkedHashMap<Integer, String>();
        map.put(1000, "M");
        map.put(900, "CM");
        map.put(500, "D");
        map.put(400, "CD");
        map.put(100, "C");
        map.put(90, "XC");
        map.put(50, "L");
        map.put(40, "XL");
        map.put(10, "X");
        map.put(9, "IX");
        map.put(5, "V");
        map.put(4, "IV");
        map.put(1, "I");

        return map;
    }
}