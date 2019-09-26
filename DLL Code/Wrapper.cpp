#include "Wrapper.h"

SaverLoader sl;

PLUGIN_API bool Save()
{
	return sl.Save();
}

PLUGIN_API void PushToSaveStack(SaveObj toSave)
{
	sl.PushToSaveStack(toSave);
}

PLUGIN_API int GetNumberOfLines()
{
	return sl.GetNumberOfLines();
}
