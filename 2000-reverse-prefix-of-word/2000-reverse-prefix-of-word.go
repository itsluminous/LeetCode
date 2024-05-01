func reversePrefix(word string, ch byte) string {
    for i:= range word{
        if word[i] == ch{
            prefix := reverseStr(word[:i+1])
            return prefix + word[i+1:]
        }
    }
    return word
}

func reverseStr(word string) string{
    rns := []rune(word)
    for i,j := 0, len(rns)-1; i<j; i,j = i+1,j-1 {
        rns[i], rns[j] = rns[j], rns[i]
    }
    return string(rns)
}