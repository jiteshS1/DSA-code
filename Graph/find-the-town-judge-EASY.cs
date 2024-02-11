public class Solution {
    public int FindJudge(int n, int[][] trust) {
        int[] trustCounts = new int[n + 1];
        
        foreach (var relation in trust) {
            trustCounts[relation[0]]--; // decrement trust count for the person who trusts
            trustCounts[relation[1]]++; // increment trust count for the person being trusted
        }

        for (int i = 1; i <= n; i++) {
            if (trustCounts[i] == n - 1) {
                // If a person is trusted by all others (n-1), then it satisfies the conditions
                return i;
            }
        }

        return -1;
    }
}