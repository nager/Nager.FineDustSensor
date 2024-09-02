# Sensirion SPS30 Client in C#

## Overview

This project provides a C# client for communicating with the Sensirion SPS30 particulate matter sensor via a UART (serial) interface.
It includes both a console application and a Windows Forms application ("SensorControl") that provides all the sensor functionalities through a graphical user interface (GUI).
The application also offers the ability to plot the sensor values in a graph.

## Features

- Communication with the SPS30 sensor over UART (SHDLC Frame Layer)
- Reading measurements (PM1, PM2.5, PM4, PM10)
- Starting and stopping measurements
- Plotting sensor data in a graph

## Requirements

- .NET 8 or higher
- A USB-to-serial adapter or a serial port
- SPS30 particulate matter sensor

## Usage

### Windows Forms Application ("SensorControl")

#### Main Features

- **Start/Stop Measurement**: Start or stop the measurement using buttons.
- **Display Measurements**: Real-time display of current measurements (PM1, PM2.5, PM4, PM10).
- **Plot Data**: Graph to visualize particle concentrations over time.

The Windows Forms application provides a user-friendly interface for interacting with the SPS30 sensor.<br>
[<kbd> <br> Download SensorControl <br> </kbd>](https://github.com/nager/Nager.FineDustSensor/releases/latest/download/Nager.FineDustSensor.SensorControl.zip)

![SensorControl Screenshot](/docs/SensorControl.png)

## Contribution

Contributions are welcome! Please create a pull request or open an issue to report bugs or suggest new features.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more information.
