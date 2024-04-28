public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        if(n==0) return true;
        for(int i=0; i<flowerbed.Length; i ++){
            if(flowerbed[i] == 0) {
                //get next and prev flower bed slot values. 
                //If i lies at the ends the next and prev are considered as 0. 
            int next = (i == flowerbed.Length - 1) ? 0 : flowerbed[i + 1]; 
            int prev = (i == 0) ? 0 : flowerbed[i - 1];
            if(next == 0 && prev == 0) {
                flowerbed[i] = 1;
                n--;
            }
            }
        }
        if(n<=0)
            return true;
        else 
            return false;
    }
}