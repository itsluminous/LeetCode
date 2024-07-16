func convertToTitle(columnNumber int) string {
    ans := ""
    for columnNumber > 0 {
        columnNumber--
        remainder := columnNumber % 26
        columnNumber /= 26

        ch := 'A' + remainder
        ans = string(ch) + ans
    }

    return ans
}