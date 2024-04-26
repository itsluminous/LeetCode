public class Solution : GuessGame {
    public int GuessNumber(int right, int left=1) {
        var mid = left + (right - left)/2;
        var match = guess(mid);
        if(match == -1) return GuessNumber(mid, left);
        if(match == 1) return GuessNumber(right, mid+1);
        return mid;
    }
}

/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */