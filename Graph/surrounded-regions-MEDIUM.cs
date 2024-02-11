public class Solution {
    int m,n;
    public void Solve(char[][] board) {
        m = board.Length;
        n = board[0].Length;
        
        //Capture all indices which cannot be capture
        for(int i=0; i<m; i++){
            Capture(i, 0, board);
            Capture(i, n-1, board);
        }
        for(int j=0; j<n; j++){
            Capture(0, j, board);
            Capture(m-1, j, board);
        }

        for(int r=0; r<m; r++){
            for(int c=0; c<n; c++){
                if(board[r][c]=='X')
                    continue;
                if(board[r][c]=='O')
                    board[r][c] = 'X';
                else if(board[r][c]=='T')
                    board[r][c] = 'O';
            }
        }
    }
    public void Capture(int r, int c, char[][] board){
        if(r<0 || r>=m 
        || c<0 || c>=n
        || board[r][c]!='O')
            return;
        board[r][c] = 'T';

        Capture(r+1, c, board);
        Capture(r-1, c, board);
        Capture(r, c+1, board);
        Capture(r, c-1, board);
    }
}
/*
 //We will use boundary DFS to solve this problem
        
      // Let's analyze when an 'O' cannot be flipped,
      // if it has atleast one 'O' in it's adjacent, AND ultimately this chain of adjacent 'O's is connected to some 'O' which lies on boundary of board
        
      //consider these two cases for clarity :
      /*
        O's won't be flipped          O's will be flipped
        [X O X X X]                   [X X X X X]     
        [X O O O X]                   [X O O O X]
        [X O X X X]                   [X O X X X] 
        [X X X X X]                   [X X X X X]
      
      So we can conclude if a chain of adjacent O's is connected some O on boundary then they cannot be flipped
      
      */
*/