#pragma once

#ifdef  SAVELOADPLUGIN_EXPORTS
#define PLUGIN_API __declspec(dllexport)
#elif SAVELOADPLUGIN_IMPORTS
#define PLUGIN_API __declspec(dllexport)
#else
#define PLUGIN_API
#endif