public class Solution {
    public bool[,] vis;
    public char[][] boardAr;
    HashSet<string> res;
    int m, n;
    public IList<string> FindWords(char[][] board, string[] words) {
        var root = GenerateTrie(words);
        m = board.Length;
        n = board[0].Length;

        vis = new bool[m, n];
        res = new HashSet<string>();
        boardAr = board;

        Node cur = root;
        for(int r=0; r<m; r++){
            for(int c=0; c<n; c++){
                DFS(r, c, "", cur);
                cur = root;
            }
        }
        return res.ToList();
    }
    //DFS method for checking words
    public void DFS(int r, int c, string word, Node cur){
        if(r<0 || r>=m
        || c<0 || c>=n
        || vis[r, c]
        || !cur.Contains(boardAr[r][c]))
            return;
        
        vis[r, c] = true;
        word += boardAr[r][c];
        cur = cur.child[boardAr[r][c] - 'a'];
        if(cur.isEnd){
            if(!res.Contains(word))
                res.Add(word);
        }

        DFS(r-1, c, word, cur);
        DFS(r+1, c, word, cur);
        DFS(r, c-1, word, cur);
        DFS(r, c+1, word, cur);
               
        vis[r, c] = false;
    }
    //Generate trie
    public Node GenerateTrie(string[] words){
        var root = new Node();
        Node cur = root;
        foreach(string word in words){
            foreach(char ch in word){
                cur = cur.Insert(ch);
            }
            cur.isEnd = true;
            cur = root;
        }
        return root;
    }
}
public class Node{
    public Node[] child;
    public bool isEnd;
    
    public Node(){
        child = new Node[26];
        isEnd = false;
    }
    public Node Insert(char ch){
        if(!Contains(ch))
        {
            child[ch-'a'] = new Node();
            return child[ch-'a'];
        }
        else
            return child[ch-'a'];
    }
    public bool Contains(char ch){
        if(child[ch-'a']!=null)
            return true;
        else 
            return false;
    }
}

/*
Brute force solution:
    TC: w * m * n * (4^m*n)

Above solution:
TC: O((W * L) + (M * N) 4^L)
SC: O((W * L) + (M * N))
where 
W is the number of words, 
L is the average length of each word, 
M and N are the dimensions of the board
*/