#include "LightBuzzerHandler.h"
#include "DisplayHandler.h"
#include "PinConfig.h"
#include <Arduino.h>

void setupLightsAndBuzzer() {
  pinMode(LED1, OUTPUT);
  pinMode(LED2, OUTPUT);
  pinMode(LED3, OUTPUT);
  pinMode(BUZZER_PIN, OUTPUT);
}

void beep(int times, int duration) {
  for (int i = 0; i < times; ++i) {
    digitalWrite(BUZZER_PIN, HIGH);
    delay(duration);
    digitalWrite(BUZZER_PIN, LOW);
    delay(duration);
  }
}

void turnOnYellowLight() {
  digitalWrite(LED1, HIGH);
}

void turnOffYellowLight() {
  digitalWrite(LED1, LOW);
}

void turnOnGreenLight() {
  digitalWrite(LED2, HIGH);
}

void turnOffAllLights() {
  digitalWrite(LED1, LOW);
  digitalWrite(LED2, LOW);
  digitalWrite(LED3, LOW);
}

void handleUnsupportedDish() {
  turnOffAllLights();
  digitalWrite(LED3, HIGH);
  beep(2, 500);
  displayMessage("Unsupported Dish", "Type");
  delay(5000);
  turnOffAllLights();
}
