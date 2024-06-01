#ifndef SERVO_HANDLER_H
#define SERVO_HANDLER_H

#include "DishConfig.h"
#include <ESP32Servo.h>

void setupServos();
void handleDishPreparation(DishConfig dish, int quantity);
void dispenseDish(DishConfig dish, int quantity);
int calculateRotations(DishConfig dish, int quantity);

#endif
