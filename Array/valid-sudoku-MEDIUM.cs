public class Solution {
    public bool IsValidSudoku(char[][] board) {
        int[,] row = new int[9,9];
        int[,] col = new int[9,9];
        int[,] block = new int[9,9];

        for(int r=0; r<9; r++){
            for(int c=0; c<9; c++){
                if(board[r][c]!='.'){
                    int num = board[r][c] - '1';
                    row[r, num] += 1;
                    col[c, num] += 1;
                    int boxNum = GetBoxNumber(r, c);
                    block[boxNum, num] += 1;

                    if(row[r, num]>1 || col[c, num]>1 || block[boxNum, num]>1){
                        return false;
                    }
                }
            }    
        }

        return true;
    }
    public int GetBoxNumber(int r, int c){
        if(r>=0 && r<=2)
        {
            if(c>=0 && c<=2)
            {
                return 0;
            }else if(c>=3 && c<=5)
            {
                return 1;
            }
            {
                return 2;
            }
        }else if(r>=3 && r<=5)
        {
            if(c>=0 && c<=2)
            {
                return 3;
            }else if(c>=3 && c<=5)
            {
                return 4;
            }
            {
                return 5;
            }
        }else
        {
            if(c>=0 && c<=2)
            {
                return 6;
            }else if(c>=3 && c<=5)
            {
                return 7;
            }
            {
                return 8;
            }
        }
    }
}
/*
    TC, SC: O(1)
*/