function minOperations(logs: string[]): number {
    let depth = 0;
    for(const cmd of logs){
        if(cmd == "../" && depth > 0)
            depth--;
        else if(cmd[0] != '.')
            depth++;
    }
    return depth;
};