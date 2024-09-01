public class Solution {
    public int LongestConsecutive(int[] nums) {
        if(nums.Length==0)
            return 0;
        var set = new HashSet<int>();
        foreach(int num in nums){
            if(!set.Contains(num)){
                set.Add(num);
            }
        }
        int res = 1, tLen = 1;
        foreach(int num in nums){
            if(set.Contains(num-1))
                continue;
            else{
                int next = num+1;
                while(set.Contains(next)){
                    tLen++;
                    next++; 
                }
                res = System.Math.Max(res, tLen);
                tLen = 1;
            }
        }

        return res;
    }
}
/*
- Store nums in HashSet
- Loop each num in nums
    - Check if num-1 exist in set?
        - If yes continue;
        - If no
            Check next consecutive number from nums
            Increase length count if found & update len

*/