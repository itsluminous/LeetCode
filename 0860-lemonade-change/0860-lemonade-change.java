class Solution {
    public boolean lemonadeChange(int[] bills) {
        var count = new int[21];
        for(var bill : bills){
            count[bill]++;
            if(bill > 10 && count[10] > 0){
                bill -= 10;
                count[10]--;
            }
            while(bill > 5 && count[5] > 0){
                bill -= 5;
                count[5]--;
            }
            if(bill > 5) return false;
        }
        return true;
    }
}