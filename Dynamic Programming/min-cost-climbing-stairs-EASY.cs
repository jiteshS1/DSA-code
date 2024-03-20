public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        for(int i=cost.Length-3; i>=0; i--){
            cost[i] = System.Math.Min(cost[i]+cost[i+1], cost[i] + cost[i+2]);
        }
        return System.Math.Min(cost[0], cost[1]);
    }
}
