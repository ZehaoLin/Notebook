public class Solution {
    public int HammingDistance(int x, int y) {
        int diff = x ^ y;

        int ret = 0;
        while (diff != 0)
        {
            ret += diff & 0x01;
            diff = diff >> 1;
        }

        return ret;
    }
}