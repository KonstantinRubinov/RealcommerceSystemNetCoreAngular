import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './modules/app-routing.module';

import { Store } from './redux/store';
import { NgReduxModule, NgRedux } from 'ng2-redux';
import { Reducer } from './redux/reducer';

import { LayoutComponent } from './components/design-elements/layout/layout.component';
import { FooterComponent } from './components/design-elements/footer/footer.component';
import { HeaderComponent } from './components/design-elements/header/header.component';
import { MainComponent } from './components/data-elements/main/main.component';
import { FavoritesComponent } from './components/data-elements/favorites/favorites.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
  LayoutComponent,
  FooterComponent,
  HeaderComponent,
  MainComponent,
  FavoritesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgReduxModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [LayoutComponent]
})
export class AppModule { 
  public constructor(redux:NgRedux<Store>){
    redux.configureStore(Reducer.reduce, new Store());
  }
}