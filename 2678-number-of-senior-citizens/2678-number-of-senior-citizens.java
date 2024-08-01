class Solution {
    public int countSeniors(String[] details) {
        var count = 0;
        for(var detail : details){
            var age = detail.substring(11, 13);
            if(Integer.parseInt(age) > 60) count++;
        }

        return count;
    }
}