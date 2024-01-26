public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
            int m = matrix.Length, n = matrix[0].Length;
            int low=0, mid = (m*n)/2, high = (m*n)-1;
            
            while(low<=high){
                int row = mid/n, col = mid%n; //This is main logic to get row & col.
                /*
                n * m matrix convert to an array => matrix[x][y] => a[x * m + y]

                an array convert to n * m matrix => a[x] =>matrix[x / m][x % m];
                */
                if(matrix[row][col]==target)
                    return true;
                else if(matrix[row][col] > target)
                {
                    high = mid-1;
                    mid = high/2;
                }else if(matrix[row][col] < target)
                {
                    low = mid+1;
                    mid = ((high-low)/2)+low;
                }
            }
            return false;
    }
}
