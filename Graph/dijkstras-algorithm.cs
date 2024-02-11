/*
We can store graph in adjacency list.
#Using PQ:
In PQ, we can store {distance, node}
A distance array of size n nodes. Set distance of 0 as 0 and other  Initialize values with Max Int value.
Insert {0, 0} in PQ.
Dequeue from PQ
Loop neighbour nodes of node (this case 0) using values from adj. list.
    If the distance (distance from PQ + from adj. list) is shorter then what is defined in the distance array then update the value in distance array.
    Insert that {distance, node} in PQ
    Repeat this same process.

#Using Sets:
Sets store unique value and smallest at the top, stores everything in ascending order.
Same steps as of PQ
We can erase data from set, example: suppose if we see that in distance array if at position/node-5, 10 weight distance is stored and I am currently processing {8, 5} from set then I know there must be a set of {10, 5} in sets array that I can remove directly.
Erasing data from PQ was not possible, so this is the advantage of using sets.
Erase takes log n and we can same some iterations but it will be a hardly a difference. 


*/