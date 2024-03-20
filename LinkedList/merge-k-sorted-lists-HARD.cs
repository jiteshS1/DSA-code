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
    public ListNode MergeKLists(ListNode[] lists) {
        bool flag = false;
        int min = int.MaxValue, index=-1;
        ListNode res = new ListNode();
        ListNode cur = res;
        while(flag==false){
            flag = true;
            for(int i=0; i<lists.Length; i++){
                ListNode node = lists[i];
                if(node != null){
                    flag = false;
                    if(node.val < min){
                        min = node.val;
                        index = i;
                    }
                }
            }
            if(index > -1){
                var node = lists[index];
                ListNode temp = node.next;
                node.next = null;

                cur.next = node;
                cur = cur.next;

                lists[index] = temp;

                min = int.MaxValue;
                index = -1;
            }
        }
        return res.next;
    }
}
/*
#Brute force solution:
TC: O(n*k) almost O(n*n) if k is large
SC: O(1)

- Loop till flag is false - 500 n
    - Set flag true
    - Loop lists array - k
        - If value from listnode in min, then update new min & store the index
        -  make flag false if any node is present in array.
- Take node from that index and add it is result 

---------------Using priority queue TC: O(n* log k) & SC: O(k)
public class Solution {
    public ListNode mergeKLists(List<ListNode> lists) {
        if (lists==null||lists.size()==0) return null;
        
        PriorityQueue<ListNode> queue= new PriorityQueue<ListNode>(lists.size(),new Comparator<ListNode>(){
            @Override
            public int compare(ListNode o1,ListNode o2){
                if (o1.val<o2.val)
                    return -1;
                else if (o1.val==o2.val)
                    return 0;
                else 
                    return 1;
            }
        });
        
        ListNode dummy = new ListNode(0);
        ListNode tail=dummy;
        
        for (ListNode node:lists)
            if (node!=null)
                queue.add(node);
            
        while (!queue.isEmpty()){
            tail.next=queue.poll();
            tail=tail.next;
            
            if (tail.next!=null)
                queue.add(tail.next);
        }
        return dummy.next;
    }
}
*/