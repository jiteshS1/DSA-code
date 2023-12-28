/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public int GetDecimalValue(ListNode head) {
        //Get count
        ListNode head2 = head;
        int count=0, result=0;
        while(head2!=null)
        {
            head2 = head2.next;
            count++;
        }
        while(head != null)
        {
            count--;
            if(head.val==1)
            {
                 result += PowerOfTwo(count);
            }
            head = head.next;
        }
        return result;
    }
    int PowerOfTwo(int power)
    {
        int result = 1;
        for(int i=1; i<=power; i++)
        {
            result = 2*result;
        }
        return result;
    }
}
/*
Better Solution: 
public int getDecimalValue(ListNode head) {
       int sum = 0;
        
        while (head != null){
            sum *= 2;
            sum += head.val;
            head = head.next;
        }
        return sum;
    }
Ref: https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/solutions/629087/detailed-explanation-java-faster-than-100-00/
*/