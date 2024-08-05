public class Solution {
    public string KthDistinct(string[] arr, int k) {
        var dict = new Dictionary<string, bool>();
        foreach(var str in arr){
            if(dict.ContainsKey(str))
                dict[str] = false;
            else
                dict[str] = true;
        }

        foreach(var str in arr){
            if(dict[str] && --k == 0)
                return str;
        }

        return string.Empty;
    }
}