#include "SaverLoader.h"
#include <fstream>


void SaverLoader::PushToSaveStack(SaveObj toSave)//Vector3 position, Vector3 rotation, Vector3 scale)
{
	SaveStack.push_back(toSave);
}

bool SaverLoader::Save()
{
	std::ofstream fileStream;
	fileStream.open("SaveData.txt");
	for (int i = 0; i < SaveStack.size(); ++i)
	{
		fileStream << (SaveStack[i].ToString() + "\n");
	}
	fileStream.close();
	
	return true;
}

int SaverLoader::GetNumberOfLines()
{
	std::ifstream fileStream;
	fileStream.open("SaveData.txt");
	int numLines = 0;
	std::string line;
	while (std::getline(fileStream, line))
		++numLines;
	return numLines;
}

