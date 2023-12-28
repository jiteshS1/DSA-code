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
        ListNode newHead = null, temp=null;
        int duplicate = -101;
        if(head==null) return head;
        
        while(head!=null)
        {
            if((head.next!=null && head.val == head.next.val) 
            || (head.next==null && head.val == duplicate) || head.val == duplicate)
            {
                duplicate = head.val;
            }else{
                if(newHead==null)
                {
                    newHead = head;
                    temp = head;
                }else
                {
                    temp.next = head;
                    temp = temp.next;
                }
            }
            head = head.next;
        }
        if(temp!=null)
            temp.next=null;
            
        return newHead;
    }
}
/*
    If encounter two nodes with same value:
        store that number in dupicateVar
        skip headNode till we encounter next two different node.
            make prevNode (last duplicate) next to null 
            Result: headNode is decided
        Decide next node based same process again
            Assign that node as temp: headNode.next
        
*/