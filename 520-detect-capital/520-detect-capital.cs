public class Solution {
    public bool DetectCapitalUse(string word) {
        int capital = 0, small = 0;
        // if first letter is small, next all letters have to be small
        if(word[0] >= 'a' && word[0] <= 'z') small++;
        
        // check all characters from 2nd letter
        for(var i=1; i<word.Length; i++){
            var ch = word[i];
            if(ch >= 'A' && ch <= 'Z') capital++;
            else small++;
            
            // we should have only one of the counters incremented
            if(capital > 0 && small > 0) return false;
        }
        
        return true;
    }
}