import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgRedux } from 'ng2-redux';
import { Store } from '../redux/store';
import { City } from '../models/city';
import { Action } from '../redux/action';
import { LoggerService } from './logger.service';
import { ActionType } from '../redux/action-type';
import { localCities } from 'src/environments/environment';
import { WeatherService } from './weather.service';
import { Weather } from '../models/weather';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  public constructor(private http: HttpClient,
    private redux: NgRedux<Store>,
    private logger: LoggerService,
    private weatherService:WeatherService,
  ){}

  public GetAllCities(): void {
    let he = new HttpHeaders({'Content-Type':  'application/json'});
    let observable = this.http.get<City[]>(localCities, { headers: he });
    observable.subscribe(retcities=>{
      const action: Action={type:ActionType.GetAllCities, payload:retcities};
      this.redux.dispatch(action);
      this.logger.debug("GetAllCities: ", retcities);
    }, error => {
      const action: Action={type:ActionType.GetAllCitiesError, payload:error.message};
      this.redux.dispatch(action);
      this.logger.error("GetAllCitiesError: ", error.message);
    });
  }

  public AddCity(city:City, weather:Weather): void {
    let he = new HttpHeaders({'Content-Type':  'application/json'});
    let observable = this.http.post<City>(localCities, city, { headers: he });
    observable.subscribe(retcity=>{
      const action: Action={type:ActionType.AddCity, payload:retcity};
      this.redux.dispatch(action);
      this.logger.debug("AddCity: ", retcity);
      this.weatherService.AddWeather(weather);
    }, error => {
      const action: Action={type:ActionType.AddCityError, payload:error.message};
      this.redux.dispatch(action);
      this.logger.error("AddCityError: ", error.message);
    });
  }

  public DeleteCity(key: string): void {
    let he = new HttpHeaders({'Content-Type':  'application/json'});
    let observable = this.http.delete<string>(localCities+key, { observe: 'response', headers: he});
    observable.subscribe(res =>{
      this.logger.debug("DeleteCity result status: ", res.status);
      if (res.status===204){
        const action: Action={type:ActionType.DeleteCity, payload:key };
        this.redux.dispatch(action);
        this.logger.debug("DeleteCity: ", key);
        alert("The City has been removed");
      }
    }, error => {
      const action: Action={type:ActionType.DeleteCityError, payload:error.message};
      this.redux.dispatch(action);
      this.logger.error("DeleteCityError: ", error.message);
    });
  }
}