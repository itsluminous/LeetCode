public class Solution {
    public int MaxProduct(string[] words) {
        var dict = new Dictionary<int, int>();  // bitmask and count of numbers having this bitmask
        var masks = new List<int>();            // list of all masks in dictionary
        
        // populate dictionary having bitmasks and cout of their occurrence
        foreach(var word in words){
            var mask = BitMask(word);
            if(!dict.ContainsKey(mask)){
                masks.Add(mask);
                dict[mask] = word.Length;   
            }
            else
                dict[mask] = Math.Max(dict[mask], word.Length);
        }
        
        // now compare each mask with every other mask and if they are disjoint, then check product of length
        var result = 0;
        for(var i=0; i<masks.Count; i++){
            for(var j=i+1; j<masks.Count; j++){
                if((masks[i] & masks[j]) == 0)
                    result = Math.Max(result, dict[masks[i]] * dict[masks[j]]);
            }
        }
        return result;
    }
    
    private int BitMask(string word){
        var mask = 0;
        foreach(var ch in word)
            mask |= (1 << (ch-'a'));
        
        return mask;
    }
}