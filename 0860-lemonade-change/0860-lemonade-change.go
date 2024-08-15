func lemonadeChange(bills []int) bool {
    count := make([]int, 21)
    for _,bill := range bills{
        count[bill]++
        if bill > 10 && count[10] > 0 {
            bill -= 10
            count[10]--
        }
        for bill > 5 && count[5] > 0 {
            bill -= 5
            count[5]--
        }
        if bill > 5 {
            return false
        }
    }
    return true
}