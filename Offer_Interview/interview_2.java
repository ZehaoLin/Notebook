/**
    剑指Offer 面试题2
    实现Singleton(单例)模式
 */
// case 1 只适用单线程环境
public class Singleton {
    
    private static Singleton instance = null;

    private Singleton() {

    }

    public static Singleton getInstance() {
        if (instance == null)
            instance = new Singleton();
        return instance;
    }
}

// case 2 可在多线程环境下工作，但效率不高
public class Singleton {

    private static Lock lockObj = new ReentrantLock();
    private static Singleton instance = null;

    private Singleton() {

    }

    public static Singleton getInstance() {
        lockObj.lock();
        try {
            if (instance == null)
                instance = new Singleton();
        } finally {
            lockObj.unLock();
        }

        return instance;
    }
}

// case 3 加同步锁前后两次判断实例是否存在
public class Singleton {

    private static Lock lockObj = new ReentrantLock();
    private static Singleton instance = null;

    private Singleton() {

    }

    public static Singleton getInstance() {
        if (instance == null) {
            lockObj.lock();
            try {
                if (instance == null)
                    instance = new Singleton();
            } finally {
                lockObj.unLock();
            }
        }

        return instance;
    }
}

// case 4 使用静态构造方法 *
public class Singleton {

    private static Singleton instance = new Singleton();

    private Singleton() {

    }

    public static Singleton getInstance() {
        return instance;
    }
}