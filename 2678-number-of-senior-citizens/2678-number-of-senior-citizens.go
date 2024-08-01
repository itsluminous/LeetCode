func countSeniors(details []string) int {
    count := 0
    for _, detail := range details {
        age := detail[11:13]
        agenum, _ := strconv.Atoi(age)
        if agenum > 60 {
            count++
        }
    }

    return count
}