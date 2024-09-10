/**
 * @param {number} n
 * @return {boolean}
 */
var canWinNim = function(n) {
    // return n % 4;
    return (n & 3);
};