public class Solution {
    public int Reverse(int x) {
        if (x > Int32.MaxValue || x < Int32.MinValue) return 0;
        else if (x < 10 && x > -10) return x;

        int res = 0;
        bool isN = false;
        if (x < 0)
        {
            isN = true;
            x = 0 - x;
        }

        while (x > 0)
        {
            if (res != 0 && Int32.MaxValue / res < 10)
                return 0;

            int mod = x % 10;
            x /= 10;
            res = mod + res * 10;
        }

        if (isN == true)
            res = 0 - res;

        return res;
    }
}