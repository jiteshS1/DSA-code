public class MyStack {
    DoublyLL current;
    public MyStack() {
        //Initialize node with null
        current = null;
    }
    
    public void Push(int x) {
        //Create new node
        DoublyLL node = new DoublyLL(current, null, x);
        //If no node is present then make it current
        if(current == null)
            current = node;
        else
        {
            current.next = node;
            current = current.next;
        }
    }
    
    public int Pop() {
        if(current != null){
            int value = current.value; 
            current = current.prev;
            if(current != null)
                current.next = null;

            return value;
        }else
            return -1;
    }
    
    public int Top() {
        if(current != null)
            return current.value;
        else
            return -1;
    }
    
    public bool Empty() {
        if(current != null)
            return false;
        else
            return true;
    }
}
//Class for stroing Dobly linked list node
public class DoublyLL{
    public DoublyLL prev;
    public DoublyLL next;
    public int value;
    public DoublyLL(DoublyLL prev, DoublyLL next, int value){
        this.prev = prev;
        this.next = next;
        this.value = value;
    }
}
/*
- Constructor will initialize queue
- Doubly LL can be used

1  > 2 
Dry run:
["MyStack", "push", "push", "top", "pop", "empty"]
[[], [1], [2], [], [], []]

TC: O(1), SC: (n)
*/

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */