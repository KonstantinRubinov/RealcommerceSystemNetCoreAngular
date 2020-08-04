This is your city weather database.
Connected to accuweather library, and sql database to save your favorite cities.

* .NET Core 2.1 server
* MsSql database
* Angular 9 front.
* Inter-server communication (this server communiacts with accuweather api).

- user can search for city, and get list of cities - city + country, becouse some cities has similar names (+ region and key).
- on click on the found city, user can get weather - temperature + text (+ key and timestamp).
- user can add the data to favorites.

- list of favorite sities has the city and the weather (the weather is legal for 3 hours, after this time, we again save the weather from accuweather).
- user can remove favorite city with weather.