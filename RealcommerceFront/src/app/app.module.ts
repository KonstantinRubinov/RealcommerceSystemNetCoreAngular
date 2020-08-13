import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './modules/app-routing.module';

import { Store } from './redux/store';
import { NgReduxModule, NgRedux } from 'ng2-redux';
import { Reducer } from './redux/reducer';

import { LayoutComponent } from './components/design-elements/layout/layout.component';
import { FooterComponent } from './components/design-elements/footer/footer.component';
import { HeaderComponent } from './components/design-elements/header/header.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
  LayoutComponent,
  FooterComponent,
  HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgReduxModule,
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