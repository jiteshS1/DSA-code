/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<int> RightSideView(TreeNode root) {
        IList<int> res = new List<int>();
        if(root==null)
            return res;
        var qu = new Queue<LevelNode>();
        qu.Enqueue(new LevelNode(root, 1));
        int prevVal=0, curLevel = 1;
        while(qu.Count > 0){
            var levelNode = qu.Dequeue();
            if(levelNode.level == curLevel)
                prevVal = levelNode.node.val;
            else{
                res.Add(prevVal);
                curLevel = levelNode.level;
                prevVal = levelNode.node.val;
            }

            if(levelNode.node.left != null)
                qu.Enqueue(new LevelNode(levelNode.node.left, curLevel+1));
            if(levelNode.node.right != null)
                qu.Enqueue(new LevelNode(levelNode.node.right, curLevel+1));
        }
        res.Add(prevVal);
        return res;
    }
}
public class LevelNode{
    public int level;
    public TreeNode node;
    public LevelNode(TreeNode node, int level){
        this.level = level;
        this.node = node;
    }
}
/*
TC, SC: O(n)

Another approach using recursion:
public class Solution {
    public List<Integer> rightSideView(TreeNode root) {
        List<Integer> result = new ArrayList<Integer>();
        rightView(root, result, 0);
        return result;
    }
    
    public void rightView(TreeNode curr, List<Integer> result, int currDepth){
        if(curr == null){
            return;
        }
        if(currDepth == result.size()){
            result.add(curr.val);
        }
        
        rightView(curr.right, result, currDepth + 1);
        rightView(curr.left, result, currDepth + 1);
        
    }
}
*/