func minimumDeletions(s string) int {
    minDel, b := 0, 0
        
    for _, ch := range s {
        if ch == 'b' {
            b += 1
        } else {
            minDel = min(minDel + 1, b)
        }
    }

    return minDel
}