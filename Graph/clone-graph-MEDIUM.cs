/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/
public class Solution {
    public Node CloneGraph(Node node) {
        if (node == null)
            return null;

        Dictionary<Node, Node> cloneMap = new Dictionary<Node, Node>();
        Queue<Node> queue = new Queue<Node>();
        
        Node clone = new Node(node.val);
        cloneMap[node] = clone;
        queue.Enqueue(node);
        
        while (queue.Count > 0) {
            Node original = queue.Dequeue();
            Node cloned = cloneMap[original];
            
            foreach (Node neighbor in original.neighbors) {
                if (!cloneMap.ContainsKey(neighbor)) {
                    Node neighborClone = new Node(neighbor.val);
                    cloneMap[neighbor] = neighborClone;
                    queue.Enqueue(neighbor);
                }
                cloned.neighbors.Add(cloneMap[neighbor]);
            }
        }
        
        return clone;
    }
}
