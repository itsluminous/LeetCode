/**
 * @param {string[]} logs
 * @return {number}
 */
var minOperations = function(logs) {
    let depth = 0;
    for(const cmd of logs){
        if(cmd == "../" && depth > 0)
            depth--;
        else if(cmd[0] != '.')
            depth++;
    }
    return depth;
};