public class MinStack {
    Node node;
    public MinStack() {
        node = new Node();
    }
    
    public void Push(int val) {
        Node temp = node;
        node.next = new Node(val);
        
        node = node.next;
        node.prev = temp;

        if(temp!=null 
        && temp.min!=null && temp.min<val){
            node.min = temp.min;
        }else{
            node.min = val;
        }
    }
    
    public void Pop() {
        node = node.prev;
        node.next = null;
    }
    
    public int Top() {
        return node.val;
    }
    
    public int GetMin() {
        return (int)node.min;
    }
}
class Node{
    public Node prev;
    public Node next;
    public int val;
    public int? min;
    public Node(){
        min=null;
    }
    public Node(int val){
        this.val = val;
    }
}
/*
    TC: O(1)
    SC: O(n)

    Cleaner approach:
    class MinStack {
	private Node head;
        
    public void push(int x) {
        if (head == null) 
            head = new Node(x, x, null);
        else 
            head = new Node(x, Math.min(x, head.min), head);
    }
    
    public void pop() {
        head = head.next;
    }
    
    public int top() {
        return head.val;
    }
    
    public int getMin() {
        return head.min;
    }
        
    private class Node {
        int val;
        int min;
        Node next;
            
        private Node(int val, int min, Node next) {
            this.val = val;
            this.min = min;
            this.next = next;
        }
    }
}
*/
/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */