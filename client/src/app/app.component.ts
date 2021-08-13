import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
   selector: 'app-root', //burası direk calısacak kesim
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit
{
  products: any[] = [];
      title = 'client';
     

    constructor(private http:HttpClient){
     
    }
    ngOnInit():void
    {
      this.http.get('http://localhost:15299/api/Products').subscribe((responese:any)=>{
    this.products=responese.data;  
    console.log(this.products);
    },error =>{
        console.log(error);
      });
      
   
    }
}


  