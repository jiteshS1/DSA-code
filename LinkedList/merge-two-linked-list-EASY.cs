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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if(list1==null)
            return list2;
        if(list2==null)
            return list1;
        ListNode mergedNode = new ListNode(), 
            head=null;
        while(list1 != null && list2 != null)
        {
            if(list1.val <= list2.val)
            {
                mergedNode.next = list1;
                list1 = list1.next;
            }
            else
            {
                mergedNode.next = list2;
                list2 = list2.next;
            }
            if(head==null)
                head = mergedNode;
            
            mergedNode = mergedNode.next;
            
        }
        mergedNode.next = list1 != null? list1:list2;

        return head.next;
    }
}
/*
-----Better Iterative solution:
public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if(list1 == null)
            return list2;
        if(list2 == null)
            return list1;
        
        ListNode resHead = new ListNode();
        ListNode curr = resHead;
        while(list1 != null && list2 != null){
            if(list1.val <= list2.val){
                curr.next = list1;
                list1 = list1.next;
            }else{
                curr.next = list2;
                list2 = list2.next;
            }
            curr = curr.next;
        }
        if(list1==null)
            curr.next = list2;
        else 
            curr.next = list1;
            
        return resHead.next;
    }
}

------Recursive solution:
public ListNode mergeTwoLists(ListNode l1, ListNode l2){
		if(l1 == null) return l2;
		if(l2 == null) return l1;
		if(l1.val < l2.val){
			l1.next = mergeTwoLists(l1.next, l2);
			return l1;
		} else{
			l2.next = mergeTwoLists(l1, l2.next);
			return l2;
		}
}
*/