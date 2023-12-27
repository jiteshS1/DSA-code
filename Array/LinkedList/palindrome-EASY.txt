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
    public bool IsPalindrome(ListNode head) {
        ListNode slow=head, fast=head, prev = null, temp=null;
        while(fast!=null && fast.next!=null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        //Reverse node
        prev=slow;
        slow = slow.next;
        prev.next = null;
        while(slow!=null)
        {
            temp = slow.next;
            slow.next = prev;
            prev = slow;
            slow = temp; 
        }
        //Point head to start of two LL
        fast = head;
        slow = prev;
        while(slow!=null)
        {
            if(fast.val != slow.val)
                return false;
            slow = slow.next;
            fast = fast.next;
        }
        return true;
    }
}