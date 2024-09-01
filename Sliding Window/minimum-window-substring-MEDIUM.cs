public class Solution {
    public string MinWindow(string s, string t) {
        if (s.Length == 0 || t.Length == 0) return "";
        
        var requiredChars = new Dictionary<char, int>();
        foreach (var c in t) {
            if (requiredChars.ContainsKey(c)) {
                requiredChars[c]++;
            } else {
                requiredChars[c] = 1;
            }
        }
        
        int required = requiredChars.Count;
        int formed = 0;
        
        var windowCounts = new Dictionary<char, int>();
        int l = 0, r = 0;
        int[] ans = {-1, 0, 0}; // Length of window, left, right
        
        while (r < s.Length) {
            char c = s[r];
            if (windowCounts.ContainsKey(c)) {
                windowCounts[c]++;
            } else {
                windowCounts[c] = 1;
            }
            
            if (requiredChars.ContainsKey(c) && windowCounts[c] == requiredChars[c]) {
                formed++;
            }
            
            while (l <= r && formed == required) {
                c = s[l];
                
                if (ans[0] == -1 || r - l + 1 < ans[0]) {
                    ans[0] = r - l + 1;
                    ans[1] = l;
                    ans[2] = r;
                }
                
                windowCounts[c]--;
                if (requiredChars.ContainsKey(c) && windowCounts[c] < requiredChars[c]) {
                    formed--;
                }
                
                l++;
            }
            
            r++;
        }
        
        return ans[0] == -1 ? "" : s.Substring(ans[1], ans[0]);
    }
}
