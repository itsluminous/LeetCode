public class Solution {
    public bool LemonadeChange(int[] bills) {
        var count = new int[21];
        for(var i=0; i<bills.Length; i++){
            var bill = bills[i];
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