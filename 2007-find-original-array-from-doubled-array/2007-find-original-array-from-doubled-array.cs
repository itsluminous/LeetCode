public class Solution {
    public int[] FindOriginalArray(int[] changed) {
        Array.Sort(changed);
        
        var dict = new Dictionary<int,int>();   
        var orig = new List<int>();
        foreach(var num in changed){
            if(!dict.ContainsKey(num) || dict[num] == 0 )
                AddNum(dict, num*2);
            else{
                dict[num]--;
                orig.Add(num/2);
            }
        }
        
        foreach(var k in dict.Keys){
            if(dict[k] > 0) return new int[0];
        }
        
        return orig.ToArray();
    }
    
    private void AddNum(Dictionary<int,int> dict, int num){
        if(dict.ContainsKey(num))
            dict[num]++;
        else
            dict[num] = 1;
    }
}