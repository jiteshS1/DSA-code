public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> dict = new Dictionary<int, int>(); 
        var res = new int[2];
        for(int i=0; i<nums.Length; i++){
            int num2 = target - nums[i];
            if(dict.ContainsKey(num2)){
                res[0] = i;
                res[1] = dict[num2];
                break;
            }else{
                if(!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], i);
            }
        }
        return res;
    }
}
/*
TC, SC: O(n)
*/