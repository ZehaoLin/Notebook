//找出第k大的元素  1 <= k <= array's length
//tag: Heap, Divide and Conquer
public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        if (nums.Length == 0) return -1;

        int ret = 0;
        int n = nums.Length;
        //建立大顶堆
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(nums, i, n);
        //排序
        for (int i = n - 1; i > 0; i--)
        {
            Swap(nums, 0, i);
            Heapify(nums, 0, i);   
        }
        
        return ret;
    }

    //调整堆
    public void Heapify(int[] nums, int curIndex, int heapSize)
    {
        int le = 2 * curIndex + 1;
        int ri = 2 * curIndex + 2;
        int large = curIndex;
        if (le < heapSize && nums[le] > nums[large]) large = le;
        if (ri < heapSize && nums[ri] > nums[large]) large = ri;
        if (large != curIndex)
        {
            Swap(nums, large, curIndex);
            Heapify(nums, large, heapSize);//递归调整
        }
    }

    //交换元素
    public void Swap(int[] nums, int i, int j)
    {
        int t = nums[i];
        nums[i] = nums[j];
        nums[j] = t;
    }
}