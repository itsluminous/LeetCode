func minMovesToSeat(seats []int, students []int) int {
    sort.Ints(seats)
    sort.Ints(students)

    moves := 0
    for i:=0; i < len(seats); i++ {
        moves += abs(students[i] - seats[i])
    }

    return moves
}

func abs(num int) int {
    if num < 0 {
        return -num
    }
    return num
}