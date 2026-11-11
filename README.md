## 1. API Investigation

Joke Duo integrates two external REST APIs to retrieve random jokes.

### 1.1 Chuck Norris Joke API

**Endpoint:** https://api.chucknorris.io/jokes/random

**HTTP Method:** GET

**Response Format:** JSON

The Chuck Norris API provides random jokes through an HTTP GET request.

The API returns a JSON response containing several properties. The application uses the `value` property, which contains the actual joke.

No additional request headers are required.

### 1.2 Dad Joke API

**Endpoint:** https://icanhazdadjoke.com/

**HTTP Method:** GET

**Response Format:** JSON

The Dad Joke API provides random dad jokes through an HTTP GET request.

The application sends the following request header:

`Accept: application/json`

This tells the API that the application expects a JSON response.

The application uses the `joke` property to retrieve the actual joke.

### 1.3 API Comparison

Both APIs use HTTP GET requests and return JSON responses.

However, they use different property names to store their joke content:

- Chuck Norris API: `value`
- Dad Joke API: `joke`

These properties will be mapped to C# response models during implementation.

### 1.4 API Integration Approach

The application will use a dedicated API service to communicate with both endpoints.

The service will handle HTTP requests and JSON deserialization. The ViewModel will receive the returned jokes and expose them to the View for display.
