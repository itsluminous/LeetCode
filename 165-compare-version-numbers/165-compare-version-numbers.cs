public class Solution {
    public int CompareVersion(string version1, string version2) {
        var v1 = version1.Split('.');
        var v2 = version2.Split('.');
        
        int v1idx = 0, v2idx = 0;
        while(v1idx < v1.Length && v2idx < v2.Length){
            int v1val = Convert.ToInt32(v1[v1idx]), v2val = Convert.ToInt32(v2[v2idx]);
            if(v1val < v2val) return -1;
            if(v1val > v2val) return 1;
            v1idx++;
            v2idx++;
        }
        
        while(v1idx < v1.Length && Convert.ToInt32(v1[v1idx]) == 0) v1idx++;
        while(v2idx < v2.Length && Convert.ToInt32(v2[v2idx]) == 0) v2idx++;
        
        if(v1idx == v1.Length && v2idx == v2.Length) return 0;
        if(v1idx == v1.Length) return -1; 
        return 1;
    }
}