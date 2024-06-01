#include "DishConfig.h"

DishConfig dishes[] = {
  { "fa881d8b-83a2-47b3-9d1d-15d1066d8987", "Exotic Fruit Parfait", 1, 5, 10, 500 },
  { "b841ccd2-b246-4350-b785-a369d0556bd4", "Oatmeal", 2, 8, 15, 7500 },
  { "b841ccd2-b246-4350-b756-a369d0556be4", "Savory Herb-Crusted Chicken", 3, 10, 20, 10000 }
};

const int numDishes = sizeof(dishes) / sizeof(DishConfig);
