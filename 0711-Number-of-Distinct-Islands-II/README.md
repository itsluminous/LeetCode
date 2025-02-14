<h2><a href="https://leetcode.com/problems/number-of-distinct-islands-ii/">Number of Distinct Islands II</a></h2>

<p>Given an m x n 2D binary grid representing a map of '1's (land) and '0's (water), you need to determine the number of distinct islands in the grid.</p>

<p>An island is a group of '1's connected horizontally or vertically. Two islands are considered distinct if and only if one island is not equal to another, even if one is a rotation or reflection of the other.</p>

<h3>Function Signature:</h3>
<pre><code>def numDistinctIslands2(grid: List[List[int]]) -> int:</code></pre>

<h3>Input:</h3>
<ul>
  <li><code>grid</code>: A list of lists of integers representing the m x n binary grid.</li>
</ul>

<h3>Output:</h3>
<ul>
  <li>An integer representing the number of distinct islands in the grid.</li>
</ul>

<h3>Example:</h3>
<pre><code>grid = [
    [1, 1, 0, 0, 0],
    [1, 1, 0, 0, 0],
    [0, 0, 1, 0, 0],
    [0, 0, 0, 1, 1]
]

print(numDistinctIslands2(grid))  # Output: 3</code></pre>

<h3>Note:</h3>
<p>In the example above, there are three distinct islands in the grid.</p>

<h3>Constraints:</h3>
<ul>
  <li><code>m == grid.length</code></li>
  <li><code>n == grid[i].length</code></li>
  <li><code>1 <= m, n <= 50</code></li>
  <li><code>grid[i][j] is 0 or 1.</code></li>
</ul>

<p>For more details, please refer to the <a href="https://leetcode.com/problems/number-of-distinct-islands-ii/">LeetCode problem page</a>.</p>
