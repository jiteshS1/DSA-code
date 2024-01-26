public class Solution {
    public int Search(int[] nums, int target) {
        int l=0, r = nums.Length-1, m=0;
        while(l<=r){
            m = (l+r)/2;
            
            if(nums[m]==target)
                return m;
            
            //Left sorted portion
            if (nums[l]<=nums[m]) {
                if(target<nums[l] || target>nums[m])
                {
                    l = m+1; //Search right
                }else
                    r = m-1; //Search left
            } else //Right sorted portion
            {
                if(target < nums[m] || target>nums[r])
                {
                    r = m-1; //Search left
                }else
                    l = m+1; //Search right
            }
        }
        return -1;
    }
}