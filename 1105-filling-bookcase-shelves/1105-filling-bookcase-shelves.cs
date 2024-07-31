public class Solution {
    int[,] dp;

    public int MinHeightShelves(int[][] books, int shelfWidth) {
        dp = new int[books.Length, shelfWidth+1];
        return MinHeightShelves(books, shelfWidth, 0, shelfWidth, 0);
    }

    private int MinHeightShelves(int[][] books, int shelfWidth, int idx, int width, int height){
        if(idx == books.Length) return 0;
        if(dp[idx, width] != 0) return dp[idx, width];

        var (bookWidth, bookHeight) = (books[idx][0], books[idx][1]);
        var currHeight = bookHeight + MinHeightShelves(books, shelfWidth, idx+1, shelfWidth - bookWidth, bookHeight);
        if(bookWidth <= width){
            var heightIncr = bookHeight > height ? bookHeight - height : 0;
            var sameRack = heightIncr + MinHeightShelves(books, shelfWidth, idx+1, width - bookWidth, height + heightIncr);
            currHeight = Math.Min(currHeight, sameRack);
        }

        dp[idx, width] = currHeight;
        return currHeight;
    }
}