import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Pelicula } from 'src/app/Interfaces/pelicula';
import { PeliculasService } from 'src/app/services/peliculas.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-detalle-pelicula',
  templateUrl: './detalle-pelicula.component.html',
  styleUrls: ['./detalle-pelicula.component.scss']
})
export class DetallePeliculaComponent implements OnInit {

  constructor(private _peliculasService: PeliculasService,
    private dialogRef: MatDialogRef<DetallePeliculaComponent>,
    @Inject(MAT_DIALOG_DATA) public dataPelicula: any
  ) { }

  calificacion: number = 1;
  nombrePelicula: string = "";
  idPelicula: number = 0;
  userId: number = 0;
  slider: boolean = false;
  respuesta: any;

  ngOnInit(): void {

  }

  addPelicula() {
    this.slider = true

    this.idPelicula = this.dataPelicula.id
    this.nombrePelicula = this.dataPelicula.original_title
    this.userId = parseInt(localStorage.getItem('userId') ?? '0')
  }

  guardarPelicula() {
    const objetoPelicula: Pelicula = {
      peliculaId: this.idPelicula,
      nombrePelicula: this.nombrePelicula,
      calificacion: this.calificacion,
      userId: this.userId
    }

    this._peliculasService.guardarPelicula(objetoPelicula).subscribe({
      next: data => {

        this.respuesta = data

        if (this.respuesta.status === true) {
          Swal.fire({
            icon: 'success',
            text: 'La película se guardó en tu perfil',
            showConfirmButton: false,
            timer: 2000,
            timerProgressBar: true,
            willClose: () => {
              this.dialogRef.close()
            }
          })
        } else {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: `${this.respuesta.message}`,
            showConfirmButton: false,
            timer: 2000,
            timerProgressBar: true,
            willClose: () => {
              this.dialogRef.close()
            }
          })
        }
      }, error: error => {
        console.error(error);
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: `${error.message}`,
        });
      }
    })

  }


}
