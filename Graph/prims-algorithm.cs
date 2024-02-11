/*
#Algo:
- Variable:
    - Priority Queue TElement{weight, node, parent}, TPriority {weight}
    - visited node array size number of nodes
    - res array
- Add first node in PQ with parent as -1 and weight 0 
- Loop till PQ is empty
    - Dequeue from PQ call it dqNode
    - if dqNode parent is -1
        - mark visited position as 1
        - Loop by column to visit each vertex
            - if value is 1
                enqueue that in PQ
    - else if node in dqNode is not visited
        - add that two edges in res array
        -  mark visited position as 1
        - pick node from dqNode add start repeating 
        - Loop by column to visit each vertex
            - if value is 1
                enqueue that in PQ
    - else continue
- Return result.

TC: O(n * log n)
*/