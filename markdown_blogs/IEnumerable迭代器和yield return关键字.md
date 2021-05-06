## 前言

unity中的协程，比如你需要延迟x秒后执行某个函数，在unity中通过 `yield return new WaitForSeconds(1.0f);` 就可以实现，那么在C#中yield return这个关键字是怎样的呢？下面写一个例子来测试下

说明：本文代码的运行环境 .net 4.0 C# 7.3

## IEnumerable

示例代码

```c#
static IEnumerable<int> TestAdd(int max)
{
    int first = 1, second = 1;
    Console.WriteLine($"TestAdd aaaa:{first} ");
    yield return first;
    Console.WriteLine($"TestAdd bbbb:{second} ");
    yield return second;
    for (int i = 0; i < max; ++i)
    {
        int third = first + second;
        first = second;
        second = third;//下一次执行到这里，还能记住上次的值
        Console.WriteLine($"TestAdd ccc:{third} ");
        yield return third;
    }
}

public static void Main(string[] args)
{
    int times = 0;
    foreach (int i in TestAdd(2))
    {
        Console.WriteLine($"return value:{i},times:{++times}");
    }
}
```

运行结果：TestAdd中遇到yield return则会返回Main，然后再继续执行

```
TestAdd aaaa:1
return value:1,times:1
TestAdd bbbb:1
return value:1,times:2
TestAdd ccc:2
return value:2,times:3
TestAdd ccc:3
return value:3,times:4
```

看到这个执行结果是不是有点像Unity中的协程？当遇到yield return时就会跳出当前的代码，继续后面的代码，然后再回到原来的代码继续执行



### 查看IEnumerable的定义

IEnumerable<out T>可以使用foreach

```c#
// Assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
namespace System.Collections.Generic
{
  /// <summary>
  ///   公开枚举数，该枚举数支持在指定类型的集合上进行简单迭代。
  /// 
  ///   若要浏览此类型的.NET Framework 源代码，请参阅 Reference Source。
  /// </summary>
  /// <typeparam name="T">要枚举的对象的类型。</typeparam>
  [TypeDependency("System.SZArrayHelper")]
  [__DynamicallyInvokable]
  public interface IEnumerable<out T> : IEnumerable
  {
    /// <summary>返回一个循环访问集合的枚举器。</summary>
    /// <returns>用于循环访问集合的枚举数。</returns>
    [__DynamicallyInvokable]
    IEnumerator<T> GetEnumerator();
  }
}
```

实现原理可看这篇《[人人都能学的会C++协程原理剖析与自我实现](https://zhuanlan.zhihu.com/p/363971930)》



## IEnumerator



```c#
static IEnumerator TestAdd2()
{
    int first = 1, second = 1;
    Console.WriteLine($"TestAdd2 aaaa:{first}");
    yield return first;
    first++;
    Console.WriteLine($"TestAdd2 bb:{first}");
}

public static void Main(string[] args)
{
    foreach (int i in TestAdd2())//NOTE 无法对IEnumerator<int>进行遍历
    {
    }
}
```

如果把IEnumerator改成IEnumerator<int>则无法使用foreach，会报错：

> Type 'System.Collections.Generic.IEnumerator<int>' cannot be used in 'foreach' statement because it neither implements 'IEnumerable' or 'IEnumerable<T>', nor has suitable 'GetEnumerator' method which return type has 'Current' property and 'MoveNext' method

### IEnumerator<T>定义

可以看到IEnumerator<T>没有实现IEnumerator的MoveNext接口，所以无法进行遍历，但IEnumerator可以遍历

```c#
// Assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll

namespace System.Collections.Generic
{
  /// <summary>支持在泛型集合上进行简单迭代。</summary>
  /// <typeparam name="T">要枚举的对象的类型。</typeparam>
  [__DynamicallyInvokable]
  public interface IEnumerator<out T> : IDisposable, IEnumerator
  {
    /// <summary>获取集合中位于枚举数当前位置的元素。</summary>
    /// <returns>集合中位于枚举数当前位置的元素。</returns>
    [__DynamicallyInvokable]
    T Current { [__DynamicallyInvokable] get; }
  }
    
  public interface IEnumerator
  {
	/// <summary>将枚举数推进到集合的下一个元素。</summary>
	/// <returns>
	///   如果枚举数已成功地推进到下一个元素，则为 <see langword="true" />；如果枚举数传递到集合的末尾，则为 <see langword="false" />。
	/// </returns>
	/// <exception cref="T:System.InvalidOperationException">
	///   创建枚举器后，已修改该集合。
	/// </exception>
	bool MoveNext();

	/// <summary>获取集合中位于枚举数当前位置的元素。</summary>
	/// <returns>集合中位于枚举数当前位置的元素。</returns>
	object Current { get; }

	/// <summary>将枚举数设置为其初始位置，该位置位于集合中第一个元素之前。</summary>
	/// <exception cref="T:System.InvalidOperationException">
	///   创建枚举器后，已修改该集合。
	/// </exception>
	void Reset();
  }	
}
```

## Unity中的协程

```c#
public IEnumerator OnBeforeInit()
{
	var loader = AssetBundleLoader.Load($"uiatlas/{UIModule.Instance.CommonAtlases[0]}");
	while (!loader.IsCompleted)
	{
		yield return null;
	}
}
```

