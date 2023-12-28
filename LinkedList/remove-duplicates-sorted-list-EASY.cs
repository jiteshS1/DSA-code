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
    public ListNode DeleteDuplicates(ListNode head) {
        ListNode head2 = head, prev = null;
        while(head2 != null)
        {
            if(prev !=null && prev.val ==  head2.val)
                prev.next = head2.next;
            else
                prev = head2;
            head2 = head2.next;
        }
        return head;
    }
}
/*
With only one node variable
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        ListNode head2 = head;
        while(head2 != null)
        {
            if(head2.next==null)
                break;
            if(head2.val ==  head2.next.val)
                head2.next = head2.next.next;
            else
                head2 = head2.next;
        }
        return head;
    }
}
*/