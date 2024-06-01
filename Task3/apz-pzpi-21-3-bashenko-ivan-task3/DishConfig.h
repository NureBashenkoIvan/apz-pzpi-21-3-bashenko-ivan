#ifndef DISH_CONFIG_H
#define DISH_CONFIG_H

struct DishConfig {
  const char* id;
  const char* name;
  int difficultyLevel; // 1 for simple, 2 for medium, 3 for complex
  int numberOfIngredients;
  int servo1Rotations; // Number of rotations for servo1 and servo2 for cooking
  int servo3TimePerUnit; // Time in milliseconds for servo3 per unit
};

extern DishConfig dishes[];
extern const int numDishes;

#endif
