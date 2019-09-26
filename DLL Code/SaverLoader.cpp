#include "SaverLoader.h"
#include <fstream>
#include <sstream>


void SaverLoader::PushToStack(SaveObj toSave)//Vector3 position, Vector3 rotation, Vector3 scale)
{
	objectStack.push_back(toSave);
}

bool SaverLoader::Save()
{
	std::ofstream fileStream;
	fileStream.open("SaveData.txt");// , std::ofstream::out | std::ofstream::trunc);

	for (int i = 0; i < objectStack.size(); ++i)
	{
		fileStream << (objectStack[i].ToString() + "\n");
	}
	fileStream.close();
	
	ResetStack();

	return true;
}

int SaverLoader::PreloadObjects()
{
	std::ifstream fileStream;
	fileStream.open("SaveData.txt");
	int numLines = 0;
	std::string line;
	ResetStack();

	while (std::getline(fileStream, line))
	{
		++numLines;
		SaveObj loadedObj;
		
		std::istringstream stream(line);
		std::string val;
		std::vector<std::string> values;

		while (std::getline(stream, val, ' '))
			values.push_back(val);

		//if (values.size() < 9)
		{
			loadedObj.position.x = strtof(values[0].c_str(), nullptr);
			loadedObj.position.y = strtof(values[1].c_str(), nullptr);
			loadedObj.position.z = strtof(values[2].c_str(), nullptr);

			loadedObj.rotation.x = strtof(values[3].c_str(), nullptr);
			loadedObj.rotation.y = strtof(values[4].c_str(), nullptr);
			loadedObj.rotation.z = strtof(values[5].c_str(), nullptr);

			loadedObj.scale.x = strtof(values[6].c_str(), nullptr);
			loadedObj.scale.y = strtof(values[7].c_str(), nullptr);
			loadedObj.scale.z = strtof(values[8].c_str(), nullptr);
		}

		objectStack.push_back(loadedObj);
	}

	fileStream.close();

	ResetStack();

	return numLines;
}

void SaverLoader::ResetStack()
{
	objectStack.clear();
}

SaveObj SaverLoader::LoadObject(int id)
{
	return objectStack[id];
}

