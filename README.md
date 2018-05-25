# Statistic

Rudimentary statistical extensions for .NET Core

## Installation
```
PM> Install-Package Stats.Koryakinp
```
## Basic Usage
```
new double[3] { 1.0, 1.2, 2.0 }.Mean();
new double[3] { 1.0, 1.2, 2.0 }.Variance(VarianceType.Population);
new double[3] { 1.0, 1.2, 2.0 }.StandardDeviation(VarianceType.Sample);
```
