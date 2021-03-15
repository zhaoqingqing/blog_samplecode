## ios内存限制

不同内存的苹果机型上(1G,2G,3G,4G…)，游戏内存的峰值一般最高多少能保证不闪退？

一般来讲最保险的就是不超过机器总内存的50%，具体每个机型的内存限制在列出在下面。

原贴：《[ios app maximum memory budget](https://stackoverflow.com/questions/5887248/ios-app-maximum-memory-budget)》

注意事项：查看当前app占用多少内存，通过OS的API来获取，而不要通过引擎自己的API来获取。

IOS内存不足闪退的表现：《 [iOS内存分析下-前台内存耗尽闪退(FOOM)](https://www.jianshu.com/p/deee6fedb510)》

## device: (crash amount/total amount/percentage of total)

- iPad1: 127MB/256MB/49%
- iPad2: 275MB/512MB/53%
- iPad3: 645MB/1024MB/62%
- iPad4: 585MB/1024MB/57% (iOS 8.1)
- iPad Mini 1st Generation: 297MB/512MB/58%
- iPad Mini retina: 696MB/1024MB/68% (iOS 7.1)
- iPad Air: 697MB/1024MB/68%
- iPad Air 2: 1383MB/2048MB/68% (iOS 10.2.1)
- iPad Pro 9.7": 1395MB/1971MB/71% (iOS 10.0.2 (14A456))
- iPad Pro 10.5”: 3057/4000/76% (iOS 11 beta4)
- iPad Pro 12.9” (2015): 3058/3999/76% (iOS 11.2.1)
- iPad Pro 12.9” (2017): 3057/3974/77% (iOS 11 beta4)
- iPad Pro 11.0” (2018): 2858/3769/76% (iOS 12.1)
- iPad Pro 12.9” (2018, 1TB): 4598/5650/81% (iOS 12.1)
- iPad 10.2: 1844/2998/62% (iOS 13.2.3)
- iPod touch 4th gen: 130MB/256MB/51% (iOS 6.1.1)
- iPod touch 5th gen: 286MB/512MB/56% (iOS 7.0)
- iPhone4: 325MB/512MB/63%
- iPhone4s: 286MB/512MB/56%
- iPhone5: 645MB/1024MB/62%
- iPhone5s: 646MB/1024MB/63%
- iPhone6: 645MB/1024MB/62% (iOS 8.x)
- iPhone6+: 645MB/1024MB/62% (iOS 8.x)
- iPhone6s: 1396MB/2048MB/68% (iOS 9.2)
- iPhone6s+: 1392MB/2048MB/68% (iOS 10.2.1)
- iPhoneSE: 1395MB/2048MB/69% (iOS 9.3)
- iPhone7: 1395/2048MB/68% (iOS 10.2)
- iPhone7+: 2040MB/3072MB/66% (iOS 10.2.1)
- iPhone8: 1364/1990MB/70% (iOS 12.1)
- iPhone X: 1392/2785/50% (iOS 11.2.1)
- iPhone XS: 2040/3754/54% (iOS 12.1)
- iPhone XS Max: 2039/3735/55% (iOS 12.1)
- iPhone XR: 1792/2813/63% (iOS 12.1)
- iPhone 11: 2068/3844/54% (iOS 13.1.3)
- iPhone 11 Pro Max: 2067/3740/55% (iOS 13.2.3)



## device RAM: percent range to crash

- 256MB: 49% - 51%
- 512MB: 53% - 63%
- 1024MB: 57% - 68%
- 2048MB: 68% - 69%
- 3072MB: 63% - 66%
- 4096MB: 77%
- 6144MB: 81%

## Special cases:

- iPhone X (3072MB): 50%
- iPhone XS/XS Max (4096MB): 55%
- iPhone XR (3072MB): 63%
- iPhone 11/11 Pro Max (4096MB): 54% - 55%