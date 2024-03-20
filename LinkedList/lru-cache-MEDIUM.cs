public class LRUCache {
    // Define the doubly linked list node structure
    public class Node {
        public int key;
        public int value;
        public Node prev;
        public Node next;
        public Node(int key=0, int value=0, Node prev=null, Node next=null) {
            this.key = key;
            this.value = value;
            this.prev = prev;
            this.next = next;
        }
    }

    // Declare necessary variables
    private Node head; // points to the most recently used node
    private Node last; // points to the least recently used node
    private Dictionary<int, Node> dict; // to store key-node pairs
    private int maxSize; // maximum capacity of the cache
    private int curSize; // current number of elements in the cache

    // Constructor to initialize the LRUCache
    public LRUCache(int capacity) {
        head = null;
        last = head;
        dict = new Dictionary<int, Node>();
        maxSize = capacity;
        curSize = 0;
    }

    // Get the value of a key from the cache
    public int Get(int key) {
        if (dict.ContainsKey(key)) {
            var res = dict[key];
            MakeNodeHead(res); // Move the accessed node to the head (most recently used)
            return res.value;
        } else {
            return -1;
        }
    }

    // Put a key-value pair into the cache
    public void Put(int key, int value) {
        if (!dict.ContainsKey(key)) {
            // Key does not exist
            // Add node at the beginning
            Node next = head;
            head = new Node(key, value, null, next);
            if (next != null)
                next.prev = head;

            dict.Add(key, head);
            curSize++;

            // Set last node if cache was empty
            if (next == null)
                last = head;

            if (curSize > maxSize && last != null) {
                // Size is more, remove the last node
                var temp = last;
                last = last.prev;
                if (last != null)
                    last.next = null;
                dict.Remove(temp.key);
                curSize--;
            }
        } else {
            // Key exists
            var res = dict[key];
            res.value = value; // Update value
            MakeNodeHead(res); // Move the accessed node to the head (most recently used)
        }
    }

    // Move a node to the head (most recently used)
    public void MakeNodeHead(Node node) {
        if (node != head) {
            if (node == last) {
                last = last.prev; // Update last pointer if the node is the last node
            }
            // Remove node from current position
            if (node.prev != null) {
                node.prev.next = node.next;
            }
            if (node.next != null) {
                node.next.prev = node.prev;
            }
            // Make node the new head
            node.next = head;
            node.prev = null;
            if (head != null) {
                head.prev = node;
            }
            head = node;
        }
    }
}
