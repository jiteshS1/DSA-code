/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        ListNode head2 = head;
        while(head!=null && head2!=null)
        {
            //Jump 2nd head by 2 pointers
            if(head2.next!=null)
                head2 = head2.next.next;
            else
                head2 = null;

            //It is cycle
            if(head == head2)
                return true;

            head = head.next;
        }
        return false;
    }
}