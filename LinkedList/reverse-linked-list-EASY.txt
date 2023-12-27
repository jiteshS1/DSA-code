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
    public ListNode ReverseList(ListNode head) {
        if(head != null)
        {
            ListNode currentNode = null;
            ListNode nextNode = new ListNode();
            while(head.next!=null)
            {
                nextNode = head.next;
                head.next = currentNode; 
                currentNode = head;//Make head node as current node
                head = nextNode; 
            }
            head.next = currentNode;
        }
        return head;
    }
}