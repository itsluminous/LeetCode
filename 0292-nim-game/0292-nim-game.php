class Solution {

    /**
     * @param Integer $n
     * @return Boolean
     */
    function canWinNim($n) {
        // return $n % 4;
        return $n & 3;
    }
}