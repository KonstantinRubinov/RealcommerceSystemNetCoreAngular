import { Store } from "./store";
import { Action } from "./action";
import { ActionType } from "./action-type";
import { City } from '../models/city';
import { Weather } from '../models/weather';
export class Reducer{
    public static reduce(oldStore: Store, action:Action):Store{
        let newStore:Store = {...oldStore};
        switch(action.type){
            case ActionType.GetAllCities:
                newStore.favoritecities=action.payload.map(x => new City(x.cityKey, x.cityLocalizedName, x.cityCountryLocalizedName, x.cityAdministrativeAreaLocalizedName));
                break;
            case ActionType.GetAllCitiesError:
                newStore.GetAllCitiesError=action.payload;
                break;

            case ActionType.AddCity:
                let addCity = new City(action.payload.cityKey, action.payload.cityLocalizedName, action.payload.cityCountryLocalizedName, action.payload.cityAdministrativeAreaLocalizedName);
                newStore.favoritecities.push(addCity);
                break;
            case ActionType.AddCityError:
                newStore.AddCityError=action.payload;
                break;
            
            case ActionType.DeleteCity:
                newStore.favoritecities.forEach( (item, index) => {
                    if(item.cityKey === action.payload)
                        newStore.favoritecities.splice(index,1);
                    });
                newStore.favoriteweather = null;
                break;
            case ActionType.DeleteCityError:
                newStore.DeleteCityError=action.payload;
                break;
                
            case ActionType.GetWeather:
                newStore.favoriteweather=new Weather(action.payload.weatherKey, action.payload.weatherText, action.payload.weatherValue, action.payload.weatherEpochTime);
                break;
            case ActionType.GetWeatherError:
                newStore.GetWeatherError=action.payload;
                break;

            case ActionType.GetCityCode:
                newStore.foundcities=action.payload.map(x => new City(x.cityKey, x.cityLocalizedName, x.cityCountryLocalizedName, x.cityAdministrativeAreaLocalizedName));
                break;
            case ActionType.GetCityCodeError:
                newStore.GetCityCodeError=action.payload;
                break;

            case ActionType.GetCityWeather:
                newStore.foundweather=new Weather(action.payload.weatherKey, action.payload.weatherText, action.payload.weatherValue, action.payload.weatherEpochTime);
                break;
            case ActionType.GetCityWeatherError:
                newStore.GetCityWeatherError=action.payload;
                break;

            case ActionType.AddWeather:
                newStore.favoriteweather=new Weather(action.payload.weatherKey, action.payload.weatherText, action.payload.weatherValue, action.payload.weatherEpochTime);
                break;
            case ActionType.AddWeatherError:
                newStore.AddWeatherError=action.payload;
                break;
                
            default:
                break;
        }
        return newStore;
    }
}