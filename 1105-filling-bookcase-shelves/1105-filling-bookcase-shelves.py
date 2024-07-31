class Solution:
    def minHeightShelves(self, books: List[List[int]], shelfWidth: int) -> int:
        @cache
        def getMinHeight(idx: int, width: int, height: int) -> int:
            if idx == len(books): return 0

            bookWidth, bookHeight = books[idx]
            currHeight = bookHeight + getMinHeight(idx+1, shelfWidth - bookWidth, bookHeight)
            if bookWidth <= width:
                heightIncr = max(0, bookHeight - height)
                sameRack = heightIncr + getMinHeight(idx+1, width - bookWidth, height + heightIncr)
                currHeight = min(currHeight, sameRack)

            return currHeight
    
        return getMinHeight(0, shelfWidth, 0)