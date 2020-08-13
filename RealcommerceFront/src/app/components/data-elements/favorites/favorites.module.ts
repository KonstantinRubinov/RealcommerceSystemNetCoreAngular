import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';
import { FavoritesRoutingModule } from './favorites-routing.module';
import { FavoritesComponent } from './favorites.component';

@NgModule({
  imports: [
    CommonModule,
    FavoritesRoutingModule,
    FormsModule
  ],
  declarations: [FavoritesComponent]
})
export class FavoritesModule { }
