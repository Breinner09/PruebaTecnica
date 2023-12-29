import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  constructor(private router: Router) { }

  userName: string = "";
  menu: any;

  ngOnInit(): void {
    this.userName = localStorage.getItem('userName') ?? "User"
  }

  peliculasPopulares(){
    this.router.navigate(['/inicio'])
  }

  misPeliculas(){
    this.router.navigate(['/misPeliculas'])
  }

  cerrarSesion(){
    localStorage.clear()
    this.router.navigate(['/login'])
  }
}
