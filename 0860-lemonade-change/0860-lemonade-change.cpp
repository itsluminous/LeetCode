class Solution {
public:
    bool lemonadeChange(vector<int>& bills) {
        vector<int> count(21, 0);
        for(int bill : bills){
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
};