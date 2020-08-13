import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: "main",
  loadChildren: () => import('../components/data-elements/main/main.module').then(m => m.MainModule) },
  { path: "favorites",
  loadChildren: () => import('../components/data-elements/favorites/favorites.module').then(m => m.FavoritesModule) },
  { path: '', redirectTo: "main", pathMatch: "full" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule { }