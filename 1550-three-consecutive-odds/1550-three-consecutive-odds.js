/**
 * @param {number[]} arr
 * @return {boolean}
 */
var threeConsecutiveOdds = function(arr) {
    let odd = 0;
    for(let num of arr) {
        if((num & 1) == 1) odd++;
        else odd = 0;

        if(odd == 3) return true;
    }

    return false;
};