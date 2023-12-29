import { Component, OnInit, ElementRef } from '@angular/core';
import { PeliculasService } from '../services/peliculas.service';
import { MatDialog } from '@angular/material/dialog';
import { DetallePeliculaComponent } from './detalle-pelicula/detalle-pelicula.component';
import { Pelicula } from '../Interfaces/pelicula';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.scss']
})
export class InicioComponent implements OnInit {

  constructor(private _peliculasService: PeliculasService, private dialog: MatDialog) { }
  peliculas: any;
  infoPeliculas: any = [];
  filtro: string = '';
  numerosDisponibles: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
  numeroSeleccionado: number = 1;

  ngOnInit(): void {
    this.peliculasPopulares()
  }

  enviarBusqueda(event: any) {
    this.filtro = event.target.value;

    if (this.filtro.trim() !== '') {
      this.buscarPelicula(this.filtro);
    } else {
      this.peliculasPopulares()
    }
  }

  buscarPelicula(nombre: string) {
    this._peliculasService.buscarPelicula(nombre).subscribe(data => {
      console.log(data);
      this.peliculas = data;
      this.infoPeliculas = this.peliculas.results;
    })
  }

  peliculasPopulares() {
    this._peliculasService.peliculasPopulares(1).subscribe((data) => {
      this.peliculas = data;
      this.infoPeliculas = this.peliculas.results;
    });
  }

  seleccionarNumero(numero: number) {
    this.numeroSeleccionado = numero;

    this._peliculasService.peliculasPopulares(numero).subscribe((data) => {
      this.peliculas = data;
      this.infoPeliculas = this.peliculas.results;
    });

    this.volverAlInicio()
  }

  aumentarPagina() {
    this.numeroSeleccionado = this.numeroSeleccionado + 1;

    this._peliculasService.peliculasPopulares(this.numeroSeleccionado).subscribe((data) => {
      this.peliculas = data;
      this.infoPeliculas = this.peliculas.results;
    });

    this.volverAlInicio()
  }

  disminuirPagina() {
    this.numeroSeleccionado = this.numeroSeleccionado - 1;

    this._peliculasService.peliculasPopulares(this.numeroSeleccionado).subscribe((data) => {
      this.peliculas = data;
      this.infoPeliculas = this.peliculas.results;
    });

    this.volverAlInicio()
  }

  volverAlInicio() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }

  abrirDialogoDetalle(dataPelicula: Pelicula) {
    this.dialog.open(DetallePeliculaComponent, {
      disableClose: false,
      width: "800px",
      data: dataPelicula
    })
  }
}
