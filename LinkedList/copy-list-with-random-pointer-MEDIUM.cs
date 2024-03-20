/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        var sDic = new Dictionary<Node, int>();
        var dDic = new Dictionary<int, Node>();
        Node res = new Node(-1);
        Node cur = res, oHead = head;
        int index = 0;

        while(head!=null){
            cur.next = new Node(head.val);
            dDic.Add(index, cur.next);
            cur = cur.next;
            sDic.Add(head, index++);
            head = head.next;
        }
        head = oHead;
        cur = res.next;

        while(head!=null){
            if(head.random != null){
                int sIndex = sDic[head.random];
                cur.random = dDic[sIndex];
            }
            cur = cur.next;
            head = head.next;
        }
        
        return res.next;
    }
}
/*
    TC, SC: O(n)
    SC can be optimized to O(1) if we follow below solution"
    public RandomListNode copyRandomList(RandomListNode head) {
  RandomListNode iter = head, next;

  // First round: make copy of each node,
  // and link them together side-by-side in a single list.
  while (iter != null) {
    next = iter.next;

    RandomListNode copy = new RandomListNode(iter.label);
    iter.next = copy;
    copy.next = next;

    iter = next;
  }

  // Second round: assign random pointers for the copy nodes.
  iter = head;
  while (iter != null) {
    if (iter.random != null) {
      iter.next.random = iter.random.next;
    }
    iter = iter.next.next;
  }

  // Third round: restore the original list, and extract the copy list.
  iter = head;
  RandomListNode pseudoHead = new RandomListNode(0);
  RandomListNode copy, copyIter = pseudoHead;

  while (iter != null) {
    next = iter.next.next;

    // extract the copy
    copy = iter.next;
    copyIter.next = copy;
    copyIter = copy;

    // restore the original list
    iter.next = next;

    iter = next;
  }

  return pseudoHead.next;
}
https://leetcode.com/problems/copy-list-with-random-pointer/solutions/43491/a-solution-with-constant-space-complexity-o-1-and-linear-time-complexity-o-n
*/