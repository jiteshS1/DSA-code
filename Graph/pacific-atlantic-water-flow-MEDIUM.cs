public class Solution {
    int m=0, n=0;
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        m = heights.Length;
        n = heights[0].Length; 
        var pQ = new Queue<int[]>();
        var aQ = new Queue<int[]>();
        bool[,] pV = new bool[m, n];
        bool[,] aV = new bool[m, n];

        for(int i=0; i<m; i++){
            pQ.Enqueue(new int[]{i, 0});
            aQ.Enqueue(new int[]{i, n-1});
            pV[i, 0] = true;
            aV[i, n-1] = true;
        }
        for(int i=0; i<n; i++){
            pQ.Enqueue(new int[]{0, i});
            aQ.Enqueue(new int[]{m-1, i});
            pV[0, i] = true;
            aV[m-1, i] = true;
        }
        bfs(pQ, pV, heights);
        bfs(aQ, aV, heights);

        var res = new List<IList<int>>();
        for(int r=0; r<m; r++){
            for(int c=0; c<n; c++){
                if(pV[r,c] && aV[r,c])
                    res.Add(new List<int>{r,c});
            }
        }
         return res;
    }
    public void bfs(Queue<int[]> q, bool[,] visited, int[][] heights){
        int[,] dir = new int[,]{
            {1, 0},
            {-1, 0},
            {0, 1},
            {0, -1}
        }; 
        while(q.Count>0){
            int[] node = q.Dequeue();
            for(int j=0; j<dir.GetLength(0); j++){
                int row = dir[j, 0] + node[0],
                col = dir[j, 1] + node[1];

                if(row<0 || row>=m || 
                col<0 || col>=n || visited[row, col] || heights[row][col] < heights[node[0]][node[1]] )
                    continue;

                visited[row, col] = true;
                q.Enqueue(new int[]{row, col});
            }
        }
    }
}

/*
Two Queue and add all the Pacific border to one queue; Atlantic border to another queue.
Keep a visited matrix for each queue. In the end, add the cell visited by two queue to the result.
BFS: Water flood from ocean to the cell. Since water can only flow from high/equal cell to low cell, add the neighboor cell with height larger or equal to current cell to the queue and mark as visited.
*/