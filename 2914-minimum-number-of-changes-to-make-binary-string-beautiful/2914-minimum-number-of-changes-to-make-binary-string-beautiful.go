func minChanges(s string) int {
    count := 0
    for i := 1; i < len(s); i += 2 {
        if s[i] != s[i-1] {
            count++
        }
    }
    
    return count
}