import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PeliculasService } from 'src/app/services/peliculas.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-detalle-pelicula-guardada',
  templateUrl: './detalle-pelicula-guardada.component.html',
  styleUrls: ['./detalle-pelicula-guardada.component.scss']
})
export class DetallePeliculaGuardadaComponent implements OnInit {

  constructor(private _peliculasService: PeliculasService,
    private dialogRef: MatDialogRef<DetallePeliculaGuardadaComponent>,
    @Inject(MAT_DIALOG_DATA) public dataPelicula: any
  ) { }
  calificacion: number = 1;
  estrellas: boolean[] = [];
  edicion: boolean = false;

  id: number = 0;

  ngOnInit(): void {


    if (this.dataPelicula) {
      this.calificacion = this.dataPelicula.calificacion
      this.actualizarEstrellas();

      this.id = this.dataPelicula.id

    }
  }

  sliderChange(event: any) {
    this.calificacion = event.target.value;
    this.edicion = true
    this.actualizarEstrellas();
  }

  private actualizarEstrellas() {
    this.estrellas = Array.from({ length: 5 }, (_, index) => index < this.calificacion);
  }

  eliminarPelicula() {

    Swal.fire({
      icon: 'warning',
      title: '¿Estás seguro?',
      text: 'La película se eliminará de tu perfil',
      showConfirmButton: true,
      showDenyButton: true,
      confirmButtonColor: '#cb351e',
      confirmButtonText: 'Si',
      denyButtonColor: '#000',
      denyButtonText: 'No'
    }).then((result) => {
      if (result.isConfirmed) {
        this._peliculasService.eliminarPelicula(this.id).subscribe({
          next: res => {
            this.cerrar()
            window.location.reload()
          }, error: error => {
            console.log(error);
          }
        })
      } else {

      }
    });


  }

  editarCalificacion() {
    const dataPelicula = {
      id: this.id,
      calificacion: this.calificacion
    }

    this._peliculasService.editarCalificacion(dataPelicula).subscribe({
      next: res => {
        this.cerrar()
        window.location.reload()
      }, error: error => {
        console.log(error);
      }
    })

  }

  cerrar() {
    this.dialogRef.close()
  }

}
