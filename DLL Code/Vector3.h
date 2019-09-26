#pragma once
#include <string>

struct Vector3
{
	Vector3(float _x = 0, float _y = 0, float _z = 0) { x = _x; y = _y; z = _z; }

	float x;
	float y;
	float z;

	std::string ToString();
};

struct SaveObj
{
	SaveObj();

	Vector3 position;
	Vector3 rotation;
	Vector3 scale;

	std::string ToString();
};