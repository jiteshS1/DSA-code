// C# program to print DFS traversal
// from a given graph
using System;
using System.Collections.Generic;

// This class represents a directed graph
// using adjacency list representation
class Graph {
	private int V;

	// Array of lists for
	// Adjacency List Representation
	private List<int>[] adj;

	// Constructor
	Graph(int v)
	{
		V = v;
		adj = new List<int>[ v ];
		for (int i = 0; i < v; ++i)
			adj[i] = new List<int>();
	}

	// Function to Add an edge into the graph
	void AddEdge(int v, int w)
	{
		// Add w to v's list.
		adj[v].Add(w);
	}

	// A function used by DFS
	void DFSUtil(int v, bool[] visited)
	{
		// Mark the current node as visited
		// and print it
		visited[v] = true;
		Console.Write(v + " ");

		// Recur for all the vertices
		// adjacent to this vertex
		List<int> vList = adj[v];
		foreach(var n in vList)
		{
			if (!visited[n])
				DFSUtil(n, visited);
		}
	}

	// The function to do DFS traversal.
	// It uses recursive DFSUtil()
	void DFS(int v)
	{
		// Mark all the vertices as not visited
		// (set as false by default in c#)
		bool[] visited = new bool[V];

		// Call the recursive helper function
		// to print DFS traversal
		DFSUtil(v, visited);
	}

	// Driver Code
	public static void Main(String[] args)
	{
		Graph g = new Graph(4);

		g.AddEdge(0, 1);
		g.AddEdge(0, 2);
		g.AddEdge(1, 2);
		g.AddEdge(2, 0);
		g.AddEdge(2, 3);
		g.AddEdge(3, 3);

		Console.WriteLine(
			"Following is Depth First Traversal "
			+ "(starting from vertex 2)");

		// Function call
		g.DFS(2);
		Console.ReadKey();
	}

/*
- Variables:
    - Visted node array.
    - Adj. list array
- Call df(node)
- dfs(node)
    - If node is not visited
        - mark node as visited.
        - Print Node --- It will print all nodes
        - Loop neighbour nodes (Check from adj. list)
            - dfs(neighbourNode)

Recursive solution:
//{ Driver Code Starts
//Initial Template for C#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverCode
{

    class GFG
    {
        static void Main(string[] args)
        {
            int testcases;// Taking testcase as input
            testcases = Convert.ToInt32(Console.ReadLine());
            while (testcases-- > 0)// Looping through all testcases
            {

                var ip = Console.ReadLine().Trim().Split(' ');
                int V = int.Parse(ip[0]);
                int E = int.Parse(ip[1]);
                List<int>[] adj = new List<int>[V];
                for (int i = 0; i < V; i++)
                {
                    adj[i] = new List<int>();
                }
                for (int i = 0; i < E; i++)
                {
                    ip = Console.ReadLine().Trim().Split(' ');
                    int u = int.Parse(ip[0]);
                    int v = int.Parse(ip[1]);
                    adj[u].Add(v);
                    adj[v].Add(u);
                }
                Solution obj = new Solution();
                var res = obj.dfsOfGraph(V, adj);
                foreach (int i in res)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }

        }
    }
}

// } Driver Code Ends


//User function Template for C#

class Solution
{
    //Complete this function
    //Function to return a list containing the DFS traversal of the graph.
    public int[] dfsOfGraph(int V, List<int>[] adj)
    {
        //Your code here
        var res = new int[V];
        var vis = new bool[V];
        int count = 0;
        DFS(0, adj, ref res, ref count, ref vis);
        return res;
    }
    public void DFS(int i, List<int>[] adj, ref int[] res, ref int count, ref bool[] vis){
        if(vis[i]==false){
            res[count++] = i;
            vis[i] = true;
            for(int j=0; j<adj[i].Count(); j++){
                if(vis[adj[i][j]]==false){
                    DFS(adj[i][j], adj, ref res, ref count, ref vis);
                }
            }
        }
    }
}
TC, SC: O(V +E)
             
*/