/**
 * @param {number} n
 * @return {number}
 */
var minSteps = function(n) {
    let count = 0;
    while(n != 1){
        for(let div=2; div<=n; div++){
            if(n % div != 0) continue;
            n /= div;
            count += div;
            break;
        }
    }
    return count;
};