import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from 'src/app/redux/store';
import { NgRedux } from 'ng2-redux';
import { Unsubscribe } from 'redux';
import { CityWeatherService } from 'src/app/services/city-weather.service';
import { City } from 'src/app/models/city';
import { Weather } from 'src/app/models/weather';
import { CityService } from 'src/app/services/city.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit, OnDestroy {

  private unsubscribe:Unsubscribe;
  public searchByWord:string;
  public cities:City[]=[];
  public weather:Weather;
  public localizedName:string;
  public countryLocalizedName:string;

  constructor(private redux:NgRedux<Store>,
              private cityWeatherService:CityWeatherService,
              private cityService:CityService
              ) { }

  public ngOnInit() {
    this.cities = this.redux.getState().foundcities;
    this.unsubscribe = this.redux.subscribe(()=>{
      this.cities = this.redux.getState().foundcities;
      this.weather = this.redux.getState().foundweather;
    });
  }

  public Search(){
    this.cityWeatherService.GetCityCode(this.searchByWord);
  }
  
  public showData(data){
    let key = data.target.value;
    let mycity = this.cities.filter(c => c.cityKey == key)[0];
    this.cityWeatherService.GetCityWeather(key);
    this.localizedName=mycity.cityLocalizedName
    this.countryLocalizedName=mycity.cityCountryLocalizedName;
  }

  public saveData(data){
    let key = data.target.value;
    let mycity = this.cities.filter(c => c.cityKey == key)[0];
    this.cityService.AddCity(mycity, this.weather);
  }

  public ngOnDestroy(): void {
    this.unsubscribe();
  }
}