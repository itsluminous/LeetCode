class Solution {

    /**
     * @param Integer $n
     * @param Integer $time
     * @return Integer
     */
    function passThePillow($n, $time) {
        // remove full cycles
        $roundTrip = ($n-1) * 2;
        $time %= $roundTrip;

        // left to right
        if($time < $n) return $time + 1;

        // right to left
        $time -= $n;
        return $n - $time - 1;
    }
}