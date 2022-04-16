## 解释型和编译型

**解释型：**

边解释边执行，翻译成机器代码后就执行。

**编译型：**

整篇代码编译成机器码后，保存在可执行文件中，然后启动该程序文件，运行获得结果。

## Hello World

```c++
#include <iostream> 
using namespace std;

int main() 
{ 

    cout<< "Hello C++" <<endl;

    return 0;
}
```

## 定义函数

void sphere(){

 

}

 

## 分支语句

各个case(default)出现次序任意

```c++
#include <iostream> 
using namespace std;

int main() 
{ 
    char grade='B';
    switch(grade){
    case 'A': cout<<"A"<<endl; break;
    default:cout<<"default"<<endl; break;
    case 'B': cout<<"B"<<endl; break;
    case 'C': cout<<"C"<<endl; break;
    case 'D': cout<<"D"<<endl; break;
    }
    return 0;
}
```