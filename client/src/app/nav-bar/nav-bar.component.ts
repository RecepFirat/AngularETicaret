import { Component, OnInit } from '@angular/core';
//  cd  src/app  ng g c nav-bar --skip-tests  component olusturdum ve icerisinde test olmasın diyorum 
//Kullanmak icinde selectoru app.component.html icerisinde kullanıyorum
@Component({
  selector: 'app-nav-bar', 
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
