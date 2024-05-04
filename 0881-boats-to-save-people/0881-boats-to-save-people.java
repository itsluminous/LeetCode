// idea is to try to fit heavy one first, and then fit lightest one with that person if possible
class Solution {
    public int numRescueBoats(int[] people, int limit) {
        Arrays.sort(people);
        int boats=0, left=0, right=people.length-1;

        while(left <= right){
            boats++;
            if(people[left] + people[right] <= limit) left++;
            right--;
        }
        
        return boats;
    }
}