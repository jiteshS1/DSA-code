public class Solution {
    bool[,] visited;
    public int NumIslands(char[][] grid) {
        visited = new bool[grid.Length, grid[0].Length];
        int islands=0;
        for(int r=0; r < grid.Length; r++){
            for(int c=0; c < grid[0].Length; c++){
                if(!visited[r, c] && grid[r][c] == '1')
                {
                    bfs(r, c, grid);
                    islands++;
                }
            }
        }
        return islands;
    }
    public void bfs(int r, int c, char[][] grid){
        var q = new System.Collections.Generic.Queue<int[]>();
        int[,] dir = new int[4, 2]{
            {0, 1},
            {0, -1},
            {1, 0},
            {-1, 0}
        };
        q.Enqueue(new int[2]{r, c});
        while(q.Count!=0){
            int[] val = q.Dequeue();
            visited[val[0], val[1]] = true;

            for(int i=0; i<4; i++){
                int nR = dir[i, 0] + val[0], 
                nC = dir[i, 1] + val[1];
                
                if(nR >= 0 && nR < grid.Length 
                && nC >= 0 && nC < grid[0].Length
                && grid[nR][nC]=='1'
                && visited[nR, nC] == false){
                    q.Enqueue(new int[2]{nR, nC});
                    visited[nR, nC] = true;
                }
            }
        }
    }
}
/*
- Variables:
    - Visted array

Start from 0,0
- Loop all values of grid
    - Check if node is not visited
        - mark node as visited
        - If values is 1
            - Call BFS to check next neighbour values.
            - islands++

- BFS(r, c)
    - Push val in queue
    - while queue is not empty 
        - mark node as visited
        - Dequeue val from node
        - Loop all possible directions
            if val is 1 and node is not visited
                enqueue in queue
            

return islands
*/