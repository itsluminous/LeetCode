class Solution {
    public String countOfAtoms(String formula) {
        var map = new HashMap<String, Integer>();
        var stack = new Stack<HashMap<String, Integer>>();
        int n = formula.length(), idx = 0;

        while(idx < n){
            var ch = formula.charAt(idx);
            if(ch == '('){
                stack.push(map);
                map = new HashMap<>();
                idx++;
            }
            else if(ch == ')'){
                // find out how many times this set is repeated
                var multiplier = 0;
                while(++idx < n && Character.isDigit(formula.charAt(idx))){
                    var digit = formula.charAt(idx) - '0';
                    multiplier = multiplier*10 + digit;
                }
                if(multiplier == 0) multiplier = 1;

                // apply multiplication
                var innerMap = map;
                map = stack.pop();  // map outside the bracket pair
                for(var key : innerMap.keySet()){
                    var innerCount = innerMap.get(key);
                    var outerCount = map.getOrDefault(key, 0);
                    map.put(key, outerCount + innerCount * multiplier);
                }
            }
            else{
                // figure out atomic element symbol
                var start = idx;
                while(++idx < n && Character.isLowerCase(formula.charAt(idx))) continue;
                var symbol = formula.substring(start, idx);

                // find out how many times this element is repeated
                var count = 0;
                while(idx < n && Character.isDigit(formula.charAt(idx))){
                    var digit = formula.charAt(idx) - '0';
                    count = count*10 + digit;
                    idx++;
                }
                if(count == 0) count = 1;

                // put the count of this element in map
                map.put(symbol, map.getOrDefault(symbol, 0) + count);
            }
        }

        // sort the elements in asc order
        var symbols = new ArrayList<String>(map.keySet());
        Collections.sort(symbols);

        var sb = new StringBuilder();
        for(var symbol : symbols){
            sb.append(symbol);
            if(map.get(symbol) > 1) sb.append(map.get(symbol));
        }
        return sb.toString();
    }
}