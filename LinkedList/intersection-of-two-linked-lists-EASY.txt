/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        var hashList = new System.Collections.Generic.HashSet<ListNode>();
        while(headA!=null)
        {
            hashList.Add(headA);
            headA = headA.next;
        }
        while(headB != null)
        {
            if(hashList.Contains(headB))
                return headB;
            
            headB= headB.next;
        }
        return null;
    }
}