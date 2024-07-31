class Solution {
    int[][] dp;

    public int minHeightShelves(int[][] books, int shelfWidth) {
        dp = new int[books.length][shelfWidth+1];
        return minHeightShelves(books, shelfWidth, 0, shelfWidth, 0);
    }

    private int minHeightShelves(int[][] books, int shelfWidth, int idx, int width, int height){
        if(idx == books.length) return 0;
        if(dp[idx][width] != 0) return dp[idx][width];

        int bookWidth = books[idx][0], bookHeight = books[idx][1];
        var currHeight = bookHeight + minHeightShelves(books, shelfWidth, idx+1, shelfWidth - bookWidth, bookHeight);
        if(bookWidth <= width){
            var heightIncr = Math.max(0, bookHeight - height);
            var sameRack = heightIncr + minHeightShelves(books, shelfWidth, idx+1, width - bookWidth, height + heightIncr);
            currHeight = Math.min(currHeight, sameRack);
        }

        dp[idx][width] = currHeight;
        return currHeight;
    }
}