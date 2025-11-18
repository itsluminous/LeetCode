public class Solution {
    public bool IsOneBitCharacter(int[] bits) {
        var i = 0;
        for(; i<bits.Length-1; i++)
            // if digit starts with 1, we need 2 characters 
            i += bits[i];   // novice way : if(bits[i] == 1) i++;  
        
        return i == bits.Length-1;
    }
}