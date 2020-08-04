import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from 'src/app/redux/store';
import { NgRedux } from 'ng2-redux';
import { Unsubscribe } from 'redux';
import { City } from 'src/app/models/city';
import { Weather } from 'src/app/models/weather';
import { CityService } from 'src/app/services/city.service';
import { WeatherService } from 'src/app/services/weather.service';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.css']
})
export class FavoritesComponent implements OnInit, OnDestroy {

  private unsubscribe:Unsubscribe;
  public searchByWord:string;
  public cities:City[]=[];
  public weather:Weather;
  public localizedName:string;
  public countryLocalizedName:string;

  constructor(private redux:NgRedux<Store>,
              private weatherService:WeatherService,
              private cityService:CityService
              ) { }

  public ngOnInit() {
    this.cities = this.redux.getState().favoritecities;
    this.cityService.GetAllCities();

    this.unsubscribe = this.redux.subscribe(()=>{
      this.cities = this.redux.getState().favoritecities;
      this.weather = this.redux.getState().favoriteweather;
    });
  }
  
  public showData(data){
    let key = data.target.value;
    let mycity = this.cities.filter(c => c.cityKey == key)[0];
    this.weatherService.GetWeather(key);
    this.localizedName=mycity.cityLocalizedName
    this.countryLocalizedName=mycity.cityCountryLocalizedName;
  }

  public deleteData(data){
    let key = data.target.value;
    this.cityService.DeleteCity(key);
  }

  public ngOnDestroy(): void {
    this.unsubscribe();
  }
}