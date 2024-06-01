#include <WiFi.h>
#include <WiFiClient.h>
#include <WebServer.h>
#include <uri/UriBraces.h>
#include "DishConfig.h"
#include "DisplayHandler.h"
#include "LightBuzzerHandler.h"
#include "ServoHandler.h"
#include "WiFiConfig.h"
#include "PinConfig.h"

WebServer server(80);

void sendHtml() {
  String response = R"(
    <!DOCTYPE html><html>
      <head>
        <title>ESP32 Web Server Demo</title>
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <style>
          html { font-family: sans-serif; text-align: center; }
          body { display: inline-flex; flex-direction: column; }
          h1 { margin-bottom: 1.2em; } 
          h2 { margin: 0; }
          div { display: grid; grid-template-columns: 1fr 1fr; grid-template-rows: auto auto; grid-auto-flow: column; grid-gap: 1em; }
          .btn { background-color: #5B5; border: none; color: #fff; padding: 0.5em 1em;
                 font-size: 2em; text-decoration: none }
          .btn.OFF { background-color: #333; }
        </style>
      </head>
            
      <body>
        <h1>ESP32 Web Server</h1>
        <div>
          <h2>Order a Dish</h2>
          <form action="/order" method="get">
            <label for="dish">Dish ID:</label>
            <input type="text" id="dish" name="dish"><br><br>
            <label for="quantity">Quantity:</label>
            <input type="text" id="quantity" name="quantity"><br><br>
            <input type="submit" value="Submit">
          </form>
        </div>
      </body>
    </html>
  )";
  server.send(200, "text/html", response);
}

void setup(void) {
  Serial.begin(115200);
  setupLightsAndBuzzer();
  setupServos();
  setupDisplay();

  WiFi.begin(WIFI_SSID, WIFI_PASSWORD, WIFI_CHANNEL);
  Serial.print("Connecting to WiFi ");
  Serial.print(WIFI_SSID);
  while (WiFi.status() != WL_CONNECTED) {
    delay(100);
    Serial.print(".");
  }
  Serial.println(" Connected!");

  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());

  server.on("/", sendHtml);

  server.on("/order", []() {
    if (!server.hasArg("dish") || !server.hasArg("quantity")) {
      server.send(400, "text/plain", "Bad Request");
      return;
    }

    String dishId = server.arg("dish");
    int quantity = server.arg("quantity").toInt();

    DishConfig* selectedDish = nullptr;
    for (int i = 0; i < numDishes; ++i) {
      if (dishId == dishes[i].id) {
        selectedDish = &dishes[i];
        break;
      }
    }

    if (selectedDish == nullptr) {
      Serial.println("Unsupported dish type");
      handleUnsupportedDish();
      server.send(200, "text/plain", "Unsupported Dish Type");
      return;
    }

    Serial.print("Preparing ");
    Serial.print(selectedDish->name);
    Serial.print(" x");
    Serial.println(quantity);

    handleDishPreparation(*selectedDish, quantity);

    server.send(200, "text/plain", "Dish prepared");

    while (true) {
      if (digitalRead(BUTTON_PIN) == LOW) {
        Serial.println("Button pressed");
        dispenseDish(*selectedDish, quantity);
        break;
      }
      delay(10);
    }
  });

  server.begin();
  Serial.println("HTTP server started");
}

void loop(void) {
  server.handleClient();
  delay(2);
}
