func canBeEqual(target []int, arr []int) bool {
    freq := make([]int, 1001)
    for _, num := range arr {
        freq[num]++
    }

    for _, num := range target {
        freq[num]--
        if freq[num] == -1 {
            return false
        }
    }
    
    return true
}