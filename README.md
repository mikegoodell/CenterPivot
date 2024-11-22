# Pivot

Proof of concept to demonstrate a potential use for c# dependency injection.
The sample project is for running a center pivot irrigation system.

Based on the hardcoded dependency injection, this code will either run on RealHardware or SimulatedHardware.

Note: This project is a class library, it is not intended to actually run.  :-)

# Model
These files represent potential data elements that can be stored as records or database elements.

# GeoLocation.cs
Lat/Long coordinates, precise location on the planet

# PivotConfig.cs
Items that describe a given pivot configuration

# PivotStatus.cs
Metrics to read/write status and operation control of the pivot

# Program.cs
Simulated Console program that shows c# dependency injection for both RealHardware and SimulatedHardware

## The contents of this project is entirely fictional and does not represent actual control of a center pivot.

