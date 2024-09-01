public class Solution {
    public int NumDecodings(string s) {
        // Use a dictionary for memoization
        var memo = new Dictionary<int, int>();
        return DFS(0, s, memo);
    }
    
    public int DFS(int i, string s, Dictionary<int, int> memo){
        if(i >= s.Length)
            return 1;
        
        if(memo.ContainsKey(i))
            return memo[i];

        // Single character decode
        if(s[i] == '0')
            return 0;

        int res = DFS(i + 1, s, memo);

        // Two-character decode
        if(i + 1 < s.Length) {
            string decode = s.Substring(i, 2);
            int digit = Convert.ToInt32(decode);
            if(digit <= 26) {
                res += DFS(i + 2, s, memo);
            }
        }

        memo[i] = res;
        return res;
    }
}
/*
    TC, SC: O(n)
*/