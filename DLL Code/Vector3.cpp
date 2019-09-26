#include "Vector3.h"

std::string Vector3::ToString()
{
	return std::to_string(x) + " " + std::to_string(y) + " " + std::to_string(z);
}

std::string SaveObj::ToString()
{
	return position.ToString() + " " + rotation.ToString() + " " + scale.ToString();
}
