public class Solution {
    public int OrangesRotting(int[][] grid) {
        var q = new Queue<(int, int)>();
        int min = 0, fresh = 0;

        for(int r=0; r<grid.Length; r++){
            for(int c=0; c<grid[0].Length; c++){
                if(grid[r][c]==1)
                    fresh++;
                else if(grid[r][c]==2)
                    q.Enqueue((r, c));
            }    
        }

        var dir = new int[4, 2]{
            {1, 0},
            {-1, 0},
            {0, 1},
            {0, -1}
        };
        while(q.Count()>0 && fresh>0){
            int len = q.Count();
            for(int i=0; i<len; i++){
                var node = q.Dequeue();
                int r = node.Item1, c = node.Item2;
                //Check all 4 directions
                for(int d=0; d<4; d++){
                    int row = r + dir[d, 0],
                        col = c + dir[d, 1];
                    if(row >= 0 && row<grid.Length 
                        && col >= 0 && col<grid[0].Length
                        && grid[row][col]==1){
                        grid[row][col] = 2;
                        fresh--;
                        q.Enqueue((row, col));
                    }
                }
            }
            min++;
        }
        return fresh>0? -1:min;
    }
}
