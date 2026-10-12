# Unit Conversion API

A RESTful API built with ASP.NET Core that converts values between different units of measurement, including length, mass, temperature, and time.

## Features

- **Length conversion:** Meters, kilometers, centimeters, millimeters, miles, feet, and inches.
- **Mass conversion:** Kilograms, grams, milligrams, tonnes, pounds.
- **Temperature conversion:** Celsius, Fahrenheit, and Kelvin.
- **Time conversion:** Milliseconds, seconds, minutes, hours, days, and weeks.
- **Input validation:** Validates conversion requests and returns descriptive validation errors.
- **RESTful endpoint:** Exposes a POST endpoint for unit conversions.
- **Extensible design:** Supports adding new measurement types and units.

## Tech Stack

- C#
- ASP.NET Core Web API
- .NET
- REST API principles

## API Endpoint

### Convert Units

Converts a numeric value from one unit to another within the specified measurement category.

**Endpoint:** `POST /Convert`

**Content-Type:** `application/json`

### Request Body

```json
{
  "measurementType": "Length",
  "from": "km",
  "to": "mile",
  "value": 5
}
```

| Property | Description |
|---|---|
| `measurementType` | Measurement category: `Length`, `Mass`, `Temperature`, or `Time` |
| `from` | Source unit |
| `to` | Target unit |
| `value` | Numeric value to convert |

### Successful Response

**Status Code:** `200 OK`

```json
{
  "value": 3.106855961
}
```

### Validation Error Response

**Status Code:** `400 Bad Request`

When the request contains invalid input, the API returns validation errors.

```json
{
  "errors": [
    "Measurement Type is required"
  ]
}
```

The exact error messages and response structure depend on the validation implementation.

## Examples

### 1. Length Conversion

Convert 5 kilometers to miles.

```json
{
  "measurementType": "Length",
  "from": "km",
  "to": "mile",
  "value": 5
}
```

Expected result: approximately `3.106856` miles.

### 2. Mass Conversion

Convert 100 kilograms to pounds.

```json
{
  "measurementType": "Mass",
  "from": "kg",
  "to": "pound",
  "value": 100
}
```

Expected result: approximately `220.462262` pounds.

### 3. Temperature Conversion

Convert 100 degrees Celsius to Fahrenheit.

```json
{
  "measurementType": "Temperature",
  "from": "C",
  "to": "F",
  "value": 100
}
```

Expected result: `212` degrees Fahrenheit.

### 4. Time Conversion

Convert 90 minutes to hours.

```json
{
  "measurementType": "Time",
  "from": "minute",
  "to": "hour",
  "value": 90
}
```

Expected result: `1.5` hours.

## Supported Units

| Category | Supported units |
|---|---|
| Length | meter, km, cm, mm, mile, yard, foot, inch |
| Mass | kg, g, mg, tonne, pound, ounce |
| Temperature | Celsius, Fahrenheit, Kelvin |
| Time | millisecond, second, minute, hour, day, week |

Unit names are case-insensitive. Supported abbreviations depend on the measurement category.

## How It Works

The conversion service uses a common base unit for measurements that can be converted using a scale factor.

- **Length:** Meter
- **Mass:** Kilogram
- **Time:** Second
- **Temperature:** Celsius

For length, mass, and time, the conversion follows two steps:

1. Convert the input value to the category's base unit.
2. Convert the base-unit value to the requested target unit.

Temperature conversions use dedicated formulas because Celsius, Fahrenheit, and Kelvin involve offsets as well as scaling.

