[Difference between Hashtable and Dictionary in C#](https://www.geeksforgeeks.org/difference-between-hashtable-and-dictionary-in-c-sharp/)

| HASHTABLE                                                    | DICTIONARY                                                   |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| A Hashtable is a non-generic collection.                     | A Dictionary is a generic collection.                        |
| Hashtable is defined under System.Collections namespace.     | Dictionary is defined under System.Collections.Generic namespace. |
| In Hashtable, you can store key/value pairs of the same type or of the different type. | In Dictionary, you can store key/value pairs of same type.   |
| In Hashtable, there is no need to specify the type of the key and value. | In Dictionary, you must specify the type of key and value.   |
| The data retrieval is slower than Dictionary due to boxing/ unboxing. | The data retrieval is faster than Hashtable due to no boxing/ unboxing. |
| In Hashtable, if you try to access a key that doesn’t present in the given Hashtable, then it will give null values. | In Dictionary, if you try to access a key that doesn’t present in the given Dictionary, then it will give error. |
| It is thread safe.                                           | It is also thread safe but only for public static members.   |
| It doesn’t maintain the order of stored values.              | It always maintain the order of stored values.               |

[C#中字典集合HashTable、Dictionary、ConcurrentDictionary三者区别](https://www.cnblogs.com/yinrq/p/5584885.html)

大数据插入Dictionary花费时间最少

遍历HashTable最快是Dictionary的1/5,ConcurrentDictionary的1/10

单线程建议用Dictionary，多线程建议用ConcurrentDictionary或者HashTable（Hashtable tab = Hashtable.Synchronized(new Hashtable());获得线程安全的对象）