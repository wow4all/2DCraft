using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LuaInterface;

namespace _2DCraft
{
	static class Lua
	{
		static private LuaInterface.Lua lua;

		static public void Init()
		{
			lua = new LuaInterface.Lua();
		}


	}
}