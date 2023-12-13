int findEquilibriumIndex(vector<int> &arr) {
    int n = arr.size();
    int arraySum = 0, leftSum = 0;

    // Finding the total sum of the array.
    for (int i = 0; i < n; i++) {
        arraySum += arr[i];
    }

    for (int i = 0; i < n; i++) {
        // Checking if the given condition is true or not.
        if (leftSum == arraySum - leftSum - arr[i]) {
            return i;
        }

        // Finding the sum of the left prefix of the array.
        leftSum += arr[i];
    }

    // If we don't find an equilibrium index, then we return -1.
    return -1;
}
