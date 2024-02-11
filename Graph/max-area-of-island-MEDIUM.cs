public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int r = grid.Length, c = grid[0].Length, res=0;
        bool[,] visited = new bool[r, c];
        for(int i=0; i<r; i++){
            for(int j=0; j<c; j++){
                if(visited[i, j] == false){
                    if(grid[i][j] == 0)
                        visited[i, j] = true;
                    else{
                        var q = new Queue<int[]>();
                        q.Enqueue(new int[]{i,j});
                        int count=0;
                        int[,] dir = new int[4,2]{
                            {1, 0},
                            {-1, 0},
                            {0, 1},
                            {0, -1},
                        };
                        while(q.Count != 0){
                            var temp = q.Dequeue();
                            int r1 = temp[0], c1 = temp[1];
                            if(grid[r1][c1]==1 && visited[r1, c1] == false){
                                count++;
                                visited[r1, c1] = true;
                                for(int k=0; k<4; k++){
                                    int r2 = r1+dir[k, 0],
                                        c2 = c1+dir[k, 1];

                                    if(r2>=0 && r2<r 
                                    && c2>=0 && c2<c
                                    && grid[r2][c2]==1
                                    && visited[r2, c2]==false)
                                        q.Enqueue(new int[]{r2,c2});
                                }
                            }
                        }
                        res = System.Math.Max(res, count);
                    }
                }
            }
        }
        return res;
    }
}
/*
#Variables:
    - Visited Array
- Loop elements by row
    - Loop elements by column
        - if node is not visited
            - If value 0 
                mark node as visited
            - If value is 1:
                - Push this node in queue
                - Loop while queue is not empty
                    - Take node from queue
                    - if value is 1 && node is not visited
                        - increase count
                        - Mark as visited
                        - Loop in all 4 directions:
                            If 1 && node is not visited
                                push in queue
                    - 
            - if maxCOunt is smaller than count then switch

return maxCount

---------------DFS Solution with same TC & SC: O(m*n)----------------
    public int maxAreaOfIsland(int[][] grid) {
        int max_area = 0;
        for(int i = 0; i < grid.length; i++)
            for(int j = 0; j < grid[0].length; j++)
                if(grid[i][j] == 1)max_area = Math.max(max_area, AreaOfIsland(grid, i, j));
        return max_area;
    }
    
    public int AreaOfIsland(int[][] grid, int i, int j){
        if( i >= 0 && i < grid.length && j >= 0 && j < grid[0].length && grid[i][j] == 1){
            grid[i][j] = 0;
            return 1 + AreaOfIsland(grid, i+1, j) + AreaOfIsland(grid, i-1, j) + AreaOfIsland(grid, i, j-1) + AreaOfIsland(grid, i, j+1);
        }
        return 0;
    }
*/