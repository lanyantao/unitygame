MLoader("MyLua.Libs.Core.GlobalNS");
MLoader("MyLua.Libs.Core.Class");
MLoader("MyLua.Libs.Core.GObject");

MLoader("MyLua.UI.UIItempricePanel.ItempricePanelNS");

--数据区
local M = GlobalNS.Class(GlobalNS.GObject);
M.clsName = "ItempricePanelData";
GlobalNS.ItempricePanelNS[M.clsName] = M;

function M:ctor()
	
end

function M:dtor()
	
end

return M;