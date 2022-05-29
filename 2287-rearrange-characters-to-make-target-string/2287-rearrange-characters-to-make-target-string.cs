public class Solution {
    public int RearrangeCharacters(string s, string target) {
        var dict = new Dictionary<char, int>();
        foreach(var ch in s){
            if(dict.ContainsKey(ch))
                dict[ch]++;
            else
                dict[ch] = 1;
        }
        
        var count = 0;
        while(true){
            foreach(var ch in target){
                if(!dict.ContainsKey(ch) || dict[ch] == 0)
                    return count;
                dict[ch]--;
            }
            count++;
        }
        
        return count;
    }
}