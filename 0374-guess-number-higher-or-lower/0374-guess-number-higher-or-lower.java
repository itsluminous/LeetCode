public class Solution extends GuessGame {
    public int guessNumber(int n) {
        return guessNumber(1, n);
    }

    private int guessNumber(int left, int right) {
        var mid = left + (right - left)/2;
        var match = guess(mid);
        if(match == -1) return guessNumber(left, mid);
        if(match == 1) return guessNumber(mid+1, right);
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