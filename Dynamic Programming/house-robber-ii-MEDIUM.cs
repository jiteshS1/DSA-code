public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 1) return nums[0];
        
        // Rob first house, exclude last
        int robFirstExcludeLast = RobHelper(nums, 0, nums.Length - 2);
        // Exclude first house, include last
        int excludeFirstIncludeLast = RobHelper(nums, 1, nums.Length - 1);
        
        return Math.Max(robFirstExcludeLast, excludeFirstIncludeLast);
    }
    
    private int RobHelper(int[] nums, int start, int end) {
        int rob1 = 0, rob2 = 0;
        
        for (int i = start; i <= end; i++) {
            int temp = Math.Max(nums[i] + rob1, rob2);
            rob1 = rob2;
            rob2 = temp;
        }
        
        return rob2;
    }
}
