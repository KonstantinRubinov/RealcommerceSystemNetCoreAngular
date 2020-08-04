import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgRedux } from 'ng2-redux';
import { Store } from '../redux/store';
import { Action } from '../redux/action';
import { LoggerService } from './logger.service';
import { ActionType } from '../redux/action-type';
import { Weather } from '../models/weather';
import { localWeather } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  public constructor(private http: HttpClient,
    private redux: NgRedux<Store>,
    private logger: LoggerService
  ){}

  public GetWeather(key:string): void {
    let he = new HttpHeaders({'Content-Type':  'application/json'});
    let observable = this.http.get<Weather>(localWeather+key, { headers: he });
    observable.subscribe(retWeather=>{
      const action: Action={type:ActionType.GetWeather, payload:retWeather};
      this.redux.dispatch(action);
      this.logger.debug("GetWeather: ", retWeather);
    }, error => {
      const action: Action={type:ActionType.GetWeatherError, payload:error.message};
      this.redux.dispatch(action);
      this.logger.error("GetWeatherError: ", error.message);
    });
  }

  public AddWeather(weather:Weather): void {
    let he = new HttpHeaders({'Content-Type':  'application/json'});
    let observable = this.http.post<Weather>(localWeather, weather, { headers: he });
    observable.subscribe(retWeather=>{
      const action: Action={type:ActionType.AddWeather, payload:retWeather};
      this.redux.dispatch(action);
      this.logger.debug("AddWeather: ", retWeather);
      alert("The City has been added");
    }, error => {
      const action: Action={type:ActionType.AddWeatherError, payload:error.message};
      this.redux.dispatch(action);
      this.logger.error("AddWeatherError: ", error.message);
    });
  }
}