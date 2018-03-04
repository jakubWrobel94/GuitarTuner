# Guitar Tuner

App for guitar tuning which retrives audio signal from audio input device and allows you to tune up your instrument.

![alt text](https://github.com/jakubWrobel94/GuitarTuner/blob/master/screenShot.png "Screen shot")
## Features

- 25Hz - 1000Hz frequency range detection 
- working with every installed input audio device
- diffrent tunings

## Background
Input signal is monitored by using Windows waveIn APIs. Fundamental frequency calculations are based on autocorrelation method.
To improve frequency resolution, spline interpolation is used. App informs in real time about detected frequency and error 
beetween this frequency and nearest pitch fundamental frequency. 

## Built With

* [Naudio](https://github.com/naudio/NAudio/tree/master/NAudio) - .net sound library
* [C# Cubic Spline Interpolation](https://www.codeproject.com/Articles/560163/Csharp-Cubic-Spline-Interpolation) - implementation of cubic spline interpolation used for resolution improvement
* Windows Forms - GUI

## To Do list

* add more tunings
* algorithm improvement - get rid off some random frequency changes
* better GUI
* diffrent pitch standard ( i.e. 432Hz)
