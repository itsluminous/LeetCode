public class Solution {
    public string CountOfAtoms(string formula) {
        var map = new Dictionary<string, int>();
        var stack = new Stack<Dictionary<string, int>>();
        int n = formula.Length, idx = 0;

        while(idx < n){
            var ch = formula[idx];
            if(ch == '('){
                stack.Push(map);
                map = new();
                idx++;
            }
            else if(ch == ')'){
                // find out how many times this set is repeated
                var multiplier = 0;
                while(++idx < n && char.IsDigit(formula[idx])){
                    var digit = formula[idx] - '0';
                    multiplier = multiplier*10 + digit;
                }
                if(multiplier == 0) multiplier = 1;

                // apply multiplication
                var innerMap = map;
                map = stack.Pop();  // map outside the bracket pair
                foreach(var kvp in innerMap){
                    var key = kvp.Key;
                    var innerCount = kvp.Value;
                    var outerCount = map.ContainsKey(key) ? map[key] : 0;
                    map[key] = outerCount + innerCount * multiplier;
                }
            }
            else{
                // figure out atomic element symbol
                var start = idx;
                while(++idx < n && char.IsLower(formula[idx])) continue;
                var symbol = formula.Substring(start, idx - start);

                // find out how many times this element is repeated
                var count = 0;
                while(idx < n && char.IsDigit(formula[idx])){
                    var digit = formula[idx] - '0';
                    count = count*10 + digit;
                    idx++;
                }
                if(count == 0) count = 1;

                // put the count of this element in map
                if (map.ContainsKey(symbol)) map[symbol] += count;
                else map[symbol] = count;
            }
        }

        // sort the elements in asc order
        var symbols = new List<string>(map.Keys);
        symbols.Sort();

        var sb = new StringBuilder();
        foreach(var symbol in symbols){
            sb.Append(symbol);
            if(map[symbol] > 1) sb.Append(map[symbol]);
        }
        return sb.ToString();
    }
}