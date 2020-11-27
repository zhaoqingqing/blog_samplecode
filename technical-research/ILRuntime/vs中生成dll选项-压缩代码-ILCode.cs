// Type: HotFix_Project.InstanceClass 
// Assembly: HotFix_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CAD4C6D-5443-445D-89AB-1447434300E1
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

    // [106 9 - 106 42]
    IL_0000: ldarg.0      // this
    IL_0001: newobj       instance void class [mscorlib]System.Collections.Generic.List`1<int32>::.ctor()
    IL_0006: stfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list

    // [180 9 - 180 64]
    IL_000b: ldarg.0      // this
    IL_000c: newobj       instance void class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32>::.ctor()
    IL_0011: stfld        class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32> HotFix_Project.InstanceClass::dict

    // [11 9 - 11 31]
    IL_0016: ldarg.0      // this
    IL_0017: call         instance void [mscorlib]System.Object::.ctor()

    // [13 13 - 13 73]
    IL_001c: ldstr        "!!! InstanceClass::InstanceClass()"
    IL_0021: call         void [UnityEngine.CoreModule]UnityEngine.Debug::Log(object)

    // [14 13 - 14 25]
    IL_0026: ldarg.0      // this
    IL_0027: ldc.i4.0
    IL_0028: stfld        int32 HotFix_Project.InstanceClass::id

    // [15 9 - 15 10]
    IL_002d: ret

  } // end of method InstanceClass::.ctor

  .method public hidebysig specialname rtspecialname instance void
    .ctor(
      int32 id
    ) cil managed
  {
    .maxstack 8

    // [106 9 - 106 42]
    IL_0000: ldarg.0      // this
    IL_0001: newobj       instance void class [mscorlib]System.Collections.Generic.List`1<int32>::.ctor()
    IL_0006: stfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list

    // [180 9 - 180 64]
    IL_000b: ldarg.0      // this
    IL_000c: newobj       instance void class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32>::.ctor()
    IL_0011: stfld        class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32> HotFix_Project.InstanceClass::dict

    // [17 9 - 17 37]
    IL_0016: ldarg.0      // this
    IL_0017: call         instance void [mscorlib]System.Object::.ctor()

    // [19 13 - 19 84]
    IL_001c: ldstr        "!!! InstanceClass::InstanceClass() id = "
    IL_0021: ldarg.1      // id
    IL_0022: box          [mscorlib]System.Int32
    IL_0027: call         string [mscorlib]System.String::Concat(object, object)
    IL_002c: call         void [UnityEngine.CoreModule]UnityEngine.Debug::Log(object)

    // [20 13 - 20 26]
    IL_0031: ldarg.0      // this
    IL_0032: ldarg.1      // id
    IL_0033: stfld        int32 HotFix_Project.InstanceClass::id

    // [21 9 - 21 10]
    IL_0038: ret

  } // end of method InstanceClass::.ctor

  .method public hidebysig specialname instance int32
    get_ID() cil managed
  {
    .maxstack 8

    // [25 19 - 25 29]
    IL_0000: ldarg.0      // this
    IL_0001: ldfld        int32 HotFix_Project.InstanceClass::id
    IL_0006: ret

  } // end of method InstanceClass::get_ID

  .method public hidebysig static void
    StaticFunTest() cil managed
  {
    .maxstack 8

    // [33 13 - 33 72]
    IL_0000: ldstr        "!!! InstanceClass.StaticFunTest()"
    IL_0005: call         void [UnityEngine.CoreModule]UnityEngine.Debug::Log(object)

    // [34 13 - 34 40]
    IL_000a: newobj       instance void HotFix_Project.InstanceClass::.ctor()
    IL_000f: stsfld       class HotFix_Project.InstanceClass HotFix_Project.InstanceClass::self

    // [35 13 - 35 30]
    IL_0014: ldsfld       class HotFix_Project.InstanceClass HotFix_Project.InstanceClass::self
    IL_0019: callvirt     instance void HotFix_Project.InstanceClass::test_init()

    // [36 9 - 36 10]
    IL_001e: ret

  } // end of method InstanceClass::StaticFunTest

  .method public hidebysig static void
    StaticFunTest2(
      int32 a
    ) cil managed
  {
    .maxstack 8

    // [40 13 - 40 81]
    IL_0000: ldstr        "!!! InstanceClass.StaticFunTest2(), a="
    IL_0005: ldarg.0      // a
    IL_0006: box          [mscorlib]System.Int32
    IL_000b: call         string [mscorlib]System.String::Concat(object, object)
    IL_0010: call         void [UnityEngine.CoreModule]UnityEngine.Debug::Log(object)

    // [41 9 - 41 10]
    IL_0015: ret

  } // end of method InstanceClass::StaticFunTest2

  .method public hidebysig static void
    GenericMethod<T>(
      !!0/*T*/ a
    ) cil managed
  {
    .maxstack 8

    // [45 13 - 45 80]
    IL_0000: ldstr        "!!! InstanceClass.GenericMethod(), a="
    IL_0005: ldarg.0      // a
    IL_0006: box          !!0/*T*/
    IL_000b: call         string [mscorlib]System.String::Concat(object, object)
    IL_0010: call         void [UnityEngine.CoreModule]UnityEngine.Debug::Log(object)

    // [46 9 - 46 10]
    IL_0015: ret

  } // end of method InstanceClass::GenericMethod

  .method public hidebysig instance void
    RefOutMethod(
      int32 addition,
      [out] class [mscorlib]System.Collections.Generic.List`1<int32>& lst,
      int32& val
    ) cil managed
  {
    .maxstack 8

    // [50 13 - 50 39]
    IL_0000: ldarg.3      // val
    IL_0001: ldarg.3      // val
    IL_0002: ldind.i4
    IL_0003: ldarg.1      // addition
    IL_0004: add
    IL_0005: ldarg.0      // this
    IL_0006: ldfld        int32 HotFix_Project.InstanceClass::id
    IL_000b: add
    IL_000c: stind.i4

    // [51 13 - 51 35]
    IL_000d: ldarg.2      // lst
    IL_000e: newobj       instance void class [mscorlib]System.Collections.Generic.List`1<int32>::.ctor()
    IL_0013: stind.ref

    // [52 13 - 52 25]
    IL_0014: ldarg.2      // lst
    IL_0015: ldind.ref
    IL_0016: ldarg.0      // this
    IL_0017: ldfld        int32 HotFix_Project.InstanceClass::id
    IL_001c: callvirt     instance void class [mscorlib]System.Collections.Generic.List`1<int32>::Add(!0/*int32*/)

    // [53 9 - 53 10]
    IL_0021: ret

  } // end of method InstanceClass::RefOutMethod

  .method private hidebysig instance void
    test_init() cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 i
    )

    // [62 18 - 62 27]
    IL_0000: ldc.i4.0
    IL_0001: stloc.0      // i

    IL_0002: br.s         IL_003b
    // start of loop, entry point: IL_003b

      // [64 17 - 64 46]
      IL_0004: ldarg.0      // this
      IL_0005: ldftn        instance void HotFix_Project.InstanceClass::test_empty()
      IL_000b: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
      IL_0010: call         void ['Assembly-CSharp']App::add_test_empty(class [mscorlib]System.Action)

      // [65 17 - 65 50]
      IL_0015: ldarg.0      // this
      IL_0016: ldftn        instance void HotFix_Project.InstanceClass::test_add_App()
      IL_001c: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
      IL_0021: call         void ['Assembly-CSharp']App::add_test_add_App(class [mscorlib]System.Action)

      // [66 17 - 66 54]
      IL_0026: ldarg.0      // this
      IL_0027: ldftn        instance void HotFix_Project.InstanceClass::test_add_Logic()
      IL_002d: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
      IL_0032: call         void ['Assembly-CSharp']App::add_test_add_Logic(class [mscorlib]System.Action)

      // [62 40 - 62 43]
      IL_0037: ldloc.0      // i
      IL_0038: ldc.i4.1
      IL_0039: add
      IL_003a: stloc.0      // i

      // [62 29 - 62 38]
      IL_003b: ldloc.0      // i
      IL_003c: ldc.i4       10000 // 0x00002710
      IL_0041: blt.s        IL_0004
    // end of loop

    // [69 13 - 69 56]
    IL_0043: ldarg.0      // this
    IL_0044: ldftn        instance void HotFix_Project.InstanceClass::test_add_App10000()
    IL_004a: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_004f: call         void ['Assembly-CSharp']App::add_test_add_App10000(class [mscorlib]System.Action)

    // [70 13 - 70 60]
    IL_0054: ldarg.0      // this
    IL_0055: ldftn        instance void HotFix_Project.InstanceClass::test_add_Logic10000()
    IL_005b: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_0060: call         void ['Assembly-CSharp']App::add_test_add_Logic10000(class [mscorlib]System.Action)

    // [72 13 - 72 48]
    IL_0065: ldarg.0      // this
    IL_0066: ldftn        instance void HotFix_Project.InstanceClass::test_list_add()
    IL_006c: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_0071: call         void ['Assembly-CSharp']App::add_test_list_add(class [mscorlib]System.Action)

    // [73 13 - 73 48]
    IL_0076: ldarg.0      // this
    IL_0077: ldftn        instance void HotFix_Project.InstanceClass::test_list_for()
    IL_007d: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_0082: call         void ['Assembly-CSharp']App::add_test_list_for(class [mscorlib]System.Action)

    // [74 13 - 74 56]
    IL_0087: ldarg.0      // this
    IL_0088: ldftn        instance void HotFix_Project.InstanceClass::test_list_foreach()
    IL_008e: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_0093: call         void ['Assembly-CSharp']App::add_test_list_foreach(class [mscorlib]System.Action)

    // [75 13 - 75 50]
    IL_0098: ldarg.0      // this
    IL_0099: ldftn        instance void HotFix_Project.InstanceClass::test_array_for()
    IL_009f: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_00a4: call         void ['Assembly-CSharp']App::add_test_array_for(class [mscorlib]System.Action)

    // [76 13 - 76 58]
    IL_00a9: ldarg.0      // this
    IL_00aa: ldftn        instance void HotFix_Project.InstanceClass::test_array_foreach()
    IL_00b0: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_00b5: call         void ['Assembly-CSharp']App::add_test_array_foreach(class [mscorlib]System.Action)

    // [78 13 - 78 48]
    IL_00ba: ldarg.0      // this
    IL_00bb: ldftn        instance void HotFix_Project.InstanceClass::test_dict_add()
    IL_00c1: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_00c6: call         void ['Assembly-CSharp']App::add_test_dict_add(class [mscorlib]System.Action)

    // [79 13 - 79 52]
    IL_00cb: ldarg.0      // this
    IL_00cc: ldftn        instance void HotFix_Project.InstanceClass::test_dict_while()
    IL_00d2: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_00d7: call         void ['Assembly-CSharp']App::add_test_dict_while(class [mscorlib]System.Action)

    // [80 13 - 80 56]
    IL_00dc: ldarg.0      // this
    IL_00dd: ldftn        instance void HotFix_Project.InstanceClass::test_dict_foreach()
    IL_00e3: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_00e8: call         void ['Assembly-CSharp']App::add_test_dict_foreach(class [mscorlib]System.Action)

    // [81 13 - 81 64]
    IL_00ed: ldarg.0      // this
    IL_00ee: ldftn        instance void HotFix_Project.InstanceClass::logic_2_call_app()
    IL_00f4: newobj       instance void [mscorlib]System.Action::.ctor(object, native int)
    IL_00f9: call         void ['Assembly-CSharp']App::add_test_call_logic_2_call_app(class [mscorlib]System.Action)

    // [84 9 - 84 10]
    IL_00fe: ret

  } // end of method InstanceClass::test_init

  .method private hidebysig instance void
    test_empty() cil managed
  {
    .maxstack 8

    // [87 29 - 87 30]
    IL_0000: ret

  } // end of method InstanceClass::test_empty

  .method private hidebysig instance void
    test_add_App() cil managed
  {
    .maxstack 8

    // [89 31 - 89 46]
    IL_0000: ldsfld       int32 ['Assembly-CSharp']App::test_int
    IL_0005: ldc.i4.1
    IL_0006: add
    IL_0007: stsfld       int32 ['Assembly-CSharp']App::test_int

    // [89 47 - 89 48]
    IL_000c: ret

  } // end of method InstanceClass::test_add_App

  .method private hidebysig instance void
    test_add_App10000() cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 i
    )

    // [92 18 - 92 27]
    IL_0000: ldc.i4.0
    IL_0001: stloc.0      // i

    IL_0002: br.s         IL_0014
    // start of loop, entry point: IL_0014

      // [93 17 - 93 32]
      IL_0004: ldsfld       int32 ['Assembly-CSharp']App::test_int
      IL_0009: ldc.i4.1
      IL_000a: add
      IL_000b: stsfld       int32 ['Assembly-CSharp']App::test_int

      // [92 40 - 92 43]
      IL_0010: ldloc.0      // i
      IL_0011: ldc.i4.1
      IL_0012: add
      IL_0013: stloc.0      // i

      // [92 29 - 92 38]
      IL_0014: ldloc.0      // i
      IL_0015: ldc.i4       10000 // 0x00002710
      IL_001a: blt.s        IL_0004
    // end of loop

    // [94 9 - 94 10]
    IL_001c: ret

  } // end of method InstanceClass::test_add_App10000

  .method private hidebysig instance void
    test_add_Logic() cil managed
  {
    .maxstack 8

    // [97 33 - 97 44]
    IL_0000: ldarg.0      // this
    IL_0001: ldarg.0      // this
    IL_0002: ldfld        int32 HotFix_Project.InstanceClass::test_int
    IL_0007: ldc.i4.1
    IL_0008: add
    IL_0009: stfld        int32 HotFix_Project.InstanceClass::test_int

    // [97 45 - 97 46]
    IL_000e: ret

  } // end of method InstanceClass::test_add_Logic

  .method private hidebysig instance void
    test_add_Logic10000() cil managed
  {
    .maxstack 3
    .locals init (
      [0] int32 i
    )

    // [101 18 - 101 27]
    IL_0000: ldc.i4.0
    IL_0001: stloc.0      // i

    IL_0002: br.s         IL_0016
    // start of loop, entry point: IL_0016

      // [102 17 - 102 28]
      IL_0004: ldarg.0      // this
      IL_0005: ldarg.0      // this
      IL_0006: ldfld        int32 HotFix_Project.InstanceClass::test_int
      IL_000b: ldc.i4.1
      IL_000c: add
      IL_000d: stfld        int32 HotFix_Project.InstanceClass::test_int

      // [101 40 - 101 43]
      IL_0012: ldloc.0      // i
      IL_0013: ldc.i4.1
      IL_0014: add
      IL_0015: stloc.0      // i

      // [101 29 - 101 38]
      IL_0016: ldloc.0      // i
      IL_0017: ldc.i4       10000 // 0x00002710
      IL_001c: blt.s        IL_0004
    // end of loop

    // [103 9 - 103 10]
    IL_001e: ret

  } // end of method InstanceClass::test_add_Logic10000

  .method private hidebysig instance void
    test_list_add() cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 i
    )

    // [110 13 - 110 26]
    IL_0000: ldarg.0      // this
    IL_0001: ldfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list
    IL_0006: callvirt     instance void class [mscorlib]System.Collections.Generic.List`1<int32>::Clear()

    // [111 18 - 111 27]
    IL_000b: ldc.i4.0
    IL_000c: stloc.0      // i

    IL_000d: br.s         IL_001f
    // start of loop, entry point: IL_001f

      // [113 17 - 113 29]
      IL_000f: ldarg.0      // this
      IL_0010: ldfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list
      IL_0015: ldloc.0      // i
      IL_0016: callvirt     instance void class [mscorlib]System.Collections.Generic.List`1<int32>::Add(!0/*int32*/)

      // [111 40 - 111 43]
      IL_001b: ldloc.0      // i
      IL_001c: ldc.i4.1
      IL_001d: add
      IL_001e: stloc.0      // i

      // [111 29 - 111 38]
      IL_001f: ldloc.0      // i
      IL_0020: ldc.i4       10000 // 0x00002710
      IL_0025: blt.s        IL_000f
    // end of loop

    // [115 13 - 115 36]
    IL_0027: ldarg.0      // this
    IL_0028: ldarg.0      // this
    IL_0029: ldfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list
    IL_002e: callvirt     instance !0/*int32*/[] class [mscorlib]System.Collections.Generic.List`1<int32>::ToArray()
    IL_0033: stfld        int32[] HotFix_Project.InstanceClass::'array'

    // [116 9 - 116 10]
    IL_0038: ret

  } // end of method InstanceClass::test_list_add

  .method private hidebysig instance void
    test_list_for() cil managed
  {
    .maxstack 4
    .locals init (
      [0] int32 len,
      [1] int32 i
    )

    // [121 13 - 121 34]
    IL_0000: ldarg.0      // this
    IL_0001: ldfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list
    IL_0006: callvirt     instance int32 class [mscorlib]System.Collections.Generic.List`1<int32>::get_Count()
    IL_000b: stloc.0      // len

    // [122 13 - 122 19]
    IL_000c: ldarg.0      // this
    IL_000d: ldc.i4.0
    IL_000e: stfld        int32 HotFix_Project.InstanceClass::n

    // [123 18 - 123 27]
    IL_0013: ldc.i4.0
    IL_0014: stloc.1      // i

    IL_0015: br.s         IL_0034
    // start of loop, entry point: IL_0034

      // [125 17 - 125 30]
      IL_0017: ldarg.0      // this
      IL_0018: ldarg.0      // this
      IL_0019: ldfld        int32 HotFix_Project.InstanceClass::n
      IL_001e: ldarg.0      // this
      IL_001f: ldfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list
      IL_0024: ldloc.1      // i
      IL_0025: callvirt     instance !0/*int32*/ class [mscorlib]System.Collections.Generic.List`1<int32>::get_Item(int32)
      IL_002a: add
      IL_002b: stfld        int32 HotFix_Project.InstanceClass::n

      // [123 38 - 123 41]
      IL_0030: ldloc.1      // i
      IL_0031: ldc.i4.1
      IL_0032: add
      IL_0033: stloc.1      // i

      // [123 29 - 123 36]
      IL_0034: ldloc.1      // i
      IL_0035: ldloc.0      // len
      IL_0036: blt.s        IL_0017
    // end of loop

    // [127 9 - 127 10]
    IL_0038: ret

  } // end of method InstanceClass::test_list_for

  .method private hidebysig instance void
    test_list_foreach() cil managed
  {
    .maxstack 3
    .locals init (
      [0] valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32> V_0,
      [1] int32 i
    )

    // [130 13 - 130 19]
    IL_0000: ldarg.0      // this
    IL_0001: ldc.i4.0
    IL_0002: stfld        int32 HotFix_Project.InstanceClass::n

    // [131 31 - 131 35]
    IL_0007: ldarg.0      // this
    IL_0008: ldfld        class [mscorlib]System.Collections.Generic.List`1<int32> HotFix_Project.InstanceClass::list
    IL_000d: callvirt     instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0/*int32*/> class [mscorlib]System.Collections.Generic.List`1<int32>::GetEnumerator()
    IL_0012: stloc.0      // V_0
    .try
    {

      IL_0013: br.s         IL_002b
      // start of loop, entry point: IL_002b

        // [131 22 - 131 27]
        IL_0015: ldloca.s     V_0
        IL_0017: call         instance !0/*int32*/ valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32>::get_Current()
        IL_001c: stloc.1      // i

        // [133 17 - 133 24]
        IL_001d: ldarg.0      // this
        IL_001e: ldarg.0      // this
        IL_001f: ldfld        int32 HotFix_Project.InstanceClass::n
        IL_0024: ldloc.1      // i
        IL_0025: add
        IL_0026: stfld        int32 HotFix_Project.InstanceClass::n

        // [131 28 - 131 30]
        IL_002b: ldloca.s     V_0
        IL_002d: call         instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32>::MoveNext()
        IL_0032: brtrue.s     IL_0015
      // end of loop
      IL_0034: leave.s      IL_0044
    } // end of .try
    finally
    {

      IL_0036: ldloca.s     V_0
      IL_0038: constrained. valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32>
      IL_003e: callvirt     instance void [mscorlib]System.IDisposable::Dispose()
      IL_0043: endfinally
    } // end of finally

    // [135 9 - 135 10]
    IL_0044: ret

  } // end of method InstanceClass::test_list_foreach

  .method private hidebysig instance void
    test_array_for() cil managed
  {
    .maxstack 4
    .locals init (
      [0] int32 len,
      [1] int32 i
    )

    // [139 13 - 139 36]
    IL_0000: ldarg.0      // this
    IL_0001: ldfld        int32[] HotFix_Project.InstanceClass::'array'
    IL_0006: ldlen
    IL_0007: conv.i4
    IL_0008: stloc.0      // len

    // [140 13 - 140 19]
    IL_0009: ldarg.0      // this
    IL_000a: ldc.i4.0
    IL_000b: stfld        int32 HotFix_Project.InstanceClass::n

    // [141 18 - 141 27]
    IL_0010: ldc.i4.0
    IL_0011: stloc.1      // i

    IL_0012: br.s         IL_002d
    // start of loop, entry point: IL_002d

      // [143 17 - 143 31]
      IL_0014: ldarg.0      // this
      IL_0015: ldarg.0      // this
      IL_0016: ldfld        int32 HotFix_Project.InstanceClass::n
      IL_001b: ldarg.0      // this
      IL_001c: ldfld        int32[] HotFix_Project.InstanceClass::'array'
      IL_0021: ldloc.1      // i
      IL_0022: ldelem.i4
      IL_0023: add
      IL_0024: stfld        int32 HotFix_Project.InstanceClass::n

      // [141 38 - 141 41]
      IL_0029: ldloc.1      // i
      IL_002a: ldc.i4.1
      IL_002b: add
      IL_002c: stloc.1      // i

      // [141 29 - 141 36]
      IL_002d: ldloc.1      // i
      IL_002e: ldloc.0      // len
      IL_002f: blt.s        IL_0014
    // end of loop

    // [145 9 - 145 10]
    IL_0031: ret

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
      [4] int32 i
    )

    // [149 13 - 149 45]
    IL_0000: call         valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
    IL_0005: stloc.3      // V_3
    IL_0006: ldloca.s     V_3
    IL_0008: call         instance int64 [mscorlib]System.DateTime::get_Ticks()
    IL_000d: stloc.0      // before

    // [150 13 - 150 82]
    IL_000e: newobj       instance void [System]System.Diagnostics.Stopwatch::.ctor()
    IL_0013: stloc.1      // sw

    // [151 13 - 151 24]
    IL_0014: ldloc.1      // sw
    IL_0015: callvirt     instance void [System]System.Diagnostics.Stopwatch::Start()

    // [153 18 - 153 27]
    IL_001a: ldc.i4.0
    IL_001b: stloc.s      i

    IL_001d: br.s         IL_0032
    // start of loop, entry point: IL_0032

      // [155 17 - 155 26]
      IL_001f: ldsfld       int32 HotFix_Project.InstanceClass::cnt
      IL_0024: ldloc.s      i
      IL_0026: add
      IL_0027: stsfld       int32 HotFix_Project.InstanceClass::cnt

      // [153 41 - 153 44]
      IL_002c: ldloc.s      i
      IL_002e: ldc.i4.1
      IL_002f: add
      IL_0030: stloc.s      i

      // [153 29 - 153 39]
      IL_0032: ldloc.s      i
      IL_0034: ldc.i4       500000 // 0x0007a120
      IL_0039: blt.s        IL_001f
    // end of loop

    // [157 13 - 157 23]
    IL_003b: ldloc.1      // sw
    IL_003c: callvirt     instance void [System]System.Diagnostics.Stopwatch::Stop()

    // [158 13 - 158 57]
    IL_0041: call         valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
    IL_0046: stloc.3      // V_3
    IL_0047: ldloca.s     V_3
    IL_0049: call         instance int64 [mscorlib]System.DateTime::get_Ticks()
    IL_004e: ldloc.0      // before
    IL_004f: sub
    IL_0050: stloc.2      // tick_diff

    // [159 13 - 159 150]
    IL_0051: ldstr        "UnitTest_Performance50Íò Elapsed time:{0:0}ms, result = {1}  ,Tick:{2}"
    IL_0056: ldloc.1      // sw
    IL_0057: callvirt     instance int64 [System]System.Diagnostics.Stopwatch::get_ElapsedMilliseconds()
    IL_005c: box          [mscorlib]System.Int64
    IL_0061: ldsfld       int32 HotFix_Project.InstanceClass::cnt
    IL_0066: box          [mscorlib]System.Int32
    IL_006b: ldloc.2      // tick_diff
    IL_006c: box          [mscorlib]System.Int64
    IL_0071: call         string [mscorlib]System.String::Format(string, object, object, object)
    IL_0076: call         void [UnityEngine.CoreModule]UnityEngine.Debug::Log(object)

    // [160 9 - 160 10]
    IL_007b: ret

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

    // [164 13 - 164 19]
    IL_0000: ldarg.0      // this
    IL_0001: ldc.i4.0
    IL_0002: stfld        int32 HotFix_Project.InstanceClass::n

    // [165 31 - 165 36]
    IL_0007: ldarg.0      // this
    IL_0008: ldfld        int32[] HotFix_Project.InstanceClass::'array'
    IL_000d: stloc.0      // V_0
    IL_000e: ldc.i4.0
    IL_000f: stloc.1      // V_1

    IL_0010: br.s         IL_0028
    // start of loop, entry point: IL_0028

      // [165 22 - 165 27]
      IL_0012: ldloc.0      // V_0
      IL_0013: ldloc.1      // V_1
      IL_0014: ldelem.i4
      IL_0015: stloc.2      // i

      // [167 17 - 167 24]
      IL_0016: ldarg.0      // this
      IL_0017: ldarg.0      // this
      IL_0018: ldfld        int32 HotFix_Project.InstanceClass::n
      IL_001d: ldloc.2      // i
      IL_001e: add
      IL_001f: stfld        int32 HotFix_Project.InstanceClass::n

      IL_0024: ldloc.1      // V_1
      IL_0025: ldc.i4.1
      IL_0026: add
      IL_0027: stloc.1      // V_1

      // [165 28 - 165 30]
      IL_0028: ldloc.1      // V_1
      IL_0029: ldloc.0      // V_0
      IL_002a: ldlen
      IL_002b: conv.i4
      IL_002c: blt.s        IL_0012
    // end of loop

    // [178 9 - 178 10]
    IL_002e: ret

  } // end of method InstanceClass::test_array_foreach

  .method private hidebysig instance void
    test_dict_add() cil managed
  {
    .maxstack 3
    .locals init (
      [0] int32 i
    )

    // [183 13 - 183 26]
    IL_0000: ldarg.0      // this
    IL_0001: ldfld        class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32> HotFix_Project.InstanceClass::dict
    IL_0006: callvirt     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32>::Clear()

    // [184 18 - 184 27]
    IL_000b: ldc.i4.0
    IL_000c: stloc.0      // i

    IL_000d: br.s         IL_0022
    // start of loop, entry point: IL_0022

      // [186 17 - 186 33]
      IL_000f: ldarg.0      // this
      IL_0010: ldfld        class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32> HotFix_Project.InstanceClass::dict
      IL_0015: ldloc.0      // i
      IL_0016: ldloc.0      // i
      IL_0017: mul
      IL_0018: ldloc.0      // i
      IL_0019: callvirt     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32>::set_Item(!0/*int32*/, !1/*int32*/)

      // [184 40 - 184 43]
      IL_001e: ldloc.0      // i
      IL_001f: ldc.i4.1
      IL_0020: add
      IL_0021: stloc.0      // i

      // [184 29 - 184 38]
      IL_0022: ldloc.0      // i
      IL_0023: ldc.i4       10000 // 0x00002710
      IL_0028: blt.s        IL_000f
    // end of loop

    // [188 9 - 188 10]
    IL_002a: ret

  } // end of method InstanceClass::test_dict_add

  .method private hidebysig instance void
    test_dict_while() cil managed
  {
    .maxstack 3
    .locals init (
      [0] valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<int32, int32> ite,
      [1] valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<int32, int32> V_1
    )

    // [192 13 - 192 19]
    IL_0000: ldarg.0      // this
    IL_0001: ldc.i4.0
    IL_0002: stfld        int32 HotFix_Project.InstanceClass::n

    // [193 13 - 193 44]
    IL_0007: ldarg.0      // this
    IL_0008: ldfld        class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32> HotFix_Project.InstanceClass::dict
    IL_000d: callvirt     instance valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<!0/*int32*/, !1/*int32*/> class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32>::GetEnumerator()
    IL_0012: stloc.0      // ite

    IL_0013: br.s         IL_0031
    // start of loop, entry point: IL_0031

      // [196 17 - 196 40]
      IL_0015: ldarg.0      // this
      IL_0016: ldarg.0      // this
      IL_0017: ldfld        int32 HotFix_Project.InstanceClass::n
      IL_001c: ldloca.s     ite
      IL_001e: call         instance valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<!0/*int32*/, !1/*int32*/> valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<int32, int32>::get_Current()
      IL_0023: stloc.1      // V_1
      IL_0024: ldloca.s     V_1
      IL_0026: call         instance !1/*int32*/ valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<int32, int32>::get_Value()
      IL_002b: add
      IL_002c: stfld        int32 HotFix_Project.InstanceClass::n

      // [194 13 - 194 35]
      IL_0031: ldloca.s     ite
      IL_0033: call         instance bool valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<int32, int32>::MoveNext()
      IL_0038: brtrue.s     IL_0015
    // end of loop

    // [198 9 - 198 10]
    IL_003a: ret

  } // end of method InstanceClass::test_dict_while

  .method private hidebysig instance void
    test_dict_foreach() cil managed
  {
    .maxstack 3
    .locals init (
      [0] valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<int32, int32> V_0,
      [1] valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<int32, int32> kv
    )

    // [201 13 - 201 19]
    IL_0000: ldarg.0      // this
    IL_0001: ldc.i4.0
    IL_0002: stfld        int32 HotFix_Project.InstanceClass::n

    // [202 32 - 202 36]
    IL_0007: ldarg.0      // this
    IL_0008: ldfld        class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32> HotFix_Project.InstanceClass::dict
    IL_000d: callvirt     instance valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<!0/*int32*/, !1/*int32*/> class [mscorlib]System.Collections.Generic.Dictionary`2<int32, int32>::GetEnumerator()
    IL_0012: stloc.0      // V_0
    .try
    {

      IL_0013: br.s         IL_0031
      // start of loop, entry point: IL_0031

        // [202 22 - 202 28]
        IL_0015: ldloca.s     V_0
        IL_0017: call         instance valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<!0/*int32*/, !1/*int32*/> valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<int32, int32>::get_Current()
        IL_001c: stloc.1      // kv

        // [204 17 - 204 31]
        IL_001d: ldarg.0      // this
        IL_001e: ldarg.0      // this
        IL_001f: ldfld        int32 HotFix_Project.InstanceClass::n
        IL_0024: ldloca.s     kv
        IL_0026: call         instance !1/*int32*/ valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<int32, int32>::get_Value()
        IL_002b: add
        IL_002c: stfld        int32 HotFix_Project.InstanceClass::n

        // [202 29 - 202 31]
        IL_0031: ldloca.s     V_0
        IL_0033: call         instance bool valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<int32, int32>::MoveNext()
        IL_0038: brtrue.s     IL_0015
      // end of loop
      IL_003a: leave.s      IL_004a
    } // end of .try
    finally
    {

      IL_003c: ldloca.s     V_0
      IL_003e: constrained. valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<int32, int32>
      IL_0044: callvirt     instance void [mscorlib]System.IDisposable::Dispose()
      IL_0049: endfinally
    } // end of finally

    // [206 9 - 206 10]
    IL_004a: ret

  } // end of method InstanceClass::test_dict_foreach

  .method private hidebysig instance void
    logic_2_call_app() cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 i
    )

    // [210 18 - 210 27]
    IL_0000: ldc.i4.0
    IL_0001: stloc.0      // i

    IL_0002: br.s         IL_000d
    // start of loop, entry point: IL_000d

      // [212 17 - 212 37]
      IL_0004: call         void ['Assembly-CSharp']App::callFromLogic()

      // [210 40 - 210 43]
      IL_0009: ldloc.0      // i
      IL_000a: ldc.i4.1
      IL_000b: add
      IL_000c: stloc.0      // i

      // [210 29 - 210 38]
      IL_000d: ldloc.0      // i
      IL_000e: ldc.i4       10000 // 0x00002710
      IL_0013: blt.s        IL_0004
    // end of loop

    // [214 9 - 214 10]
    IL_0015: ret

  } // end of method InstanceClass::logic_2_call_app

  .method private hidebysig static specialname rtspecialname void
    .cctor() cil managed
  {
    .maxstack 8

    IL_0000: ret

  } // end of method InstanceClass::.cctor

  .property instance int32 ID()
  {
    .get instance int32 HotFix_Project.InstanceClass::get_ID()
  } // end of property InstanceClass::ID
} // end of class HotFix_Project.InstanceClass
