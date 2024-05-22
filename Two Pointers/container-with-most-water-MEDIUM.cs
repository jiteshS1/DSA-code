public class Solution {
    public int MaxArea(int[] height) {
        int l = 0, r = height.Length-1;
        int maxArea = 0;
        while(l<r){
            int len = Math.Min(height[l], height[r]);
            int bre = r - l;
            maxArea = Math.Max(maxArea, (len * bre));
            if(height[l] < height[r])
                l++;
            else if(height[r] < height[l])
                r--;
            else{
                l++;
                r--;
            }
        }
        return maxArea;
    }
}
/*
TC: O(n), SC:(1)
- Need maxLength & maxBreadth to get max area
- Can not contain water on left side of 0 & right side of len-1
- Two pointers one at start
- Get max from left & right side

initial maxarea by 0 
l = 0 & r = len-1
Loop into height
    - Check & set maxl & maxr
    - Calcular max area
    - dec pointers

*/