public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int length=nums.Length, sortedIndex=0;
        int i;
        for(i=0; i<length-1; i++){
            if(nums[i] != nums[i+1])
            {
                nums[sortedIndex++] = nums[i];
            }
        }
        if(nums[i] > nums[sortedIndex])
        {
            nums[sortedIndex] = nums[i];
        }
        return sortedIndex+1;
    }
}