func minOperations(logs []string) int {
    depth := 0
    for _, cmd := range logs {
        if cmd == "../" && depth > 0 {
            depth--
        } else if cmd[0] != '.' {
            depth++;
        }
    }
    return depth
}