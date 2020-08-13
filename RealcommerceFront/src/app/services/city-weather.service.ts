import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgRedux } from 'ng2-redux';
import { Store } from '../redux/store';
import { Action } from '../redux/action';
import { LoggerService } from './logger.service';
import { ActionType } from '../redux/action-type';
import { siteCities, siteWeather, localWeather } from 'src/environments/environment';
import { City } from '../models/city';
import { Weather } from '../models/weather';

@Injectable({
  providedIn: 'root'
})
export class CityWeatherService {

  public constructor(private http: HttpClient,
    private redux: NgRedux<Store>,
    private logger: LoggerService
  ){}
  
  public GetCityCode(city:string): void {
    let he = new HttpHeaders({'Content-Type':  'application/json'});
    let observable = this.http.get<City[]>(siteCities+city, { headers: he });
    observable.subscribe(retCity=>{
      const action: Action={type:ActionType.GetCityCode, payload:retCity};
      this.redux.dispatch(action);
      this.logger.debug("GetCityCode: ", retCity);
    }, error => {
      const action: Action={type:ActionType.GetCityCodeError, payload:error.message};
      this.redux.dispatch(action);
      this.logger.error("GetCityCodeError: ", error.message);
    });
  }

  public GetCityWeather(key:string): void {
    let he = new HttpHeaders({'Content-Type':  'application/json'});
    let observable = this.http.get<Weather>(localWeather+key, { headers: he });
    observable.subscribe(retWeather=>{
      const action: Action={type:ActionType.GetCityWeather, payload:retWeather};
      this.redux.dispatch(action);
      this.logger.debug("GetCityWeather: ", retWeather);
    }, error => {
      const action: Action={type:ActionType.GetCityWeatherError, payload:error.message};
      this.redux.dispatch(action);
      this.logger.error("GetCityWeatherError: ", error.message);
    });
  }
}