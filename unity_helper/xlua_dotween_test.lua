-- transform:DOMove(Vector3.zero, 3, false);

--场景中绑定LuaBehaviour，执行Unity的默认函数

function start()
    print("lua start .");
    local tween = self.transform:DOMoveX(10,3)
    --tween:OnComplete(){
    --    print("move callback")
    --}
end