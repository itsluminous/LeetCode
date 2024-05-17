/*
INTUITION
If n = 0 => {0}
If n = 1 => {0,1} {0 , 0 + pow(2,0)}
If n = 2 => {0,1,3,2} {0 , 1 , 1 + pow(2,1) , 0 + pow(2,1)}
If n = 3 => {0,1,3,2,6,7,5,4} {0 , 1 , 3 , 2 , 2 + pow(2,2) , 3 + pow(2,2) , 1 + pow(2,2) , 0 + pow(2,2)}
*/

class Solution {
    public List<Integer> grayCode(int n) {
        var len = Math.pow(2, n);
        var ans = new ArrayList<Integer>();
        ans.add(0);

        for(var pow=0; ans.size() < len; pow++){
            for(var i=ans.size()-1; i>=0; i--){
                ans.add(ans.get(i) + (int)Math.pow(2, pow));
            }
        }

        return ans;
    }
}