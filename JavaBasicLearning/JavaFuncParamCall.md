---
title: Java中方法(函数)参数的传递
tag: Java
---

## Java中方法(函数)参数的传递

### 概述
在程序设计语言中，按值调用（call by value）表示方法接收的是调用者提供的值，而按引用调用（call by reference）表示方法接收的是调用者提供的变量地址（指针）。一个方法可以修改传递引用所对应的变量值，但是不能修改传递值调用所对应的变量值。

在Java程序设计语言中，总是采用[按值调用]()。也就是说，方法得到的是所有参数值的一个拷贝，特别是，方法不能修改传递给它的任何参数变量的内容。

### 例子

* 例子1
用一个方法试图将一个参数值增加到3倍

        public static void tripleValue(int x) { // 无法实现
            x = x * 3;
        }

        public static void main(String[] args) {
            int intValue = 1;
            tripleValue(intValue); 
            System.out.println(intValue); // doubleValue = 1
        }

说明：在main方法中，我们定义一个变量intValue，其值为1，再调用tripleValue方法，将x传入，完成函数调用后在console上打印x的值，结果还是为原来的值，并未改变。tripleValue方法被调用整个过程运行的步骤如下：

    1. x被初始化，且其值为调用者传递参数doubleValue的一个拷贝，即 x = 10
    2. 运算x = x * 3 ,即 x * 3 = 30 ，30赋值给x，x = 30 ，x为intValue的一个拷贝，x变了，但是intValue却未曾改变
    3. 方法运行结束，释放x

* 例子2
用一个方法实现将一个员工的工资提高2倍

        public static void tripleSalary(Employee e) { // 可以实现
            e.raiseSalary(200); //e的salary提高200%
        }

        public static void main(String... args) {
            Employee harry = new Employee(...);
            tripleSalary(harry);
            System.out.println(harry.salary);
        }

说明：在main方法中，我们实例化一个Employee对象harry，再调用tripleSalary方法来提高员工的工资，将harry传入，完成函数调用后在console上打印harry的工资，结果工资真的提高的两倍。tripleSalary方法被调用整个过程运行的步骤如下：

    1. e被初始化，并且为harry的值的拷贝，这里是一个对象的引用
    2. e和harry同时引用一个Employee对象，所以e提高了工资相当于提高了harry的工资
    3. 方法运行结束，释放e

* 例子3
很多程序员认为Java中对对象采用的是引用传递，实际上，这样理解是错误的。由于这种误解具有一定的普遍性，所以下面采用一个反例方法来说明，该方法是交换两个员工的对象

        public static void swap(Employee x, Employee y) { //无法实现
            Employee e = x;
            x = y;
            y = e;
        }
        
        public static void main(String[] args) {
            Employee a = new Employee("Alice", ...);
            Employee b = new Employee("Bob", ...);
            swap(a, b);
        }

说明：在main方法中，实例化了两个员工对象，分别是Alice和Bob，然后传递给swap方法。x和y拷贝了a和b，也就是引用了a和b对象，在swap方法内部将x和y进行交换，确实是可以的，交换完成后x引用Bob，y引用Alice，但是，重点是，a还是引用Alice，b还是引用Bob，并没有改变。最后，swap方法结束，x和y也别GC回收。所以，Java中对对象的传递是值传递而不是引用调用，此操作也就是白费了力气。

### 总结
我们首先说明、强调了Java中方法的参数传递不同于其他语言，总是对值的传递而不是引用调用，再用三个例子来说明，下面用3点来总结一下Java中方法参数的使用：

* 一个方法不能修改一个基本数据类型的参数（即数值型或者布尔型）
* 一个方法可以修改一个对象参数的状态
* 一个方法不能让对象参数引用一个新的对象


### 参考文章

 [Java核心技术 卷I 基础知识]()