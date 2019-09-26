#pragma once

#include "PluginSettings.h"
#include "Vector3.h"
#include <vector>

class PLUGIN_API SaverLoader
{
public:
	std::vector<SaveObj> objectStack;
	
	void PushToStack(SaveObj toSave);
	
	bool Save();

	int PreloadObjects();

	void ResetStack();
	
	SaveObj LoadObject(int id);


};