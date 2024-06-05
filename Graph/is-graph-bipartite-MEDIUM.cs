public class Solution {
    public bool IsBipartite(int[][] graph) {
        if(graph.Length==0)
            return true;
        var vis = new int[graph.Length];
        for(int i=0; i<graph.Length; i++){
            if(vis[i] == 0){
                var res = DFS(graph, i, ref vis, 1);
                if(res == false)
                    return false;
            }
        }
        return true;
    }
    public bool DFS(int[][] graph, int v, ref int[] vis, int color){
        if(vis[v] !=0 && vis[v]==color){
            //Color is already set & it is same as given
            return true;
        } else if(vis[v] != 0 && vis[v]!=color)
        {
            //Color is set 
            //If same color in adjacent node then return false
            return false;
        }else{
            //Color is not set
            vis[v] = color; //Set color
            //Check adjacent vertex 
            for(int i=0; i<graph[v].Length; i++)
            {
                var res = DFS(graph, graph[v][i], ref vis, color == 1? 2:1);
                if(res == false)
                    return false;
                else
                    continue;
            }
            return true;
        }
    }
}
/*
TC: O(V+E), SC: O(V)
Above solution is DFS approach
If I want to use BFS then I can use queue to store nodes which I want to process.
rather then using recursion.
*/