public class Solution {
    public bool IsPalindrome(int x) {
        if (x < 0) return false;

        //识别多少位
        int len = 1;
        int left, right;
        while (x / len >= 10)
            len *= 10;

        while (x > 0)
        {
            //取头尾两位数对比
            left = x / len;
            right = x % 10;
            if (left != right)
                return false;
            else
            {
                //去除首尾
                x = (x % len) / 10;
                len /= 100;
            }
        }

        return true;
    }
}