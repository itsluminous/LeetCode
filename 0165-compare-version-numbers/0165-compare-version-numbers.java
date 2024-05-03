public class Solution {
    public int compareVersion(String version1, String version2) {
        String[] v1 = version1.split("\\."), v2 = version2.split("\\.");
        int len1 = v1.length, len2 = v2.length, len = Math.max(len1, len2);

        for(var i=0; i<len; i++){
            var val1 = i < len1 ? Integer.parseInt(v1[i]) : 0;
            var val2 = i < len2 ? Integer.parseInt(v2[i]) : 0;
            
            if(val1 < val2) return -1;
            if(val1 > val2) return 1;
        }
        return 0;
    }
}