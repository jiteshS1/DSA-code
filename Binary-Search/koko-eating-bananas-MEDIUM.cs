public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        //Find max number from piles
        int max = piles[0];
        for(int i=1; i<piles.Length; i++){
            max = (max < piles[i])? piles[i]:max;
        }
        int l=1, r=max, m=0, result = max;
        //Use binary search to select values of k
        while(l<=r){
            m = (l + r)/2;
            long hours = 0;
            for(int i=0; i<piles.Length; i++){
                if(piles[i]<=m){
                    hours++;
                }else{
                    hours = hours + (piles[i]/m) + ((piles[i]%m>0)? 1:0);
                }
            }
            if(hours<=h){
                if(result>m)
                    result = m;
                r = m-1;
            }else{
                l=m+1;
            }
        }
        return result;
    }
}