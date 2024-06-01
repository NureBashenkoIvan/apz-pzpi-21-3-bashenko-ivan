#include "ServoHandler.h"
#include "LightBuzzerHandler.h"
#include "DisplayHandler.h"
#include "PinConfig.h"
#include <Arduino.h>
#include <ESP32Servo.h>

Servo servo1;
Servo servo2;
Servo servo3;

void setupServos() {
  servo1.attach(SERVO1_PIN);
  servo2.attach(SERVO2_PIN);
  servo3.attach(SERVO3_PIN);
}

void handleDishPreparation(DishConfig dish, int quantity) {
  turnOnYellowLight();

  String quantityStr = "Qty: " + String(quantity);
  displayMessage(dish.name, quantityStr.c_str());

  int totalRotations = calculateRotations(dish, quantity);
  const int halfRotationTime = 750;

  for (int i = 0; i < totalRotations; ++i) {
    servo1.write(0);
    servo2.write(0);
    delay(halfRotationTime);
    servo1.write(180);
    servo2.write(180);
    delay(halfRotationTime);
  }

  servo1.write(90);
  servo2.write(90);

  turnOffYellowLight();
  beep(1, 500);
  turnOnGreenLight();
  displayMessage(dish.name, "Ready");
}

void dispenseDish(DishConfig dish, int quantity) {
  const int rotationTime = 1000;
  int rotations = quantity * 2;

  for (int i = 0; i < rotations; ++i) {
    servo3.write(0);
    delay(rotationTime);
    servo3.write(180);
    delay(rotationTime);
  }

  servo3.write(90);

  turnOffAllLights();
  displayMessage("", "");
}

int calculateRotations(DishConfig dish, int quantity) {
  // Base rotations per quantity unit
  int baseRotations = dish.servo1Rotations;

  // Additional rotations based on difficulty level
  int difficultyRotations = dish.difficultyLevel * 2;

  // Additional rotations based on number of ingredients
  int ingredientRotations = dish.numberOfIngredients * 1;

  // Total rotations calculation
  int totalRotations = (baseRotations + difficultyRotations + ingredientRotations) * quantity;

  return totalRotations;
}
