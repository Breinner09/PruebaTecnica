import { Component, OnInit } from '@angular/core';
import { PeliculasService } from '../services/peliculas.service';
import { Pelicula } from '../Interfaces/pelicula';
import { DetallePeliculaComponent } from '../inicio/detalle-pelicula/detalle-pelicula.component';
import { MatDialog } from '@angular/material/dialog';
import { DetallePeliculaGuardadaComponent } from './detalle-pelicula-guardada/detalle-pelicula-guardada.component';

@Component({
  selector: 'app-peliculas-guardadas',
  templateUrl: './peliculas-guardadas.component.html',
  styleUrls: ['./peliculas-guardadas.component.scss']
})
export class PeliculasGuardadasComponent implements OnInit {

  userId: number = 0;
  dataObtenida: any;
  arrayPeliculas: any = [];
  infoPeliculas: any;


  constructor(private _peliculasService: PeliculasService, private dialog: MatDialog) {

  }

  ngOnInit(): void {
    this.userId = parseInt(localStorage.getItem('userId') ?? '0')

    this.obtenerPorUsuario()
  }

  obtenerPorUsuario() {
    this._peliculasService.peliculasPorUsuario(this.userId).subscribe({
      next: (data) => {
        this.dataObtenida = data
        this.arrayPeliculas = this.dataObtenida.value

        this.obtenerPeliculasGuardadas()
      },
      error: (error) => {
        console.log(error);

      }
    })
  }

  obtenerPeliculasGuardadas() {
    for (let i = 0; i < this.arrayPeliculas.length; i++) {
      const element = this.arrayPeliculas[i].peliculaId;

      this._peliculasService.buscarPeliculaPorId(element).subscribe(data => {
        // Almacena la información de la película en arrayPeliculas
        this.arrayPeliculas[i].infoPeliculas = data;
        
      });
    }
  }

  abrirDialogoDetalle(dataPelicula: Pelicula) {
    this.dialog.open(DetallePeliculaGuardadaComponent, {
      disableClose: false,
      width: "800px",
      data: dataPelicula
    })
  }

}
