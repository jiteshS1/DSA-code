public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        //Declaring variables
        int m = obstacleGrid.Length, n = obstacleGrid[0].Length; 
        int[,] count = new int[m, n];
        
        // Edge case: if the starting point or ending point has an obstacle
        if (obstacleGrid[0][0] == 1 || obstacleGrid[m-1][n-1] == 1)
            return 0;
        
        //Set destination as 1
        count[m-1, n-1] = 1;
        
        //Loop from bottom right square
        for(int r=m-1; r>=0; r--){
            for(int c=n-1; c>=0; c--){
                if(r == m-1 && c == n-1)
                    continue;
                //If there is no obstacle then only update value
                if(obstacleGrid[r][c] == 0)
                {
                    //Initialize bottom & right as 0
                    int bottom = 0, right = 0;

                    //Get value from right cell
                    if(c+1 < n)
                        right = count[r, c+1];

                    //Get value from down cell
                    if(r+1 < m)
                        bottom = count[r+1, c];

                    count[r, c] = bottom + right;
                }
            }    
        }
        return count[0, 0];
    }
}
/*
TC, SC: O(M x N)

Brute force soln: O(2 ^(mxn))

    
*/