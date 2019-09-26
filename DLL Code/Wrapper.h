#pragma once
#include "PluginSettings.h"
#include "SaverLoader.h"

#ifdef __cplusplus
extern "C"
{
#endif

	PLUGIN_API bool Save();
	PLUGIN_API void PushToSaveStack(SaveObj toSave);
	PLUGIN_API int GetNumberOfLines();

#ifdef __cplusplus
}
#endif