---初始化CreatureGizmosHelper
function Actor:ctor(model)
	self.gizmos = self.gameObject:AddComponent(typeof(CS.CreatureGizmosHelper))
	self.gizmos.LuaRef = self
end
	
---返回字符串	
function AITrait:Dump()
    local str = "\n\t性格：" .. characterType
    str = str .. "\n\tmasterId:" .. self.actor.model.masterId
    str = str .. "\n\t" .. string.format("当前搜索怪物次数%s，最大次数%s", self.searchCount, self.searchMax)
    return str
end