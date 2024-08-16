func maxDistance(arrays [][]int) int {
    smallest, biggest, maxDist := 10001, -10001, 0
    for _, arr := range arrays{
        maxDist = int(math.Max(float64(maxDist), float64(biggest-arr[0])))
		maxDist = int(math.Max(float64(maxDist), float64(arr[len(arr)-1]-smallest)))
		smallest = int(math.Min(float64(smallest), float64(arr[0])))
		biggest = int(math.Max(float64(biggest), float64(arr[len(arr)-1])))
    }

    return maxDist
}