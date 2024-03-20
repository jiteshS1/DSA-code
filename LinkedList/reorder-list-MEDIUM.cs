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
    public void ReorderList(ListNode head) {
        var st = new System.Collections.Generic.Stack<ListNode>();
        var qu = new System.Collections.Generic.Queue<ListNode>();

        ListNode slow = head, fast = head;
        while(fast!=null && fast.next!=null){
            qu.Enqueue(slow);
            slow = slow.next;
            fast = fast.next.next;
        }
        while(slow!=null){
            st.Push(slow);
            slow = slow.next;
        }

        ListNode current = head;
        while (st.Count > 0 || qu.Count > 0) {
            if (qu.Count > 0) {
                current.next = qu.Dequeue();
                current = current.next;
            }
            if (st.Count > 0) {
                current.next = st.Pop();
                current = current.next;
            }
        }
        current.next = null; // Set the next of the last node to null to terminate the list

    }
}\
/*
TC & SC of above solution is O(n)

Better approach with TC: O(n) & SC: O(1)
class Solution:
    def reorderList(self, head):
        #step 1: find middle
        if not head: return []
        slow, fast = head, head
        while fast.next and fast.next.next:
            slow = slow.next
            fast = fast.next.next
        
        #step 2: reverse second half
        prev, curr = None, slow.next
        while curr:
            nextt = curr.next
            curr.next = prev
            prev = curr
            curr = nextt    
        slow.next = None
        
        #step 3: merge lists
        head1, head2 = head, prev
        while head2:
            nextt = head1.next
            head1.next = head2
            head1 = head2
            head2 = nextt
*/