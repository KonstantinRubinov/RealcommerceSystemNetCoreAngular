import { City } from '../models/city';
import { Weather } from '../models/weather';

export class Store{
    public favoritecities:City[]=[];
    public foundcities:City[]=[];
    public favoriteweather:Weather;
    public foundweather:Weather;
    
    public GetAllCitiesError:string;
    public AddCityError:string;
    public DeleteCityError:string;
    public GetWeatherError:string;
    public GetCityCodeError:string;
    public GetCityWeatherError:string;
    public AddWeatherError:string;
}