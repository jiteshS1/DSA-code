public class Solution {
    public int UniquePaths(int m, int n) {
        int res = 0;
        DFS(0, 0, m, n, ref res);
        return res;
    }
    public void DFS(int r, int c, int m, int n, ref int res){
        if(r >= m || c >= n)
            return;
        if(r == m-1 && c == n-1)
            res++;

        int[,] loc = new int[2,2]{
            {0, 1},
            {1, 0}
        };
        for(int i=0; i<loc.GetLength(0); i++){
            int row = r + loc[i, 0];
            int col = c + loc[i, 1];
            //Check if index is in bounds
            if(row < m && col < n){
                DFS(row, col, m, n, ref res);
            }
        }

    }
}
/*
Above code TC is O(2^(m+n)) & SC: O(max(m, n))
But above solution is not that effective as it may visit same cell multiple times.

In below code, I am checking the visit count from bottom right & adding  
public class Solution {
    public int UniquePaths(int m, int n) {
        int[,] grid = new int[m, n];
        grid[m-1, n-1] = 1;
        for(int r = m-1; r>=0; r--){
            for(int c = n-1; c>=0; c--){
                if(r+1 < m)
                    grid[r, c] += grid[r+1, c]; //add value from below cell
                
                if(c+1 < n)
                    grid[r, c] += grid[r, c+1]; //add value from right cell
            }
        }
        return grid[0, 0];
    }
}


Also, I can use memoization approach with DFS code: it will reduce TC to O(m * n)
public class Solution {
    public int UniquePaths(int m, int n) {
        int[,] cache = new int[m, n];
        DFS(0, 0, m, n, ref cache);
        return cache[0, 0];
    }
    public int DFS(int r, int c, int m, int n, ref int[,] cache){
        if(r >= m || c >= n){
            cache[r, c] = 0;
            return 0;
        }
        if(r == m-1 && c == n-1)
        {
            cache[r, c] = 1;
            return 1;
        }

        if(cache[r, c] != 0)
            return cache[r, c];

        int[,] loc = new int[2,2]{
            {0, 1},
            {1, 0}
        };
        int count = 0;
        for(int i=0; i<loc.GetLength(0); i++){
            int row = r + loc[i, 0];
            int col = c + loc[i, 1];
            //Check if index is in bounds
            if(row < m && col < n){
                count += DFS(row, col, m, n, ref cache);
            }
        }
        cache[r, c] = count;
        return count;
    }
}
*/