public class Solution {
    public int SubarraySum(int[] nums, int k) {
        var dict = new Dictionary<int, int>();
        dict.Add(0, 1);

        int sum = 0, res = 0;
        for(int i=0; i<nums.Length; i++){
            sum += nums[i];
            
            int prefixSum = sum - k;
            if(dict.ContainsKey(prefixSum))
                res += dict[prefixSum];
            //Check in prefix sum dictionary if it is already present
            if(dict.ContainsKey(sum)){
                dict[sum] += 1;
            }else{
                dict.Add(sum, 1);
            }

        }
        return res; 
    }
}
/*
 TC, SC: O(n)
*/