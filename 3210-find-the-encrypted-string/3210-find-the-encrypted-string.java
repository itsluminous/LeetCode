class Solution {
    public String getEncryptedString(String s, int k) {
        var n = s.length();
        var sb = new StringBuilder();

        for(var i=0; i<n; i++){
            var substitute = (i + k) % n;
            sb.append(s.charAt(substitute));
        }

        return sb.toString();
    }
}