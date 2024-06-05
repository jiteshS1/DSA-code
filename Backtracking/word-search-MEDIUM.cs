public class Solution {
    public bool Exist(char[][] board, string word) {
        for(int m=0; m < board.Length; m++){
            for(int n=0; n < board[0].Length; n++){
                bool[,] visited = new bool[board.Length, board[0].Length];
                bool temp = CheckWord(m, n, 0, visited, board, word);
                if(temp == true)
                    return true;
            }
        }      
        return false;
    }
    public bool CheckWord(int m, int n, int i, 
            bool[,] visited, char[][] board, string word)
    {
        if(i >= word.Length)
            return true;
        
        if(board[m][n] != word[i])
        {
            return false;
        }else{
            //Char is same
            //Mark location as visited
            visited[m,n] = true;
            if(i == word.Length-1){
                return true;
            }
            int[,] dir = new int[4,2]{
                {-1, 0},
                {1, 0},
                {0, -1},
                {0, 1}
            };
            for(int j=0; j<4; j++){
                int row = m + dir[j, 0],
                    col = n +  dir[j, 1];
                
                if(row >= 0 && row < board.Length 
                && col >= 0 && col < board[0].Length 
                && visited[row, col]== false){
                    bool temp = CheckWord(row, col, i+1, visited, board, word);
                    visited[row, col] = false;
                    if(temp == true)
                        return true;
                }
            }
            return false;
        }
    }
}
/*
TC: O(m*n*4^k)
SC: O(m*n+k)
*/