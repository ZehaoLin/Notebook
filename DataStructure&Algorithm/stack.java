import java.util.Iterator;//Java迭代器接口所属包

public class Stack<T> implements Iterable<T> {
    private T[] arr;
    private int len;

    public Stack() {//默认构造器
        arr = (T)new Object[1];//Java中不支持泛型对象数组 这里采用强制类型转换办法
        len = 0;//默认元素数量
    }

    public void push(T item) {//入栈
        if (arr.len == len) 
            resize(2 * arr.length);
        arr[len++] = item;
    }

    public T pop() {//出栈
        T t = arr[--len];
        arr[len] = null;//避免对象游离
        if (len > 0 && len == arr.length / 4)
            resize(arr.length / 2);
        return t;
    }

    public boolean isEmpty() {//检查栈是否为空
        return len == 0;
    }

    public int size() {//查看栈大小
        return len;
    }

    private void resize(int max) {//重新分配数组大小
        T[] t = (T[])new Object[max];
        for (int i = 0; i < len; i++) {
            t[i] = arr[i];
        }
        arr = t;
    }

    public Iterator<T> iterator() {
        return new ReverseArrayIterator();
    }

    private class ReverseArrayIterator implements Iterator<T> {//内部类，实现迭代器接口
        //支持先进后出迭代
        private int i = len;
        public boolean hasNext() { return i > 0; }
        public T next() { return arr[--i]; }
        public void remove { }
    }
} 