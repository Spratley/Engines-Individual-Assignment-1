#pragma once
#include "PluginSettings.h"
#include "SaverLoader.h"

#ifdef __cplusplus
extern "C"
{
#endif

	PLUGIN_API bool Save();
	PLUGIN_API void PushToStack(SaveObj toSave);
	PLUGIN_API int PreloadObjects();
	PLUGIN_API SaveObj LoadObject(int id);

#ifdef __cplusplus
}
#endif