public class Solution {
    public int CompareVersion(string version1, string version2) {
        var v1 = version1.Split('.');
        var v2 = version2.Split('.');
        var len = Math.Max(v1.Length, v2.Length);
        
        for (var i=0; i<len; i++) {
            var val1 = i < v1.Length ? Convert.ToInt32(v1[i]) : 0;
            var val2 = i < v2.Length ? Convert.ToInt32(v2[i]) : 0;
            
            if(val1 < val2) return -1;
            if(val1 > val2) return 1;
        }

        return 0;
    }
}

// Accepted
public class Solution1 {
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