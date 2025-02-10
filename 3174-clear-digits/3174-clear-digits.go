func clearDigits(s string) string {
    var alpha []rune
    for _,ch := range s {
        if unicode.IsDigit(ch) {
            alpha = alpha[:len(alpha)-1]   // alpha will always have something
        } else {
            alpha = append(alpha, ch)
        }
    }
    
    return string(alpha)
}