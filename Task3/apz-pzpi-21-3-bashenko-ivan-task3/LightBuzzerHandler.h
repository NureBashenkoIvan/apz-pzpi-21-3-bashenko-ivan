#ifndef LIGHT_BUZZER_HANDLER_H
#define LIGHT_BUZZER_HANDLER_H

void setupLightsAndBuzzer();
void beep(int times, int duration);
void turnOnYellowLight();
void turnOffYellowLight();
void turnOnGreenLight();
void turnOffAllLights();
void handleUnsupportedDish();

#endif
