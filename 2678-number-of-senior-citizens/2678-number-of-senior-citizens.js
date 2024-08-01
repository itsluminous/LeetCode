/**
 * @param {string[]} details
 * @return {number}
 */
var countSeniors = function(details) {
    let count = 0;
    for(var i=0; i<details.length; i++) {
        var age = details[i].substring(11, 13);
        if(parseInt(age) > 60) count++;
    }

    return count;
};