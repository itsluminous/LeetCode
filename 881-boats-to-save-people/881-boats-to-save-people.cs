public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        Array.Sort(people);
        int boats=0, left=0, right=people.Length-1;
        
        while(left <= right){
            boats++;
            // if heaviest and lightest person can go together, then reduce 2 people
            if(people[left] + people[right] <= limit)
                left++;
            right--;
        }
        
        return boats;
    }
}