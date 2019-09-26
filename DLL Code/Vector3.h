#pragma once
#include <string>

struct Vector3
{
	float x;
	float y;
	float z;

	std::string ToString();
};

struct SaveObj
{
	Vector3 position;
	Vector3 rotation;
	Vector3 scale;

	std::string ToString();
};