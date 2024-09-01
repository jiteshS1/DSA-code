public class Solution {
    //Brute force solution TC: O(n^2)
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int start = 0, cGas = 0;
        while(start < gas.Length){
            if(gas[start] >= cost[start])
            {
                int count = 0, i=-1;
                for(i=start; i<gas.Length && count<gas.Length; count++){
                    cGas += gas[i];
                    //Check if current gas is more or equal then 
                    if(cGas >= cost[i]){
                        cGas -= cost[i];
                    }else{
                        break;
                    }
                    i++;
                    i = i % gas.Length;
                }
                if(i == start){
                    return start;
                }
            }
            cGas = 0;
            start++;
        }
        return -1;
    }
}
/*
class Solution {
    public int canCompleteCircuit(List<int> A, List<int> B) {
        int startIndex = 0, currentGas = 0;
        
        for(int i=0; i<A.Count(); i++){
            startIndex = i;
            int currentIndex = startIndex;
            currentGas += A[i];
            if(currentGas >= B[i]){
                //I can go to next station
                currentIndex++;
                currentIndex = currentIndex % A.Count(); 
                currentGas -= B[i];
                while(startIndex != currentIndex){
                    currentGas += A[currentIndex];
                    if(currentGas >= B[currentIndex]){
                        //I can go to next station
                        currentGas -= B[currentIndex];
                    }else{
                        //I cannot go to next station
                        if(currentIndex>i)
                            i = currentIndex; //Update i index
                            
                        currentGas = 0;
                        break;
                    }
                    currentIndex++;
                    currentIndex = currentIndex % A.Count(); 
                }   
                if(startIndex ==  currentIndex)
                    return startIndex;
            }else{
                currentGas = 0;
            }
        }
        return -1;
    }
}


#Better solution:
TC: O(n), SC: O(1)
https://leetcode.com/problems/gas-station/solutions/1706142/java-c-python-an-explanation-that-ever-exists-till-now/
public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int totalGas = 0, curGas = 0, startIndex = 0;
        
        for(int i=0; i<gas.Length; i++){
            totalGas += gas[i] - cost[i];
            curGas += gas[i];
            if(curGas < cost[i]){
                //Can NOT go to next station
                curGas = 0; 
                startIndex = i+1;
            }else{
                //Can go to next station
                curGas -= cost[i]; 
            }
        }

        return (totalGas < 0)? -1:startIndex; 
    }
}


#Brute force solution
sIndex = 0
cGas = 0
while sIndex<Length
    Loop each gas station value, i = sIndex        
        cGas += gas[i]
        //Check if gas is more then cost or same
        if cGas <= cost[i]
            cGas = cGas - cost[i] //Increment i
        else
            sIndex++
            break;
        
        //Start from starting
        if i = Length-1
            i=-1
        
        if sIndex = i
                return sIndex;

return -1
*/