import { Component, OnInit } from '@angular/core';
import { MyNavigator } from 'src/app/models/mynavigator';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  navigators = [
    new MyNavigator("/main", 'Search'),
    new MyNavigator("/favorites", 'Favorites'),
  ];

  constructor() { }

  ngOnInit(): void {
  }
}