# Joke Dou
##  Part 1: API Investigation

### Joke Duo uses two external APIs to retrieve rando jokes.

## 1. Chuck Norris Joke API

### Endpoint: https://api.chucknorris.io/jokes/random


- HTTP method: GET

- Response format: JSON

- Data used: value

The application sends a GET request to the endpoint. The API returns a JSON response containing a random Chuck Norris joke. The application uses the value field to retrieve and display the joke.

## 2. Dad Joke API

### Endpoint: https://icanhazdadjoke.com/

- HTTP method: GET

- Request header: Accept: application/json

- Response format: JSON

- Data used: joke

The application sends a GET request with the Accept: application/json header. This tells the API to return JSON data. The application uses the joke field to retrieve and display the dad joke.

## 3. API Comparison

Both APIs use HTTP GET requests and return JSON responses. However, they use different property names for their joke content. The Chuck Norris API uses value, while the Dad Joke API uses joke.
