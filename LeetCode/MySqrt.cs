//求一个数的平方根
public class Solution {
    //二分法
    public int MySqrt(int x) {
        if (x == 0) return 0;

        int left = 1, right = x;
        while (left <= right)
        {
            int mid  = left + (right - left) / 2;
            if (mid > x / mid) // 相当于mid * mid ==? x 防止溢出
                right = mid - 1;
            else if (mid < x / mid)
                left = mid + 1;
            else 
                return mid;
        }

        return right;
    }

    //牛顿迭代法
    public int MySqrtByNewton(int x) {
        long t = x;
        while (t * t > x)
            t = (t + x / r) / 2;
        return (int)t;
    }
}