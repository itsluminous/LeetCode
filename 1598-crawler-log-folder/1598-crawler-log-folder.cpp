class Solution {
public:
    int minOperations(vector<string>& logs) {
        int depth = 0;
        for(string cmd : logs){
            if(cmd == "../" && depth > 0)
                depth--;
            else if(cmd[0] != '.')
                depth++;
        }
        return depth;
    }
};