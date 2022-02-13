public class Solution {
    public int CountOperations(int num1, int num2) {
        var operations = 0;
        while(num1 != 0 && num2 != 0){
            if(num1 == num2) return operations+1;
            
            if(num1 > num2) num1 -= num2;
            else if(num2 > num1) num2 -= num1;
            operations++;
        }
        return operations;
    }
}