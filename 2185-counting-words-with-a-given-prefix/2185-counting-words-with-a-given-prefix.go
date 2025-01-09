func prefixCount(words []string, pref string) int {
    count := 0
    for _, w := range(words) {
        if strings.HasPrefix(w, pref) {
            count++
        }
    }
    return count
}