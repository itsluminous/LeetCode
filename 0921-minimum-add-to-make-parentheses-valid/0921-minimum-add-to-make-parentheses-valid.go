func minAddToMakeValid(s string) int {
    open, close := 0, 0
    for _, ch := range s {
        if ch == '(' {
            open++
        } else if open > 0 {
            open--
        } else {
            close++
        }
    }

    // we will have to balance leftover open & close brackets
    return open + close
}