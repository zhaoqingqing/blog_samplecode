## Logs Viewer

### ��������

Using this tool you can easily check your editor console logs inside the game itself! No need to go back to the project and do any tests to track the problems!

ʹ�ô˹��ߣ��������ֻ�����Unity Editor�У��㶼���Ժ����׵ؼ��/�鿴��Ϸ�������־��������Ҫ�ص���Ŀ�����κβ��Ը�������!(��Դ���)

### ����Ԥ��
���ֻ���Ҳ���Ժܷ���ز鿴��־�������log�ļ�
![](http://images2015.cnblogs.com/blog/363476/201608/363476-20160821234231183-1276911599.png)


![](http://images2015.cnblogs.com/blog/363476/201608/363476-20160821234038198-669809906.png)

### ��������

All what you have to do is to make a circle gesture using your mouse (click and drag) or your finger (touch and drag) on the mobile screen to show all these logs!

��Ҫ������ʾ����־�أ���PC/MAC������ƽ̨������Ҫʹ����갴ס����ȦȦ����Mobileƽ̨�ϣ�����Ҫʹ����ָ��ȦȦ�Ϳ�����ʾ��־��



### ���ò���

To setup log viewer do the following

1. create reporter from menu (Reporter->Create) at first scene your game start .
2. then set the �� Scrip execution order �� in (Edit -> Project Settings ) of Reporter.cs to be the highest.

���ò���
1. ����Ϸ��������(�״�������Scene)������˵��� **Reporter** �� **Create**�������ڳ����д���һ��**Reporter**��Gameobject�ϰ���**Reporter**��**ReporterMessageReceiver**�ű�
2. ��� **Edit** �� **Project Settings** ��**Scrip Execution Order**���ڴ򿪵�MonoManager�У����+��,���Reporter




### ��Դ���

AssetStore: [https://www.assetstore.unity3d.com/en/#!/content/12047]( https://www.assetstore.unity3d.com/en/#!/content/12047)

GitHub: [https://github.com/aliessmael/Unity-Logs-Viewer/]( https://github.com/aliessmael/Unity-Logs-Viewer/)

����Դ����ĵ���������Դ���� `Reporter/Documentation/index.html`

��ο���https://github.com/zhaoqingqing/blog_samplecode/tree/master/unity_protobuf_sample/Assets/Reporter

### �汾��¼



### Version 1.8

    - Add Copy to clipboard.
    - Merge Fix for Unity 2019.
    - Fix ReporterModificationProcessor is annoying.
    - Fix waste ram.

### Version 1.7

    - Add Save logs button( thanks for Ahmed Shbli ).
    - Fix deprecated code for new unity.
    - Fix Warnings.
    - Fix loading scene from asset bundle error.



## �Ľ�����

���Ļ��ڲ����1.6�汾 (2016-06-13����)��Unity 5.3.4f1 ����������

### �޸Ŀ���Ȧ��

��**Reporter** ������壬�޸� **Num of Circle to Sh** ����ֵΪ������Ĭ��Ϊ1



### ����ʱ����NGUI������

������ڿ�����־����ʱ������NGUI��Input������ʹ��������¡���ReporterMessageReceiver.cs

```csharp
void OnHideReporter()
	{
        //TO DO : resume your game
        //NOTE if use ngui enable input
        //if (UICamera.eventHandler != null)
        //{
        //    UICamera.eventHandler.useMouse = true;
        //    UICamera.eventHandler.useTouch = true;
        //}
    }

    void OnShowReporter()
	{
        //TO DO : pause your game and disable its GUI
        //NOTE if use ngui disable input
        //if (UICamera.eventHandler != null)
        //{
        //    UICamera.eventHandler.useMouse = false;
        //    UICamera.eventHandler.useTouch = false;
        //}
    }
```



### ����ע������
[���ִ������ᵽ](http://www.maosongliang.com/archives/175)�����������ʹ��Assetbundle���صĻ�������쳣�����Ĵ���ʽ�ǰ��õ� string[] scenes ;�ĵط�����������(ע��)


�Ҳ�û����ϸ����ʹ��ab���������������ͨ���п��������쳣�ĳ��֣��鿴�ҵ��޸ģ�https://github.com/zhaoqingqing/blog_samplecode/commit/f0eb5045cd9aa1bda7efe257647e885f6367ed14


### ������ʾ����

�������£�Ĭ�϶����İ�ť��ʾ�Ĳ���������ʵ���ϣ��������ǿ��Ի����ġ�

������Setting(����)���ǿ��ԷŴ����С����ġ�