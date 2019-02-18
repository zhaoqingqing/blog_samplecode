--- 使用jit构建vector3，测试性能
--- TODO ffi：http://luajit.org/ext_ffi.html
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2019/2/18
---
local ffi_benchmark = {}

local ffi = require("ffi")
ffi.cdef [[
    typedef struct { float x, y, z; } vector3c;
    ]]
local count = 100000
local function test1()
    local startTime = os.time()
    -- lua table的代码
    local vecs = {}
    for i = 1, count do
        vecs[i] = { x = 1, y = 2, z = 3 }
    end
    local total = 0
    -- gc后记录下面for循环运行时的时间和内存占用，这里省略
    for i = 1, count do
        total = total + vecs[i].x + vecs[i].y + vecs[i].z
    end
    local diffTime = os.time() - startTime
    print("lua table 耗时：", diffTime)
end

local function test2()
    local startTime = os.time()
    -- ffi的代码
    local vecs = ffi.new("vector3c[?]", count)
    for i = 1, count do
        vecs[i] = { x = 1, y = 2, z = 3 }
    end

    local total = 0
    -- gc后记录下面for循环运行时的时间和内存占用，这里省略
    for i = 1, count do
        total = total + vecs[i].x + vecs[i].y + vecs[i].z
    end
    local diffTime = os.time() - startTime
    print("ffi 耗时：", diffTime)
end

test1()
test2()

return ffi_benchmark