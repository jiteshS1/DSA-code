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
    public ListNode ReverseKGroup(ListNode head, int k) {
        ListNode temp = head, kthNode = null, nextNode = null, prevNode=null, newHead=null;
        while(temp!=null){
            //Find kth node
            kthNode = findKthNode(temp, k); //it can return null also
            if(kthNode==null){
                prevNode.next = temp;
                break;
            }
            nextNode = kthNode.next;
            kthNode.next = null;
            newHead = ReverseNode(temp);
            //Reverse node list
            if(head==temp)
                head = newHead;
            else
                prevNode.next = newHead; 

            temp.next = nextNode;
            prevNode = temp;
            temp = temp.next;
        }
        return head;
    }
    ListNode findKthNode(ListNode start, int k){
        int count=k;
        while(count>1 && start!=null){
            count--;
            start = start.next;
        }
        return start;
    }
    ListNode ReverseNode(ListNode begin){
        ListNode next, prev=null;
        while(begin!=null){
            next = begin.next;
            begin.next = prev;
            prev = begin;
            begin = next;
        }
        return prev;
    }

}