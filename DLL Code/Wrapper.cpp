#include "Wrapper.h"

SaverLoader sl;

PLUGIN_API bool Save()
{
	return sl.Save();
}

PLUGIN_API void PushToStack(SaveObj toSave)
{
	sl.PushToStack(toSave);
}

PLUGIN_API int PreloadObjects()
{
	return sl.PreloadObjects();
}

PLUGIN_API SaveObj LoadObject(int id)
{
	return sl.LoadObject(id);
}
