public class Solution {
    public int CompareVersion(string version1, string version2) {
        string[] v1 = version1.Split('.'), v2 = version2.Split('.');
        int len1 = v1.Length, len2 = v2.Length, len = Math.Max(len1, len2);

        for(var i=0; i<len; i++){
            var val1 = i < len1 ? int.Parse(v1[i]) : 0;
            var val2 = i < len2 ? int.Parse(v2[i]) : 0;

            if(val1 < val2) return -1;
            if(val1 > val2) return 1;
        }
        return 0;
    }
}

// Accepted - more verbose
public class SolutionVerbose {
    public int CompareVersion(string version1, string version2) {
        string[] v1 = version1.Split('.'), v2 = version2.Split('.');
        int len1 = v1.Length, len2 = v2.Length;

        for(int i1=0, i2=0; i1 < len1 || i2 < len2; i1++, i2++){
            var cmp = 0;
            if(i1 >= len1)
                cmp = CompareNums(0, int.Parse(v2[i2]));
            else if(i2 >= len2)
                cmp = CompareNums(int.Parse(v1[i1]), 0);
            else 
                cmp = CompareNums(int.Parse(v1[i1]), int.Parse(v2[i2]));

            if(cmp == 0) continue;
            return cmp;
        }
        return 0;
    }

    private int CompareNums(int num1, int num2){
        if(num1 < num2) return -1;
        if(num1 > num2) return 1;
        return 0;
    }
}