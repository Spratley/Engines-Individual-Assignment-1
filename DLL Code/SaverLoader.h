#pragma once

#include "PluginSettings.h"
#include "Vector3.h"
#include <vector>

class PLUGIN_API SaverLoader
{
public:
	std::vector<SaveObj> SaveStack;
	
	void PushToSaveStack(SaveObj toSave);
	
	bool Save();

	int GetNumberOfLines();


};