require "MyLua.Libs.Core.GlobalNS"
require "MyLua.Libs.Core.Class"
require "MyLua.Libs.Core.GObject"

local M = GlobalNS.Class(GlobalNS.SceneEntity);
M.clsName = "Home";
GlobalNS[M.clsName] = M;

function M:ctor()

end