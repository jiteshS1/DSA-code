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
    public ListNode SortList(ListNode head) {
        if(head==null)
            return null;
        var pq = new PriorityQueue<ListNode, int>();
        while(head!=null){
            pq.Enqueue(head, head.val);
            head = head.next;
        }
        ListNode res = pq.Dequeue(); 
        ListNode temp = res;
        while(pq.Count > 0){
            temp.next = pq.Dequeue();
            temp = temp.next;
        }
        temp.next = null;

        return res;
    }
}
/*
TC: O(n log n), SC: O(n)

Below solution takes TC: O(n log n) & SC: O(log n)
TC: O(n) (For merge opearation)  * O(log n) depth of tree.

public class Solution {
    public ListNode SortList(ListNode head) {
        if(head == null || head.next == null)
            return head;
        
        return MergeSort(head); // TC: 
    }
    //Find middle node method
    public ListNode FindMiddle(ListNode node){
        ListNode slow = node, fast = node;
        while(fast!=null && fast.next != null && fast.next.next != null){
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }
    //Merge Sort
    public ListNode MergeSort(ListNode node){
        if(node == null || node.next == null)
            return node;

        ListNode middleNode = FindMiddle(node); it will take O(n/2)
        
        ListNode rightHead = middleNode.next;
        middleNode.next = null;

        //Depth of tree will be log n
        ListNode leftList = MergeSort(node); 
        ListNode rightList = MergeSort(rightHead);

        //Merge both left & right List
        return MergeNodes(leftList, rightList);  // it will take O(n)
    }
    //Merge list of nodes
    public ListNode MergeNodes(ListNode left, ListNode right){
        ListNode res = new ListNode();
        ListNode head = res;
        while(left != null || right != null){
            if(left==null)
            {
                res.next = right;
                break;
            }
            else if(right == null){
                res.next = left;
                break;
            }
            else{
                if(left.val < right.val){
                    res.next = left;
                    left = left.next;
                }else{
                    res.next = right;
                    right = right.next;
                }
                res = res.next;
            }
        }
        return head.next;
    }
}
*/