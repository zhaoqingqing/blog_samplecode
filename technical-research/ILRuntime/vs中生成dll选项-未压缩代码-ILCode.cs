// Type: HotFix_Project.InstanceClass 
// Assembly: HotFix_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 28E36C3F-C3ED-4A02-B073-AC0F5908561C
// Location: E:\Code\ILRuntimeU3D\ILRuntimeDemo\Assets\StreamingAssets\HotFix_Project.dll
// Sequence point data from E:\Code\ILRuntimeU3D\ILRuntimeDemo\Assets\StreamingAssets\HotFix_Project.pdb

.class public auto ansi beforefieldinit
  HotFix_Project.InstanceClass
    extends [mscorlib]System.Object
{

  .field private int32 id

  .field private static class HotFix_Project.InstanceClass self

  .field private int32 test_int

  .field private class [mscorlib]System.Collections.Generic.List`1<int32> list

  .field private int32[] 'array'

  .field private int32 n

  .field private static int32 cnt

  .field private class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32> dict

  .method public hidebysig specialname rtspecialname instance void
    .ctor() cil managed
  {
    .maxstack 8

    // [96 9 - 96 26]
    IL_0000: ldarg.0      // this
    IL_0001: ldc.i4.0
    IL_0002: stfld        int32 HotFix_Project.InstanceClass::test_int

    // [106 9 - 106 42]
    IL_0007: ldarg.0      // this
    IL_0008: newobj       instance void class [mscorlib]System.Collections.Generic.List`1<int32>::.ctor()
    IL_000d: stfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list

    // [118 9 - 118 19]
    IL_0012: ldarg.0      // this
    IL_0013: ldc.i4.0
    IL_0014: stfld        int32 HotFix_Project.InstanceClass::n

    // [180 9 - 180 64]
    IL_0019: ldarg.0      // this
    IL_001a: newobj       instance void class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32>::.ctor()
    IL_001f: stfld        class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32> HotFix_Project.InstanceClass::dict

    // [11 9 - 11 31]
    IL_0024: ldarg.0      // this
    IL_0025: call         instance void [mscorlib]System.Object::.ctor()
    IL_002a: nop

    // [12 9 - 12 10]
    IL_002b: nop

    // [13 13 - 13 73]
    IL_002c: ldstr        "!!! InstanceClass::InstanceClass()"
    IL_0031: call         void [UnityEngine.CoreModule]UnityEngine.Debug::Log(object)
    IL_0036: nop

    // [14 13 - 14 25]
    IL_0037: ldarg.0      // this
    IL_0038: ldc.i4.0
    IL_0039: stfld        int32 HotFix_Project.InstanceClass::id

    // [15 9 - 15 10]
    IL_003e: ret

  } // end of method InstanceClass::.ctor

  .method public hidebysig specialname rtspecialname instance void
    .ctor(
      int32 id
    ) cil managed
  {
    .maxstack 2

    // [96 9 - 96 26]
    IL_0000: ldarg.0      // this
    IL_0001: ldc.i4.0
    IL_0002: stfld        int32 HotFix_Project.InstanceClass::test_int

    // [106 9 - 106 42]
    IL_0007: ldarg.0      // this
    IL_0008: newobj       instance void class [mscorlib]System.Collections.Generic.List`1<int32>::.ctor()
    IL_000d: stfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list

    // [118 9 - 118 19]
    IL_0012: ldarg.0      // this
    IL_0013: ldc.i4.0
    IL_0014: stfld        int32 HotFix_Project.InstanceClass::n

    // [180 9 - 180 64]
    IL_0019: ldarg.0      // this
    IL_001a: newobj       instance void class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32>::.ctor()
    IL_001f: stfld        class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32> HotFix_Project.InstanceClass::dict

    // [17 9 - 17 37]
    IL_0024: ldarg.0      // this
    IL_0025: call         instance void [mscorlib]System.Object::.ctor()
    IL_002a: nop

    // [18 9 - 18 10]
    IL_002b: nop

    // [19 13 - 19 84]
    IL_002c: ldstr        "!!! InstanceClass::InstanceClass() id = "
    IL_0031: ldarg.1      // id
    IL_0032: box          [mscorlib]System.Int32
    IL_0037: call         string [mscorlib]System.String::Concat(object, object)
    IL_003c: call         void [UnityEngine.CoreModule]UnityEngine.Debug::Log(object)
    IL_0041: nop

    // [20 13 - 20 26]
    IL_0042: ldarg.0      // this
    IL_0043: ldarg.1      // id
    IL_0044: stfld        int32 HotFix_Project.InstanceClass::id

    // [21 9 - 21 10]
    IL_0049: ret

  } // end of method InstanceClass::.ctor

  .method public hidebysig specialname instance int32
    get_ID() cil managed
  {
    .maxstack 1
    .locals init (
      [0] int32 V_0
    )

    // [25 17 - 25 18]
    IL_0000: nop

    // [25 19 - 25 29]
    IL_0001: ldarg.0      // this
    IL_0002: ldfld        int32 HotFix_Project.InstanceClass::id
    IL_0007: stloc.0      // V_0
    IL_0008: br.s         IL_000a

    // [25 30 - 25 31]
    IL_000a: ldloc.0      // V_0
    IL_000b: ret

  } // end of method InstanceClass::get_ID

  .method public hidebysig static void
    StaticFunTest() cil managed
  {
    .maxstack 8

    // [32 9 - 32 10]
    IL_0000: nop

    // [33 13 - 33 72]
    IL_0001: ldstr        "!!! InstanceClass.StaticFunTest()"
    IL_0006: call         void [UnityEngine.CoreModule]UnityEngine.Debug::Log(object)
    IL_000b: nop

    // [34 13 - 34 40]
    IL_000c: newobj       instance void HotFix_Project.InstanceClass::.ctor()
    IL_0011: stsfld       class HotFix_Project.InstanceClass HotFix_Project.InstanceClass::self

    // [35 13 - 35 30]
    IL_0016: ldsfld       class HotFix_Project.InstanceClass HotFix_Project.InstanceClass::self
    IL_001b: callvirt     instance void HotFix_Project.InstanceClass::test_init()
    IL_0020: nop

    // [36 9 - 36 10]
    IL_0021: ret

  } // end of method InstanceClass::StaticFunTest

  .method public hidebysig static void
    StaticFunTest2(
      int32 a
    ) cil managed
  {
    .maxstack 8

    // [39 9 - 39 10]
    IL_0000: nop

    // [40 13 - 40 81]
    IL_0001: ldstr        "!!! InstanceClass.StaticFunTest2(), a="
    IL_0006: ldarg.0      // a
    IL_0007: box          [mscorlib]System.Int32
    IL_000c: call         string [mscorlib]System.String::Concat(object, object)
    IL_0011: call         void [UnityEngine.CoreModule]UnityEngine.Debug::Log(object)
    IL_0016: nop

    // [41 9 - 41 10]
    IL_0017: ret

  } // end of method InstanceClass::StaticFunTest2

  .method public hidebysig static void
    GenericMethod<T>(
      !!0/*T*/ a
    ) cil managed
  {
    .maxstack 8

    // [44 9 - 44 10]
    IL_0000: nop

    // [45 13 - 45 80]
    IL_0001: ldstr        "!!! InstanceClass.GenericMethod(), a="
    IL_0006: ldarg.0      // a
    IL_0007: box          !!0/*T*/
    IL_000c: call         string [mscorlib]System.String::Concat(object, object)
    IL_0011: call         void [UnityEngine.CoreModule]UnityEngine.Debug::Log(object)
    IL_0016: nop

    // [46 9 - 46 10]
    IL_0017: ret

  } // end of method InstanceClass::GenericMethod

  .method public hidebysig instance void
    RefOutMethod(
      int32 addition,
      [out] class [mscorlib]System.Collections.Generic.List`1<int32>& lst,
      int32& val
    ) cil managed
  {
    .maxstack 8

    // [49 9 - 49 10]
    IL_0000: nop

    // [50 13 - 50 39]
    IL_0001: ldarg.3      // val
    IL_0002: ldarg.3      // val
    IL_0003: ldind.i4
    IL_0004: ldarg.1      // addition
    IL_0005: add
    IL_0006: ldarg.0      // this
    IL_0007: ldfld        int32 HotFix_Project.InstanceClass::id
    IL_000c: add
    IL_000d: stind.i4

    // [51 13 - 51 35]
    IL_000e: ldarg.2      // lst
    IL_000f: newobj       instance void class [mscorlib]System.Collections.Generic.List`1<int32>::.ctor()
    IL_0014: stind.ref

    // [52 13 - 52 25]
    IL_0015: ldarg.2      // lst
    IL_0016: ldind.ref
    IL_0017: ldarg.0      // this
    IL_0018: ldfld        int32 HotFix_Project.InstanceClass::id
    IL_001d: callvirt     instance void class [mscorlib]System.Collections.Generic.List`1<int32>::Add(!0/*int32*/)
    IL_0022: nop

    // [53 9 - 53 10]
    IL_0023: ret

  } // end of method InstanceClass::RefOutMethod

  .method private hidebysig instance void
    test_init() cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 i,
      [1] bool V_1
    )

    // [61 9 - 61 10]
    IL_0000: nop

    // [62 18 - 62 27]
    IL_0001: ldc.i4.0
    IL_0002: stloc.0      // i

    IL_0003: br.s         IL_0041
    // start of loop, entry point: IL_0041

      // [63 13 - 63 14]
      IL_0005: nop

      // [64 17 - 64 46]
      IL_0006: ldarg.0      // this
      IL_0007: ldftn        instance void HotFix_Project.InstanceClass::test_empty()
      IL_000d: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
      IL_0012: call         void ['Assembly-CSharp']App::add_test_empty(class [mscorlib]System.Action)
      IL_0017: nop

      // [65 17 - 65 50]
      IL_0018: ldarg.0      // this
      IL_0019: ldftn        instance void HotFix_Project.InstanceClass::test_add_App()
      IL_001f: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
      IL_0024: call         void ['Assembly-CSharp']App::add_test_add_App(class [mscorlib]System.Action)
      IL_0029: nop

      // [66 17 - 66 54]
      IL_002a: ldarg.0      // this
      IL_002b: ldftn        instance void HotFix_Project.InstanceClass::test_add_Logic()
      IL_0031: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
      IL_0036: call         void ['Assembly-CSharp']App::add_test_add_Logic(class [mscorlib]System.Action)
      IL_003b: nop

      // [67 13 - 67 14]
      IL_003c: nop

      // [62 40 - 62 43]
      IL_003d: ldloc.0      // i
      IL_003e: ldc.i4.1
      IL_003f: add
      IL_0040: stloc.0      // i

      // [62 29 - 62 38]
      IL_0041: ldloc.0      // i
      IL_0042: ldc.i4       10000 // 0x00002710
      IL_0047: clt
      IL_0049: stloc.1      // V_1

      IL_004a: ldloc.1      // V_1
      IL_004b: brtrue.s     IL_0005
    // end of loop

    // [69 13 - 69 56]
    IL_004d: ldarg.0      // this
    IL_004e: ldftn        instance void HotFix_Project.InstanceClass::test_add_App10000()
    IL_0054: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_0059: call         void ['Assembly-CSharp']App::add_test_add_App10000(class [mscorlib]System.Action)
    IL_005e: nop

    // [70 13 - 70 60]
    IL_005f: ldarg.0      // this
    IL_0060: ldftn        instance void HotFix_Project.InstanceClass::test_add_Logic10000()
    IL_0066: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_006b: call         void ['Assembly-CSharp']App::add_test_add_Logic10000(class [mscorlib]System.Action)
    IL_0070: nop

    // [72 13 - 72 48]
    IL_0071: ldarg.0      // this
    IL_0072: ldftn        instance void HotFix_Project.InstanceClass::test_list_add()
    IL_0078: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_007d: call         void ['Assembly-CSharp']App::add_test_list_add(class [mscorlib]System.Action)
    IL_0082: nop

    // [73 13 - 73 48]
    IL_0083: ldarg.0      // this
    IL_0084: ldftn        instance void HotFix_Project.InstanceClass::test_list_for()
    IL_008a: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_008f: call         void ['Assembly-CSharp']App::add_test_list_for(class [mscorlib]System.Action)
    IL_0094: nop

    // [74 13 - 74 56]
    IL_0095: ldarg.0      // this
    IL_0096: ldftn        instance void HotFix_Project.InstanceClass::test_list_foreach()
    IL_009c: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_00a1: call         void ['Assembly-CSharp']App::add_test_list_foreach(class [mscorlib]System.Action)
    IL_00a6: nop

    // [75 13 - 75 50]
    IL_00a7: ldarg.0      // this
    IL_00a8: ldftn        instance void HotFix_Project.InstanceClass::test_array_for()
    IL_00ae: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_00b3: call         void ['Assembly-CSharp']App::add_test_array_for(class [mscorlib]System.Action)
    IL_00b8: nop

    // [76 13 - 76 58]
    IL_00b9: ldarg.0      // this
    IL_00ba: ldftn        instance void HotFix_Project.InstanceClass::test_array_foreach()
    IL_00c0: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_00c5: call         void ['Assembly-CSharp']App::add_test_array_foreach(class [mscorlib]System.Action)
    IL_00ca: nop

    // [78 13 - 78 48]
    IL_00cb: ldarg.0      // this
    IL_00cc: ldftn        instance void HotFix_Project.InstanceClass::test_dict_add()
    IL_00d2: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_00d7: call         void ['Assembly-CSharp']App::add_test_dict_add(class [mscorlib]System.Action)
    IL_00dc: nop

    // [79 13 - 79 52]
    IL_00dd: ldarg.0      // this
    IL_00de: ldftn        instance void HotFix_Project.InstanceClass::test_dict_while()
    IL_00e4: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_00e9: call         void ['Assembly-CSharp']App::add_test_dict_while(class [mscorlib]System.Action)
    IL_00ee: nop

    // [80 13 - 80 56]
    IL_00ef: ldarg.0      // this
    IL_00f0: ldftn        instance void HotFix_Project.InstanceClass::test_dict_foreach()
    IL_00f6: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_00fb: call         void ['Assembly-CSharp']App::add_test_dict_foreach(class [mscorlib]System.Action)
    IL_0100: nop

    // [81 13 - 81 64]
    IL_0101: ldarg.0      // this
    IL_0102: ldftn        instance void HotFix_Project.InstanceClass::logic_2_call_app()
    IL_0108: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_010d: call         void ['Assembly-CSharp']App::add_test_call_logic_2_call_app(class [mscorlib]System.Action)
    IL_0112: nop

    // [84 9 - 84 10]
    IL_0113: ret

  } // end of method InstanceClass::test_init

  .method private hidebysig instance void
    test_empty() cil managed
  {
    .maxstack 8

    // [87 27 - 87 28]
    IL_0000: nop

    // [87 29 - 87 30]
    IL_0001: ret

  } // end of method InstanceClass::test_empty

  .method private hidebysig instance void
    test_add_App() cil managed
  {
    .maxstack 8

    // [89 29 - 89 30]
    IL_0000: nop

    // [89 31 - 89 46]
    IL_0001: ldsfld       int32 ['Assembly-CSharp']App::test_int
    IL_0006: ldc.i4.1
    IL_0007: add
    IL_0008: stsfld       int32 ['Assembly-CSharp']App::test_int

    // [89 47 - 89 48]
    IL_000d: ret

  } // end of method InstanceClass::test_add_App

  .method private hidebysig instance void
    test_add_App10000() cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 i,
      [1] bool V_1
    )

    // [91 9 - 91 10]
    IL_0000: nop

    // [92 18 - 92 27]
    IL_0001: ldc.i4.0
    IL_0002: stloc.0      // i

    IL_0003: br.s         IL_0015
    // start of loop, entry point: IL_0015

      // [93 17 - 93 32]
      IL_0005: ldsfld       int32 ['Assembly-CSharp']App::test_int
      IL_000a: ldc.i4.1
      IL_000b: add
      IL_000c: stsfld       int32 ['Assembly-CSharp']App::test_int

      // [92 40 - 92 43]
      IL_0011: ldloc.0      // i
      IL_0012: ldc.i4.1
      IL_0013: add
      IL_0014: stloc.0      // i

      // [92 29 - 92 38]
      IL_0015: ldloc.0      // i
      IL_0016: ldc.i4       10000 // 0x00002710
      IL_001b: clt
      IL_001d: stloc.1      // V_1

      IL_001e: ldloc.1      // V_1
      IL_001f: brtrue.s     IL_0005
    // end of loop

    // [94 9 - 94 10]
    IL_0021: ret

  } // end of method InstanceClass::test_add_App10000

  .method private hidebysig instance void
    test_add_Logic() cil managed
  {
    .maxstack 8

    // [97 31 - 97 32]
    IL_0000: nop

    // [97 33 - 97 44]
    IL_0001: ldarg.0      // this
    IL_0002: ldarg.0      // this
    IL_0003: ldfld        int32 HotFix_Project.InstanceClass::test_int
    IL_0008: ldc.i4.1
    IL_0009: add
    IL_000a: stfld        int32 HotFix_Project.InstanceClass::test_int

    // [97 45 - 97 46]
    IL_000f: ret

  } // end of method InstanceClass::test_add_Logic

  .method private hidebysig instance void
    test_add_Logic10000() cil managed
  {
    .maxstack 3
    .locals init (
      [0] int32 cnt,
      [1] int32 i,
      [2] bool V_2
    )

    // [99 9 - 99 10]
    IL_0000: nop

    // [100 13 - 100 25]
    IL_0001: ldc.i4.0
    IL_0002: stloc.0      // cnt

    // [101 18 - 101 27]
    IL_0003: ldc.i4.0
    IL_0004: stloc.1      // i

    IL_0005: br.s         IL_0019
    // start of loop, entry point: IL_0019

      // [102 17 - 102 28]
      IL_0007: ldarg.0      // this
      IL_0008: ldarg.0      // this
      IL_0009: ldfld        int32 HotFix_Project.InstanceClass::test_int
      IL_000e: ldc.i4.1
      IL_000f: add
      IL_0010: stfld        int32 HotFix_Project.InstanceClass::test_int

      // [101 40 - 101 43]
      IL_0015: ldloc.1      // i
      IL_0016: ldc.i4.1
      IL_0017: add
      IL_0018: stloc.1      // i

      // [101 29 - 101 38]
      IL_0019: ldloc.1      // i
      IL_001a: ldc.i4       10000 // 0x00002710
      IL_001f: clt
      IL_0021: stloc.2      // V_2

      IL_0022: ldloc.2      // V_2
      IL_0023: brtrue.s     IL_0007
    // end of loop

    // [103 9 - 103 10]
    IL_0025: ret

  } // end of method InstanceClass::test_add_Logic10000

  .method private hidebysig instance void
    test_list_add() cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 i,
      [1] bool V_1
    )

    // [109 9 - 109 10]
    IL_0000: nop

    // [110 13 - 110 26]
    IL_0001: ldarg.0      // this
    IL_0002: ldfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list
    IL_0007: callvirt     instance void class [mscorlib]System.Collections.Generic.List`1<int32>::Clear()
    IL_000c: nop

    // [111 18 - 111 27]
    IL_000d: ldc.i4.0
    IL_000e: stloc.0      // i

    IL_000f: br.s         IL_0024
    // start of loop, entry point: IL_0024

      // [112 13 - 112 14]
      IL_0011: nop

      // [113 17 - 113 29]
      IL_0012: ldarg.0      // this
      IL_0013: ldfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list
      IL_0018: ldloc.0      // i
      IL_0019: callvirt     instance void class [mscorlib]System.Collections.Generic.List`1<int32>::Add(!0/*int32*/)
      IL_001e: nop

      // [114 13 - 114 14]
      IL_001f: nop

      // [111 40 - 111 43]
      IL_0020: ldloc.0      // i
      IL_0021: ldc.i4.1
      IL_0022: add
      IL_0023: stloc.0      // i

      // [111 29 - 111 38]
      IL_0024: ldloc.0      // i
      IL_0025: ldc.i4       10000 // 0x00002710
      IL_002a: clt
      IL_002c: stloc.1      // V_1

      IL_002d: ldloc.1      // V_1
      IL_002e: brtrue.s     IL_0011
    // end of loop

    // [115 13 - 115 36]
    IL_0030: ldarg.0      // this
    IL_0031: ldarg.0      // this
    IL_0032: ldfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list
    IL_0037: callvirt     instance !0/*int32*/[] class [mscorlib]System.Collections.Generic.List`1<int32>::ToArray()
    IL_003c: stfld        int32[] HotFix_Project.InstanceClass::'array'

    // [116 9 - 116 10]
    IL_0041: ret

  } // end of method InstanceClass::test_list_add

  .method private hidebysig instance void
    test_list_for() cil managed
  {
    .maxstack 4
    .locals init (
      [0] int32 len,
      [1] int32 i,
      [2] bool V_2
    )

    // [120 9 - 120 10]
    IL_0000: nop

    // [121 13 - 121 34]
    IL_0001: ldarg.0      // this
    IL_0002: ldfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list
    IL_0007: callvirt     instance int32 class [mscorlib]System.Collections.Generic.List`1<int32>::get_Count()
    IL_000c: stloc.0      // len

    // [122 13 - 122 19]
    IL_000d: ldarg.0      // this
    IL_000e: ldc.i4.0
    IL_000f: stfld        int32 HotFix_Project.InstanceClass::n

    // [123 18 - 123 27]
    IL_0014: ldc.i4.0
    IL_0015: stloc.1      // i

    IL_0016: br.s         IL_0037
    // start of loop, entry point: IL_0037

      // [124 13 - 124 14]
      IL_0018: nop

      // [125 17 - 125 30]
      IL_0019: ldarg.0      // this
      IL_001a: ldarg.0      // this
      IL_001b: ldfld        int32 HotFix_Project.InstanceClass::n
      IL_0020: ldarg.0      // this
      IL_0021: ldfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list
      IL_0026: ldloc.1      // i
      IL_0027: callvirt     instance !0/*int32*/ class [mscorlib]System.Collections.Generic.List`1<int32>::get_Item(int32)
      IL_002c: add
      IL_002d: stfld        int32 HotFix_Project.InstanceClass::n

      // [126 13 - 126 14]
      IL_0032: nop

      // [123 38 - 123 41]
      IL_0033: ldloc.1      // i
      IL_0034: ldc.i4.1
      IL_0035: add
      IL_0036: stloc.1      // i

      // [123 29 - 123 36]
      IL_0037: ldloc.1      // i
      IL_0038: ldloc.0      // len
      IL_0039: clt
      IL_003b: stloc.2      // V_2

      IL_003c: ldloc.2      // V_2
      IL_003d: brtrue.s     IL_0018
    // end of loop

    // [127 9 - 127 10]
    IL_003f: ret

  } // end of method InstanceClass::test_list_for

  .method private hidebysig instance void
    test_list_foreach() cil managed
  {
    .maxstack 3
    .locals init (
      [0] valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32> V_0,
      [1] int32 i
    )

    // [129 9 - 129 10]
    IL_0000: nop

    // [130 13 - 130 19]
    IL_0001: ldarg.0      // this
    IL_0002: ldc.i4.0
    IL_0003: stfld        int32 HotFix_Project.InstanceClass::n

    // [131 13 - 131 20]
    IL_0008: nop

    // [131 31 - 131 35]
    IL_0009: ldarg.0      // this
    IL_000a: ldfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list
    IL_000f: callvirt     instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0/*int32*/> class [mscorlib]System.Collections.Generic.List`1<int32>::GetEnumerator()
    IL_0014: stloc.0      // V_0
    .try
    {

      IL_0015: br.s         IL_002f
      // start of loop, entry point: IL_002f

        // [131 22 - 131 27]
        IL_0017: ldloca.s     V_0
        IL_0019: call         instance !0/*int32*/ valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32>::get_Current()
        IL_001e: stloc.1      // i

        // [132 13 - 132 14]
        IL_001f: nop

        // [133 17 - 133 24]
        IL_0020: ldarg.0      // this
        IL_0021: ldarg.0      // this
        IL_0022: ldfld        int32 HotFix_Project.InstanceClass::n
        IL_0027: ldloc.1      // i
        IL_0028: add
        IL_0029: stfld        int32 HotFix_Project.InstanceClass::n

        // [134 13 - 134 14]
        IL_002e: nop

        // [131 28 - 131 30]
        IL_002f: ldloca.s     V_0
        IL_0031: call         instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32>::MoveNext()
        IL_0036: brtrue.s     IL_0017
      // end of loop
      IL_0038: leave.s      IL_0049
    } // end of .try
    finally
    {

      IL_003a: ldloca.s     V_0
      IL_003c: constrained. valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32>
      IL_0042: callvirt     instance void [mscorlib]System.IDisposable::Dispose()
      IL_0047: nop
      IL_0048: endfinally
    } // end of finally

    // [135 9 - 135 10]
    IL_0049: ret

  } // end of method InstanceClass::test_list_foreach

  .method private hidebysig instance void
    test_array_for() cil managed
  {
    .maxstack 4
    .locals init (
      [0] int32 len,
      [1] int32 i,
      [2] bool V_2
    )

    // [138 9 - 138 10]
    IL_0000: nop

    // [139 13 - 139 36]
    IL_0001: ldarg.0      // this
    IL_0002: ldfld        int32[] HotFix_Project.InstanceClass::'array'
    IL_0007: ldlen
    IL_0008: conv.i4
    IL_0009: stloc.0      // len

    // [140 13 - 140 19]
    IL_000a: ldarg.0      // this
    IL_000b: ldc.i4.0
    IL_000c: stfld        int32 HotFix_Project.InstanceClass::n

    // [141 18 - 141 27]
    IL_0011: ldc.i4.0
    IL_0012: stloc.1      // i

    IL_0013: br.s         IL_0030
    // start of loop, entry point: IL_0030

      // [142 13 - 142 14]
      IL_0015: nop

      // [143 17 - 143 31]
      IL_0016: ldarg.0      // this
      IL_0017: ldarg.0      // this
      IL_0018: ldfld        int32 HotFix_Project.InstanceClass::n
      IL_001d: ldarg.0      // this
      IL_001e: ldfld        int32[] HotFix_Project.InstanceClass::'array'
      IL_0023: ldloc.1      // i
      IL_0024: ldelem.i4
      IL_0025: add
      IL_0026: stfld        int32 HotFix_Project.InstanceClass::n

      // [144 13 - 144 14]
      IL_002b: nop

      // [141 38 - 141 41]
      IL_002c: ldloc.1      // i
      IL_002d: ldc.i4.1
      IL_002e: add
      IL_002f: stloc.1      // i

      // [141 29 - 141 36]
      IL_0030: ldloc.1      // i
      IL_0031: ldloc.0      // len
      IL_0032: clt
      IL_0034: stloc.2      // V_2

      IL_0035: ldloc.2      // V_2
      IL_0036: brtrue.s     IL_0015
    // end of loop

    // [145 9 - 145 10]
    IL_0038: ret

  } // end of method InstanceClass::test_array_for

  .method public hidebysig static void
    UnitTest_Performance3() cil managed
  {
    .maxstack 4
    .locals init (
      [0] int64 before,
      [1] class [System]System.Diagnostics.Stopwatch sw,
      [2] int64 tick_diff,
      [3] valuetype [mscorlib]System.DateTime V_3,
      [4] int32 i,
      [5] bool V_5
    )

    // [148 9 - 148 10]
    IL_0000: nop

    // [149 13 - 149 45]
    IL_0001: call         valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
    IL_0006: stloc.3      // V_3
    IL_0007: ldloca.s     V_3
    IL_0009: call         instance int64 [mscorlib]System.DateTime::get_Ticks()
    IL_000e: stloc.0      // before

    // [150 13 - 150 82]
    IL_000f: newobj       instance void [System]System.Diagnostics.Stopwatch::.ctor()
    IL_0014: stloc.1      // sw

    // [151 13 - 151 24]
    IL_0015: ldloc.1      // sw
    IL_0016: callvirt     instance void [System]System.Diagnostics.Stopwatch::Start()
    IL_001b: nop

    // [153 18 - 153 27]
    IL_001c: ldc.i4.0
    IL_001d: stloc.s      i

    IL_001f: br.s         IL_0036
    // start of loop, entry point: IL_0036

      // [154 13 - 154 14]
      IL_0021: nop

      // [155 17 - 155 26]
      IL_0022: ldsfld       int32 HotFix_Project.InstanceClass::cnt
      IL_0027: ldloc.s      i
      IL_0029: add
      IL_002a: stsfld       int32 HotFix_Project.InstanceClass::cnt

      // [156 13 - 156 14]
      IL_002f: nop

      // [153 41 - 153 44]
      IL_0030: ldloc.s      i
      IL_0032: ldc.i4.1
      IL_0033: add
      IL_0034: stloc.s      i

      // [153 29 - 153 39]
      IL_0036: ldloc.s      i
      IL_0038: ldc.i4       500000 // 0x0007a120
      IL_003d: clt
      IL_003f: stloc.s      V_5

      IL_0041: ldloc.s      V_5
      IL_0043: brtrue.s     IL_0021
    // end of loop

    // [157 13 - 157 23]
    IL_0045: ldloc.1      // sw
    IL_0046: callvirt     instance void [System]System.Diagnostics.Stopwatch::Stop()
    IL_004b: nop

    // [158 13 - 158 57]
    IL_004c: call         valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
    IL_0051: stloc.3      // V_3
    IL_0052: ldloca.s     V_3
    IL_0054: call         instance int64 [mscorlib]System.DateTime::get_Ticks()
    IL_0059: ldloc.0      // before
    IL_005a: sub
    IL_005b: stloc.2      // tick_diff

    // [159 13 - 159 150]
    IL_005c: ldstr        "UnitTest_Performance50Íò Elapsed time:{0:0}ms, result = {1}  ,Tick:{2}"
    IL_0061: ldloc.1      // sw
    IL_0062: callvirt     instance int64 [System]System.Diagnostics.Stopwatch::get_ElapsedMilliseconds()
    IL_0067: box          [mscorlib]System.Int64
    IL_006c: ldsfld       int32 HotFix_Project.InstanceClass::cnt
    IL_0071: box          [mscorlib]System.Int32
    IL_0076: ldloc.2      // tick_diff
    IL_0077: box          [mscorlib]System.Int64
    IL_007c: call         string [mscorlib]System.String::Format(string, object, object, object)
    IL_0081: call         void [UnityEngine.CoreModule]UnityEngine.Debug::Log(object)
    IL_0086: nop

    // [160 9 - 160 10]
    IL_0087: ret

  } // end of method InstanceClass::UnitTest_Performance3

  .method private hidebysig instance void
    test_array_foreach() cil managed
  {
    .maxstack 3
    .locals init (
      [0] int32[] V_0,
      [1] int32 V_1,
      [2] int32 i
    )

    // [163 9 - 163 10]
    IL_0000: nop

    // [164 13 - 164 19]
    IL_0001: ldarg.0      // this
    IL_0002: ldc.i4.0
    IL_0003: stfld        int32 HotFix_Project.InstanceClass::n

    // [165 13 - 165 20]
    IL_0008: nop

    // [165 31 - 165 36]
    IL_0009: ldarg.0      // this
    IL_000a: ldfld        int32[] HotFix_Project.InstanceClass::'array'
    IL_000f: stloc.0      // V_0
    IL_0010: ldc.i4.0
    IL_0011: stloc.1      // V_1

    IL_0012: br.s         IL_002c
    // start of loop, entry point: IL_002c

      // [165 22 - 165 27]
      IL_0014: ldloc.0      // V_0
      IL_0015: ldloc.1      // V_1
      IL_0016: ldelem.i4
      IL_0017: stloc.2      // i

      // [166 13 - 166 14]
      IL_0018: nop

      // [167 17 - 167 24]
      IL_0019: ldarg.0      // this
      IL_001a: ldarg.0      // this
      IL_001b: ldfld        int32 HotFix_Project.InstanceClass::n
      IL_0020: ldloc.2      // i
      IL_0021: add
      IL_0022: stfld        int32 HotFix_Project.InstanceClass::n

      // [168 13 - 168 14]
      IL_0027: nop

      IL_0028: ldloc.1      // V_1
      IL_0029: ldc.i4.1
      IL_002a: add
      IL_002b: stloc.1      // V_1

      // [165 28 - 165 30]
      IL_002c: ldloc.1      // V_1
      IL_002d: ldloc.0      // V_0
      IL_002e: ldlen
      IL_002f: conv.i4
      IL_0030: blt.s        IL_0014
    // end of loop

    // [178 9 - 178 10]
    IL_0032: ret

  } // end of method InstanceClass::test_array_foreach

  .method private hidebysig instance void
    test_dict_add() cil managed
  {
    .maxstack 3
    .locals init (
      [0] int32 i,
      [1] bool V_1
    )

    // [182 9 - 182 10]
    IL_0000: nop

    // [183 13 - 183 26]
    IL_0001: ldarg.0      // this
    IL_0002: ldfld        class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32> HotFix_Project.InstanceClass::dict
    IL_0007: callvirt     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32>::Clear()
    IL_000c: nop

    // [184 18 - 184 27]
    IL_000d: ldc.i4.0
    IL_000e: stloc.0      // i

    IL_000f: br.s         IL_0027
    // start of loop, entry point: IL_0027

      // [185 13 - 185 14]
      IL_0011: nop

      // [186 17 - 186 33]
      IL_0012: ldarg.0      // this
      IL_0013: ldfld        class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32> HotFix_Project.InstanceClass::dict
      IL_0018: ldloc.0      // i
      IL_0019: ldloc.0      // i
      IL_001a: mul
      IL_001b: ldloc.0      // i
      IL_001c: callvirt     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32>::set_Item(!0/*int32*/, !1/*int32*/)
      IL_0021: nop

      // [187 13 - 187 14]
      IL_0022: nop

      // [184 40 - 184 43]
      IL_0023: ldloc.0      // i
      IL_0024: ldc.i4.1
      IL_0025: add
      IL_0026: stloc.0      // i

      // [184 29 - 184 38]
      IL_0027: ldloc.0      // i
      IL_0028: ldc.i4       10000 // 0x00002710
      IL_002d: clt
      IL_002f: stloc.1      // V_1

      IL_0030: ldloc.1      // V_1
      IL_0031: brtrue.s     IL_0011
    // end of loop

    // [188 9 - 188 10]
    IL_0033: ret

  } // end of method InstanceClass::test_dict_add

  .method private hidebysig instance void
    test_dict_while() cil managed
  {
    .maxstack 3
    .locals init (
      [0] valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<int32, int32> ite,
      [1] valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<int32, int32> V_1,
      [2] bool V_2
    )

    // [191 9 - 191 10]
    IL_0000: nop

    // [192 13 - 192 19]
    IL_0001: ldarg.0      // this
    IL_0002: ldc.i4.0
    IL_0003: stfld        int32 HotFix_Project.InstanceClass::n

    // [193 13 - 193 44]
    IL_0008: ldarg.0      // this
    IL_0009: ldfld        class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32> HotFix_Project.InstanceClass::dict
    IL_000e: callvirt     instance valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<!0/*int32*/, !1/*int32*/> class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32>::GetEnumerator()
    IL_0013: stloc.0      // ite

    IL_0014: br.s         IL_0034
    // start of loop, entry point: IL_0034

      // [195 13 - 195 14]
      IL_0016: nop

      // [196 17 - 196 40]
      IL_0017: ldarg.0      // this
      IL_0018: ldarg.0      // this
      IL_0019: ldfld        int32 HotFix_Project.InstanceClass::n
      IL_001e: ldloca.s     ite
      IL_0020: call         instance valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<!0/*int32*/, !1/*int32*/> valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<int32, int32>::get_Current()
      IL_0025: stloc.1      // V_1
      IL_0026: ldloca.s     V_1
      IL_0028: call         instance !1/*int32*/ valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<int32, int32>::get_Value()
      IL_002d: add
      IL_002e: stfld        int32 HotFix_Project.InstanceClass::n

      // [197 13 - 197 14]
      IL_0033: nop

      // [194 13 - 194 35]
      IL_0034: ldloca.s     ite
      IL_0036: call         instance bool valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<int32, int32>::MoveNext()
      IL_003b: stloc.2      // V_2

      IL_003c: ldloc.2      // V_2
      IL_003d: brtrue.s     IL_0016
    // end of loop

    // [198 9 - 198 10]
    IL_003f: ret

  } // end of method InstanceClass::test_dict_while

  .method private hidebysig instance void
    test_dict_foreach() cil managed
  {
    .maxstack 3
    .locals init (
      [0] valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<int32, int32> V_0,
      [1] valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<int32, int32> kv
    )

    // [200 9 - 200 10]
    IL_0000: nop

    // [201 13 - 201 19]
    IL_0001: ldarg.0      // this
    IL_0002: ldc.i4.0
    IL_0003: stfld        int32 HotFix_Project.InstanceClass::n

    // [202 13 - 202 20]
    IL_0008: nop

    // [202 32 - 202 36]
    IL_0009: ldarg.0      // this
    IL_000a: ldfld        class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32> HotFix_Project.InstanceClass::dict
    IL_000f: callvirt     instance valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<!0/*int32*/, !1/*int32*/> class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32>::GetEnumerator()
    IL_0014: stloc.0      // V_0
    .try
    {

      IL_0015: br.s         IL_0035
      // start of loop, entry point: IL_0035

        // [202 22 - 202 28]
        IL_0017: ldloca.s     V_0
        IL_0019: call         instance valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<!0/*int32*/, !1/*int32*/> valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<int32, int32>::get_Current()
        IL_001e: stloc.1      // kv

        // [203 13 - 203 14]
        IL_001f: nop

        // [204 17 - 204 31]
        IL_0020: ldarg.0      // this
        IL_0021: ldarg.0      // this
        IL_0022: ldfld        int32 HotFix_Project.InstanceClass::n
        IL_0027: ldloca.s     kv
        IL_0029: call         instance !1/*int32*/ valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<int32, int32>::get_Value()
        IL_002e: add
        IL_002f: stfld        int32 HotFix_Project.InstanceClass::n

        // [205 13 - 205 14]
        IL_0034: nop

        // [202 29 - 202 31]
        IL_0035: ldloca.s     V_0
        IL_0037: call         instance bool valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<int32, int32>::MoveNext()
        IL_003c: brtrue.s     IL_0017
      // end of loop
      IL_003e: leave.s      IL_004f
    } // end of .try
    finally
    {

      IL_0040: ldloca.s     V_0
      IL_0042: constrained. valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<int32, int32>
      IL_0048: callvirt     instance void [mscorlib]System.IDisposable::Dispose()
      IL_004d: nop
      IL_004e: endfinally
    } // end of finally

    // [206 9 - 206 10]
    IL_004f: ret

  } // end of method InstanceClass::test_dict_foreach

  .method private hidebysig instance void
    logic_2_call_app() cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 i,
      [1] bool V_1
    )

    // [209 9 - 209 10]
    IL_0000: nop

    // [210 18 - 210 27]
    IL_0001: ldc.i4.0
    IL_0002: stloc.0      // i

    IL_0003: br.s         IL_0011
    // start of loop, entry point: IL_0011

      // [211 13 - 211 14]
      IL_0005: nop

      // [212 17 - 212 37]
      IL_0006: call         void ['Assembly-CSharp']App::callFromLogic()
      IL_000b: nop

      // [213 13 - 213 14]
      IL_000c: nop

      // [210 40 - 210 43]
      IL_000d: ldloc.0      // i
      IL_000e: ldc.i4.1
      IL_000f: add
      IL_0010: stloc.0      // i

      // [210 29 - 210 38]
      IL_0011: ldloc.0      // i
      IL_0012: ldc.i4       10000 // 0x00002710
      IL_0017: clt
      IL_0019: stloc.1      // V_1

      IL_001a: ldloc.1      // V_1
      IL_001b: brtrue.s     IL_0005
    // end of loop

    // [214 9 - 214 10]
    IL_001d: ret

  } // end of method InstanceClass::logic_2_call_app

  .method private hidebysig static specialname rtspecialname void
    .cctor() cil managed
  {
    .maxstack 8

    // [146 9 - 146 28]
    IL_0000: ldc.i4.0
    IL_0001: stsfld       int32 HotFix_Project.InstanceClass::cnt
    IL_0006: ret

  } // end of method InstanceClass::.cctor

  .property instance int32 ID()
  {
    .get instance int32 HotFix_Project.InstanceClass::get_ID()
  } // end of property InstanceClass::ID
} // end of class HotFix_Project.InstanceClass
