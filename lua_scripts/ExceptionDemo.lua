--- lua异常处理
--- xpcall和pcall的区别
--- Created by zhaoq.
--- DateTime: 2017/10/19 21:51
---


local status, err = pcall(function()
    error({ code = 121 })
end)
print(err.code)  -->  121