class Solution {
    public String kthDistinct(String[] arr, int k) {
        var map = new HashMap<String, Boolean>();
        for(var str : arr){
            if(map.containsKey(str))
                map.put(str, false);
            else
                map.put(str, true);
        }

        for(var str : arr){
            if(map.get(str) && --k == 0)
                return str;
        }

        return "";
    }
}