public class Solution {
    public int[][] UpdateMatrix(int[][] mat) {
        //Create result matrix
        int m= mat.Length, n = mat[0].Length;
        int[][] res;
        res = new int[m][];
        //Initialize each cell with -1 in result matrix
        for(int r=0; r<m; r++){
            res[r] = new int[n];
            for(int c=0; c<n; c++){
                res[r][c] = -1;
            }
        }

        //Creating queue to store index which needs to looped
        var qu = new Queue<IndexDet>();
        for(int r=0; r<m; r++){
            for(int c=0; c<n; c++){
                if(mat[r][c] == 0){
                    //Update result index
                    res[r][c] = 0;
                    //Push this index in Queue
                    qu.Enqueue(new IndexDet(r, c));
                }
            }
        }

        int[,] dir = new int[4, 2]{
            {-1, 0},
            {1, 0},
            {0, 1},
            {0, -1}
        };
        while(qu.Count > 0){
            var indDet = qu.Dequeue();
            int bitDistance = res[indDet.r][indDet.c];
            //Check if it's adjacent cell have 1 value
            for(int i=0; i<4; i++){
                int row = indDet.r + dir[i, 0],
                    col = indDet.c + dir[i, 1];
                
                if(row>=0 && row<m &&
                    col>=0 && col<n && 
                    mat[row][col]==1 && res[row][col]==-1){
                    res[row][col] = bitDistance + 1;
                    qu.Enqueue(new IndexDet(row, col));
                }
            }

        }
        return res;
    }
}
public class IndexDet{
    public int r;
    public int c;
    public IndexDet(int r, int c){
        this.r = r;
        this.c = c;
    }
}
/*
    TC, SC: O(m*n)
    Solution with O(1) space: 
    https://leetcode.com/problems/01-matrix/solutions/1369741/c-java-python-bfs-dp-solutions-with-picture-clean-concise-o-1-space/
*/