func findChampion(n int, edges [][]int) int {
    if n == 1 { // no competitors
        return 0   
    }

    // 0 = undefined, 1 = weak, 2 = strong
    val := make([]int, n)

    for _, edge := range edges {
        src, dest := edge[0], edge[1]
        val[dest] = 1
        if val[src] == 0 {
            val[src] = 2
        }
    }

    ans := -1
    for i:=0; i<n; i++ {
        if val[i] == 1 {    // don't care about losers
            continue
        }   
        if val[i] == 0 {   // if we don't know about even a single team, return -1
            return -1
        }  
        if ans != -1 { // we already have one strong team
            return -1
        }    
        ans = i
    }

    return ans
}