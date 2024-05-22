public class Solution {
    public int FindDuplicate(int[] nums) {
        var hs = new HashSet<int>();
        foreach(int num in nums){
            if(hs.Contains(num))
                return num;
            else
                hs.Add(num);
        }
        return -1;
    }
}
/*
1st approach:
- Use HashSet
    - TC, SC: O(n)

2nd:
Can use linked list to store numbers in sorted list 
 - Insertion will take O(log n)
 - TC: (n log n)

*/